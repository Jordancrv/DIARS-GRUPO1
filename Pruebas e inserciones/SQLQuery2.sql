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
('Carlos', 'Ram�rez Soto', 'hash12345abc', 'admin', GETDATE(), 1),
('Luc�a', 'Fern�ndez L�pez', 'hashabc67890', 'vendedor', GETDATE(), 1),
('Miguel', 'Torres Huam�n', 'hashxyz11122', 'almacen', GETDATE(), 1),
('Ana', 'Garc�a P�rez', 'hashsecure333', 'compras', GETDATE(), 1),
('Javier', 'Castillo Le�n', 'hashpass444', 'vendedor', GETDATE(), 0),
('Elena', 'Ruiz D�az', 'hashkey555', 'almacen', GETDATE(), 1),
('Sof�a', 'Mendoza R�os', 'hashclave666', 'compras', GETDATE(), 1);



-- Insertar en Proveedores
INSERT INTO Proveedores (razon_social, ruc, direccion, contacto) VALUES
('Distribuidora Santa Anita S.A.C.', '20123456789', 'Av. Per� 456, Lima', 'Luis Quispe'),
('Alimentos del Sur EIRL', '20456789123', 'Jr. Arequipa 234, Arequipa', 'Carmen Huam�n'),
('Comercial Andina SRL', '20543219876', 'Av. Cusco 789, Cusco', 'Jorge C�rdenas');
GO

-- Insertar en CategoriaProductos
INSERT INTO CategoriaProductos (nombreCategoria) VALUES
('Alimentos'),
('Bebidas'),
('Limpieza'),
('L�cteos'),
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
('Empaque pl�stico', 'Pl�stico'),
('Empaque met�lico', 'Metal'),
('Empaque de cart�n', 'Cart�n');
GO

-- Insertar en Productos
INSERT INTO Productos (
    codigo, nombre, descripcion, precio, stock, stock_minimo, unidad_medida,
    id_proveedor, idCategoria, idPresentacion, idTipoEmpaque, activo
)
VALUES
('P001', 'Arroz Coste�o 5kg', 'Arroz superior en presentaci�n de 5kg', 24.90, 100, 10, 'kg', 1, 1, 1, 1, 1),
('P002', 'Aceite Primor 1L', 'Aceite vegetal ideal para fre�r', 10.50, 80, 10, 'L', 2, 1, 2, 1, 1),
('P003', 'Leche Gloria 400g', 'Leche evaporada entera en lata', 4.20, 150, 20, 'g', 1, 4, 3, 2, 1),
('P004', 'Fideos Don Vittorio 500g', 'Fideos spaghetti de trigo selecto', 3.50, 120, 10, 'g', 2, 1, 1, 1, 1),
('P005', 'At�n Florida 170g', 'At�n en aceite vegetal', 6.00, 60, 5, 'g', 3, 5, 3, 2, 1),
('P006', 'Az�car Rubia 1kg', 'Az�car rubia peruana de calidad', 3.80, 90, 10, 'kg', 1, 1, 1, 1, 1),
('P007', 'Panet�n D�Onofrio 900g', 'Panet�n tradicional con frutas y pasas', 18.00, 30, 5, 'g', 2, 1, 4, 3, 1),
('P008', 'Gaseosa Inca Kola 1.5L', 'Bebida gaseosa tradicional peruana', 6.50, 75, 10, 'L', 1, 2, 2, 1, 1),
('P009', 'Jab�n Bol�var 200g', 'Jab�n para lavado de ropa', 2.20, 110, 15, 'g', 3, 3, 1, 1, 1),
('P010', 'Cerveza Cusque�a 355ml', 'Cerveza premium rubia', 6.80, 50, 5, 'ml', 2, 2, 2, 1, 1);
GO