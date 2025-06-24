select * from Clientes
go
select * from Usuarios
go
select * from ComprobantesPago
go
select * from PedidosVenta
go
select * from DetallesVenta;
go
DELETE FROM PedidosVenta;
go
select * from Productos;
go
select count(*) as Numerototal from PedidosVenta
go
INSERT INTO ComprobantesPago (tipo, serie, numero, activo)
VALUES 
('factura', 'F001', '00000001', 1),
('boleta', 'B001', '00000001', 1),
('nota_credito', 'NC01', '00000001', 1),
('factura', 'F001', '00000002', 1),
('boleta', 'B001', '00000002', 1),
('nota_credito', 'NC01', '00000002', 0),
('factura', 'F002', '00000001', 1),
('boleta', 'B002', '00000001', 0),
('nota_credito', 'NC02', '00000001', 1),
('factura', 'F003', '00000001', 1);


INSERT INTO Usuarios (nombres, apellidos, password_hash, rol, fecha_creacion, activo)
VALUES 
('Carlos', 'Ramírez Soto', 'hash12345abc', 'admin', GETDATE(), 1),
('Lucía', 'Fernández López', 'hashabc67890', 'vendedor', GETDATE(), 1),
('Miguel', 'Torres Huamán', 'hashxyz11122', 'almacen', GETDATE(), 1),
('Ana', 'García Pérez', 'hashsecure333', 'compras', GETDATE(), 1),
('Javier', 'Castillo León', 'hashpass444', 'vendedor', GETDATE(), 0),
('Elena', 'Ruiz Díaz', 'hashkey555', 'almacen', GETDATE(), 1),
('Sofía', 'Mendoza Ríos', 'hashclave666', 'compras', GETDATE(), 1);



-- Insertar en Proveedores
INSERT INTO Proveedores (razon_social, ruc, direccion, contacto) VALUES
('Distribuidora Santa Anita S.A.C.', '20123456789', 'Av. Perú 456, Lima', 'Luis Quispe'),
('Alimentos del Sur EIRL', '20456789123', 'Jr. Arequipa 234, Arequipa', 'Carmen Huamán'),
('Comercial Andina SRL', '20543219876', 'Av. Cusco 789, Cusco', 'Jorge Cárdenas');
GO

-- Insertar en CategoriaProductos
INSERT INTO CategoriaProductos (nombreCategoria) VALUES
('Alimentos'),
('Bebidas'),
('Limpieza'),
('Lácteos'),
('Conservas');
GO

-- Insertar en Presentacion
INSERT INTO Presentacion (nombrePresentacion) VALUES
('Bolsa'),
('Botella'),
('Lata'),
('Caja');
GO

-- Insertar en TipoEmpaque
INSERT INTO TipoEmpaque (nombreEmpaque, material) VALUES
('Empaque plástico', 'Plástico'),
('Empaque metálico', 'Metal'),
('Empaque de cartón', 'Cartón');
GO

-- Insertar en Productos
INSERT INTO Productos (
    codigo, nombre, descripcion, precio, stock, stock_minimo, unidad_medida,
    id_proveedor, idCategoria, idPresentacion, idTipoEmpaque, activo
)
VALUES
('P001', 'Arroz Costeño 5kg', 'Arroz superior en presentación de 5kg', 24.90, 100, 10, 'kg', 1, 1, 1, 1, 1),
('P002', 'Aceite Primor 1L', 'Aceite vegetal ideal para freír', 10.50, 80, 10, 'L', 2, 1, 2, 1, 1),
('P003', 'Leche Gloria 400g', 'Leche evaporada entera en lata', 4.20, 150, 20, 'g', 1, 4, 3, 2, 1),
('P004', 'Fideos Don Vittorio 500g', 'Fideos spaghetti de trigo selecto', 3.50, 120, 10, 'g', 2, 1, 1, 1, 1),
('P005', 'Atún Florida 170g', 'Atún en aceite vegetal', 6.00, 60, 5, 'g', 3, 5, 3, 2, 1),
('P006', 'Azúcar Rubia 1kg', 'Azúcar rubia peruana de calidad', 3.80, 90, 10, 'kg', 1, 1, 1, 1, 1),
('P007', 'Panetón D’Onofrio 900g', 'Panetón tradicional con frutas y pasas', 18.00, 30, 5, 'g', 2, 1, 4, 3, 1),
('P008', 'Gaseosa Inca Kola 1.5L', 'Bebida gaseosa tradicional peruana', 6.50, 75, 10, 'L', 1, 2, 2, 1, 1),
('P009', 'Jabón Bolívar 200g', 'Jabón para lavado de ropa', 2.20, 110, 15, 'g', 3, 3, 1, 1, 1),
('P010', 'Cerveza Cusqueña 355ml', 'Cerveza premium rubia', 6.80, 50, 5, 'ml', 2, 2, 2, 1, 1);
GO