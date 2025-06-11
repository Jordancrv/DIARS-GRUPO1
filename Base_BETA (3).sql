CREATE DATABASE DiarsBeta; 
GO
USE DiarsBeta; 
GO


-- Usuarios del sistema
CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    rol VARCHAR(50) NOT NULL CHECK (rol IN ('admin', 'vendedor', 'almacen', 'compras')),
    fecha_creacion DATETIME DEFAULT GETDATE(),
    activo BIT DEFAULT 1
);
GO



-- Correos de usuarios
CREATE TABLE UsuarioCorreos (
    id_usuario INT,
    email VARCHAR(100) UNIQUE,
    PRIMARY KEY (id_usuario, email),
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);
GO

-- Cliente
CREATE TABLE tipoCliente (
    id_tipo_cliente INT PRIMARY KEY,
    nombre_tipo VARCHAR(20) NOT NULL -- Ejemplo: 'persona', 'empresa'
);

GO
drop table tipoCliente
INSERT INTO TipoCliente (id_tipo_cliente, nombre_tipo)
VALUES (1, 'persona'), (2, 'empresa');




CREATE TABLE Clientes (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    id_tipo_cliente INT NOT NULL, 
    
    -- Para persona (boleta)
    nombres VARCHAR(100),
    apellidos VARCHAR(100),
	dni varchar(16) , 

    -- Para empresa (factura)
    razon_social VARCHAR(100),
    ruc VARCHAR(11) UNIQUE,

    direccion TEXT,
    activo BIT DEFAULT 1, 
	FOREIGN KEY (id_tipo_cliente) REFERENCES tipoCliente(id_tipo_cliente)

);
go
drop table Clientes

CREATE TABLE ClienteCorreos (
    id_cliente INT,
    email VARCHAR(100),
    PRIMARY KEY (id_cliente, email),
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente)
);
GO
drop table ClienteCorreos

CREATE TABLE ClienteTelefonos (
    id_cliente INT,
    telefono VARCHAR(20),
    PRIMARY KEY (id_cliente, telefono),
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente)
);
GO
drop table ClienteTelefonos
-- Proveedores
CREATE TABLE Proveedores (
    id_proveedor INT IDENTITY(1,1) PRIMARY KEY,
    razon_social VARCHAR(100) NOT NULL,
    ruc VARCHAR(11) UNIQUE NOT NULL,
    direccion TEXT,
    contacto VARCHAR(100),
    activo BIT DEFAULT 1
);
GO

CREATE TABLE ProveedorCorreos (
    id_proveedor INT,
    email VARCHAR(100),
    PRIMARY KEY (id_proveedor, email),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor)
);
GO

CREATE TABLE ProveedorTelefonos (
    id_proveedor INT,
    telefono VARCHAR(20),
    PRIMARY KEY (id_proveedor, telefono),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor)
);
GO

-- Productos

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
    idCategoria INT,
    idPresentacion INT,
    idTipoEmpaque INT,
    activo BIT DEFAULT 1,
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor),
    FOREIGN KEY (idCategoria) REFERENCES CategoriaProductos(idCategoria),
    FOREIGN KEY (idPresentacion) REFERENCES Presentacion(idPresentacion),
    FOREIGN KEY (idTipoEmpaque) REFERENCES TipoEmpaque(idTipoEmpaque)
);
GO
drop table Productos
select * from Productos


CREATE TABLE CategoriaProductos(

  idCategoria INT PRIMARY KEY IDENTITY(1,1),
   nombreCategoria VARCHAR(50) NOT NULL
); 
Go


CREATE TABLE Presentacion(

idPresentacion INT PRIMARY KEY IDENTITY(1,1),
   nombrePresentacion VARCHAR(64) NOT NULL,


); 
Go

CREATE TABLE TipoEmpaque(
idTipoEmpaque INT PRIMARY KEY IDENTITY(1,1),
nombreEmpaque VARCHAR(64) NOT NULL,
material VARCHAR(64) NULL -- opcional: plástico, cartón, vidrio

); 
Go

Create table TipoPromociones(
it_tipo_promociones int primary key identity(1,1), 





); 
CREATE TABLE TipoPromocion (
    id_tipo_promocion INT PRIMARY KEY IDENTITY(1,1),
    nombre_tipo VARCHAR(50) NOT NULL -- Ej: 'por producto', 'por monto', 'general', 'por categoría', etc.
);
GO


