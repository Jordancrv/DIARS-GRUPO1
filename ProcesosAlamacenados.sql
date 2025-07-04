
use DiarsAlfa; 
-----------------------------------------Para que el sistema elijga automaticamente el 
----------------------menor precio ------------------------

CREATE or alter PROCEDURE AdjudicarLicitacion (
    @id_orden_compra INT
)
AS
BEGIN
    DECLARE @id_proveedor INT;
    DECLARE @precio_ofertado DECIMAL(12,2);

    SELECT TOP 1 
        @id_proveedor = id_proveedor,
        @precio_ofertado = precio_ofertado
    FROM OfertasProveedor
    WHERE id_orden_compra = @id_orden_compra
    ORDER BY precio_ofertado ASC;

    UPDATE OrdenesCompra
    SET id_proveedor = @id_proveedor,
        total = @precio_ofertado,
        estado = 'pendiente'
    WHERE id_orden_compra = @id_orden_compra;
END;


GO



-----------------------------------------Para que el sistema elijga automaticamente el 
----------------------menor precio ------------------------

CREATE or alter  PROCEDURE AdjudicarLicitacion (
    @id_orden_compra INT
)
AS
BEGIN
    DECLARE @id_proveedor INT;
    DECLARE @precio_ofertado DECIMAL(12,2);

    SELECT TOP 1 
        @id_proveedor = id_proveedor,
        @precio_ofertado = precio_ofertado
    FROM OfertasProveedor
    WHERE id_orden_compra = @id_orden_compra
    ORDER BY precio_ofertado ASC;

    UPDATE OrdenesCompra
    SET id_proveedor = @id_proveedor,
        total = @precio_ofertado,
        estado = 'pendiente'
    WHERE id_orden_compra = @id_orden_compra;
END;
GO

-----------PROCEDIMIENTOS ALMACENADOS---------------------------
-------------------------------------------------------------
-------------PROCESO PARA USUARIO-----------------------
-- Insertar usuario con correo
CREATE OR ALTER PROCEDURE sp_InsertarUsuario
 
    @email VARCHAR(100),
    @password_hash VARCHAR(255),
    @rol VARCHAR(50),
    @activo BIT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Usuarios ( password_hash, rol, fecha_creacion, activo)
        VALUES ( @password_hash, @rol, GETDATE(), @activo);

        DECLARE @id_usuario INT = SCOPE_IDENTITY();

        INSERT INTO UsuarioCorreos (id_usuario, email)
        VALUES (@id_usuario, @email);

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

-- Listar usuarios
CREATE or alter PROCEDURE sp_ListarUsuarios
AS
BEGIN
    SELECT 
        u.id_usuario,
        uc.email,
        u.rol,
        u.fecha_creacion,
        u.activo
    FROM Usuarios u
    LEFT JOIN UsuarioCorreos uc ON u.id_usuario = uc.id_usuario;
END
GO

-- Buscar usuario por ID
CREATE OR ALTER  PROCEDURE sp_BuscarUsuarioPorId
    @id_usuario INT
AS
BEGIN
    SELECT 
        u.id_usuario,
        uc.email,
        u.rol,
        u.fecha_creacion,
        u.activo
    FROM Usuarios u
    LEFT JOIN UsuarioCorreos uc ON u.id_usuario = uc.id_usuario
    WHERE u.id_usuario = @id_usuario;
END
GO

-- Editar usuario
CREATE OR ALTER  PROCEDURE sp_EditarUsuario
    @id_usuario INT,
    @nombres VARCHAR(100),
    @apellidos VARCHAR(100),
    @email VARCHAR(100),
    @password_hash VARCHAR(255),
    @rol VARCHAR(50),
    @activo BIT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Usuarios
        SET 
          password_hash = @password_hash,
            rol = @rol,
            activo = @activo
        WHERE id_usuario = @id_usuario;

        UPDATE UsuarioCorreos
        SET email = @email
        WHERE id_usuario = @id_usuario;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

-- Borrado lógico de usuario
CREATE OR ALTER PROCEDURE sp_EliminarUsuario
    @id_usuario INT
AS
BEGIN
    UPDATE Usuarios
    SET activo = 0
    WHERE id_usuario = @id_usuario;
END
GO


------------------------PROCESO PARA CLIENTE........................
CREATE or alter PROCEDURE sp_ListarClienteCompleto
AS
BEGIN
    SELECT 
        c.id_cliente,
        c.id_tipo_cliente,
        c.nombres,
        c.apellidos,
        c.dni,
        c.razon_social,
        c.ruc,
        c.direccion,
        c.id_usuario,
        c.activo,
        t.telefono,
        co.email
    FROM Clientes c
    LEFT JOIN ClienteTelefonos t ON c.id_cliente = t.id_cliente
    LEFT JOIN ClienteCorreos co ON c.id_cliente = co.id_cliente
    ORDER BY c.id_cliente;
