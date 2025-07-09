-- SCRIPT COMPLETO CORREGIDO DE LA BASE DE DATOS DiarsBeta
CREATE DATABASE DiarsAlfa;
GO
USE DiarsAlfa;
GO


-- Tabla de usuarios
CREATE TABLE Usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    password_hash VARCHAR(255) NOT NULL,
    rol VARCHAR(50) NOT NULL CHECK (rol IN ('admin','vendedor' , 'compras', 'cliente', 'proveedor')),
    fecha_creacion DATETIME DEFAULT GETDATE(),
    activo BIT DEFAULT 1
);
GO


CREATE TABLE UsuarioCorreos (
    id_usuario INT,
    email VARCHAR(100) UNIQUE,
    PRIMARY KEY (id_usuario, email),
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
	); 



-- Tabla de tipo de cliente
CREATE TABLE TipoCliente (
    id_tipo_cliente INT PRIMARY KEY,
    nombre_tipo VARCHAR(20) NOT NULL
);
GO

-- Tabla de clientes
CREATE TABLE Clientes (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    id_tipo_cliente INT NOT NULL,
    nombres VARCHAR(100),
    apellidos VARCHAR(100),
    dni VARCHAR(16),
    razon_social VARCHAR(100),
    ruc VARCHAR(11) NULL,
    direccion TEXT,
	id_usuario INT NULL REFERENCES Usuarios(id_usuario), 
    activo BIT DEFAULT 1,
    FOREIGN KEY (id_tipo_cliente) REFERENCES TipoCliente(id_tipo_cliente)
);
GO


CREATE TABLE ClienteCorreos (
    id_cliente INT,
    email VARCHAR(100),
    PRIMARY KEY (id_cliente, email),
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente)
);
GO

CREATE TABLE ClienteTelefonos (
    id_cliente INT,
    telefono VARCHAR(20),
    PRIMARY KEY (id_cliente, telefono),
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente)
);
GO

CREATE TABLE Trabajadores (
    id_trabajador INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NULL REFERENCES Usuarios(id_usuario), -- Enlace opcional a la cuenta de usuario
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    dni CHAR(8) NOT NULL UNIQUE,
    cargo VARCHAR(50) NULL,
    fecha_ingreso DATE NULL,
    activo BIT DEFAULT 1 NOT NULL
);
GO
-- Tabla para almacenar los correos electrónicos de los trabajadores.
CREATE TABLE TrabajadorCorreo (
    id_trabajador INT REFERENCES Trabajadores(id_trabajador),
    email VARCHAR(100) UNIQUE,
    PRIMARY KEY (id_trabajador, email)
);

-- Tabla para almacenar los números de teléfono de los trabajadores.
CREATE TABLE TrabajadorTelefono (
    id_trabajador INT REFERENCES Trabajadores(id_trabajador),
    telefono VARCHAR(100) UNIQUE,
    PRIMARY KEY (id_trabajador, telefono)
);