CREATE TABLE Promociones (
    IdPromocion INT PRIMARY KEY IDENTITY(1,1),
    NombrePromocion VARCHAR(128) NOT NULL,
    Descuento DECIMAL(5,2) NOT NULL, -- Porcentaje: 10.00 = 10%
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    Estado BIT DEFAULT 1,
    id_tipo_promocion INT NOT NULL,
    FOREIGN KEY (id_tipo_promocion) REFERENCES TipoPromocion(id_tipo_promocion)
);
GO




CREATE TABLE ProductoPromocion (
    id_producto INT,
    id_promocion INT,

    PRIMARY KEY (id_producto, id_promocion), 
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto),
    FOREIGN KEY (id_promocion) REFERENCES Promociones(IdPromocion)
);



CREATE TABLE VentaPromocion (
    id_pedido INT,
    id_promocion INT,
	--monto_descuento DECIMAL(10,2), -- opcional: puedes dejarlo NULL si lo calculas dinámicamente
    PRIMARY KEY (id_pedido, id_promocion),
    FOREIGN KEY (id_pedido) REFERENCES PedidosVenta(id_pedido),
    FOREIGN KEY (id_promocion) REFERENCES Promociones(IdPromocion)
);










-- Métodos de pago
CREATE TABLE MetodosPago (
    id_metodo_pago INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    activo BIT DEFAULT 1
);
GO

-- Comprobantes
CREATE TABLE ComprobantesPago (
    id_comprobante INT IDENTITY(1,1) PRIMARY KEY,
    tipo VARCHAR(50) NOT NULL CHECK (tipo IN ('factura', 'boleta', 'nota_credito')),
    serie VARCHAR(20),
    numero VARCHAR(20),
    activo BIT DEFAULT 1
);
GO
select razon_social from Clientes
-- Ventas
CREATE TABLE PedidosVenta (
    id_pedido INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT REFERENCES Clientes(id_cliente),
    id_usuario INT REFERENCES Usuarios(id_usuario),
    fecha DATETIME DEFAULT GETDATE(),
    id_comprobante INT REFERENCES ComprobantesPago(id_comprobante),
	  total DECIMAL(12,2),
    total_descuento_productos DECIMAL(12,2),
    total_descuento_promociones DECIMAL(12,2),--------------------- quiza que vaya como registro. ver si va id de promociones o creo que va en promociones venta. y prmociones producto. 
    total_con_descuento DECIMAL(12,2),


    --total AS (
    --    SELECT SUM(subtotal)
    --    FROM DetallesVenta
    --    WHERE id_pedido = PedidosVenta.id_pedido
    --),

    --total_descuento_productos AS (
    --    SELECT ISNULL(SUM(subtotal - total_con_descuento), 0)
    --    FROM DetallesVenta
    --    WHERE id_pedido = PedidosVenta.id_pedido
    --),

    --total_descuento_promociones AS (
    --    SELECT ISNULL(SUM(monto_descuento), 0)
    --    FROM VentaPromocion
    --    WHERE id_pedido = PedidosVenta.id_pedido
    --),

    --total_con_descuento AS (
    --    SELECT 
    --        ISNULL(SUM(subtotal), 0)
    --        - ISNULL(SUM(subtotal - total_con_descuento), 0)
    --        - (
    --            SELECT ISNULL(SUM(monto_descuento), 0)
    --            FROM VentaPromocion
    --            WHERE id_pedido = PedidosVenta.id_pedido
    --        )
    --    FROM DetallesVenta
    --    WHERE id_pedido = PedidosVenta.id_pedido
    --),

    estado VARCHAR(20) NOT NULL CHECK (estado IN ('pendiente', 'procesado', 'anulado'))
);
go


drop table PedidosVenta






CREATE TABLE DetallesVenta (
     id_detalle INT IDENTITY(1,1) primary key ,
    id_pedido INT,
    id_producto INT,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal AS (cantidad * precio_unitario),
	descuento DECIMAL(5,2) DEFAULT 0,
	total_con_descuento AS (subtotal* (1 - descuento/100.0))
    
    FOREIGN KEY (id_pedido) REFERENCES PedidosVenta(id_pedido),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);