END
GO
-- Insertar cliente con email y teléfono
--CREATE OR ALTER PROCEDURE sp_InsertarCliente
--    @id_tipo_cliente INT,
--    @nombres VARCHAR(100),
--    @apellidos VARCHAR(100),
--    @dni VARCHAR(16),
--    @razon_social VARCHAR(100),
--    @ruc VARCHAR(11),
--    @direccion TEXT,
--	@idUsuario int,
--    @email VARCHAR(100),
--    @telefono VARCHAR(20),
--    @activo BIT
--AS
--BEGIN
--    SET NOCOUNT ON;
--    BEGIN TRY
--        BEGIN TRANSACTION;

--        INSERT INTO Clientes (id_tipo_cliente, nombres, apellidos, dni, razon_social, ruc, direccion,id_usuario , activo)
--        VALUES (@id_tipo_cliente, @nombres, @apellidos, @dni, @razon_social, @ruc, @direccion,@idUsuario, @activo);

--        DECLARE @id_cliente INT = SCOPE_IDENTITY();

--        INSERT INTO ClienteCorreos (id_cliente, email)
--        VALUES (@id_cliente, @email);

--        INSERT INTO ClienteTelefonos (id_cliente, telefono)
--        VALUES (@id_cliente, @telefono);

--        COMMIT;
--    END TRY
--    BEGIN CATCH
--        ROLLBACK;
--        THROW;
--    END CATCH
--END
--GO

-- Listar clientes
CREATE OR ALTER PROCEDURE sp_InsertarCliente
    @id_tipo_cliente INT,
    @nombres NVARCHAR(100),
    @apellidos NVARCHAR(100),
    @dni CHAR(8),
    @razon_social NVARCHAR(150),
    @ruc CHAR(11),
    @direccion NVARCHAR(200),
	@idUsuario int, 
    @activo BIT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Clientes (id_tipo_cliente, nombres, apellidos, dni, razon_social, ruc, direccion,id_usuario, activo)
    VALUES (@id_tipo_cliente, @nombres, @apellidos, @dni, @razon_social, @ruc, @direccion,@idUsuario,  @activo);

    SELECT SCOPE_IDENTITY() AS id_generado;
END;
GO


CREATE OR ALTER PROCEDURE sp_InsertarClienteCorreo
    @id_cliente INT,
    @correo NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ClienteCorreos (id_cliente, email)
    VALUES (@id_cliente, @correo);
END;
GO




--select  * from ClienteTelefonos
CREATE OR ALTER PROCEDURE sp_InsertarClienteTelefono
    @id_cliente INT,
    @telefono NVARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ClienteTelefonos(id_cliente, telefono)
    VALUES (@id_cliente, @telefono);
END;
GO



--CREATE OR ALTER PROCEDURE sp_InsertarClienteV2
--    @id_tipo_cliente INT,
--    @nombres VARCHAR(100),
--    @apellidos VARCHAR(100),
--    @dni VARCHAR(16),
--    @razon_social VARCHAR(100),
--    @ruc VARCHAR(11),
--    @direccion TEXT,
--    @email VARCHAR(100),
--    @telefono VARCHAR(20),
--    @activo BIT
--AS
--BEGIN
--    SET NOCOUNT ON;
--    BEGIN TRY
--        BEGIN TRANSACTION;

--        -- Insertar cliente
--        INSERT INTO Clientes (id_tipo_cliente, nombres, apellidos, dni, razon_social, ruc, direccion, activo)
--        VALUES (@id_tipo_cliente, @nombres, @apellidos, @dni, @razon_social, @ruc, @direccion, @activo);

--        DECLARE @id_cliente INT = SCOPE_IDENTITY();

--        -- Validar límite de correos
--        IF (SELECT COUNT(*) FROM ClienteCorreos WHERE id_cliente = @id_cliente) < 2
--        BEGIN
--            INSERT INTO ClienteCorreos (id_cliente, email)
--            VALUES (@id_cliente, @email);
--        END
--        ELSE
--        BEGIN
--            RAISERROR('El cliente ya tiene el máximo de correos permitidos (2).', 16, 1);
--        END

--        -- Validar límite de teléfonos
--        IF (SELECT COUNT(*) FROM ClienteTelefonos WHERE id_cliente = @id_cliente) < 2
--        BEGIN
--            INSERT INTO ClienteTelefonos (id_cliente, telefono)
--            VALUES (@id_cliente, @telefono);
--        END
--        ELSE
--        BEGIN
--            RAISERROR('El cliente ya tiene el máximo de teléfonos permitidos (2).', 16, 1);
--        END

--        COMMIT;
--    END TRY
--    BEGIN CATCH
--        ROLLBACK;
--        THROW;
--    END CATCH
--END
--GO

-- Buscar cliente por ID
CREATE OR ALTER PROCEDURE sp_BuscarCliente
    @id_cliente INT
AS
BEGIN
    SELECT 
        c.id_cliente,
        c.id_tipo_cliente,
        c.nombres,
        c.apellidos,
        c.dni,
        c.razon_social,
        c.ruc,
        c.direccion,
		c.id_usuario, 
        (SELECT TOP 1 email FROM ClienteCorreos WHERE id_cliente = c.id_cliente) AS email,
        (SELECT TOP 1 telefono FROM ClienteTelefonos WHERE id_cliente = c.id_cliente) AS telefono,
        c.activo
    FROM Clientes c
    WHERE c.id_cliente = @id_cliente;
END
GO

