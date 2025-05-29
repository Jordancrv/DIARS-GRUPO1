create database Diars
use Diars


CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    rol VARCHAR(50) NOT NULL CHECK (rol IN ('admin', 'vendedor', 'almacen', 'compras')),
    fecha_creacion DATETIME DEFAULT GETDATE(),
    activo BIT DEFAULT 1  -- 1 = TRUE, 0 = FALSE
);

CREATE TABLE Clientes (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    razon_social VARCHAR(100) NOT NULL,
    ruc VARCHAR(11) UNIQUE NOT NULL,
    direccion TEXT,
    telefono VARCHAR(20),
    email VARCHAR(100),
    activo BIT DEFAULT 1
);

CREATE TABLE Almacen (
    id_almacen INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    ubicacion NVARCHAR(200),
    descripcion NVARCHAR(250),
    estado BIT NOT NULL DEFAULT 1 -- 1 = activo, 0 = inactivo
);



CREATE TABLE Proveedores (
    id_proveedor INT IDENTITY(1,1) PRIMARY KEY,
    razon_social VARCHAR(100) NOT NULL,
    ruc VARCHAR(11) UNIQUE NOT NULL,
    direccion TEXT,
    contacto VARCHAR(100),
    telefono VARCHAR(20),
    email VARCHAR(100),
    activo BIT DEFAULT 1
);

CREATE TABLE Productos (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(50) UNIQUE NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    precio DECIMAL(10, 2) NOT NULL,
    stock INT NOT NULL DEFAULT 0,
    stock_minimo INT NOT NULL DEFAULT 5,
    unidad_medida VARCHAR(20),
    id_proveedor INT,
    activo BIT DEFAULT 1,
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor)
);

CREATE TABLE MetodosPago (
    id_metodo_pago INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    activo BIT DEFAULT 1
);

CREATE TABLE ComprobantesPago (
    id_comprobante INT IDENTITY(1,1) PRIMARY KEY,
    tipo VARCHAR(50) NOT NULL CHECK (tipo IN ('factura', 'boleta', 'nota_credito')),
    serie VARCHAR(20),
    numero VARCHAR(20),
    activo BIT DEFAULT 1
);

CREATE TABLE PedidosVenta (
    id_pedido INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT REFERENCES Clientes(id_cliente),
    id_usuario INT REFERENCES Usuarios(id_usuario),
    fecha DATETIME DEFAULT GETDATE(),
    estado VARCHAR(20) NOT NULL CHECK (estado IN ('pendiente', 'procesado', 'anulado')),
    total DECIMAL(12, 2) NOT NULL
);

CREATE TABLE DetallesPedido (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_pedido INT REFERENCES PedidosVenta(id_pedido),
    id_producto INT REFERENCES Productos(id_producto),
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal AS (cantidad * precio_unitario)  
);

CREATE TABLE PagosVenta (
    id_pago INT IDENTITY(1,1) PRIMARY KEY,
    id_pedido INT REFERENCES PedidosVenta(id_pedido),
    id_metodo_pago INT REFERENCES MetodosPago(id_metodo_pago),
    id_comprobante INT REFERENCES ComprobantesPago(id_comprobante),
    monto DECIMAL(12, 2) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    estado VARCHAR(20) CHECK (estado IN ('completado', 'anulado', 'pendiente'))
);


CREATE TABLE OrdenesCompra (
    id_orden_compra INT IDENTITY(1,1) PRIMARY KEY,
    id_proveedor INT REFERENCES Proveedores(id_proveedor),
    id_usuario INT REFERENCES Usuarios(id_usuario),
    fecha DATETIME DEFAULT GETDATE(),
    estado VARCHAR(20) NOT NULL CHECK (estado IN ('pendiente', 'recibido', 'cancelado')),
    total DECIMAL(12, 2) NOT NULL
);