GO
drop table DetallesVenta; 


---------------------------------Para seleccionar el descuento que "tiene" ese producto
--------------------------------esta seleccion la utilizaresmos en algun proceso almacenado
-------------------------------- y utilizado direcctamente en aplicacion para filtrar pro el id del producto----
---------------------------automaticamente el desuento que le corresponde-------------------------

CREATE PROCEDURE ObtenerDescuentoProductoActivo
    @id_producto INT
AS
BEGIN
    SELECT TOP 1 p.Descuento
    FROM ProductoPromocion pp
    JOIN Promociones p ON p.IdPromocion = pp.id_promocion
    WHERE 
        pp.id_producto = @id_producto
        AND p.FechaInicio <= GETDATE()
        AND p.FechaFin >= GETDATE()
        AND p.Estado = 1
    ORDER BY p.Descuento DESC
END
GO


---------------------------------
-----------------------------




------- vista opcional para llenar el descuento correspondiente a ese producto ..


--CREATE VIEW VistaDetallesConDescuento AS
--SELECT 
--    dv.id_detalle,
--    dv.id_pedido,
--    dv.id_producto,
--    dv.cantidad,
--    dv.precio_unitario,
--    dv.subtotal,
--    ISNULL(p.Descuento, 0) AS descuento,
--    dv.subtotal * (1 - ISNULL(p.Descuento, 0) / 100.0) AS total_con_descuento
--FROM DetallesVenta dv
--LEFT JOIN ProductoPromocion pp ON pp.id_producto = dv.id_producto
--LEFT JOIN Promociones p ON p.IdPromocion = pp.id_promocion
--    AND GETDATE() BETWEEN p.FechaInicio AND p.FechaFin
--    AND p.Estado = 1;


-------------------------------------------------------------------------





CREATE TABLE PagosVenta (
    id_pago INT IDENTITY(1,1) PRIMARY KEY,
    id_pedido INT REFERENCES PedidosVenta(id_pedido),
    id_metodo_pago INT REFERENCES MetodosPago(id_metodo_pago), 
    monto DECIMAL(12, 2) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    estado VARCHAR(20) CHECK (estado IN ('completado', 'anulado', 'pendiente'))
);
GO
drop table PagosVenta



-- Ordenes de compra
CREATE TABLE OrdenesCompra (
    id_orden_compra INT IDENTITY(1,1) PRIMARY KEY,
    id_proveedor INT REFERENCES Proveedores(id_proveedor),
    id_usuario INT REFERENCES Usuarios(id_usuario),
    fecha DATETIME DEFAULT GETDATE(),
    estado VARCHAR(20) NOT NULL CHECK (estado IN ('pendiente', 'recibido', 'cancelado')),
    total DECIMAL(12, 2) NOT NULL
);
GO

CREATE TABLE DetallesOrdenCompra (
	id_pago INT IDENTITY(1,1) primary key,
    id_orden_compra INT,
    id_producto INT,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal AS (cantidad * precio_unitario),
   
    FOREIGN KEY (id_orden_compra) REFERENCES OrdenesCompra(id_orden_compra),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);
GO
--drop table DetallesOrdenCompra

-- Movimiento de stock
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
GO
drop table MovimientosStock






---------------REGION PROCESOS ALMACENADOS 

CREATE TYPE DetallePedidoType AS TABLE
(
    id_producto INT,
    cantidad INT,
    precio_unitario DECIMAL(10, 2)
);

go
CREATE or alter  PROCEDURE sp_RegistrarPedidoVenta
    @id_cliente INT,
    @id_usuario INT,
    @estado NVARCHAR(20),
    @Detalles DetallePedidoType READONLY,
    @Resultado BIT OUTPUT,
    @PedidoId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar cabecera del pedido
        INSERT INTO PedidosVenta (id_cliente, id_usuario, fecha, estado)
        VALUES (@id_cliente, @id_usuario, GETDATE(), @estado);

        SET @PedidoId = SCOPE_IDENTITY();

        -- Insertar detalles
        INSERT INTO DetallesVenta (id_pedido, id_producto, cantidad, precio_unitario)
        SELECT 
            @PedidoId,
            id_producto,
            cantidad,
            precio_unitario
        FROM @Detalles;

        SET @Resultado = 1;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Resultado = 0;
        SET @PedidoId = 0;
    END CATCH