-- Editar cliente
CREATE OR ALTER PROCEDURE sp_EditarCliente
    @id_cliente INT,
    @id_tipo_cliente INT,
    @nombres VARCHAR(100),
    @apellidos VARCHAR(100),
    @dni VARCHAR(16),
    @razon_social VARCHAR(100),
    @ruc VARCHAR(11),
    @direccion TEXT,
    @email VARCHAR(100),
    @telefono VARCHAR(20),
    @activo BIT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Clientes
        SET 
            id_tipo_cliente = @id_tipo_cliente,
            nombres = @nombres,
            apellidos = @apellidos,
            dni = @dni,
            razon_social = @razon_social,
            ruc = @ruc,
            direccion = @direccion,
            activo = @activo
        WHERE id_cliente = @id_cliente;

        UPDATE ClienteCorreos
        SET email = @email
        WHERE id_cliente = @id_cliente;

        UPDATE ClienteTelefonos
        SET telefono = @telefono
        WHERE id_cliente = @id_cliente;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

-- Borrado lógico de cliente
CREATE OR ALTER PROCEDURE sp_EliminarCliente
    @id_cliente INT
AS
BEGIN
    UPDATE Clientes
    SET activo = 0
    WHERE id_cliente = @id_cliente;
END
GO

-------------------------------------------------------------------------------------------
----------------------------------PROVEEDORES---------------
-- Insertar proveedor
CREATE OR ALTER PROCEDURE sp_InsertarProveedor
    @razon_social VARCHAR(100),
    @ruc VARCHAR(11),
    @direccion TEXT,
    @contacto VARCHAR(100),
    @email VARCHAR(100),
    @telefono VARCHAR(20),
    @activo BIT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Proveedores (razon_social, ruc, direccion, contacto, activo)
        VALUES (@razon_social, @ruc, @direccion, @contacto, @activo);

        DECLARE @id_proveedor INT = SCOPE_IDENTITY();

        INSERT INTO ProveedorCorreos (id_proveedor, email)
        VALUES (@id_proveedor, @email);

        INSERT INTO ProveedorTelefonos (id_proveedor, telefono)
        VALUES (@id_proveedor, @telefono);

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE sp_ListarProveedoresCompleto
AS
BEGIN
    SELECT 
        p.id_proveedor,
        p.razon_social,
        p.ruc,
        p.direccion,
        p.contacto,
        p.activo,
        t.telefono,
        c.email
    FROM Proveedores p
    LEFT JOIN ProveedorTelefonos t ON p.id_proveedor = t.id_proveedor
    LEFT JOIN ProveedorCorreos c ON p.id_proveedor = c.id_proveedor
END;
GO



-- Buscar proveedor por ID
CREATE OR ALTER PROCEDURE sp_BuscarProveedor
    @id_proveedor INT
AS
BEGIN
    SELECT 
        p.id_proveedor,
        p.razon_social,
        p.ruc,
        p.direccion,
        p.contacto,
        p.activo,
        (
            SELECT STRING_AGG(t.telefono, ',') 
            FROM ProveedorTelefonos t 
            WHERE t.id_proveedor = p.id_proveedor
        ) AS telefonos,
        (
            SELECT STRING_AGG(c.email, ',') 
            FROM ProveedorCorreos c 
            WHERE c.id_proveedor = p.id_proveedor
        ) AS correos
    FROM Proveedores p
    WHERE p.id_proveedor = @id_proveedor;
END
GO


--CREATE OR ALTER PROCEDURE sp_BuscarProveedor
--    @id_proveedor INT
--AS
--BEGIN
--    SELECT 
--        id_proveedor,
--        razon_social,
--        ruc,
--        direccion,
--        contacto,
--        activo
--    FROM Proveedores
--    WHERE id_proveedor = @id_proveedor;
--END
--GO

--CREATE OR ALTER PROCEDURE sp_ListarCorreosProveedor
--    @id_proveedor INT
--AS
--BEGIN
--    SELECT email
--    FROM ProveedorCorreos
--    WHERE id_proveedor = @id_proveedor;
--END
--GO

--CREATE OR ALTER PROCEDURE sp_ListarCorreosProveedor
--    @id_proveedor INT
--AS
--BEGIN
--    SELECT email
--    FROM ProveedorCorreos
--    WHERE id_proveedor = @id_proveedor;
--END
--GO



-- Tipo para correos
CREATE TYPE CorreoTableType AS TABLE (
    email VARCHAR(100)
);
GO

-- Tipo para teléfonos
CREATE TYPE TelefonoTableType AS TABLE (
    telefono VARCHAR(20)
);
GO



-- Editar proveedor
CREATE OR ALTER PROCEDURE sp_EditarProveedor
    @id_proveedor INT,
    @razon_social VARCHAR(100),
    @ruc VARCHAR(11),
    @direccion TEXT,
    @contacto VARCHAR(100),
    @Correos CorreoTableType READONLY,
    @Telefonos TelefonoTableType READONLY,
    @activo BIT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Actualizar datos principales
        UPDATE Proveedores
        SET razon_social = @razon_social,
            ruc = @ruc,
            direccion = @direccion,
            contacto = @contacto,
            activo = @activo
        WHERE id_proveedor = @id_proveedor;

        -- Reemplazar correos
        DELETE FROM ProveedorCorreos WHERE id_proveedor = @id_proveedor;
        INSERT INTO ProveedorCorreos (id_proveedor, email)
        SELECT @id_proveedor, email FROM @Correos;

        -- Reemplazar teléfonos
        DELETE FROM ProveedorTelefonos WHERE id_proveedor = @id_proveedor;
        INSERT INTO ProveedorTelefonos (id_proveedor, telefono)
        SELECT @id_proveedor, telefono FROM @Telefonos;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO


-- Borrado lógico de proveedor
CREATE OR ALTER PROCEDURE sp_EliminarProveedor
    @id_proveedor INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Proveedores
    SET activo = 0
    WHERE id_proveedor = @id_proveedor;
END;
GO
------------------------PROCESOS PARA PRODUCTOS----------------------
-- Insertar producto
CREATE OR ALTER PROCEDURE sp_InsertarProducto
    @codigo VARCHAR(50),
    @nombre VARCHAR(100),
    @descripcion TEXT,
    @precio DECIMAL(10,2),
    @stock INT,
    @stock_minimo INT,
    @unidad_medida VARCHAR(20),
    @id_proveedor INT,
    @idCategoria INT,
    @idPresentacion INT,
    @idTipoEmpaque INT,
    @activo BIT
AS
BEGIN
    INSERT INTO Productos (
        codigo, nombre, descripcion, precio, stock, stock_minimo, 
        unidad_medida, id_proveedor, idCategoria, idPresentacion, idTipoEmpaque, activo
    )
    VALUES (
        @codigo, @nombre, @descripcion, @precio, @stock, @stock_minimo, 
        @unidad_medida, @id_proveedor, @idCategoria, @idPresentacion, @idTipoEmpaque, @activo
    );
END
GO

-- Listar productos
---
CREATE OR ALTER PROCEDURE sp_ListarProductos
AS
BEGIN
    SELECT
        p.id_producto,
        p.codigo,
        p.nombre,
        p.descripcion,
        p.precio,
        p.stock,
        p.stock_minimo,
        p.unidad_medida,
        p.id_proveedor, -- Add this
        pr.razon_social AS proveedor,
        p.idCategoria, -- Add this
        c.nombreCategoria,
        p.idPresentacion, -- Add this
        pre.nombrePresentacion,
        p.idTipoEmpaque, -- Add this
        te.nombreEmpaque,
        te.material,
        p.activo
    FROM Productos p
    LEFT JOIN Proveedores pr ON p.id_proveedor = pr.id_proveedor
    LEFT JOIN CategoriaProductos c ON p.idCategoria = c.idCategoria
    LEFT JOIN Presentacion pre ON p.idPresentacion = pre.idPresentacion
    LEFT JOIN TipoEmpaque te ON p.idTipoEmpaque = te.idTipoEmpaque;
END
GO



-- Buscar producto por ID
CREATE OR ALTER PROCEDURE sp_BuscarProducto
    @id_producto INT
AS
BEGIN
    SELECT 
        p.*, 
        pr.razon_social AS proveedor,
        c.nombreCategoria,
        pre.nombrePresentacion,
        te.nombreEmpaque
    FROM Productos p
    LEFT JOIN Proveedores pr ON p.id_proveedor = pr.id_proveedor
    LEFT JOIN CategoriaProductos c ON p.idCategoria = c.idCategoria
    LEFT JOIN Presentacion pre ON p.idPresentacion = pre.idPresentacion
    LEFT JOIN TipoEmpaque te ON p.idTipoEmpaque = te.idTipoEmpaque
    WHERE p.id_producto = @id_producto;
END
GO

-- Editar producto
CREATE OR ALTER PROCEDURE sp_EditarProducto
    @id_producto INT,
    @codigo VARCHAR(50),
    @nombre VARCHAR(100),
    @descripcion TEXT,
    @precio DECIMAL(10,2),
    @stock INT,
    @stock_minimo INT,
    @unidad_medida VARCHAR(20),
    @id_proveedor INT,
    @idCategoria INT,
    @idPresentacion INT,
    @idTipoEmpaque INT,
    @activo BIT
AS
BEGIN
    UPDATE Productos
    SET codigo = @codigo,
        nombre = @nombre,
        descripcion = @descripcion,
        precio = @precio,
        stock = @stock,
        stock_minimo = @stock_minimo,
        unidad_medida = @unidad_medida,
        id_proveedor = @id_proveedor,
        idCategoria = @idCategoria,
        idPresentacion = @idPresentacion,
        idTipoEmpaque = @idTipoEmpaque,
        activo = @activo
    WHERE id_producto = @id_producto;
END
GO

-- Borrado lógico de producto
CREATE OR ALTER PROCEDURE sp_EliminarProducto
    @id_producto INT
AS
BEGIN
    UPDATE Productos
    SET activo = 0
    WHERE id_producto = @id_producto;
END
GO

---------------------------------------PROMOCION---------


CREATE OR ALTER PROCEDURE sp_InsertarTipoPromocion
    @nombre_tipo VARCHAR(50)
AS
BEGIN
    INSERT INTO TipoPromocion (nombre_tipo)
    VALUES (@nombre_tipo);