-- Tabla de proveedores
CREATE TABLE Proveedores (
    id_proveedor INT IDENTITY(1,1) PRIMARY KEY,
    razon_social VARCHAR(100) NOT NULL,
    ruc VARCHAR(11) UNIQUE NOT NULL,
    direccion TEXT,
    contacto VARCHAR(100),
	id_usuario INT NULL REFERENCES Usuarios(id_usuario), 
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

-- Tabla de categorías de productos
CREATE TABLE CategoriaProductos (
    idCategoria INT PRIMARY KEY IDENTITY(1,1),
    nombreCategoria VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Presentacion (
    idPresentacion INT PRIMARY KEY IDENTITY(1,1),
    nombrePresentacion VARCHAR(64) NOT NULL
);
GO

CREATE TABLE TipoEmpaque (
    idTipoEmpaque INT PRIMARY KEY IDENTITY(1,1),
    nombreEmpaque VARCHAR(64) NOT NULL,	
    material VARCHAR(64) NULL
);
GO

-- Tabla de productos
CREATE TABLE Productos (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(50) UNIQUE NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    precio DECIMAL(10, 2) NOT NULL,
	precioventa DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
    stock INT NOT NULL DEFAULT 0,
    stock_minimo INT NOT NULL DEFAULT 5,
    unidad_medida VARCHAR(20),
    imagen_url VARCHAR(255),
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


-- Tipo de promoción
	CREATE TABLE TipoPromocion (
		id_tipo_promocion INT PRIMARY KEY IDENTITY(1,1),
		nombre_tipo VARCHAR(50) NOT NULL
	);
	GO

	-- Promociones
	CREATE TABLE Promociones (
		IdPromocion INT PRIMARY KEY IDENTITY(1,1),
		NombrePromocion VARCHAR(128) NOT NULL,
		Descuento DECIMAL(5,2) NOT NULL,
		FechaInicio DATE NOT NULL,
		FechaFin DATE NOT NULL,
		Estado BIT DEFAULT 1,
		id_tipo_promocion INT NOT NULL,
		FOREIGN KEY (id_tipo_promocion) REFERENCES TipoPromocion(id_tipo_promocion)
	);
	GO



-- Relación producto-promoción
CREATE TABLE ProductoPromocion (
    id_producto INT,
    id_promocion INT,
    PRIMARY KEY (id_producto, id_promocion),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto),
    FOREIGN KEY (id_promocion) REFERENCES Promociones(IdPromocion)
);
GO



-- Comprobantes de pago
CREATE TABLE ComprobantesPago (
    id_comprobante INT IDENTITY(1,1) PRIMARY KEY,
    tipo VARCHAR(50) NOT NULL CHECK (tipo IN ('factura', 'boleta', 'nota_credito')),
    serie VARCHAR(20)unique ,-- agregar unique para evitar duplicados. 
    numero VARCHAR(20)unique,--agregar unique para evitar duplicados. 
    activo BIT DEFAULT 1
);
GO





-- Métodos de pago
CREATE TABLE MetodosPago (
    id_metodo_pago INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    activo BIT DEFAULT 1
);
GO

-- Pedidos de venta
CREATE TABLE PedidosVenta (
    id_pedido INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT REFERENCES Clientes(id_cliente),
    id_usuario INT NULL REFERENCES Usuarios(id_usuario),
    fecha DATETIME DEFAULT GETDATE(),
    id_comprobante INT REFERENCES ComprobantesPago(id_comprobante),
    total DECIMAL(12,2),
    total_descuento_productos DECIMAL(12,2),
    total_descuento_promociones DECIMAL(12,2),
	   total_con_descuento DECIMAL(12,2),
    estado VARCHAR(20) NOT NULL CHECK (estado IN ('pendiente', 'procesado', 'anulado'))
);
GO

-- Detalles de la venta
CREATE TABLE DetallesVenta (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_pedido INT,
    id_producto INT,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal DECIMAL(10, 2),
    descuento DECIMAL(5,2) DEFAULT 0,
    total_con_descuento DECIMAL(10,2),
    FOREIGN KEY (id_pedido) REFERENCES PedidosVenta(id_pedido),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);
GO


CREATE TABLE VentaPromocion (
    id_pedido INT,
    id_promocion INT,
    PRIMARY KEY (id_pedido, id_promocion),
    FOREIGN KEY (id_pedido) REFERENCES PedidosVenta(id_pedido),
    FOREIGN KEY (id_promocion) REFERENCES Promociones(IdPromocion)
);
GO

-- Pagos de venta
CREATE TABLE PagosVenta (
    id_pago INT IDENTITY(1,1) PRIMARY KEY,
    id_pedido INT REFERENCES PedidosVenta(id_pedido),
    id_metodo_pago INT REFERENCES MetodosPago(id_metodo_pago),
    monto DECIMAL(12, 2) NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    estado VARCHAR(20) CHECK (estado IN ('completado', 'anulado', 'pendiente'))
);
GO

-- Ordenes de compra
CREATE TABLE OrdenesCompra (
    id_orden_compra INT IDENTITY(1,1) PRIMARY KEY,
    id_proveedor INT NULL REFERENCES  Proveedores(id_proveedor),
    id_usuario INT REFERENCES Usuarios(id_usuario),
    fecha DATETIME DEFAULT GETDATE(),
    estado VARCHAR(20) NOT NULL CHECK (estado IN ('pendiente', 'recibido', 'cancelado')),
    total DECIMAL(12, 2) NOT NULL,
	tipo_orden VARCHAR(20) NOT NULL CHECK (tipo_orden IN ('directa', 'licitacion')) DEFAULT 'directa'
);

GO

-- Detalles de orden de compra
CREATE TABLE DetallesOrdenCompra (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_orden_compra INT,
    id_producto INT,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal AS (cantidad * precio_unitario),
    FOREIGN KEY (id_orden_compra) REFERENCES OrdenesCompra(id_orden_compra),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);
GO





CREATE TABLE PagosOrdenCompra (
    id_pago INT IDENTITY(1,1) PRIMARY KEY,
    id_orden_compra INT REFERENCES OrdenesCompra(id_orden_compra),
    id_metodo_pago INT REFERENCES MetodosPago(id_metodo_pago),
    monto DECIMAL(12, 2) NOT NULL,
    fecha_pago DATETIME DEFAULT GETDATE(),
    estado VARCHAR(20) CHECK (estado IN ('pendiente', 'completado', 'anulado')),
    observaciones VARCHAR(255)
);
go


ALTER TABLE PagosOrdenCompra
ADD id_comprobante INT;
ALTER TABLE PagosOrdenCompra
ADD CONSTRAINT FK_PagosOrdenCompra_Comprobantes
FOREIGN KEY (id_comprobante) REFERENCES ComprobantesPago(id_comprobante);



CREATE TABLE OfertasProveedor (
    id_oferta INT IDENTITY(1,1) PRIMARY KEY,
    id_orden_compra INT REFERENCES OrdenesCompra(id_orden_compra),
    id_proveedor INT REFERENCES Proveedores(id_proveedor),
    precio_ofertado DECIMAL(12,2) NOT NULL,
    fecha_oferta DATETIME DEFAULT GETDATE(),
    observaciones VARCHAR(255)
);
go

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