CREATE TABLE DetallesOrdenCompra (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_orden_compra INT REFERENCES OrdenesCompra(id_orden_compra),
    id_producto INT REFERENCES Productos(id_producto),
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal AS (cantidad * precio_unitario) 
);

CREATE TABLE MovimientosStock (
    id_movimiento INT IDENTITY(1,1) PRIMARY KEY,
    id_producto INT REFERENCES Productos(id_producto),
    tipo VARCHAR(20) NOT NULL CHECK (tipo IN ('entrada', 'salida', 'ajuste')),
    cantidad INT NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    id_pedido INT NULL REFERENCES PedidosVenta(id_pedido),
    id_orden_compra INT NULL REFERENCES OrdenesCompra(id_orden_compra),
    motivo TEXT
);

CREATE TYPE DetallePedidoTyppe AS TABLE (
    id_producto INT,
    cantidad INT,
    precio_unitario DECIMAL(10, 2)
);
CREATE PROCEDURE sp_RegistrarPedidoVenta
    @id_cliente INT,
    @id_usuario INT,
    @total DECIMAL(12, 2),
    @Detalles DetallePedidoTyppe READONLY,
    @PedidoId INT OUTPUT,
    @Mensaje NVARCHAR(500) OUTPUT,
    @Resultado BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO PedidosVenta(id_cliente, id_usuario, fecha, estado, total)
        VALUES (@id_cliente, @id_usuario, GETDATE(), 'pendiente', @total);

        SET @PedidoId = SCOPE_IDENTITY();

        INSERT INTO DetallesPedido(id_pedido, id_producto, cantidad, precio_unitario)
        SELECT @PedidoId, id_producto, cantidad, precio_unitario
        FROM @Detalles;

        SET @Resultado = 1;
        SET @Mensaje = 'Pedido registrado correctamente.';

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END;

CREATE or alter PROCEDURE sp_ListarVentasPorFecha
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SELECT
        pv.id_pedido AS VentaId,
        pv.fecha,
        pv.estado,
        pv.total,
        c.id_cliente AS ClienteId,
        c.razon_social AS RazonSocial
    FROM PedidosVenta pv
    INNER JOIN Clientes c ON pv.id_cliente = c.id_cliente
    WHERE pv.fecha BETWEEN @FechaInicio AND @FechaFin
    ORDER BY pv.fecha DESC;
END

CREATE PROCEDURE sp_ObtenerVentaPorId
    @id_pedido INT
AS
BEGIN
    -- Cabecera del pedido
    SELECT
        p.id_pedido,
        p.fecha,
        p.estado,
        p.total,
        c.id_cliente,
        c.razon_social,
        c.ruc,
        c.direccion,
        c.telefono,
        c.email,
        c.activo
    FROM PedidosVenta p
    INNER JOIN Clientes c ON p.id_cliente = c.id_cliente
    WHERE p.id_pedido = @id_pedido;

    -- Detalle del pedido
    SELECT
        d.id_detalle,
        d.id_producto,
        d.cantidad,
        d.precio_unitario,
        d.subtotal,
        pr.nombre AS nombre_producto,
        pr.descripcion
    FROM DetallesPedido d
    INNER JOIN Productos pr ON d.id_producto = pr.id_producto
    WHERE d.id_pedido = @id_pedido;
END
CREATE PROCEDURE sp_AnularVenta
    @VentaId INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    BEGIN TRY
        -- Verifica si la venta existe y no está ya anulada
        IF EXISTS (SELECT 1 FROM PedidosVenta WHERE id_pedido = @VentaId AND estado <> 'Anulado')
        BEGIN
            -- Actualiza el estado a "Anulado"
            UPDATE PedidosVenta
            SET estado = 'Anulado'
            WHERE id_pedido = @VentaId;

            SET @Resultado = 1;
            SET @Mensaje = 'La venta fue anulada correctamente.';
        END
        ELSE
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'La venta no existe o ya fue anulada.';
        END
    END TRY
    BEGIN CATCH
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END