END;
GO

CREATE OR ALTER PROCEDURE sp_InsertarPromocion
    @NombrePromocion VARCHAR(128),
    @Descuento DECIMAL(5,2),
    @FechaInicio DATE,
    @FechaFin DATE,
    @id_tipo_promocion INT
AS
BEGIN
    INSERT INTO Promociones (
        NombrePromocion,
        Descuento,
        FechaInicio,
        FechaFin,
        Estado,
        id_tipo_promocion
    )
    VALUES (
        @NombrePromocion,
        @Descuento,
        @FechaInicio,
        @FechaFin,
        1, -- Estado activo por defecto
        @id_tipo_promocion
    );
END;
GO


CREATE OR ALTER PROCEDURE sp_ListarPromociones
AS
BEGIN
    SELECT 
        p.IdPromocion,
        p.NombrePromocion,
        p.Descuento,
        p.FechaInicio,
        p.FechaFin,
        p.Estado,
        p.id_tipo_promocion,
        tp.nombre_tipo AS TipoPromocion
    FROM Promociones p
    INNER JOIN TipoPromocion tp ON p.id_tipo_promocion = tp.id_tipo_promocion;
END;
GO


CREATE OR ALTER PROCEDURE sp_BuscarPromocionPorId
    @id_promocion INT
AS
BEGIN
    -- Datos de la promoción
    SELECT 
        p.IdPromocion,
        p.NombrePromocion,
        p.Descuento,
        p.FechaInicio,
        p.FechaFin,
        tp.nombre_tipo AS TipoPromocion,
        p.Estado
    FROM Promociones p
    INNER JOIN TipoPromocion tp ON p.id_tipo_promocion = tp.id_tipo_promocion
    WHERE p.IdPromocion = @id_promocion;

    -- Productos asociados
    SELECT 
        pr.id_producto,
        pr.codigo,
        pr.nombre,
        pr.precio
    FROM ProductoPromocion pp
    INNER JOIN Productos pr ON pp.id_producto = pr.id_producto
    WHERE pp.id_promocion = @id_promocion;
END;
GO


CREATE OR ALTER PROCEDURE sp_EditarPromocion
    @id_promocion INT,
    @NombrePromocion VARCHAR(128),
    @Descuento DECIMAL(5,2),
    @FechaInicio DATE,
    @FechaFin DATE,
    @id_tipo_promocion INT,
    @Estado BIT
AS
BEGIN
    UPDATE Promociones
    SET 
        NombrePromocion = @NombrePromocion,
        Descuento = @Descuento,
        FechaInicio = @FechaInicio,
        FechaFin = @FechaFin,
        id_tipo_promocion = @id_tipo_promocion,
        Estado = @Estado
    WHERE IdPromocion = @id_promocion;
END;
GO


CREATE OR ALTER PROCEDURE sp_EliminarPromocion
    @id_promocion INT
AS
BEGIN
    UPDATE Promociones
    SET Estado = 0
    WHERE IdPromocion = @id_promocion;
END;
GO


---------------------------PROC. TIPO PROMOCION........OPCIONAL .....


CREATE OR ALTER PROCEDURE sp_InsertarTipoPromocion
    @nombre_tipo VARCHAR(50)
AS
BEGIN
    INSERT INTO TipoPromocion (nombre_tipo)
    VALUES (@nombre_tipo);
END;
GO

CREATE OR ALTER PROCEDURE sp_ListarTipoPromocion
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id_tipo_promocion, nombre_tipo
    FROM TipoPromocion
    
END;
GO


CREATE OR ALTER PROCEDURE sp_EditarTipoPromocion
    @id_tipo_promocion INT,
    @nombre_tipo VARCHAR(50)
AS
BEGIN
    UPDATE TipoPromocion
    SET nombre_tipo = @nombre_tipo
    WHERE id_tipo_promocion = @id_tipo_promocion;
END;
GO

CREATE OR ALTER PROCEDURE sp_EliminarTipoPromocion
    @id_tipo_promocion INT
AS
BEGIN
    DELETE FROM TipoPromocion
    WHERE id_tipo_promocion = @id_tipo_promocion;
END;
GO




---------------------------PROC. PRODUCTO-PROMCIONES---------------
CREATE TYPE ProductosPromocionType AS TABLE (
    id_producto INT
);
GO

--CREATE OR ALTER PROCEDURE sp_InsertarPromocion
--    @NombrePromocion VARCHAR(128),
--    @Descuento DECIMAL(5,2),
--    @FechaInicio DATE,
--    @FechaFin DATE,
--    @Estado BIT,
--    @id_tipo_promocion INT,
--    @Productos ProductosPromocionType READONLY
--AS
--BEGIN
--    SET NOCOUNT ON;
--    BEGIN TRY
--        BEGIN TRANSACTION;

--        INSERT INTO Promociones (
--            NombrePromocion, Descuento, FechaInicio, FechaFin, Estado, id_tipo_promocion
--        )
--        VALUES (
--            @NombrePromocion, @Descuento, @FechaInicio, @FechaFin, @Estado, @id_tipo_promocion
--        );

--        DECLARE @id_promocion INT = SCOPE_IDENTITY();