END

go


------- Listar cabeceras, solo la tabla de listar per se

CREATE or alter PROCEDURE sp_ListarVentas
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        pv.id_pedido,
        pv.fecha,
        pv.estado,
        c.id_cliente,
        c.razon_social AS cliente,
        u.id_usuario,
        (u.nombres + ' ' + u.apellidos) AS usuario
    FROM PedidosVenta pv
    INNER JOIN Clientes c ON pv.id_cliente = c.id_cliente
    INNER JOIN Usuarios u ON pv.id_usuario = u.id_usuario
    ORDER BY pv.fecha DESC;
END;
GO

------ listar con detalles , si esnecesario .......
CREATE OR ALTER PROCEDURE sp_ListarVentasConDetalles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dv.id_detalle,          -- ID del detalle
        pv.id_pedido,
        pv.fecha,
        pv.estado,
        c.razon_social AS cliente,
        (u.nombres + ' ' + u.apellidos) AS usuario,
        p.nombre AS producto,
        dv.cantidad,
        dv.precio_unitario,
        dv.subtotal              -- Usar la columna calculada ya definida
    FROM PedidosVenta pv
    INNER JOIN Clientes c ON pv.id_cliente = c.id_cliente
    INNER JOIN Usuarios u ON pv.id_usuario = u.id_usuario
    INNER JOIN DetallesVenta dv ON pv.id_pedido = dv.id_pedido
    INNER JOIN Productos p ON dv.id_producto = p.id_producto
    ORDER BY pv.fecha DESC, pv.id_pedido, dv.id_detalle;
END;
GO



----- obtener venta por id cliente (opcional) 


CREATE or alter  PROCEDURE sp_ObtenerVentasPorClienteId
    @id_cliente INT
AS
BEGIN
    SELECT 
        v.id_pedido,
        v.fecha,
        v.estado,
        c.id_cliente,
        c.razon_social
    FROM PedidoVenta v
    INNER JOIN Cliente c ON v.id_cliente = c.id_cliente
    WHERE v.id_cliente = @id_cliente;
END

go

----------------------- buscar venta por Id_venta


CREATE or alter PROCEDURE sp_BuscarVentaPorId
    @id_pedido INT
AS
BEGIN
    -- Datos de la venta
    SELECT v.id_pedido, v.fecha, v.estado, 
           c.id_cliente, c.razon_social, c.ruc, c.direccion, c.telefono, c.email, c.activo
    FROM PedidoVenta v
    INNER JOIN Clientes c ON v.id_cliente = c.id_cliente
    WHERE v.id_pedido = @id_pedido;

    -- Detalles de la venta
    SELECT d.id_detalle, d.id_producto, d.cantidad, d.precio_unitario, d.subtotal,
           p.nombre AS nombre_producto, p.descripcion
    FROM DetallePedidoVenta d
    INNER JOIN Productos p ON d.id_producto = p.id_producto
    WHERE d.id_pedido = @id_pedido;
END


go





--------------------- referente a Usuario ----------------

CREATE or alter PROCEDURE sp_InsertarUsuario
     @nombres NVARCHAR(100),
    @apellidos NVARCHAR(100),
    @email NVARCHAR(100),
    @password_hash NVARCHAR(200),
    @rol NVARCHAR(50),
    @activo BIT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar en la tabla Usuarios
        INSERT INTO Usuarios (nombres, apellidos, password_hash, rol, fecha_creacion, activo)
        VALUES (@nombres, @apellidos, @password_hash, @rol, GETDATE(), @activo);

        -- Obtener el ID del usuario recién insertado
        DECLARE @id_usuario INT = SCOPE_IDENTITY();

        -- Insertar en la tabla UsuarioCorreos
        INSERT INTO UsuarioCorreos (id_usuario, email)
        VALUES (@id_usuario, @email);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE or alter PROCEDURE sp_ListarUsuarios
AS
BEGIN
    SELECT 
        u.id_usuario,
        u.nombres,
        u.apellidos,
        u.password_hash,     -- ✅ Agregado
        uc.email,
        u.rol,
        u.fecha_creacion,
        u.activo
    FROM Usuarios u
    LEFT JOIN UsuarioCorreos uc ON u.id_usuario = uc.id_usuario
