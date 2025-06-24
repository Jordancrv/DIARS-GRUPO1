import pyodbc
import random
from datetime import datetime, timedelta

# Conexión a SQL Server
conn = pyodbc.connect(
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=PC101;"
    "DATABASE=DiarsAlfa;"
    "Trusted_Connection=yes;"
)
cursor = conn.cursor()

# Obtener el precio del producto desde la tabla Productos
def obtener_precio_producto(id_producto):
    cursor.execute("SELECT precio FROM Productos WHERE id_producto = ?", id_producto)
    row = cursor.fetchone()
    return float(row[0]) if row else 0.0

# Insertar detalle de venta
def insertar_detalle(id_pedido, id_producto, cantidad, precio_unitario, descuento):
    cursor.execute("""
        INSERT INTO DetallesVenta (
            id_pedido, id_producto, cantidad, precio_unitario, descuento
        ) VALUES (?, ?, ?, ?, ?)
    """, (id_pedido, id_producto, cantidad, precio_unitario, descuento))

# Calcular y actualizar totales en PedidosVenta
def actualizar_totales(id_pedido):
    cursor.execute("""
        SELECT 
            SUM(cantidad * precio_unitario) AS total,
            SUM(cantidad * precio_unitario * (descuento / 100.0)) AS descuento_productos,
            SUM(cantidad * precio_unitario * (1 - descuento / 100.0)) AS total_con_descuento
        FROM DetallesVenta
        WHERE id_pedido = ?
    """, id_pedido)
    row = cursor.fetchone()
    if row:
        total, descuento_productos, total_con_descuento = row
        cursor.execute("""
            UPDATE PedidosVenta
            SET total = ?, total_descuento_productos = ?, total_con_descuento = ?
            WHERE id_pedido = ?
        """, (total or 0, descuento_productos or 0, total_con_descuento or 0, id_pedido))

# Generar e insertar pedidos con detalles
def generar_e_insertar_pedidos(cantidad=10):
    estados = ['pendiente', 'procesado', 'anulado']
    for _ in range(cantidad):
        id_cliente = random.randint(1, 10)
        id_usuario = random.randint(1, 10)
        id_comprobante = random.randint(1, 10)
        fecha = datetime.now() - timedelta(days=random.randint(0, 365))
        estado = random.choice(estados)

        # Insertar pedido y obtener ID generado
        cursor.execute("""
            INSERT INTO PedidosVenta (
                id_cliente, id_usuario, fecha, id_comprobante,
                total, total_descuento_productos, total_descuento_promociones,
                total_con_descuento, estado
            ) OUTPUT INSERTED.id_pedido
            VALUES (?, ?, ?, ?, 0, 0, 0, 0, ?)
        """, (id_cliente, id_usuario, fecha, id_comprobante, estado))
        id_pedido = cursor.fetchone()[0]

        # Insertar detalles aleatorios
        for _ in range(random.randint(1, 5)):
            id_producto = random.randint(1, 10)
            cantidad = random.randint(1, 10)
            precio_unitario = obtener_precio_producto(id_producto)
            descuento = random.choice([0, 5, 10])
            insertar_detalle(id_pedido, id_producto, cantidad, precio_unitario, descuento)

        # Actualizar totales en el pedido
        actualizar_totales(id_pedido)

    conn.commit()
    print(f"✅ Se insertaron {cantidad} pedidos con sus detalles.")

# Ejecutar función principal
generar_e_insertar_pedidos(10)

cursor.close()
conn.close()
