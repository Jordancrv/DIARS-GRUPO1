import pyodbc
import random
from datetime import datetime
from decimal import Decimal
import logging

# Configuración de logging
logging.basicConfig(
    filename=f"bulk_insert_{datetime.now().strftime('%Y%m%d_%H%M%S')}.log",
    level=logging.INFO,
    format="%(asctime)s %(levelname)s:%(message)s"
)

# Configuración de conexión (autenticación integrada)
CONN_STR = (
    'DRIVER={ODBC Driver 17 for SQL Server};'
    'SERVER=PC101;'
    'DATABASE=DiarsAlfa;'
    'Trusted_Connection=yes;'
)

# Parámetros configurables
NUM_PEDIDOS = 3000
CLIENTE_RANGE = (1, 250)
PRODUCTO_RANGE = (1, 200)
METODO_PAGO_RANGE = (1, 10)
DETALLES_MIN = 1
DETALLES_MAX = 5
PROMO_PROB = 0.3
TIPOS_COMPROBANTE = {'factura': 'F001', 'boleta': 'B001', 'nota_credito': 'NC01'}
ESTADOS_PAGO = ['completado', 'anulado', 'pendiente']

# Contador global para numeración de comprobantes
comprobante_counter = 0


def get_active_promociones(cursor):
    hoy = datetime.now().date()
    cursor.execute(
        """
        SELECT IdPromocion, Descuento
        FROM Promociones
        WHERE Estado = 1 AND FechaInicio <= ? AND FechaFin >= ?
        """,
        hoy, hoy
    )
    return [(row[0], Decimal(row[1])) for row in cursor.fetchall()]


def get_id_usuario(cursor, id_cliente):
    cursor.execute("SELECT id_usuario FROM Clientes WHERE id_cliente = ?", id_cliente)
    row = cursor.fetchone()
    return row[0] if row else None


def get_precio_producto(cursor, id_producto):
    cursor.execute("SELECT precioventa FROM Productos WHERE id_producto = ?", id_producto)
    row = cursor.fetchone()
    return Decimal(row[0]) if row and row[0] is not None else Decimal('0')


def generar_comprobante(cursor, id_pedido):
    """
    Genera comprobante con serie única por script y número correlativo.
    """
    global comprobante_counter
    comprobante_counter += 1
    tipo = random.choice(list(TIPOS_COMPROBANTE.keys()))
    base_serie = TIPOS_COMPROBANTE[tipo]
    # Serie único: <base>_<correlativo>
    serie = f"{base_serie}_{comprobante_counter:06d}"
    numero = f"{comprobante_counter:06d}"
    cursor.execute(
        "INSERT INTO ComprobantesPago (tipo, serie, numero, activo) OUTPUT INSERTED.id_comprobante VALUES (?, ?, ?, 1)",
        tipo, serie, numero
    )
    comp_id = cursor.fetchone()[0]
    logging.debug(f"Comprobante insertado: id={comp_id}, serie={serie}, numero={numero}")
    # Asociar comprobante al pedido
    cursor.execute(
        "UPDATE PedidosVenta SET id_comprobante = ? WHERE id_pedido = ?",
        comp_id, id_pedido
    )
    return comp_id


def insertar_pedido(cursor, cliente, usuario):
    cursor.execute(
        "INSERT INTO PedidosVenta (id_cliente, id_usuario, estado) OUTPUT INSERTED.id_pedido VALUES (?, ?, 'pendiente')",
        cliente, usuario
    )
    pid = cursor.fetchone()[0]
    return pid


def insertar_detalle(cursor, id_pedido, promociones):
    sum_sub, sum_desc = Decimal('0'), Decimal('0')
    detalles_num = random.randint(DETALLES_MIN, DETALLES_MAX)
    applied_promos = set()
    for _ in range(detalles_num):
        prod = random.randint(*PRODUCTO_RANGE)
        qty = random.randint(1, 10)
        price = get_precio_producto(cursor, prod)
        subtotal = price * qty
        disc_pct = Decimal('0')
        if promociones and random.random() < PROMO_PROB:
            pid_prom, pct = random.choice(promociones)
            if pid_prom not in applied_promos:
                applied_promos.add(pid_prom)
                disc_pct = pct
                cursor.execute(
                    "INSERT INTO VentaPromocion (id_pedido, id_promocion) VALUES (?, ?)",
                    id_pedido, pid_prom
                )
        total_disc = (subtotal * disc_pct) / Decimal('100')
        total_cd = subtotal - total_disc
        cursor.execute(
            "INSERT INTO DetallesVenta (id_pedido, id_producto, cantidad, precio_unitario, subtotal, descuento, total_con_descuento) VALUES (?, ?, ?, ?, ?, ?, ?)",
            id_pedido, prod, qty, price, subtotal, disc_pct, total_cd
        )
        sum_sub += subtotal
        sum_desc += total_disc
    return sum_sub, sum_desc


def insertar_pago(cursor, id_pedido, amount):
    metodo = random.randint(*METODO_PAGO_RANGE)
    estado = random.choice(ESTADOS_PAGO)
    cursor.execute(
        "INSERT INTO PagosVenta (id_pedido, id_metodo_pago, monto, estado) VALUES (?, ?, ?, ?)",
        id_pedido, metodo, amount, estado
    )


def actualizar_pedido(cursor, id_pedido, total, desc):
    total_cd = total - desc
    cursor.execute(
        "UPDATE PedidosVenta SET total=?, total_descuento_productos=?, total_descuento_promociones=0, total_con_descuento=?, estado='procesado' WHERE id_pedido=?",
        total, desc, total_cd, id_pedido
    )


def main():
    conn = pyodbc.connect(CONN_STR)
    cursor = conn.cursor()
    promociones = get_active_promociones(cursor)
    conn.autocommit = False
    for i in range(1, NUM_PEDIDOS+1):
        try:
            print(f"Procesando pedido {i}/{NUM_PEDIDOS}", end='\r')
            cliente = random.randint(*CLIENTE_RANGE)
            usuario = get_id_usuario(cursor, cliente)
            pid = insertar_pedido(cursor, cliente, usuario)
            total, desc = insertar_detalle(cursor, pid, promociones)
            comp = generar_comprobante(cursor, pid)
            actualizar_pedido(cursor, pid, total, desc)
            insertar_pago(cursor, pid, total-desc)
            conn.commit()
        except Exception as ex:
            conn.rollback()
            logging.error(f"Error pedido {i}: {ex}")
            print(f"\nError pedido {i}: {ex}")
    cursor.close()
    conn.close()
    logging.info("Inserción completada.")

if __name__ == '__main__':
    main()