--        INSERT INTO ProductoPromocion (id_producto, id_promocion)
--        SELECT id_producto, @id_promocion FROM @Productos;

--        COMMIT;
--    END TRY
--    BEGIN CATCH
--        ROLLBACK;
--        THROW;
--    END CATCH
--END;
--GO
CREATE OR ALTER PROCEDURE sp_InsertarPromocion
    @NombrePromocion VARCHAR(128),
    @Descuento DECIMAL(5,2),
    @FechaInicio DATE,
    @FechaFin DATE,
    @id_tipo_promocion INT,
    @Estado BIT
AS
BEGIN
    INSERT INTO Promociones (
        NombrePromocion,
        Descuento,
        FechaInicio,
        FechaFin,
        id_tipo_promocion,
        Estado
    )
    VALUES (
        @NombrePromocion,
        @Descuento,
        @FechaInicio,
        @FechaFin,
        @id_tipo_promocion,
        @Estado
    );
END;
GO



CREATE OR ALTER PROCEDURE sp_ListarPromociones
AS
BEGIN
    SELECT 
        p.IdPromocion,
        p.NombrePromocion,
        p.Descuento,
        p.FechaInicio,
        p.FechaFin,
        tp.nombre_tipo AS TipoPromocion,
        p.Estado
    FROM Promociones p
    INNER JOIN TipoPromocion tp ON p.id_tipo_promocion = tp.id_tipo_promocion
    ORDER BY p.FechaInicio DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_BuscarPromocionPorId
    @id_promocion INT
AS
BEGIN
    -- Datos de la promoción
    SELECT 
        p.IdPromocion,
        p.NombrePromocion,
        p.Descuento,
        p.FechaInicio,
        p.FechaFin,
        tp.nombre_tipo AS TipoPromocion,
        p.Estado
    FROM Promociones p
    INNER JOIN TipoPromocion tp ON p.id_tipo_promocion = tp.id_tipo_promocion
    WHERE p.IdPromocion = @id_promocion;

    -- Productos asociados
    SELECT 
        pr.id_producto,
        pr.codigo,
        pr.nombre,
        pr.precio
    FROM ProductoPromocion pp
    INNER JOIN Productos pr ON pp.id_producto = pr.id_producto
    WHERE pp.id_promocion = @id_promocion;
END;
GO


CREATE OR ALTER PROCEDURE sp_EditarPromocion
    @id_promocion INT,
    @NombrePromocion VARCHAR(128),
    @Descuento DECIMAL(5,2),
    @FechaInicio DATE,
    @FechaFin DATE,
    @Estado BIT,
    @id_tipo_promocion INT
AS
BEGIN
    UPDATE Promociones
    SET 
        NombrePromocion = @NombrePromocion,
        Descuento = @Descuento,
        FechaInicio = @FechaInicio,
        FechaFin = @FechaFin,
        Estado = @Estado,
        id_tipo_promocion = @id_tipo_promocion
    WHERE IdPromocion = @id_promocion;
END;
GO


CREATE OR ALTER PROCEDURE sp_ActualizarProductosDePromocion
    @id_promocion INT,
    @Productos ProductosPromocionType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM ProductoPromocion WHERE id_promocion = @id_promocion;

        INSERT INTO ProductoPromocion (id_producto, id_promocion)
        SELECT id_producto, @id_promocion FROM @Productos;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END;
GO




CREATE OR ALTER PROCEDURE sp_EliminarPromocion
    @id_promocion INT
AS
BEGIN
    UPDATE Promociones
    SET Estado = 0
    WHERE IdPromocion = @id_promocion;
END;
GO




-----------PROC.  PEDIDO-VENTA----------------


CREATE TYPE DetalleVentaType AS TABLE (
    id_producto INT,
    cantidad INT,
    precio_unitario DECIMAL(10,2),
    subtotal DECIMAL(10,2),
    descuento DECIMAL(5,2),
    total_con_descuento DECIMAL(10,2)
);
go
-- Para promociones aplicadas en una venta
--CREATE TYPE VentaPromocionType AS TABLE (
--    id_promocion INT
--);
--GO
CREATE or alter PROCEDURE InsertarPedidoVenta
    @id_cliente INT,
    @id_usuario INT = NULL,
    @id_comprobante INT,
    @total DECIMAL(12,2),
    @total_descuento_productos DECIMAL(12,2),
    @total_descuento_promociones DECIMAL(12,2),
    @total_con_descuento DECIMAL(12,2),
    @estado VARCHAR(20),
    @Detalles DetalleVentaType READONLY -- Este es un tipo de tabla (debes crearlo si no lo tienes aún)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        -- Insertar en PedidosVenta
        INSERT INTO PedidosVenta (
            id_cliente, id_usuario, id_comprobante, total,
            total_descuento_productos, total_descuento_promociones,
            total_con_descuento, estado
        )
        VALUES (
            @id_cliente, @id_usuario, @id_comprobante,
            @total, @total_descuento_productos,
            @total_descuento_promociones, @total_con_descuento, @estado
        );

        DECLARE @id_pedido INT = SCOPE_IDENTITY();

        -- Insertar en DetallesVenta
        INSERT INTO DetallesVenta (
            id_pedido, id_producto, cantidad,
            precio_unitario, subtotal, descuento, total_con_descuento
        )
        SELECT
            @id_pedido, id_producto, cantidad,
            precio_unitario, subtotal, descuento, total_con_descuento
        FROM @Detalles;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;

        THROW;
    END CATCH