END
GO



CREATE or alter PROCEDURE sp_BuscarUsuarioPorId
    @id_usuario INT
AS
BEGIN
    SELECT * FROM Usuario WHERE id_usuario = @id_usuario
END
go

CREATE or alter PROCEDURE sp_ActualizarUsuario
    @id_usuario INT,
    @nombre NVARCHAR(100),
    @apellidos NVARCHAR(100),
    @email NVARCHAR(100),
    @password_hash NVARCHAR(200),
    @rol NVARCHAR(50),
    @activo BIT
AS
BEGIN
    UPDATE Usuario
    SET nombre = @nombre,
        apellidos = @apellidos,
        email = @email,
        password_hash = @password_hash,
        rol = @rol,
        activo = @activo
    WHERE id_usuario = @id_usuario
END
go


CREATE or alter PROCEDURE sp_EliminarUsuario
    @id_usuario INT
AS
BEGIN
    DELETE FROM Usuario WHERE id_usuario = @id_usuario
END
go



------------------------------- Referente a Productos--------
CREATE or alter PROCEDURE spListarProductos
AS
BEGIN
    SELECT * FROM Productos
END
go


select * from 

CREATE or alter  PROCEDURE spInsertarProducto
    @codigo NVARCHAR(50),
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(MAX),
    @precio DECIMAL(18,2),
    @stock INT,
    @stock_minimo INT,
    @unidad_medida NVARCHAR(50),
    @id_proveedor INT,
    @activo BIT
AS
BEGIN
    INSERT INTO Productos(codigo, nombre, descripcion, precio, stock, stock_minimo, unidad_medida, id_proveedor, activo)
    VALUES (@codigo, @nombre, @descripcion, @precio, @stock, @stock_minimo, @unidad_medida, @id_proveedor, @activo)
END
go

CREATE or alter PROCEDURE spEditarProducto
    @id_producto INT,
    @codigo NVARCHAR(50),
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(MAX),
    @precio DECIMAL(18,2),
    @stock INT,
    @stock_minimo INT,
    @unidad_medida NVARCHAR(50),
    @id_proveedor INT,
    @activo BIT
AS
BEGIN
    UPDATE Producto
    SET codigo = @codigo,
        nombre = @nombre,
        descripcion = @descripcion,
        precio = @precio,
        stock = @stock,
        stock_minimo = @stock_minimo,
        unidad_medida = @unidad_medida,
        id_proveedor = @id_proveedor,
        activo = @activo
    WHERE id_producto = @id_producto
END
go



CREATE or alter PROCEDURE spBuscarProductoPorId
    @id_producto INT
AS
BEGIN
    SELECT * FROM Producto WHERE id_producto = @id_producto
END
go

CREATE or alter PROCEDURE spEliminarProducto
    @id_producto INT
AS
BEGIN
    DELETE FROM Producto WHERE id_producto = @id_producto
END
go




----------------------- Referente a  cliente 


CREATE or alter PROCEDURE sp_ListarCliente
AS
BEGIN
    SELECT 
        c.id_cliente,
        c.razon_social,
        c.ruc,
        c.direccion,
        
        -- Subconsulta para obtener un solo teléfono
        (SELECT TOP 1 telefono 
         FROM ClienteTelefonos 
         WHERE id_cliente = c.id_cliente) AS telefono,

        -- Subconsulta para obtener un solo correo
        (SELECT TOP 1 email 
         FROM ClienteCorreos 
         WHERE id_cliente = c.id_cliente) AS email,

        c.activo
    FROM Clientes c;
END
go


CREATE or alter PROCEDURE sp_InsertarCliente

    @razon_social NVARCHAR(100),
    @ruc NVARCHAR(20),
    @direccion NVARCHAR(200),
    @telefono NVARCHAR(20),
    @email NVARCHAR(100),
    @activo BIT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar en la tabla Clientes
        INSERT INTO Clientes (razon_social, ruc, direccion, activo)
        VALUES (@razon_social, @ruc, @direccion, @activo);

        -- Obtener el id generado
        DECLARE @id_cliente INT = SCOPE_IDENTITY();

        -- Insertar correo en ClienteCorreos
        INSERT INTO ClienteCorreos (id_cliente, email)
        VALUES (@id_cliente, @email);

        -- Insertar teléfono en ClienteTelefonos
        INSERT INTO ClienteTelefonos (id_cliente, telefono)
        VALUES (@id_cliente, @telefono);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO



CREATE or alter PROCEDURE sp_EditarCliente
    @id_cliente INT,
    @razon_social NVARCHAR(100),
    @ruc NVARCHAR(20),
    @direccion NVARCHAR(200),
    @telefono NVARCHAR(20),
    @email NVARCHAR(100),
    @activo BIT
AS
BEGIN
    UPDATE Cliente
    SET 
        razon_social = @razon_social,
        ruc = @ruc,
        direccion = @direccion,
        telefono = @telefono,
        email = @email,
        activo = @activo
    WHERE id_cliente = @id_cliente
END
go

CREATE or alter PROCEDURE sp_BuscarCliente
    @id_cliente INT
AS
BEGIN
    SELECT 
        id_cliente,
        razon_social,
        ruc,
        direccion,
        telefono,
        email,
        activo
    FROM Cliente
    WHERE id_cliente = @id_cliente
END
go


CREATE or alter PROCEDURE sp_EliminarCliente
    @id_cliente INT
AS
BEGIN
    DELETE FROM Cliente WHERE id_cliente = @id_cliente
END
go


CREATE or alter PROCEDURE sp_EliminaEditaCliente
    @id_cliente INT
AS
BEGIN
    UPDATE Cliente
    SET activo = 0
    WHERE id_cliente = @id_cliente
END
go

-------

------


-- Cliente 1
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Tecnología Castro', '10245789321', N'Av. Bolívar 152, Lima', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente1@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '987654321';

-- Cliente 2
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Comercial Ruiz SAC', '10456237891', N'Jr. Ayacucho 854, Arequipa', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente2@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '989112233';

-- Cliente 3
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Importaciones Velásquez', '10987654321', N'Calle Colón 220, Trujillo', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente3@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '912334455';

-- Cliente 4
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Grupo Mendoza SRL', '10543219876', N'Avenida Perú 710, Chiclayo', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente4@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '911223344';

-- Cliente 5
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Constructora Andina', '10123456789', N'Av. Brasil 1020, Lima', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente5@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '944556677';

-- Cliente 6
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Servicios López', '10444332211', N'Calle Grau 221, Piura', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente6@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '933221100';

-- Cliente 7
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Mercantil Rojas', '10765432981', N'Av. Primavera 330, Cusco', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente7@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '955667788';

-- Cliente 8
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Consultora Global SAC', '10678912345', N'Calle Lima 402, Huancayo', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente8@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '977889900';

-- Cliente 9
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Industria Pérez', '10293847566', N'Av. Grau 77, Cajamarca', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente9@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '922334455';

-- Cliente 10
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Corporación Sánchez', '10992384756', N'Av. San Martín 1600, Tacna', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente10@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '999887766';

-- Cliente 11
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Soluciones Ramírez', '10334455667', N'Av. Túpac Amaru 89, Huaraz', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente11@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '966554433';

-- Cliente 12
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Negocios Gómez', '10777788899', N'Jr. Arequipa 33, Moquegua', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente12@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '922113355';

-- Cliente 13
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Empresas Chávez', '10112233445', N'Av. Grau 410, Ica', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente13@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '944556677';

-- Cliente 14
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Importadora Ramal', '10889977665', N'Calle Cuzco 150, Puno', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente14@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '911887744';

-- Cliente 15
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Mega Servicios EIRL', '10099887766', N'Jr. Sucre 203, Lima', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente15@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '933224466';

-- Cliente 16
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Servicios Integrales SRL', '10665443322', N'Av. Benavides 445, Trujillo', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente16@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '977223344';

-- Cliente 17
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Comercial Tacna SAC', '10223344556', N'Av. El Sol 100, Tacna', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente17@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '988776655';

-- Cliente 18
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Ferretería El Progreso', '10557788990', N'Jr. Piura 315, Chiclayo', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente18@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '922334477';

-- Cliente 19
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Innovación Global SAC', '10778899001', N'Av. Arenales 540, Huánuco', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente19@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '955667788';