END
GO


--CREATE OR ALTER PROCEDURE sp_RegistrarPedidoVenta
--    @id_cliente INT,
--    @id_usuario INT,
--    @id_comprobante INT,
--    @estado VARCHAR(20),
--    @Detalles DetalleVentaType READONLY,
--    @Promociones VentaPromocionType READONLY,
--    @PedidoId INT OUTPUT,
--    @Resultado BIT OUTPUT
--AS
--BEGIN
--    SET NOCOUNT ON;
--    BEGIN TRY
--        BEGIN TRANSACTION;

--        DECLARE @total DECIMAL(12,2) = 0;
--        DECLARE @total_descuento_producto DECIMAL(12,2) = 0;
--        DECLARE @total_descuento_promocion DECIMAL(12,2) = 0;

--        -- Calcular totales
--        SELECT 
--            @total = SUM(cantidad * precio_unitario),
--            @total_descuento_producto = SUM(cantidad * precio_unitario * (descuento / 100.0))
--        FROM @Detalles;

--        -- Suponiendo un 10% de descuento total por promociones aplicadas
--        SELECT @total_descuento_promocion = @total * 0.10
--        WHERE EXISTS (SELECT 1 FROM @Promociones); -- Solo si hay promociones

--        DECLARE @total_con_descuento DECIMAL(12,2) = @total - @total_descuento_producto - @total_descuento_promocion;

--        -- Insertar cabecera
--        INSERT INTO PedidosVenta (
--            id_cliente, id_usuario, fecha, id_comprobante,
--            total, total_descuento_productos, total_descuento_promociones, total_con_descuento, estado
--        )
--        VALUES (
--            @id_cliente, @id_usuario, GETDATE(), @id_comprobante,
--            @total, @total_descuento_producto, @total_descuento_promocion, @total_con_descuento, @estado
--        );

--        SET @PedidoId = SCOPE_IDENTITY();

--        -- Insertar detalles
--        INSERT INTO DetallesVenta (id_pedido, id_producto, cantidad, precio_unitario, descuento)
--        SELECT 
--            @PedidoId, id_producto, cantidad, precio_unitario, descuento
--        FROM @Detalles;

--        -- Insertar promociones aplicadas
--        INSERT INTO VentaPromocion (id_pedido, id_promocion)
--        SELECT @PedidoId, id_promocion FROM @Promociones;

--        SET @Resultado = 1;
--        COMMIT;
--    END TRY
--    BEGIN CATCH
--        ROLLBACK;
--        SET @Resultado = 0;
--        SET @PedidoId = 0;
--    END CATCH
--END;
--GO

CREATE or alter PROCEDURE sp_ObtenerDescuentoPromocion
    @idProducto INT,
    @descuento DECIMAL(5,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 @descuento = descuento
    FROM PromocionesProducto
    WHERE id_producto = @idProducto
      AND GETDATE() BETWEEN fecha_inicio AND fecha_fin
    ORDER BY fecha_inicio DESC;
END;
GO

CREATE OR ALTER PROCEDURE sp_ListarPedidosVenta
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        pv.id_pedido,
        pv.fecha,
        pv.estado,
        c.razon_social AS cliente,
        (u.nombres + ' ' + u.apellidos) AS usuario,
        pv.total,
        pv.total_descuento_productos,
        pv.total_descuento_promociones,
        pv.total_con_descuento
    FROM PedidosVenta pv
    INNER JOIN Clientes c ON pv.id_cliente = c.id_cliente
    INNER JOIN Usuarios u ON pv.id_usuario = u.id_usuario
    ORDER BY pv.fecha DESC;
END;
GO




CREATE OR ALTER PROCEDURE sp_BuscarPedidoVenta
    @id_pedido INT
AS
BEGIN
    -- Cabecera
    SELECT 
        pv.id_pedido, pv.fecha, pv.estado,
        c.razon_social AS cliente,
        u.nombres + ' ' + u.apellidos AS usuario,
        pv.total, pv.total_descuento_productos, pv.total_descuento_promociones, pv.total_con_descuento
    FROM PedidosVenta pv
    INNER JOIN Clientes c ON pv.id_cliente = c.id_cliente
    INNER JOIN Usuarios u ON pv.id_usuario = u.id_usuario
    WHERE pv.id_pedido = @id_pedido;

    -- Detalles
    SELECT 
        dv.id_detalle, p.nombre AS producto,
        dv.cantidad, dv.precio_unitario,
        dv.descuento,
        dv.subtotal,
        dv.total_con_descuento
    FROM DetallesVenta dv
    INNER JOIN Productos p ON dv.id_producto = p.id_producto
    WHERE dv.id_pedido = @id_pedido;

    -- Promociones
    SELECT 
        pr.IdPromocion, pr.NombrePromocion, pr.Descuento, pr.FechaInicio, pr.FechaFin
    FROM VentaPromocion vp
    INNER JOIN Promociones pr ON vp.id_promocion = pr.IdPromocion
    WHERE vp.id_pedido = @id_pedido;
END;
GO




CREATE OR ALTER PROCEDURE sp_AnularPedidoVenta
    @id_pedido INT
AS
BEGIN
    UPDATE PedidosVenta
    SET estado = 'anulado'
    WHERE id_pedido = @id_pedido;
END;
GO



CREATE OR ALTER PROCEDURE sp_ListarPedidosPorCliente
    @id_cliente INT
AS
BEGIN
    SELECT 
        id_pedido,
        fecha,
        estado,
        total_con_descuento
    FROM PedidosVenta
    WHERE id_cliente = @id_cliente
    ORDER BY fecha DESC;
END;
GO



-----------------PROC. ORDENES-COMPRA: 
-- Tipo de tabla para detalles de orden de compra



CREATE OR ALTER PROCEDURE sp_InsertarPagoVenta
    @id_pedido INT,
    @id_metodo_pago INT,
    @monto DECIMAL(12,2),
    @estado VARCHAR(20)
AS
BEGIN
    INSERT INTO PagosVenta (id_pedido, id_metodo_pago, monto, fecha, estado)
    VALUES (@id_pedido, @id_metodo_pago, @monto, GETDATE(), @estado);
END;
GO


CREATE OR ALTER PROCEDURE sp_ListarPagosVenta
AS
BEGIN
    SELECT 
        pv.id_pago,
        pv.fecha,
        pv.monto,
        pv.estado,
        mp.nombre_metodo,
        c.razon_social AS cliente
    FROM PagosVenta pv
    INNER JOIN PedidosVenta p ON pv.id_pedido = p.id_pedido
    INNER JOIN Clientes c ON p.id_cliente = c.id_cliente
    INNER JOIN MetodosPago mp ON pv.id_metodo_pago = mp.id_metodo_pago;
END;
GO

CREATE OR ALTER PROCEDURE sp_BuscarPagoVenta
    @id_pago INT
AS
BEGIN
    SELECT * FROM PagosVenta WHERE id_pago = @id_pago;
END;
GO

CREATE OR ALTER PROCEDURE sp_AnularPagoVenta
    @id_pago INT
AS
BEGIN
    UPDATE PagosVenta SET estado = 'anulado' WHERE id_pago = @id_pago;
END;
GO


----ORDENES DE COMPRA---------
CREATE TYPE DetalleOrdenCompraType AS TABLE (
    id_producto INT,
    cantidad INT,
    precio_unitario DECIMAL(10,2)
);
GO


CREATE OR ALTER PROCEDURE sp_InsertarOrdenCompra
    @id_proveedor INT,
    @id_usuario INT,
    @estado VARCHAR(20),
    @Detalles DetalleOrdenCompraType READONLY,
    @OrdenCompraId INT OUTPUT,
    @Resultado BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @total DECIMAL(12,2);
        SELECT @total = SUM(cantidad * precio_unitario) FROM @Detalles;

        INSERT INTO OrdenesCompra (id_proveedor, id_usuario, fecha, estado, total)
        VALUES (@id_proveedor, @id_usuario, GETDATE(), @estado, @total);

        SET @OrdenCompraId = SCOPE_IDENTITY();

        INSERT INTO DetallesOrdenCompra (id_orden_compra, id_producto, cantidad, precio_unitario)
        SELECT @OrdenCompraId, id_producto, cantidad, precio_unitario
        FROM @Detalles;

        SET @Resultado = 1;
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @Resultado = 0;
        SET @OrdenCompraId = 0;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_ListarOrdenesCompra
AS
BEGIN
    SELECT 
        o.id_orden_compra,
        o.fecha,
        o.estado,
        o.total,
        p.razon_social AS proveedor,
        u.nombres + ' ' + u.apellidos AS usuario
    FROM OrdenesCompra o
    INNER JOIN Proveedores p ON o.id_proveedor = p.id_proveedor
    INNER JOIN Usuarios u ON o.id_usuario = u.id_usuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_BuscarOrdenCompra
    @id_orden_compra INT
AS
BEGIN
    -- Cabecera
    SELECT 
        o.id_orden_compra,
        o.fecha,
        o.estado,
        o.total,
        p.razon_social AS proveedor,
        u.nombres + ' ' + u.apellidos AS usuario
    FROM OrdenesCompra o
    INNER JOIN Proveedores p ON o.id_proveedor = p.id_proveedor
    INNER JOIN Usuarios u ON o.id_usuario = u.id_usuario
    WHERE o.id_orden_compra = @id_orden_compra;

    -- Detalles
    SELECT 
        d.id_detalle,
        pr.nombre AS producto,
        d.cantidad,
        d.precio_unitario,
        d.subtotal
    FROM DetallesOrdenCompra d
    INNER JOIN Productos pr ON d.id_producto = pr.id_producto
    WHERE d.id_orden_compra = @id_orden_compra;
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarEstadoOrdenCompra
    @id_orden_compra INT,
    @nuevo_estado VARCHAR(20)
AS
BEGIN
    UPDATE OrdenesCompra
    SET estado = @nuevo_estado
    WHERE id_orden_compra = @id_orden_compra;
END;
GO