-- Cliente 20
INSERT INTO Clientes (razon_social, ruc, direccion, activo)
VALUES (N'Multiservicios Quispe', '10339988771', N'Av. La Marina 920, Lima', 1);
INSERT INTO ClienteCorreos (id_cliente, email)
SELECT IDENT_CURRENT('Clientes'), 'cliente20@example.com';
INSERT INTO ClienteTelefonos (id_cliente, telefono)
SELECT IDENT_CURRENT('Clientes'), '900112233';
go



























--------------------------------------------------
------------------------------------------------
---------------------------------------------------
------------------------------------------------
------------------------------------------------
--------------------------------------------------


INSERT INTO Usuarios (nombres, apellidos, password_hash, rol)
VALUES 
('Luis', 'García', 'hash123', 'vendedor'),
('María', 'Pérez', 'hash456', 'vendedor'),
('Carlos', 'Ramírez', 'hash789', 'vendedor');
go
INSERT INTO Clientes (razon_social, ruc, direccion)
VALUES 
('Cliente Uno S.A.C', '20100000001', 'Av. Lima 123'),
('Cliente Dos S.A.C', '20100000002', 'Av. Perú 456'),
('Cliente Tres EIRL', '20100000003', 'Av. Arequipa 789'),
('Cliente Cuatro S.A.C', '20100000004', 'Jr. Amazonas 100'),
('Cliente Cinco SRL', '20100000005', 'Calle Los Olivos 200'),
('Cliente Seis S.A.C', '20100000006', 'Calle Real 321'),
('Cliente Siete EIRL', '20100000007', 'Av. Brasil 111'),
('Cliente Ocho SAC', '20100000008', 'Jr. Tacna 222'),
('Cliente Nueve SRL', '20100000009', 'Av. Grau 333'),
('Cliente Diez S.A.C', '20100000010', 'Calle Lima 444');

INSERT INTO Proveedores (razon_social, ruc, direccion, contacto)
VALUES ('Proveedor A SAC', '10401010101', 'Av. Proveedores 123', 'Contacto A');
go
INSERT INTO Productos (codigo, nombre, descripcion, precio, stock, unidad_medida, id_proveedor)
VALUES 
('P001', 'Producto A', 'Descripción A', 10.50, 100, 'unidad', 1),
('P002', 'Producto B', 'Descripción B', 20.00, 100, 'unidad', 1),
('P003', 'Producto C', 'Descripción C', 15.75, 100, 'unidad', 1),
('P004', 'Producto D', 'Descripción D', 8.40, 100, 'unidad', 1),
('P005', 'Producto E', 'Descripción E', 12.30, 100, 'unidad', 1);
go
select * from Productos

DECLARE @i INT = 1;
DECLARE @Resultado BIT;
DECLARE @PedidoId INT;

WHILE @i <= 30
BEGIN
    DECLARE @clienteId INT = (1 + ABS(CHECKSUM(NEWID())) % 10); -- Cliente 1 a 10
    DECLARE @usuarioId INT = (1 + ABS(CHECKSUM(NEWID())) % 3);  -- Usuario 1 a 3
    DECLARE @estado NVARCHAR(20) = 'procesado';

    DECLARE @Detalles DetallePedidoType;
    
    -- Agrega de 1 a 3 productos aleatorios por venta
    INSERT INTO @Detalles (id_producto, cantidad, precio_unitario)
    VALUES 
        ((1 + ABS(CHECKSUM(NEWID())) % 5), (1 + ABS(CHECKSUM(NEWID())) % 5), 10.50 + (ABS(CHECKSUM(NEWID())) % 20)),
        ((1 + ABS(CHECKSUM(NEWID())) % 5), (1 + ABS(CHECKSUM(NEWID())) % 5), 10.50 + (ABS(CHECKSUM(NEWID())) % 20));

    EXEC sp_RegistrarPedidoVenta
        @id_cliente = @clienteId,
        @id_usuario = @usuarioId,
        @estado = @estado,
        @Detalles = @Detalles,
        @Resultado = @Resultado OUTPUT,
        @PedidoId = @PedidoId OUTPUT;

    SET @i += 1;
END
go
--------------------------------------------
EXEC sp_ListarVentasConDetalles;
go


select * from PedidosVenta; 






