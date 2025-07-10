use DiarsAlfa;


-- Inserciones para TipoCliente
-- Asumiendo que id_tipo_cliente 1 es 'Persona Natural' y 2 es 'Persona Juridica'
INSERT INTO TipoCliente (id_tipo_cliente, nombre_tipo) VALUES
(1, 'Persona Natural'),
(2, 'Persona Juridica');
GO

INSERT INTO Usuarios (password_hash, rol, activo) VALUES
('HASH_ADMIN_INIC1', 'admin', 1),        -- id_usuario = 1 (para Trabajador 1)
('HASH_VENDEDOR_INIC1', 'vendedor', 1),  -- id_usuario = 2 (para Trabajador 2)
('HASH_COMPRAS_INIC1', 'compras', 1),    -- id_usuario = 3 (para Trabajador 3)
('HASH_CLIENTE_INIC1', 'cliente', 1),    -- id_usuario = 4 (para Cliente 1)
('HASH_CLIENTE_INIC2', 'cliente', 1),    -- id_usuario = 5 (para Cliente 6)
('HASH_PROVEEDOR_INIC1', 'proveedor', 1),-- id_usuario = 6 (para Proveedor 1)
('HASH_VENDEDOR_INIC2', 'vendedor', 1),  -- id_usuario = 7 (para Trabajador 4)
('HASH_CLIENTE_INIC3', 'cliente', 1),    -- id_usuario = 8 (para Cliente 2)
('HASH_CLIENTE_INIC4', 'cliente', 1),    -- id_usuario = 9 (para Cliente 7)
('HASH_PROVEEDOR_INIC2', 'proveedor', 1),-- id_usuario = 10 (para Proveedor 10)

-- Usuarios para los 10 trabajadores adicionales (id_trabajador 6 al 15)
('HASH_VENDEDOR_T6', 'vendedor', 1),    -- id_usuario = 11 (para Trabajador 6)
('HASH_COMPRAS_T7', 'compras', 1),      -- id_usuario = 12 (para Trabajador 7)
('HASH_VENDEDOR_T8', 'vendedor', 1),    -- id_usuario = 13 (para Trabajador 8)
('HASH_ADMIN_T9', 'admin', 1),          -- id_usuario = 14 (para Trabajador 9)
('HASH_COMPRAS_T10', 'compras', 1),     -- id_usuario = 15 (para Trabajador 10)
('HASH_VENDEDOR_T11', 'vendedor', 1),   -- id_usuario = 16 (para Trabajador 11)
('HASH_COMPRAS_T12', 'compras', 1),     -- id_usuario = 17 (para Trabajador 12)
('HASH_VENDEDOR_T13', 'vendedor', 1),   -- id_usuario = 18 (para Trabajador 13)
('HASH_ADMIN_T14', 'admin', 1),         -- id_usuario = 19 (para Trabajador 14)
('HASH_COMPRAS_T15', 'compras', 1),     -- id_usuario = 20 (para Trabajador 15)

-- Usuarios para 86 clientes adicionales (id_cliente 11 al 250, 86 de ellos tendrán usuario)
-- Usaremos un patrón para los IDs de usuario de clientes, comenzando desde 21
('HASH_CLIENTE_ADD_1', 'cliente', 1),   -- id_usuario = 21 (para Cliente 11)
('HASH_CLIENTE_ADD_2', 'cliente', 1),   -- id_usuario = 22 (para Cliente 12)
('HASH_CLIENTE_ADD_3', 'cliente', 1),   -- id_usuario = 23 (para Cliente 13)
('HASH_CLIENTE_ADD_4', 'cliente', 1),   -- id_usuario = 24 (para Cliente 14)
('HASH_CLIENTE_ADD_5', 'cliente', 1),   -- id_usuario = 25 (para Cliente 15)
('HASH_CLIENTE_ADD_6', 'cliente', 1),   -- id_usuario = 26 (para Cliente 16)
('HASH_CLIENTE_ADD_7', 'cliente', 1),   -- id_usuario = 27 (para Cliente 17)
('HASH_CLIENTE_ADD_8', 'cliente', 1),   -- id_usuario = 28 (para Cliente 18)
('HASH_CLIENTE_ADD_9', 'cliente', 1),   -- id_usuario = 29 (para Cliente 19)
('HASH_CLIENTE_ADD_10', 'cliente', 1),  -- id_usuario = 30 (para Cliente 20)
('HASH_CLIENTE_ADD_11', 'cliente', 1),  -- id_usuario = 31 (para Cliente 21)
('HASH_CLIENTE_ADD_12', 'cliente', 1),  -- id_usuario = 32 (para Cliente 22)
('HASH_CLIENTE_ADD_13', 'cliente', 1),  -- id_usuario = 33 (para Cliente 23)
('HASH_CLIENTE_ADD_14', 'cliente', 1),  -- id_usuario = 34 (para Cliente 24)
('HASH_CLIENTE_ADD_15', 'cliente', 1),  -- id_usuario = 35 (para Cliente 25)
('HASH_CLIENTE_ADD_16', 'cliente', 1),  -- id_usuario = 36 (para Cliente 26)
('HASH_CLIENTE_ADD_17', 'cliente', 1),  -- id_usuario = 37 (para Cliente 27)
('HASH_CLIENTE_ADD_18', 'cliente', 1),  -- id_usuario = 38 (para Cliente 28)
('HASH_CLIENTE_ADD_19', 'cliente', 1),  -- id_usuario = 39 (para Cliente 29)
('HASH_CLIENTE_ADD_20', 'cliente', 1),  -- id_usuario = 40 (para Cliente 30)
('HASH_CLIENTE_ADD_21', 'cliente', 1),  -- id_usuario = 41 (para Cliente 31)
('HASH_CLIENTE_ADD_22', 'cliente', 1),  -- id_usuario = 42 (para Cliente 32)
('HASH_CLIENTE_ADD_23', 'cliente', 1),  -- id_usuario = 43 (para Cliente 33)
('HASH_CLIENTE_ADD_24', 'cliente', 1),  -- id_usuario = 44 (para Cliente 34)
('HASH_CLIENTE_ADD_25', 'cliente', 1),  -- id_usuario = 45 (para Cliente 35)
('HASH_CLIENTE_ADD_26', 'cliente', 1),  -- id_usuario = 46 (para Cliente 36)
('HASH_CLIENTE_ADD_27', 'cliente', 1),  -- id_usuario = 47 (para Cliente 37)
('HASH_CLIENTE_ADD_28', 'cliente', 1),  -- id_usuario = 48 (para Cliente 38)
('HASH_CLIENTE_ADD_29', 'cliente', 1),  -- id_usuario = 49 (para Cliente 39)
('HASH_CLIENTE_ADD_30', 'cliente', 1),  -- id_usuario = 50 (para Cliente 40)
('HASH_CLIENTE_ADD_31', 'cliente', 1),  -- id_usuario = 51 (para Cliente 41)
('HASH_CLIENTE_ADD_32', 'cliente', 1),  -- id_usuario = 52 (para Cliente 42)
('HASH_CLIENTE_ADD_33', 'cliente', 1),  -- id_usuario = 53 (para Cliente 43)
('HASH_CLIENTE_ADD_34', 'cliente', 1),  -- id_usuario = 54 (para Cliente 44)
('HASH_CLIENTE_ADD_35', 'cliente', 1),  -- id_usuario = 55 (para Cliente 45)
('HASH_CLIENTE_ADD_36', 'cliente', 1),  -- id_usuario = 56 (para Cliente 46)
('HASH_CLIENTE_ADD_37', 'cliente', 1),  -- id_usuario = 57 (para Cliente 47)
('HASH_CLIENTE_ADD_38', 'cliente', 1),  -- id_usuario = 58 (para Cliente 48)
('HASH_CLIENTE_ADD_39', 'cliente', 1),  -- id_usuario = 59 (para Cliente 49)
('HASH_CLIENTE_ADD_40', 'cliente', 1),  -- id_usuario = 60 (para Cliente 50)
('HASH_CLIENTE_ADD_41', 'cliente', 1),  -- id_usuario = 61 (para Cliente 51)
('HASH_CLIENTE_ADD_42', 'cliente', 1),  -- id_usuario = 62 (para Cliente 52)
('HASH_CLIENTE_ADD_43', 'cliente', 1),  -- id_usuario = 63 (para Cliente 53)
('HASH_CLIENTE_ADD_44', 'cliente', 1),  -- id_usuario = 64 (para Cliente 54)
('HASH_CLIENTE_ADD_45', 'cliente', 1),  -- id_usuario = 65 (para Cliente 55)
('HASH_CLIENTE_ADD_46', 'cliente', 1),  -- id_usuario = 66 (para Cliente 56)
('HASH_CLIENTE_ADD_47', 'cliente', 1),  -- id_usuario = 67 (para Cliente 57)
('HASH_CLIENTE_ADD_48', 'cliente', 1),  -- id_usuario = 68 (para Cliente 58)
('HASH_CLIENTE_ADD_49', 'cliente', 1),  -- id_usuario = 69 (para Cliente 59)
('HASH_CLIENTE_ADD_50', 'cliente', 1),  -- id_usuario = 70 (para Cliente 60)
('HASH_CLIENTE_ADD_51', 'cliente', 1),  -- id_usuario = 71 (para Cliente 61)
('HASH_CLIENTE_ADD_52', 'cliente', 1),  -- id_usuario = 72 (para Cliente 62)
('HASH_CLIENTE_ADD_53', 'cliente', 1),  -- id_usuario = 73 (para Cliente 63)
('HASH_CLIENTE_ADD_54', 'cliente', 1),  -- id_usuario = 74 (para Cliente 64)
('HASH_CLIENTE_ADD_55', 'cliente', 1),  -- id_usuario = 75 (para Cliente 65)
('HASH_CLIENTE_ADD_56', 'cliente', 1),  -- id_usuario = 76 (para Cliente 66)
('HASH_CLIENTE_ADD_57', 'cliente', 1),  -- id_usuario = 77 (para Cliente 67)
('HASH_CLIENTE_ADD_58', 'cliente', 1),  -- id_usuario = 78 (para Cliente 68)
('HASH_CLIENTE_ADD_59', 'cliente', 1),  -- id_usuario = 79 (para Cliente 69)
('HASH_CLIENTE_ADD_60', 'cliente', 1),  -- id_usuario = 80 (para Cliente 70)
('HASH_CLIENTE_ADD_61', 'cliente', 1),  -- id_usuario = 81 (para Cliente 71)
('HASH_CLIENTE_ADD_62', 'cliente', 1),  -- id_usuario = 82 (para Cliente 72)
('HASH_CLIENTE_ADD_63', 'cliente', 1),  -- id_usuario = 83 (para Cliente 73)
('HASH_CLIENTE_ADD_64', 'cliente', 1),  -- id_usuario = 84 (para Cliente 74)
('HASH_CLIENTE_ADD_65', 'cliente', 1),  -- id_usuario = 85 (para Cliente 75)
('HASH_CLIENTE_ADD_66', 'cliente', 1),  -- id_usuario = 86 (para Cliente 76)
('HASH_CLIENTE_ADD_67', 'cliente', 1),  -- id_usuario = 87 (para Cliente 77)
('HASH_CLIENTE_ADD_68', 'cliente', 1),  -- id_usuario = 88 (para Cliente 78)
('HASH_CLIENTE_ADD_69', 'cliente', 1),  -- id_usuario = 89 (para Cliente 79)
('HASH_CLIENTE_ADD_70', 'cliente', 1),  -- id_usuario = 90 (para Cliente 80)
('HASH_CLIENTE_ADD_71', 'cliente', 1),  -- id_usuario = 91 (para Cliente 81)
('HASH_CLIENTE_ADD_72', 'cliente', 1),  -- id_usuario = 92 (para Cliente 82)
('HASH_CLIENTE_ADD_73', 'cliente', 1),  -- id_usuario = 93 (para Cliente 83)
('HASH_CLIENTE_ADD_74', 'cliente', 1),  -- id_usuario = 94 (para Cliente 84)
('HASH_CLIENTE_ADD_75', 'cliente', 1),  -- id_usuario = 95 (para Cliente 85)
('HASH_CLIENTE_ADD_76', 'cliente', 1),  -- id_usuario = 96 (para Cliente 86)
('HASH_CLIENTE_ADD_77', 'cliente', 1),  -- id_usuario = 97 (para Cliente 87)
('HASH_CLIENTE_ADD_78', 'cliente', 1),  -- id_usuario = 98 (para Cliente 88)
('HASH_CLIENTE_ADD_79', 'cliente', 1),  -- id_usuario = 99 (para Cliente 89)
('HASH_CLIENTE_ADD_80', 'cliente', 1),  -- id_usuario = 100 (para Cliente 90)
('HASH_CLIENTE_ADD_81', 'cliente', 1),  -- id_usuario = 101 (para Cliente 91)
('HASH_CLIENTE_ADD_82', 'cliente', 1),  -- id_usuario = 102 (para Cliente 92)
('HASH_CLIENTE_ADD_83', 'cliente', 1),  -- id_usuario = 103 (para Cliente 93)
('HASH_CLIENTE_ADD_84', 'cliente', 1),  -- id_usuario = 104 (para Cliente 94)
('HASH_CLIENTE_ADD_85', 'cliente', 1),  -- id_usuario = 105 (para Cliente 95)
('HASH_CLIENTE_ADD_86', 'cliente', 1);  -- id_usuario = 106 (para Cliente 96)
GO


-- *** 2. INSERCIONES PARA USUARIOCORREOS ***
-- Correos para todos los 106 usuarios
INSERT INTO UsuarioCorreos (id_usuario, email) VALUES
(1, 'admin.principal@tuempresa.com'),
(2, 'ventas.equipo@tuempresa.com'),
(3, 'compras.gestion@tuempresa.com'),
(4, 'cliente.andrea.vega@gmail.com'),
(5, 'cliente.laesquina@negocio.com'),
(6, 'contacto@proveedorandina.com'),
(7, 'ventas.ana.gomez@tuempresa.com'),
(8, 'cliente.roberto.quispe@hotmail.com'),
(9, 'cliente.minimarket.vecino@tienda.pe'),
(10, 'contacto@proveedorsanjuan.com'),
(11, 'carlos.rojas@tuempresa.com'),
(12, 'elena.diaz@tuempresa.com'),
(13, 'javier.sanchez@tuempresa.com'),
(14, 'lorena.mendoza@tuempresa.com'),
(15, 'ricardo.jimenez@tuempresa.com'),
(16, 'miguel.torres@tuempresa.com'),
(17, 'paola.soto@tuempresa.com'),
(18, 'daniel.bravo@tuempresa.com'),
(19, 'carla.quispe@tuempresa.com'),
(20, 'fernando.diaz@tuempresa.com');

-- Correos para los 86 clientes adicionales
INSERT INTO UsuarioCorreos (id_usuario, email) VALUES
(21, 'cliente.add1@email.com'), (22, 'cliente.add2@email.com'), (23, 'cliente.add3@email.com'), (24, 'cliente.add4@email.com'), (25, 'cliente.add5@email.com'),
(26, 'cliente.add6@email.com'), (27, 'cliente.add7@email.com'), (28, 'cliente.add8@email.com'), (29, 'cliente.add9@email.com'), (30, 'cliente.add10@email.com'),
(31, 'cliente.add11@email.com'), (32, 'cliente.add12@email.com'), (33, 'cliente.add13@email.com'), (34, 'cliente.add14@email.com'), (35, 'cliente.add15@email.com'),
(36, 'cliente.add16@email.com'), (37, 'cliente.add17@email.com'), (38, 'cliente.add18@email.com'), (39, 'cliente.add19@email.com'), (40, 'cliente.add20@email.com'),
(41, 'cliente.add21@email.com'), (42, 'cliente.add22@email.com'), (43, 'cliente.add23@email.com'), (44, 'cliente.add24@email.com'), (45, 'cliente.add25@email.com'),
(46, 'cliente.add26@email.com'), (47, 'cliente.add27@email.com'), (48, 'cliente.add28@email.com'), (49, 'cliente.add29@email.com'), (50, 'cliente.add30@email.com'),
(51, 'cliente.add31@email.com'), (52, 'cliente.add32@email.com'), (53, 'cliente.add33@email.com'), (54, 'cliente.add34@email.com'), (55, 'cliente.add35@email.com'),
(56, 'cliente.add36@email.com'), (57, 'cliente.add37@email.com'), (58, 'cliente.add38@email.com'), (59, 'cliente.add39@email.com'), (60, 'cliente.add40@email.com'),
(61, 'cliente.add41@email.com'), (62, 'cliente.add42@email.com'), (63, 'cliente.add43@email.com'), (64, 'cliente.add44@email.com'), (65, 'cliente.add45@email.com'),
(66, 'cliente.add46@email.com'), (67, 'cliente.add47@email.com'), (68, 'cliente.add48@email.com'), (69, 'cliente.add49@email.com'), (70, 'cliente.add50@email.com'),
(71, 'cliente.add51@email.com'), (72, 'cliente.add52@email.com'), (73, 'cliente.add53@email.com'), (74, 'cliente.add54@email.com'), (75, 'cliente.add55@email.com'),
(76, 'cliente.add56@email.com'), (77, 'cliente.add57@email.com'), (78, 'cliente.add58@email.com'), (79, 'cliente.add59@email.com'), (80, 'cliente.add60@email.com'),
(81, 'cliente.add61@email.com'), (82, 'cliente.add62@email.com'), (83, 'cliente.add63@email.com'), (84, 'cliente.add64@email.com'), (85, 'cliente.add65@email.com'),
(86, 'cliente.add66@email.com'), (87, 'cliente.add67@email.com'), (88, 'cliente.add68@email.com'), (89, 'cliente.add69@email.com'), (90, 'cliente.add70@email.com'),
(91, 'cliente.add71@email.com'), (92, 'cliente.add72@email.com'), (93, 'cliente.add73@email.com'), (94, 'cliente.add74@email.com'), (95, 'cliente.add75@email.com'),
(96, 'cliente.add76@email.com'), (97, 'cliente.add77@email.com'), (98, 'cliente.add78@email.com'), (99, 'cliente.add79@email.com'), (100, 'cliente.add80@email.com'),
(101, 'cliente.add81@email.com'), (102, 'cliente.add82@email.com'), (103, 'cliente.add83@email.com'), (104, 'cliente.add84@email.com'), (105, 'cliente.add85@email.com'),
(106, 'cliente.add86@email.com');
GO

---

-- *** 3. INSERCIONES PARA PROVEEDORES ***
-- 35 proveedores, enlazando algunos a Usuarios con rol 'proveedor'
INSERT INTO Proveedores (razon_social, ruc, direccion, contacto, id_usuario, activo) VALUES
('Comercial Andina SRL', '20123456781', 'Av. Perú 123, Lima', 'Carlos Ruiz', 6, 1),      -- id_proveedor = 1, id_usuario = 6
('Alimentos del Sur EIRL', '20456789123', 'Jr. Ayacucho 456, Arequipa', 'María Torres', NULL, 1), -- id_proveedor = 2
('Distribuidora Santa Anita S.A.C.', '20567891234', 'Calle Comercio 789, Lima', 'Jorge Sánchez', NULL, 1), -- id_proveedor = 3
('Importaciones Perú Norte S.A.', '20678912345', 'Av. Norte 321, Piura', 'Luis Cárdenas', NULL, 1), -- id_proveedor = 4
('Productos Naturales Andinos EIRL', '20789123456', 'Jr. Andino 147, Cusco', 'Sofía Mamani', NULL, 1), -- id_proveedor = 5
('Inversiones La Molina SAC', '20891234567', 'Av. La Molina 876, Lima', 'Pedro Gamarra', NULL, 1), -- id_proveedor = 6
('Comercializadora Lima Este S.A.C.', '20912345678', 'Calle Lima Este 741, Lima', 'Ana Fernández', NULL, 1), -- id_proveedor = 7
('Distribuidora Las Palmas S.R.L.', '20111222334', 'Av. Palmas 456, Chiclayo', 'Rosa Bravo', NULL, 1), -- id_proveedor = 8
('Corporación Abarrotes Perú SAC', '20222333445', 'Jr. Abarrotes 154, Lima', 'Carlos Huamán', NULL, 1), -- id_proveedor = 9
('Mercantil San Juan SRL', '20333444556', 'Av. San Juan 963, Lima', 'Elena Trujillo', 10, 1), -- id_proveedor = 10, id_usuario = 10
('Tecnología Global SAC', '20444555667', 'Av. Innovación 101, Lima', 'Andrés Soto', NULL, 1), -- id_proveedor = 11
('Construcciones Sol EIRL', '20555666778', 'Jr. Concreto 202, Arequipa', 'Silvia Ramos', NULL, 1), -- id_proveedor = 12
('Muebles Modernos SA', '20666777889', 'Calle Diseño 303, Trujillo', 'Roberto Castro', NULL, 1), -- id_proveedor = 13
('Servicios Industriales Perú SRL', '20777888990', 'Av. Industria 404, Callao', 'Carmen Luna', NULL, 1), -- id_proveedor = 14
('Ferretería El Martillo SAC', '20888999001', 'Jr. Herramientas 505, Lima', 'Fernando Vidal', NULL, 1), -- id_proveedor = 15
('Textiles Peruanos EIRL', '20999000112', 'Jr. Tejidos 606, Cusco', 'Isabel Flores', NULL, 1), -- id_proveedor = 16
('Electrodomésticos Futuro S.A.C.', '20000111223', 'Av. Voltaje 707, Lima', 'Gustavo Paredes', NULL, 1), -- id_proveedor = 17
('Gráfica Creativa SRL', '20101213145', 'Calle Imprenta 808, Piura', 'Diana Morales', NULL, 1), -- id_proveedor = 18
('Comercio Justo Andino SA', '20212324256', 'Jr. Equidad 909, Ayacucho', 'Miguel Ángel', NULL, 1), -- id_proveedor = 19
('Farmacia La Salud EIRL', '20323435367', 'Av. Medicina 111, Lima', 'Laura Rojas', NULL, 1), -- id_proveedor = 20
('Panadería Tradición SAC', '20434546478', 'Calle Horno 222, Chiclayo', 'Ricardo León', NULL, 1), -- id_proveedor = 21
('Librería El Saber SRL', '20545657589', 'Jr. Letras 333, Lima', 'Patricia Vega', NULL, 1), -- id_proveedor = 22
('Joyas Preciosas EIRL', '20656768690', 'Av. Brillo 444, Ica', 'Manuel Soto', NULL, 1), -- id_proveedor = 23
('Sport World SAC', '20767879801', 'Calle Deporte 555, Lima', 'Elena Quispe', NULL, 1), -- id_proveedor = 24
('Limpieza Eficaz SRL', '20878980812', 'Jr. Frescura 666, Huancayo', 'Julia Guzmán', NULL, 1), -- id_proveedor = 25
('Hotel Paradiso SA', '20989091923', 'Av. Descanso 777, Puno', 'Sergio Díaz', NULL, 1), -- id_proveedor = 26
('Carnes Premium EIRL', '20090102034', 'Jr. Parrilla 888, Lima', 'Marcela Peña', NULL, 1), -- id_proveedor = 27
('Insumos Agrícolas SAC', '20101112135', 'Av. Cosecha 999, Cajamarca', 'Jorge Núñez', NULL, 1), -- id_proveedor = 28
('Repuestos Automotrices SRL', '20212223246', 'Calle Motor 121, Lima', 'Verónica Silva', NULL, 1), -- id_proveedor = 29
('Vidriería Transparente EIRL', '20323334357', 'Jr. Cristal 232, Cusco', 'Alberto Vargas', NULL, 1), -- id_proveedor = 30
('Materiales Eléctricos SA', '20434445468', 'Av. Corriente 343, Tacna', 'Susana Polo', NULL, 1), -- id_proveedor = 31
('Productos Químicos del Norte SAC', '20545556579', 'Calle Fórmula 454, Trujillo', 'Pablo Mendoza', NULL, 1), -- id_proveedor = 32
('Catering Gourmet SRL', '20656667680', 'Jr. Sabor 565, Lima', 'Andrea Torres', NULL, 1), -- id_proveedor = 33
('Accesorios Móviles EIRL', '20767778791', 'Av. Conexión 676, Arequipa', 'Diego Rojas', NULL, 1), -- id_proveedor = 34
('Seguridad Total SAC', '20878889802', 'Calle Vigilancia 787, Lima', 'Carla Bustamante', NULL, 1); -- id_proveedor = 35
GO

---

-- *** 4. INSERCIONES PARA PROVEEDORCORREOS ***
INSERT INTO ProveedorCorreos (id_proveedor, email) VALUES
(1, 'contacto@andinasrl.com'), (2, 'ventas@alimentosdelsur.pe'), (3, 'info@santaanita.com'),
(4, 'importaciones@nortenorte.com'), (5, 'naturales@andinos.pe'), (6, 'molina@inversiones.com'),
(7, 'limaeste@comercializadora.com'), (8, 'laspalmas@distribuidora.com'), (9, 'corporacion@abarrotesperu.com'),
(10, 'mercantil@sanjuan.pe'), (11, 'contacto@tecnologiaglobal.com'), (12, 'ventas@construccionessol.pe'),
(13, 'info@mueblesmodernos.com'), (14, 'servicios@industrialesperu.com'), (15, 'ventas@ferreteriaelmartillo.com'),
(16, 'contacto@textilesperuanos.pe'), (17, 'info@electrodomesticosfuturo.com'), (18, 'grafica@creativa.com'),
(19, 'comerciojusto@andino.pe'), (20, 'farmacia@lasalud.com'), (21, 'contacto@panaderiatradicion.pe'),
(22, 'info@libreriaelsaber.com'), (23, 'ventas@joyaspreciosas.com'), (24, 'contacto@sportworld.com'),
(25, 'info@limpiezaeficaz.pe'), (26, 'reservas@hotelparadiso.com'), (27, 'ventas@carnespremium.com'),
(28, 'contacto@insumosagricolas.com'), (29, 'repuestos@automotrices.com'), (30, 'info@vidrieriatransparente.pe'),
(31, 'ventas@materialeselectricos.com'), (32, 'contacto@productosquimicosnorte.com'), (33, 'info@cateringgourmet.com'),
(34, 'ventas@accesoriosmoviles.com'), (35, 'contacto@seguridadtotal.com');
GO

---

-- *** 5. INSERCIONES PARA PROVEEDORTELEFONOS ***
INSERT INTO ProveedorTelefonos (id_proveedor, telefono) VALUES
(1, '987654321'), (2, '956789432'), (3, '923456789'), (4, '912345678'), (5, '964578123'),
(6, '977321654'), (7, '945612378'), (8, '987123456'), (9, '954789123'), (10, '999888777'),
(11, '987012345'), (12, '956123456'), (13, '923567890'), (14, '912678901'), (15, '964789012'),
(16, '977432109'), (17, '945789012'), (18, '987234567'), (19, '954890123'), (20, '999777666'),
(21, '987123000'), (22, '956234111'), (23, '923678222'), (24, '912789333'), (25, '964890444'),
(26, '977543555'), (27, '945890666'), (28, '987345777'), (29, '954901888'), (30, '999666555'),
(31, '987000123'), (32, '956111234'), (33, '923555678'), (34, '912666789'), (35, '964777890');
GO

---

-- *** 6. INSERCIONES PARA TRABAJADORES ***
-- 15 trabajadores en total (5 iniciales + 10 adicionales).
-- Solo los roles 'Administrador', 'Vendedor', 'Encargado de Compras' tendrán id_usuario.
-- Se generarán DNIs únicos.
	INSERT INTO Trabajadores (id_usuario, nombres, apellidos, dni, cargo, fecha_ingreso, activo) VALUES
	-- 5 trabajadores iniciales
	(1, 'Juan', 'Pérez García', '78901234', 'Administrador', '2020-01-15', 1), -- id_trabajador = 1, id_usuario = 1
	(2, 'María', 'López Díaz', '45678901', 'Vendedor', '2021-03-20', 1),     -- id_trabajador = 2, id_usuario = 2
	(3, 'Pedro', 'Martínez Soto', '12345678', 'Encargado de Compras', '2019-07-10', 1), -- id_trabajador = 3, id_usuario = 3
	(7, 'Ana', 'Gómez Castro', '90123456', 'Vendedor', '2022-05-01', 1),     -- id_trabajador = 4, id_usuario = 7
	(NULL, 'Luis', 'Ramírez Flores', '34567890', 'Almacenero', '2023-01-01', 1), -- id_trabajador = 5, sin id_usuario

	-- 10 trabajadores adicionales
	(11, 'Carlos', 'Rojas Soto', '23456789', 'Vendedor', '2023-07-01', 1),       -- id_trabajador = 6, id_usuario = 11
	(12, 'Elena', 'Díaz Pinedo', '34566890', 'Encargado de Compras', '2022-11-10', 1), -- id_trabajador = 7, id_usuario = 12
	(13, 'Javier', 'Sánchez Ramos', '45678902', 'Vendedor', '2024-02-15', 1),     -- id_trabajador = 8, id_usuario = 13
	(14, 'Lorena', 'Mendoza Quispe', '56789012', 'Administrador', '2020-09-01', 1), -- id_trabajador = 9, id_usuario = 14
	(15, 'Ricardo', 'Jiménez Flores', '67890123', 'Encargado de Compras', '2021-04-22', 1), -- id_trabajador = 10, id_usuario = 15
	(16, 'Miguel', 'Torres Salas', '78901235', 'Vendedor', '2024-01-10', 1),      -- id_trabajador = 11, id_usuario = 16
	(17, 'Paola', 'Soto Bravo', '89012346', 'Encargado de Compras', '2023-03-05', 1), -- id_trabajador = 12, id_usuario = 17
	(NULL, 'Daniel', 'Bravo Luna', '90123457', 'Limpieza', '2022-09-20', 1),     -- id_trabajador = 13, sin id_usuario
	(19, 'Carla', 'Quispe Vega', '01234568', 'Administrador', '2021-06-12', 1),  -- id_trabajador = 14, id_usuario = 19
	(20, 'Fernando', 'Díaz Rojas', '12345679', 'Vendedor', '2024-04-01', 1);     -- id_trabajador = 15, id_usuario = 20
	GO


	-- *** 7. INSERCIONES PARA TRABAJADORCORREO ***
	INSERT INTO TrabajadorCorreo (id_trabajador, email) VALUES
	(1, 'juan.perez@tuempresa.com'), (2, 'maria.lopez@tuempresa.com'), (3, 'pedro.martinez@tuempresa.com'),
	(4, 'ana.gomez@tuempresa.com'), (5, 'luis.ramirez@tuempresa.com'), (6, 'carlos.rojas@tuempresa.com'),
	(7, 'elena.diaz@tuempresa.com'), (8, 'javier.sanchez@tuempresa.com'), (9, 'lorena.mendoza@tuempresa.com'),
	(10, 'ricardo.jimenez@tuempresa.com'), (11, 'miguel.torres@tuempresa.com'), (12, 'paola.soto@tuempresa.com'),
	(13, 'daniel.bravo@tuempresa.com'), (14, 'carla.quispe@tuempresa.com'), (15, 'fernando.diaz@tuempresa.com');
	GO

---

-- *** 8. INSERCIONES PARA TRABAJADORTELEFONO ***
INSERT INTO TrabajadorTelefono (id_trabajador, telefono) VALUES
(1, '998765432'), (2, '987654321'), (3, '976543210'), (4, '965432109'), (5, '954321098'),
(6, '999888777'), (7, '988777666'), (8, '977666555'), (9, '966555444'), (10, '955444333'),
(11, '944333222'), (12, '933222111'), (13, '922111000'), (14, '911000999'), (15, '900999888');
GO

---

-- *** 9. INSERCIONES PARA CLIENTES ***
-- 250 clientes en total (10 iniciales + 240 adicionales)
-- Se intercalarán Persona Natural (id_tipo_cliente = 1) y Persona Jurídica (id_tipo_cliente = 2).
-- Se asignará id_usuario a una proporción de ellos, comenzando con los IDs de usuario del 21 al 106.

INSERT INTO Clientes (id_tipo_cliente, nombres, apellidos, dni, razon_social, ruc, direccion, id_usuario, activo) VALUES
-- 10 Clientes iniciales
(1, 'Andrea', 'Vega Salas', '44556677', NULL, NULL, 'Av. Los Sauces 101, Miraflores', 4, 1), -- id_cliente = 1, id_usuario = 4
(1, 'Roberto', 'Quispe Mamani', '88990011', NULL, NULL, 'Jr. Las Palmeras 202, Comas', 8, 1), -- id_cliente = 2, id_usuario = 8
(1, 'Sofía', 'Castro Ríos', '11223344', NULL, NULL, 'Calle El Sol 303, Surco', NULL, 1), -- id_cliente = 3
(1, 'Diego', 'Flores Cárdenas', '55667788', NULL, NULL, 'Av. La Luna 404, San Juan', NULL, 1), -- id_cliente = 4
(1, 'Valeria', 'Núñez Bravo', '99001122', NULL, NULL, 'Jr. Los Andes 505, Ate', NULL, 1), -- id_cliente = 5
(2, NULL, NULL, NULL, 'Tienda La Esquina SAC', '20123456789', 'Av. Principal 123, Pueblo Libre', 5, 1), -- id_cliente = 6, id_usuario = 5
(2, NULL, NULL, NULL, 'Minimarket El Vecino EIRL', '20987654321', 'Jr. Comercio 456, Breña', 9, 1), -- id_cliente = 7, id_usuario = 9
(2, NULL, NULL, NULL, 'Bodega La Confianza', '10111222334', 'Calle Unión 789, Lince', NULL, 1), -- id_cliente = 8
(2, NULL, NULL, NULL, 'Supermercado Express S.A.', '20445566778', 'Av. Central 321, Jesús María', NULL, 1), -- id_cliente = 9
(2, NULL, NULL, NULL, 'Distribuidora Mayorista XYZ', '20556677889', 'Jr. Industrial 147, La Victoria', NULL, 1), -- id_cliente = 10

-- 240 Clientes adicionales (120 Naturales, 120 Jurídicas) con nombres y DNI/RUC ficticios más realistas
(1, 'Carlos Alberto', 'García Pérez', '70123456', NULL, NULL, 'Av. Arequipa 123, Lince', 21, 1), -- id_cliente = 11, id_usuario = 21
(1, 'María Fernanda', 'Diaz Rojas', '71234567', NULL, NULL, 'Jr. Puno 456, Cercado de Lima', 22, 1), -- id_cliente = 12, id_usuario = 22
(1, 'José Luis', 'Soto Vargas', '72345678', NULL, NULL, 'Calle Los Rosales 789, San Isidro', NULL, 1), -- id_cliente = 13
(1, 'Ana Cecilia', 'Ramírez Huamán', '73456789', NULL, NULL, 'Av. Javier Prado Este 1011, San Borja', 23, 1), -- id_cliente = 14, id_usuario = 23
(1, 'Luis Fernando', 'Quispe López', '74567890', NULL, NULL, 'Jr. Cusco 1213, Magdalena', NULL, 1), -- id_cliente = 15
(1, 'Carmen Rosa', 'Gonzales Quispe', '75678901', NULL, NULL, 'Av. La Paz 1415, Miraflores', 24, 1), -- id_cliente = 16, id_usuario = 24
(1, 'David Ricardo', 'Vargas Cárdenas', '76789012', NULL, NULL, 'Calle Berlín 1617, Barranco', 25, 1), -- id_cliente = 17, id_usuario = 25
(1, 'Elena Patricia', 'Ramos Sánchez', '77890123', NULL, NULL, 'Av. San Martín 1819, Surquillo', NULL, 1), -- id_cliente = 18
(1, 'Gabriel Alejandro', 'Mendoza Quispe', '78901234', NULL, NULL, 'Jr. Moquegua 2021, Breña', 26, 1), -- id_cliente = 19, id_usuario = 26
(1, 'Isabel Cristina', 'Torres Benites', '79012345', NULL, NULL, 'Calle Los Geranios 2223, Santiago de Surco', NULL, 1), -- id_cliente = 20
(1, 'Juan Pablo', 'Gutiérrez Morales', '80123456', NULL, NULL, 'Av. La Molina 2425, La Molina', 27, 1), -- id_cliente = 21, id_usuario = 27
(1, 'Laura Sofía', 'Chávez Rojas', '81234567', NULL, NULL, 'Jr. Ayacucho 2627, Chorrillos', 28, 1), -- id_cliente = 22, id_usuario = 28
(1, 'Miguel Ángel', 'Silva Benavides', '82345678', NULL, NULL, 'Av. Las Flores 2829, San Juan de Miraflores', NULL, 1), -- id_cliente = 23
(1, 'Natalia Elizabeth', 'Paredes Solís', '83456789', NULL, NULL, 'Calle Los Laureles 3031, Ate', 29, 1), -- id_cliente = 24, id_usuario = 29
(1, 'Óscar Javier', 'Cárdenas Castro', '84567890', NULL, NULL, 'Av. El Ejército 3233, San Miguel', NULL, 1), -- id_cliente = 25
(1, 'Patricia Soledad', 'Salazar Pinedo', '85678901', NULL, NULL, 'Jr. Huancayo 3435, Rímac', 30, 1), -- id_cliente = 26, id_usuario = 30
(1, 'Ricardo Antonio', 'Ferrer Díaz', '86789012', NULL, NULL, 'Av. Salaverry 3637, Jesús María', 31, 1), -- id_cliente = 27, id_usuario = 31
(1, 'Silvia Liliana', 'Valdez Hurtado', '87890123', NULL, NULL, 'Calle Los Olivos 3839, Los Olivos', NULL, 1), -- id_cliente = 28
(1, 'Tomás Eduardo', 'Gómez Núñez', '88901234', NULL, NULL, 'Av. Tupac Amaru 4041, Comas', 32, 1), -- id_cliente = 29, id_usuario = 32
(1, 'Úrsula Mariela', 'Zapata Ruiz', '89012345', NULL, NULL, 'Jr. La Unión 4243, Pueblo Libre', NULL, 1), -- id_cliente = 30
-- Continue with a mix of Natural and Juridical, with id_usuario assignments
(2, NULL, NULL, NULL, 'Servicios Integrales Perú SAC', '20000000011', 'Av. Argentina 101, Callao', 33, 1), -- id_cliente = 31, id_usuario = 33
(2, NULL, NULL, NULL, 'Importaciones del Norte SRL', '20000000012', 'Calle Bolognesi 202, Miraflores', NULL, 1), -- id_cliente = 32
(1, 'Victor Hugo', 'Ríos Paz', '90123456', NULL, NULL, 'Jr. Ancash 4445, Cercado de Lima', 34, 1), -- id_cliente = 33, id_usuario = 34
(2, NULL, NULL, NULL, 'Distribuidora del Centro EIRL', '20000000014', 'Av. Wilson 303, Breña', 35, 1), -- id_cliente = 34, id_usuario = 35
(1, 'Wendy Carolina', 'Soto Quispe', '91234567', NULL, NULL, 'Av. La Marina 4647, San Miguel', NULL, 1), -- id_cliente = 35
(1, 'Ximena Alessandra', 'Vásquez Ramos', '92345678', NULL, NULL, 'Calle Los Álamos 4849, Surco', 36, 1), -- id_cliente = 36, id_usuario = 36
(2, NULL, NULL, NULL, 'Construcciones Andinas SAC', '20000000017', 'Av. Aviación 404, San Borja', NULL, 1), -- id_cliente = 37
(1, 'Yanira Belén', 'Chávez Paredes', '93456789', NULL, NULL, 'Jr. Garcilaso de la Vega 5051, Jesús María', 37, 1), -- id_cliente = 38, id_usuario = 37
(1, 'Zulema Aracely', 'Flores Mendoza', '94567890', NULL, NULL, 'Av. Sucre 5253, Pueblo Libre', NULL, 1), -- id_cliente = 39
(2, NULL, NULL, NULL, 'Tecnología Peruana SRL', '20000000020', 'Av. El Polo 505, Surco', 38, 1), -- id_cliente = 40, id_usuario = 38
(1, 'Adriana Sofía', 'Ramírez Quispe', '95678901', NULL, NULL, 'Jr. Chiclayo 5455, Miraflores', 39, 1), -- id_cliente = 41, id_usuario = 39
(2, NULL, NULL, NULL, 'Soluciones Digitales EIRL', '20000000022', 'Calle Dean Valdivia 606, San Isidro', NULL, 1), -- id_cliente = 42
(1, 'Benjamín Mateo', 'Vargas Quispe', '96789012', NULL, NULL, 'Av. Benavides 5657, Miraflores', 40, 1), -- id_cliente = 43, id_usuario = 40
(2, NULL, NULL, NULL, 'Alimentos del Sur SAC', '20000000024', 'Av. Paseo de la República 707, La Victoria', NULL, 1), -- id_cliente = 44
(1, 'Camila Isabel', 'Ferrer Morales', '97890123', NULL, NULL, 'Jr. Contumazá 5859, Cercado de Lima', 41, 1), -- id_cliente = 45, id_usuario = 41
(1, 'Daniel Arturo', 'Valdez Benites', '98901234', NULL, NULL, 'Av. Grau 6061, Barranco', NULL, 1), -- id_cliente = 46
(2, NULL, NULL, NULL, 'Transportes El Rápido SRL', '20000000027', 'Av. Faucett 808, Callao', 42, 1), -- id_cliente = 47, id_usuario = 42
(1, 'Estefanía Gabriela', 'Núñez Hurtado', '99012345', NULL, NULL, 'Calle Recavarren 6263, San Isidro', NULL, 1), -- id_cliente = 48
(1, 'Fernando Javier', 'Zapata Cárdenas', '99123456', NULL, NULL, 'Av. Angamos Este 6465, Surquillo', 43, 1), -- id_cliente = 49, id_usuario = 43
(2, NULL, NULL, NULL, 'Textiles Finos EIRL', '20000000030', 'Jr. Huaraz 909, Breña', NULL, 1), -- id_cliente = 50
(1, 'Gisella Andrea', 'Medina Chávez', '99234567', NULL, NULL, 'Av. Canevaro 6667, Lince', 44, 1), -- id_cliente = 51, id_usuario = 44
(2, NULL, NULL, NULL, 'Inversiones Globales SAC', '20000000032', 'Av. Rivera Navarrete 1010, San Isidro', 45, 1), -- id_cliente = 52, id_usuario = 45
(1, 'Hector Fabián', 'Pérez Salazar', '99345678', NULL, NULL, 'Jr. Puno 6869, Cercado de Lima', NULL, 1), -- id_cliente = 53
(1, 'Irene Raquel', 'Gómez Valdivia', '99456789', NULL, NULL, 'Av. Dos de Mayo 7071, San Isidro', 46, 1), -- id_cliente = 54, id_usuario = 46
(2, NULL, NULL, NULL, 'Comercializadora del Sol SRL', '20000000035', 'Calle Schell 1111, Miraflores', NULL, 1), -- id_cliente = 55
(1, 'Joaquín Alonso', 'Vargas Huamán', '99567890', NULL, NULL, 'Av. Paseo de la Castellana 7273, Santiago de Surco', 47, 1), -- id_cliente = 56, id_usuario = 47
(2, NULL, NULL, NULL, 'Logística Avanzada EIRL', '20000000037', 'Jr. Gamarra 1212, La Victoria', 48, 1), -- id_cliente = 57, id_usuario = 48
(1, 'Karen Sofía', 'Castro Rojas', '99678901', NULL, NULL, 'Av. Brasil 7475, Jesús María', NULL, 1), -- id_cliente = 58
(1, 'Leonardo Manuel', 'Díaz Soto', '99789012', NULL, NULL, 'Calle Los Pinos 7677, Surquillo', 49, 1), -- id_cliente = 59, id_usuario = 49
(2, NULL, NULL, NULL, 'Constructora Futuro SAC', '20000000040', 'Av. Elmer Faucett 1313, San Miguel', NULL, 1), -- id_cliente = 60
(1, 'María Pía', 'Ramírez Salas', '99890123', NULL, NULL, 'Jr. Camaná 7879, Cercado de Lima', 50, 1), -- id_cliente = 61, id_usuario = 50
(2, NULL, NULL, NULL, 'Marketing Innovador SRL', '20000000042', 'Av. Santa Cruz 1414, Miraflores', 51, 1), -- id_cliente = 62, id_usuario = 51
(1, 'Nicolás Andrés', 'Quispe Vega', '99901234', NULL, NULL, 'Av. La Paz 8081, San Isidro', NULL, 1), -- id_cliente = 63
(1, 'Olivia Fernanda', 'Gonzales Bravo', '99912345', NULL, NULL, 'Jr. Miraflores 8283, San Juan de Miraflores', 52, 1), -- id_cliente = 64, id_usuario = 52
(2, NULL, NULL, NULL, 'Editorial El Saber EIRL', '20000000045', 'Calle Las Orquídeas 1515, San Borja', NULL, 1), -- id_cliente = 65
(1, 'Pedro Miguel', 'Vásquez López', '99923456', NULL, NULL, 'Av. Los Ficus 8485, Ate', 53, 1), -- id_cliente = 66, id_usuario = 53
(2, NULL, NULL, NULL, 'Consultores B&C SAC', '20000000047', 'Av. Los Fresnos 1616, La Molina', 54, 1), -- id_cliente = 67, id_usuario = 54
(1, 'Renata Jimena', 'Torres Benavides', '99934567', NULL, NULL, 'Jr. Las Magnolias 8687, Los Olivos', NULL, 1), -- id_cliente = 68
(1, 'Sergio Daniel', 'Mendoza Pinedo', '99945678', NULL, NULL, 'Av. Alfredo Mendiola 8889, Comas', 55, 1), -- id_cliente = 69, id_usuario = 55
(2, NULL, NULL, NULL, 'Industrias del Valle SRL', '20000000050', 'Jr. Cuzco 1717, Cercado de Lima', NULL, 1), -- id_cliente = 70
-- Continuamos el patrón hasta 250 clientes
(1, 'Valeria Camila', 'Silva Ruiz', '99956789', NULL, NULL, 'Av. José Pardo 9091, Miraflores', 56, 1), -- id_cliente = 71, id_usuario = 56
(1, 'Walter Alexander', 'Carrillo Luna', '99967890', NULL, NULL, 'Jr. Ica 9293, Breña', NULL, 1), -- id_cliente = 72
(2, NULL, NULL, NULL, 'Energías Renovables EIRL', '20000000053', 'Calle Roma 1818, San Isidro', 57, 1), -- id_cliente = 73, id_usuario = 57
(1, 'Yolanda Beatríz', 'Huamán Castro', '99978901', NULL, NULL, 'Av. La Cultura 9495, San Juan de Miraflores', NULL, 1), -- id_cliente = 74
(1, 'Zoe Nicole', 'Salazar Díaz', '99989012', NULL, NULL, 'Jr. Amazonas 9697, Cercado de Lima', 58, 1), -- id_cliente = 75, id_usuario = 58
(2, NULL, NULL, NULL, 'Desarrollos Inmobiliarios SAC', '20000000056', 'Av. Javier Prado Oeste 1919, San Isidro', NULL, 1), -- id_cliente = 76
(1, 'Alejandra Victoria', 'García Chávez', '99990123', NULL, NULL, 'Av. Pardo y Aliaga 9899, San Isidro', 59, 1), -- id_cliente = 77, id_usuario = 59
(2, NULL, NULL, NULL, 'Servicios Financieros del Perú SRL', '20000000058', 'Av. Ricardo Palma 2020, Miraflores', 60, 1), -- id_cliente = 78, id_usuario = 60
(1, 'Bruno Sebastián', 'López Vargas', '99991234', NULL, NULL, 'Calle Los Halcones 10001, Chorrillos', NULL, 1), -- id_cliente = 79
(1, 'Cecilia Andrea', 'Quispe Cárdenas', '99992345', NULL, NULL, 'Av. Del Río 10002, Pueblo Libre', 61, 1), -- id_cliente = 80, id_usuario = 61
(2, NULL, NULL, NULL, 'Gráficos Modernos EIRL', '20000000061', 'Jr. Cajamarca 2121, Magdalena', NULL, 1), -- id_cliente = 81
(1, 'Daniela Fernanda', 'Sánchez Bravo', '99993456', NULL, NULL, 'Av. La Paz 10003, Santiago de Surco', 62, 1), -- id_cliente = 82, id_usuario = 62
(2, NULL, NULL, NULL, 'Tecnologías del Mañana SAC', '20000000063', 'Av. Arequipa 2222, San Isidro', 63, 1), -- id_cliente = 83, id_usuario = 63
(1, 'Emilio José', 'Morales Benites', '99994567', NULL, NULL, 'Calle Manco Cápac 10004, La Victoria', NULL, 1), -- id_cliente = 84
(2, NULL, NULL, NULL, 'Exportadora Perú SRL', '20000000065', 'Av. Larco 2323, Miraflores', 64, 1), -- id_cliente = 85, id_usuario = 64
(1, 'Fabiola Belén', 'Torres Pinedo', '99995678', NULL, NULL, 'Jr. Huaraz 10005, Breña', 65, 1), -- id_cliente = 86, id_usuario = 65
(2, NULL, NULL, NULL, 'Servicios Médicos A1 EIRL', '20000000067', 'Av. Prescott 2424, San Isidro', NULL, 1), -- id_cliente = 87
(1, 'Gonzalo Rodrigo', 'Valdez Hurtado', '99996789', NULL, NULL, 'Av. Primavera 10006, Surco', 66, 1), -- id_cliente = 88, id_usuario = 66
(2, NULL, NULL, NULL, 'Comercio Exterior SAC', '20000000069', 'Av. Guardia Civil 2525, San Borja', 67, 1), -- id_cliente = 89, id_usuario = 67
(1, 'Helena Sofía', 'Zapata Ruiz', '99997890', NULL, NULL, 'Jr. Junín 10007, Cercado de Lima', NULL, 1), -- id_cliente = 90
(2, NULL, NULL, NULL, 'Soluciones Eléctricas SRL', '20000000071', 'Av. Separadora Industrial 2626, Ate', 68, 1), -- id_cliente = 91, id_usuario = 68
(1, 'Ignacio Felipe', 'Miranda Flores', '99998901', NULL, NULL, 'Calle Los Sauces 10008, San Miguel', NULL, 1), -- id_cliente = 92
(2, NULL, NULL, NULL, 'Servicios Turísticos del Perú EIRL', '20000000073', 'Av. Angamos Oeste 2727, Miraflores', 69, 1), -- id_cliente = 93, id_usuario = 69
(1, 'Jimena Belén', 'Paredes Solís', '99999012', NULL, NULL, 'Av. Salaverry 10009, Jesús María', 70, 1), -- id_cliente = 94, id_usuario = 70
(2, NULL, NULL, NULL, 'Textiles Andinos SAC', '20000000075', 'Jr. Puno 2828, Cercado de Lima', NULL, 1), -- id_cliente = 95
(1, 'Kevin Matías', 'Rivera Benavides', '99999123', NULL, NULL, 'Av. Arenales 10010, Lince', 71, 1), -- id_cliente = 96, id_usuario = 71
(2, NULL, NULL, NULL, 'Eventos y Conciertos SRL', '20000000077', 'Av. Faustino Sánchez Carrión 2929, San Isidro', 72, 1), -- id_cliente = 97, id_usuario = 72
(1, 'Lucía Camila', 'Saavedra Cárdenas', '99999234', NULL, NULL, 'Calle Comandante Espinar 10011, Miraflores', NULL, 1), -- id_cliente = 98
(2, NULL, NULL, NULL, 'Panadería y Pastelería La Ideal EIRL', '20000000079', 'Av. Reducto 3030, Miraflores', 73, 1), -- id_cliente = 99, id_usuario = 73
(1, 'Manuel Antonio', 'Chávez López', '99999345', NULL, NULL, 'Jr. Ucayali 10012, Cercado de Lima', NULL, 1), -- id_cliente = 100
(2, NULL, NULL, NULL, 'Educación Virtual SAC', '20000000081', 'Av. La Fontana 3131, La Molina', 74, 1), -- id_cliente = 101, id_usuario = 74
(1, 'Nuria Esther', 'Flores Rojas', '99999456', NULL, NULL, 'Av. Tingo María 10013, Breña', 75, 1), -- id_cliente = 102, id_usuario = 75
(2, NULL, NULL, NULL, 'Servicios Contables Profesionales SRL', '20000000083', 'Calle El Sauce 3232, San Isidro', NULL, 1), -- id_cliente = 103
(1, 'Óscar Raúl', 'García Salas', '99999567', NULL, NULL, 'Av. Los Próceres 10014, Santiago de Surco', 76, 1), -- id_cliente = 104, id_usuario = 76
(2, NULL, NULL, NULL, 'Recursos Humanos Global EIRL', '20000000085', 'Av. Del Parque Norte 3333, San Borja', 77, 1), -- id_cliente = 105, id_usuario = 77
(1, 'Pamela Ximena', 'Herrera Quispe', '99999678', NULL, NULL, 'Jr. Libertad 10015, Magdalena', NULL, 1), -- id_cliente = 106
(2, NULL, NULL, NULL, 'Fábrica de Muebles Modernos SAC', '20000000087', 'Av. Garcilaso de la Vega 3434, Cercado de Lima', 78, 1), -- id_cliente = 107, id_usuario = 78
(1, 'Raúl Alberto', 'Inca Paredes', '99999789', NULL, NULL, 'Av. Universitaria 10016, Los Olivos', 79, 1), -- id_cliente = 108, id_usuario = 79
(2, NULL, NULL, NULL, 'Productos Agrícolas del Campo SRL', '20000000089', 'Av. Pardo 3535, Miraflores', NULL, 1), -- id_cliente = 109
(1, 'Samantha Nicole', 'Juárez Soto', '99999890', NULL, NULL, 'Calle Los Claveles 10017, Surquillo', 80, 1), -- id_cliente = 110, id_usuario = 80
(2, NULL, NULL, NULL, 'Consultoría Ambiental EIRL', '20000000091', 'Av. Arequipa 3636, Lince', 81, 1), -- id_cliente = 111, id_usuario = 81
(1, 'Thiago Gabriel', 'Luna Morales', '99999901', NULL, NULL, 'Jr. Apurímac 10018, Rímac', NULL, 1), -- id_cliente = 112
(2, NULL, NULL, NULL, 'Agencia de Viajes y Turismo SAC', '20000000093', 'Av. Carlos Izaguirre 3737, Los Olivos', 82, 1), -- id_cliente = 113, id_usuario = 82
(1, 'Ursula María', 'Medina Chávez', '99999912', NULL, NULL, 'Av. Bolognesi 10019, Barranco', 83, 1), -- id_cliente = 114, id_usuario = 83
(2, NULL, NULL, NULL, 'Servicios de Limpieza Integral SRL', '20000000095', 'Calle Diez Canseco 3838, Miraflores', NULL, 1), -- id_cliente = 115
(1, 'Valeria Celeste', 'Nieto Pérez', '99999923', NULL, NULL, 'Av. La Paz 10020, Miraflores', 84, 1), -- id_cliente = 116, id_usuario = 84
(2, NULL, NULL, NULL, 'Restaurante Sabor Peruano EIRL', '20000000097', 'Av. Jose Larco 3939, Miraflores', 85, 1), -- id_cliente = 117, id_usuario = 85
(1, 'William Ernesto', 'Ortiz Ramos', '99999934', NULL, NULL, 'Jr. Gral. Garzón 10021, Jesús María', NULL, 1), -- id_cliente = 118
(2, NULL, NULL, NULL, 'Centro Médico Especializado SAC', '20000000099', 'Av. Cuba 4040, Jesús María', 86, 1), -- id_cliente = 119, id_usuario = 86
(1, 'Yamileth Lizbeth', 'Palacios Saldaña', '99999945', NULL, NULL, 'Av. Wilson 10022, Cercado de Lima', NULL, 1), -- id_cliente = 120
(2, NULL, NULL, NULL, 'Farmacias del Pueblo SRL', '20000000101', 'Av. Garcilaso de la Vega 4141, Cercado de Lima', 87, 1), -- id_cliente = 121, id_usuario = 87
(1, 'Alexandra Belén', 'Quispe Mamani', '99999956', NULL, NULL, 'Jr. Puno 10023, Cercado de Lima', 88, 1), -- id_cliente = 122, id_usuario = 88
(2, NULL, NULL, NULL, 'Ferretaría El Maestro EIRL', '20000000103', 'Av. Colonial 4242, Callao', NULL, 1), -- id_cliente = 123
(1, 'Benito José', 'Reyes Sánchez', '99999967', NULL, NULL, 'Av. Argentina 10024, Callao', 89, 1), -- id_cliente = 124, id_usuario = 89
(2, NULL, NULL, NULL, 'Confecciones del Valle SAC', '20000000105', 'Jr. Junín 4343, Rímac', NULL, 1), -- id_cliente = 125
(1, 'Carla Daniela', 'Ramos Soto', '99999978', NULL, NULL, 'Av. Abancay 10025, Cercado de Lima', 90, 1), -- id_cliente = 126, id_usuario = 90
(2, NULL, NULL, NULL, 'Vigilancia y Seguridad Integral SRL', '20000000107', 'Av. Nicolás Ayllón 4444, La Victoria', 91, 1), -- id_cliente = 127, id_usuario = 91
(1, 'Diego Fabián', 'Salazar Vega', '99999989', NULL, NULL, 'Calle General Córdova 10026, Miraflores', NULL, 1), -- id_cliente = 128
(2, NULL, NULL, NULL, 'Diseño Gráfico Creativo EIRL', '20000000109', 'Av. Comandante Espinar 4545, Miraflores', 92, 1), -- id_cliente = 129, id_usuario = 92
(1, 'Eliana Sofía', 'Torres Bravo', '99999990', NULL, NULL, 'Jr. Pachacutec 10027, Jesús María', NULL, 1), -- id_cliente = 130
(2, NULL, NULL, NULL, 'Estudios de Arquitectura Moderna SAC', '20000000111', 'Av. Dos de Mayo 4646, San Isidro', 93, 1), -- id_cliente = 131, id_usuario = 93
(1, 'Franco Sebastián', 'Ugarte Ríos', '99999991', NULL, NULL, 'Av. Pardo y Aliaga 10028, San Isidro', 94, 1), -- id_cliente = 132, id_usuario = 94
(2, NULL, NULL, NULL, 'Joyería Fina y Accesorios SRL', '20000000113', 'Calle Las Begonias 4747, San Isidro', NULL, 1), -- id_cliente = 133
(1, 'Gaby Estefanía', 'Vargas Castro', '99999992', NULL, NULL, 'Av. República de Panamá 10029, Miraflores', 95, 1), -- id_cliente = 134, id_usuario = 95
(2, NULL, NULL, NULL, 'Agencia de Publicidad Creativa EIRL', '20000000115', 'Av. Arequipa 4848, Lince', NULL, 1), -- id_cliente = 135
(1, 'Héctor Manuel', 'Zapata Huamán', '99999993', NULL, NULL, 'Jr. Gamarra 10030, La Victoria', 96, 1), -- id_cliente = 136, id_usuario = 96
(2, NULL, NULL, NULL, 'Mueblería Artesanal SAC', '20000000117', 'Av. 28 de Julio 4949, Miraflores', 97, 1), -- id_cliente = 137, id_usuario = 97
(1, 'Iván Marcelo', 'Alvares Cárdenas', '99999994', NULL, NULL, 'Av. Petit Thouars 10031, Miraflores', NULL, 1), -- id_cliente = 138
(2, NULL, NULL, NULL, 'Clínica Veterinaria Amigos SRL', '20000000119', 'Jr. Washington 5050, Cercado de Lima', 98, 1), -- id_cliente = 139, id_usuario = 98
(1, 'Jazmín Isabel', 'Benavides Quispe', '99999995', NULL, NULL, 'Av. Faustino Sánchez Carrión 10032, San Isidro', NULL, 1), -- id_cliente = 140
(2, NULL, NULL, NULL, 'Catering y Eventos Gourmet EIRL', '20000000121', 'Av. La Encalada 5151, Surco', 99, 1), -- id_cliente = 141, id_usuario = 99
(1, 'Kevin Andrés', 'Cárdenas Luna', '99999996', NULL, NULL, 'Calle Los Pinos 10033, Surquillo', 100, 1), -- id_cliente = 142, id_usuario = 100
(2, NULL, NULL, NULL, 'Spa y Centro de Belleza Armonía SAC', '20000000123', 'Av. Camino Real 5252, San Isidro', NULL, 1), -- id_cliente = 143
(1, 'Laura Gabriela', 'Díaz Morales', '99999997', NULL, NULL, 'Av. Javier Prado Este 10034, San Borja', 101, 1), -- id_cliente = 144, id_usuario = 101
(2, NULL, NULL, NULL, 'Centro de Idiomas Global SRL', '20000000125', 'Av. Angamos Este 5353, Surquillo', 102, 1), -- id_cliente = 145, id_usuario = 102
(1, 'Mario Alejandro', 'Escobar Pinedo', '99999998', NULL, NULL, 'Jr. Gamarra 10035, La Victoria', NULL, 1), -- id_cliente = 146
(2, NULL, NULL, NULL, 'Repuestos Automotrices El Motor EIRL', '20000000127', 'Av. República de Chile 5454, Jesús María', 103, 1), -- id_cliente = 147, id_usuario = 103
(1, 'Natalia Camila', 'Ferrer Paredes', '99999999', NULL, NULL, 'Av. Salaverry 10036, Jesús María', NULL, 1), -- id_cliente = 148
(2, NULL, NULL, NULL, 'Emprendimientos Tecnológicos SAC', '20000000129', 'Av. San Felipe 5555, Jesús María', 104, 1), -- id_cliente = 149, id_usuario = 104
(1, 'Omar David', 'Gómez Ríos', '00000001', NULL, NULL, 'Jr. Cuzco 10037, Cercado de Lima', NULL, 1), -- id_cliente = 150
(2, NULL, NULL, NULL, 'Seguridad y Resguardo 24/7 SRL', '20000000131', 'Av. Comandante Espinar 5656, Miraflores', 105, 1), -- id_cliente = 151, id_usuario = 105
(1, 'Paola Ximena', 'Huamán Vargas', '00000002', NULL, NULL, 'Av. La Paz 10038, Miraflores', 106, 1), -- id_cliente = 152, id_usuario = 106
(2, NULL, NULL, NULL, 'Limpieza y Mantenimiento Urbano EIRL', '20000000133', 'Av. 28 de Julio 5757, La Victoria', NULL, 1), -- id_cliente = 153
(1, 'Renzo Daniel', 'Inca Solís', '00000003', NULL, NULL, 'Calle Cantuarias 10039, Miraflores', NULL, 1), -- id_cliente = 154
(2, NULL, NULL, NULL, 'Gestión Documental y Archivo SAC', '20000000135', 'Av. Benavides 5858, Miraflores', NULL, 1), -- id_cliente = 155
(1, 'Sandra Milagros', 'Juárez Torrez', '00000004', NULL, NULL, 'Jr. Huaraz 10040, Breña', NULL, 1), -- id_cliente = 156
(2, NULL, NULL, NULL, 'Transportes Terrestres Nacionales SRL', '20000000137', 'Av. Los Faisanes 5959, Chorrillos', NULL, 1), -- id_cliente = 157
(1, 'Tomás Leonardo', 'López Benavides', '00000005', NULL, NULL, 'Av. Las Gardenias 10041, Santiago de Surco', NULL, 1), -- id_cliente = 158
(2, NULL, NULL, NULL, 'Imprenta y Publicidad Express EIRL', '20000000139', 'Calle Las Camelias 6060, San Isidro', NULL, 1), -- id_cliente = 159
(1, 'Úrsula Cristina', 'Mendoza Quispe', '00000006', NULL, NULL, 'Av. Guardia Civil 10042, San Borja', NULL, 1), -- id_cliente = 160
(2, NULL, NULL, NULL, 'Equipos Médicos e Insumos SAC', '20000000141', 'Av. Canadá 6161, La Victoria', NULL, 1), -- id_cliente = 161
(1, 'Víctor Manuel', 'Núñez Bravo', '00000007', NULL, NULL, 'Jr. Arequipa 10043, Cercado de Lima', NULL, 1), -- id_cliente = 162
(2, NULL, NULL, NULL, 'Desarrollo de Software a Medida SRL', '20000000143', 'Av. Del Sol 6262, Surco', NULL, 1), -- id_cliente = 163
(1, 'Wendy Carolina', 'Ortiz Zapata', '00000008', NULL, NULL, 'Av. Salaverry 10044, Jesús María', NULL, 1), -- id_cliente = 164
(2, NULL, NULL, NULL, 'Asesoría Legal y Corporativa EIRL', '20000000145', 'Calle Diez Canseco 6363, Miraflores', NULL, 1), -- id_cliente = 165
(1, 'Ximena Alexandra', 'Pérez Ruiz', '00000009', NULL, NULL, 'Av. Los Conquistadores 10045, San Isidro', NULL, 1), -- id_cliente = 166
(2, NULL, NULL, NULL, 'Artículos de Oficina y Papelería SAC', '20000000147', 'Av. Petit Thouars 6464, Lince', NULL, 1), -- id_cliente = 167
(1, 'Yadira Marisol', 'Quispe Salas', '00000010', NULL, NULL, 'Jr. Rufino Torrico 10046, Cercado de Lima', NULL, 1), -- id_cliente = 168
(2, NULL, NULL, NULL, 'Comercio y Representaciones SRL', '20000000149', 'Av. Arequipa 6565, Miraflores', NULL, 1), -- id_cliente = 169
(1, 'Zulema Angélica', 'Ramos Silva', '00000011', NULL, NULL, 'Av. Pardo y Aliaga 10047, San Isidro', NULL, 1), -- id_cliente = 170
(2, NULL, NULL, NULL, 'Gestión de Proyectos y Obras EIRL', '20000000151', 'Av. José Galvez Barrenechea 6666, Lince', NULL, 1), -- id_cliente = 171
(1, 'Alberto Fabián', 'Sánchez Vargas', '00000012', NULL, NULL, 'Av. Sucre 10048, Pueblo Libre', NULL, 1), -- id_cliente = 172
(2, NULL, NULL, NULL, 'Servicios de Jardinería y Paisajismo SAC', '20000000153', 'Av. San Borja Sur 6767, San Borja', NULL, 1), -- id_cliente = 173
(1, 'Brenda Sofía', 'Torres Zapata', '00000013', NULL, NULL, 'Jr. Ancash 10049, Cercado de Lima', NULL, 1), -- id_cliente = 174
(2, NULL, NULL, NULL, 'Restaurante Fusión Criolla SRL', '20000000155', 'Calle Schell 6868, Miraflores', NULL, 1), -- id_cliente = 175
(1, 'Cristian Eduardo', 'Ugarte Chávez', '00000014', NULL, NULL, 'Av. La Paz 10050, Miraflores', NULL, 1), -- id_cliente = 176
(2, NULL, NULL, NULL, 'Lavandería Industrial y Hogar EIRL', '20000000157', 'Jr. Carabaya 6969, Cercado de Lima', NULL, 1), -- id_cliente = 177
(1, 'Daniela Michelle', 'Vargas Díaz', '00000015', NULL, NULL, 'Av. Las Begonias 10051, San Isidro', NULL, 1), -- id_cliente = 178
(2, NULL, NULL, NULL, 'Eventos Corporativos Premium SAC', '20000000159', 'Av. Conquistadores 7070, San Isidro', NULL, 1), -- id_cliente = 179
(1, 'Emilio Rafael', 'Vega Huamán', '00000016', NULL, NULL, 'Av. Primavera 10052, Surco', NULL, 1), -- id_cliente = 180
(2, NULL, NULL, NULL, 'Desarrollos Web y Apps SRL', '20000000161', 'Jr. Paruro 7171, Cercado de Lima', NULL, 1), -- id_cliente = 181
(1, 'Fernanda Celeste', 'Zapata López', '00000017', NULL, NULL, 'Av. Los Próceres 10053, Santiago de Surco', NULL, 1), -- id_cliente = 182
(2, NULL, NULL, NULL, 'Equipos de Seguridad Electrónica EIRL', '20000000163', 'Av. La Molina 7272, La Molina', NULL, 1), -- id_cliente = 183
(1, 'Gabriela Alejandra', 'Alvares Pérez', '00000018', NULL, NULL, 'Calle Los Laureles 10054, Ate', NULL, 1), -- id_cliente = 184
(2, NULL, NULL, NULL, 'Agencia de Modelaje y Talento SAC', '20000000165', 'Av. Paseo de la República 7373, La Victoria', NULL, 1), -- id_cliente = 185
(1, 'Hugo Ricardo', 'Benavides Quispe', '00000019', NULL, NULL, 'Jr. Gamarra 10055, La Victoria', NULL, 1), -- id_cliente = 186
(2, NULL, NULL, NULL, 'Servicios de Fumigación y Control de Plagas SRL', '20000000167', 'Av. Las Américas 7474, Lince', NULL, 1), -- id_cliente = 187
(1, 'Isabella Victoria', 'Castro Salas', '00000020', NULL, NULL, 'Av. Sucre 10056, Pueblo Libre', NULL, 1), -- id_cliente = 188
(2, NULL, NULL, NULL, 'Consultores de Marketing Digital EIRL', '20000000169', 'Av. Angamos Oeste 7575, Miraflores', NULL, 1), -- id_cliente = 189
(1, 'Juan David', 'Díaz Morales', '00000021', NULL, NULL, 'Jr. Lampa 10057, Cercado de Lima', NULL, 1), -- id_cliente = 190
(2, NULL, NULL, NULL, 'Librería y Bazar El Lector SAC', '20000000171', 'Av. Benavides 7676, Miraflores', NULL, 1), -- id_cliente = 191
(1, 'Karen Sofía', 'Escobar Pinedo', '00000022', NULL, NULL, 'Av. Del Ejército 10058, San Isidro', NULL, 1), -- id_cliente = 192
(2, NULL, NULL, NULL, 'Inversiones en Bienes Raíces SRL', '20000000173', 'Calle San Martín 7777, Miraflores', NULL, 1), -- id_cliente = 193
(1, 'Luis Fernando', 'Ferrer Paredes', '00000023', NULL, NULL, 'Jr. Miró Quesada 10059, Cercado de Lima', NULL, 1), -- id_cliente = 194
(2, NULL, NULL, NULL, 'Productos Orgánicos Saludables EIRL', '20000000175', 'Av. Comandante Espinar 7878, Miraflores', NULL, 1), -- id_cliente = 195
(1, 'María Emilia', 'Gómez Ríos', '00000024', NULL, NULL, 'Av. Paseo de la Castellana 10060, Santiago de Surco', NULL, 1), -- id_cliente = 196
(2, NULL, NULL, NULL, 'Fábrica de Ropa y Accesorios SAC', '20000000177', 'Jr. Azángaro 7979, Cercado de Lima', NULL, 1), -- id_cliente = 197
(1, 'Nicolás Alejandro', 'Huamán Vargas', '00000025', NULL, NULL, 'Av. El Polo 10061, Surco', NULL, 1), -- id_cliente = 198
(2, NULL, NULL, NULL, 'Servicios de Traducción Profesional SRL', '20000000179', 'Av. Aramburú 8080, San Isidro', NULL, 1), -- id_cliente = 199
(1, 'Olivia Patricia', 'Inca Solís', '00000026', NULL, NULL, 'Av. De Las Artes Norte 10062, San Borja', NULL, 1), -- id_cliente = 200
(2, NULL, NULL, NULL, 'Soluciones en Redes y Telecomunicaciones EIRL', '20000000181', 'Jr. Puno 8181, Cercado de Lima', NULL, 1), -- id_cliente = 201
(1, 'Pedro José', 'Juárez Torrez', '00000027', NULL, NULL, 'Av. Salaverry 10063, Jesús María', NULL, 1), -- id_cliente = 202
(2, NULL, NULL, NULL, 'Estudios de Fotografía y Video SAC', '20000000183', 'Av. Javier Prado Este 8282, San Isidro', NULL, 1), -- id_cliente = 203
(1, 'Quispe María', 'Luna Morales', '00000028', NULL, NULL, 'Calle Los Cedros 10064, San Isidro', NULL, 1), -- id_cliente = 204
(2, NULL, NULL, NULL, 'Consultora de Negocios y Estrategia SRL', '20000000185', 'Av. Angamos Oeste 8383, Miraflores', NULL, 1), -- id_cliente = 205
(1, 'Rafael Antonio', 'Medina Chávez', '00000029', NULL, NULL, 'Av. Dos de Mayo 10065, San Isidro', NULL, 1), -- id_cliente = 206
(2, NULL, NULL, NULL, 'Sistemas de Seguridad Alarmas EIRL', '20000000187', 'Av. Caminos del Inca 8484, Surco', NULL, 1), -- id_cliente = 207
(1, 'Sandra Elizabeth', 'Nieto Pérez', '00000030', NULL, NULL, 'Jr. Zepita 10066, Cercado de Lima', NULL, 1), -- id_cliente = 208
(2, NULL, NULL, NULL, 'Colegio Bilingüe San Marcos SAC', '20000000189', 'Av. Caminos del Inca 8585, Surco', NULL, 1), -- id_cliente = 209
(1, 'Tomás Gabriel', 'Ortiz Ramos', '00000031', NULL, NULL, 'Av. La Paz 10067, Miraflores', NULL, 1), -- id_cliente = 210
(2, NULL, NULL, NULL, 'Centro de Rehabilitación Física SRL', '20000000191', 'Calle Roma 8686, San Isidro', NULL, 1), -- id_cliente = 211
(1, 'Úrsula Raquel', 'Palacios Saldaña', '00000032', NULL, NULL, 'Av. Pardo y Aliaga 10068, San Isidro', NULL, 1), -- id_cliente = 212
(2, NULL, NULL, NULL, 'Agencia de Aduanas y Comercio Exterior EIRL', '20000000193', 'Av. José Pardo 8787, Miraflores', NULL, 1), -- id_cliente = 213
(1, 'Víctor Manuel', 'Quispe Mamani', '00000033', NULL, NULL, 'Jr. Las Moras 10069, Los Olivos', NULL, 1), -- id_cliente = 214
(2, NULL, NULL, NULL, 'Estudios Contables y Tributarios SAC', '20000000195', 'Av. El Polo 8888, Surco', NULL, 1), -- id_cliente = 215
(1, 'Wendy Alexandra', 'Ramos Soto', '00000034', NULL, NULL, 'Av. Las Lomas 10070, La Molina', NULL, 1), -- id_cliente = 216
(2, NULL, NULL, NULL, 'Tienda de Ropa Deportiva SRL', '20000000197', 'Jr. Huancayo 8989, Breña', NULL, 1), -- id_cliente = 217
(1, 'Ximena Belén', 'Reyes Sánchez', '00000035', NULL, NULL, 'Av. Brasil 10071, Jesús María', NULL, 1), -- id_cliente = 218
(2, NULL, NULL, NULL, 'Servicios de Catering y Banquetes EIRL', '20000000199', 'Av. Sucre 9090, Pueblo Libre', NULL, 1), -- id_cliente = 219
(1, 'Yadira Cecilia', 'Salazar Vega', '00000036', NULL, NULL, 'Jr. Ancash 10072, Cercado de Lima', NULL, 1), -- id_cliente = 220
(2, NULL, NULL, NULL, 'Consultoría en TI e Infraestructura SAC', '20000000201', 'Av. Arequipa 9191, Miraflores', NULL, 1), -- id_cliente = 221
(1, 'Zoe Lizbeth', 'Torres Bravo', '00000037', NULL, NULL, 'Av. Primavera 10073, Surco', NULL, 1), -- id_cliente = 222
(2, NULL, NULL, NULL, 'Lavacar y Detailing Automotriz SRL', '20000000203', 'Calle Bolognesi 9292, Miraflores', NULL, 1), -- id_cliente = 223
(1, 'Alonso Fabián', 'Ugarte Ríos', '00000038', NULL, NULL, 'Av. Angamos Oeste 10074, Miraflores', NULL, 1), -- id_cliente = 224
(2, NULL, NULL, NULL, 'Asesoría de Seguros y Riesgos EIRL', '20000000205', 'Jr. Cusco 9393, Magdalena', NULL, 1), -- id_cliente = 225
(1, 'Beatriz Elena', 'Vargas Castro', '00000039', NULL, NULL, 'Av. Dos de Mayo 10075, San Isidro', NULL, 1), -- id_cliente = 226
(2, NULL, NULL, NULL, 'Distribuidora de Productos de Limpieza SAC', '20000000207', 'Av. Guardia Civil 9494, San Borja', NULL, 1), -- id_cliente = 227
(1, 'Carlos Eduardo', 'Vega Huamán', '00000040', NULL, NULL, 'Jr. Quilca 10076, Cercado de Lima', NULL, 1), -- id_cliente = 228
(2, NULL, NULL, NULL, 'Academia de Baile y Arte SRL', '20000000209', 'Av. San Felipe 9595, Jesús María', NULL, 1), -- id_cliente = 229
(1, 'Daniela Michelle', 'Zapata López', '00000041', NULL, NULL, 'Av. Aramburú 10077, San Isidro', NULL, 1), -- id_cliente = 230
(2, NULL, NULL, NULL, 'Centro Psicológico Integral EIRL', '20000000211', 'Calle Diez Canseco 9696, Miraflores', NULL, 1), -- id_cliente = 231
(1, 'Elías Gabriel', 'Alvares Pérez', '00000042', NULL, NULL, 'Av. Arequipa 10078, Lince', NULL, 1), -- id_cliente = 232
(2, NULL, NULL, NULL, 'Juguetería El Mundo Feliz SAC', '20000000213', 'Av. Benavides 9797, Miraflores', NULL, 1), -- id_cliente = 233
(1, 'Fernanda Sofía', 'Benavides Quispe', '00000043', NULL, NULL, 'Jr. Gamarra 10079, La Victoria', NULL, 1), -- id_cliente = 234
(2, NULL, NULL, NULL, 'Peluquería y Spa Urbano SRL', '20000000215', 'Av. La Paz 9898, Miraflores', NULL, 1), -- id_cliente = 235
(1, 'Gustavo Andrés', 'Castro Salas', '00000044', NULL, NULL, 'Av. Pardo y Aliaga 10080, San Isidro', NULL, 1), -- id_cliente = 236
(2, NULL, NULL, NULL, 'Estudios de Grabación Musical EIRL', '20000000217', 'Av. El Polo 9999, Surco', NULL, 1), -- id_cliente = 237
(1, 'Hilary Nicole', 'Díaz Morales', '00000045', NULL, NULL, 'Calle Enrique Palacios 10081, Miraflores', NULL, 1), -- id_cliente = 238
(2, NULL, NULL, NULL, 'Tienda de Electrónica y Gadgets SAC', '20000000219', 'Av. Primavera 10000, Surco', NULL, 1), -- id_cliente = 239
(1, 'Isaac Mateo', 'Escobar Pinedo', '00000046', NULL, NULL, 'Av. Javier Prado Este 10082, San Borja', NULL, 1), -- id_cliente = 240
(2, NULL, NULL, NULL, 'Servicios de Courier y Mensajería SRL', '20000000221', 'Jr. Miro Quesada 10001, Cercado de Lima', NULL, 1), -- id_cliente = 241
(1, 'Jacqueline Lizbeth', 'Ferrer Paredes', '00000047', NULL, NULL, 'Av. Universitaria 10083, Los Olivos', NULL, 1), -- id_cliente = 242
(2, NULL, NULL, NULL, 'Comercializadora de Productos Químicos EIRL', '20000000223', 'Av. San Juan 10002, San Juan de Miraflores', NULL, 1), -- id_cliente = 243
(1, 'Kevin Alexander', 'Gómez Ríos', '00000048', NULL, NULL, 'Av. Huaylas 10084, Chorrillos', NULL, 1), -- id_cliente = 244
(2, NULL, NULL, NULL, 'Asesoría Nutricional y Deportiva SAC', '20000000225', 'Av. Los Constructores 10003, La Molina', NULL, 1), -- id_cliente = 245
(1, 'Lorena Andrea', 'Huamán Vargas', '00000049', NULL, NULL, 'Jr. Paruro 10085, Cercado de Lima', NULL, 1), -- id_cliente = 246
(2, NULL, NULL, NULL, 'Venta de Artículos para el Hogar SRL', '20000000227', 'Av. Salaverry 10004, Jesús María', NULL, 1), -- id_cliente = 247
(1, 'Marco Antonio', 'Inca Solís', '00000050', NULL, NULL, 'Calle Los Robles 10086, Surquillo', NULL, 1), -- id_cliente = 248
(2, NULL, NULL, NULL, 'Servicios de Plomería y Gasfitería EIRL', '20000000229', 'Av. La Paz 10005, Miraflores', NULL, 1), -- id_cliente = 249
(1, 'Nancy Patricia', 'Juárez Torrez', '00000051', NULL, NULL, 'Jr. Junín 10087, Rímac', NULL, 1); -- id_cliente = 250

GO

---

-- *** 10. INSERCIONES PARA CLIENTECORREOS ***
INSERT INTO ClienteCorreos (id_cliente, email) VALUES
(1, 'andrea.vega@email.com'), (2, 'roberto.quispe@email.com'), (3, 'sofia.castro@email.com'),
(4, 'diego.flores@email.com'), (5, 'valeria.nunez@email.com'), (6, 'contacto@laesquina.com'),
(7, 'ventas@elvecino.pe'), (8, 'info@laconfianza.com'), (9, 'gerencia@supermercadoexpress.com'),
(10, 'compras@distribuidoraxyz.com');

-- Correos para los 240 clientes adicionales (continuando la numeración)
INSERT INTO ClienteCorreos (id_cliente, email) VALUES
(1, 'andrea.vega@example.com'),
(2, 'roberto.quispe@example.com'),
(3, 'sofia.castro@example.com'),
(4, 'diego.flores@example.com'),
(5, 'valeria.nunez@example.com'),
(6, 'contacto@tiendaladesquina.com'),
(7, 'ventas@minimarketelvecino.com'),
(8, 'info@bodegalaconfianza.com'),
(9, 'clientes@supermercadoexpress.com'),
(10, 'comercial@distribuidoraxyz.com'),
(11, 'carlos.garcia@example.com'),
(12, 'maria.diaz@example.com'),
(13, 'jose.soto@example.com'),
(14, 'ana.ramirez@example.com'),
(15, 'luis.quispe@example.com'),
(16, 'carmen.gonzales@example.com'),
(17, 'david.vargas@example.com'),
(18, 'elena.ramos@example.com'),
(19, 'gabriel.mendoza@example.com'),
(20, 'isabel.torres@example.com'),
(21, 'juan.gutierrez@example.com'),
(22, 'laura.chavez@example.com'),
(23, 'miguel.silva@example.com'),
(24, 'natalia.paredes@example.com'),
(25, 'oscar.cardenas@example.com'),
(26, 'patricia.salazar@example.com'),
(27, 'ricardo.ferrer@example.com'),
(28, 'silvia.valdez@example.com'),
(29, 'tomas.gomez@example.com'),
(30, 'ursula.zapata@example.com'),
(31, 'info@serviciosintegralesperu.com'),
(32, 'ventas@importacionesdelnorte.com'),
(33, 'victor.rios@example.com'),
(34, 'contacto@distribuidoradelcentro.com'),
(35, 'wendy.soto@example.com'),
(36, 'ximena.vasquez@example.com'),
(37, 'info@construccionesandinas.com'),
(38, 'yanira.chavez@example.com'),
(39, 'zulema.flores@example.com'),
(40, 'contacto@tecnologiaperuana.com'),
(41, 'adriana.ramirez@example.com'),
(42, 'ventas@solucionesdigitales.com'),
(43, 'benjamin.vargas@example.com'),
(44, 'info@alimentosdelsur.com'),
(45, 'camila.ferrer@example.com'),
(46, 'daniel.valdez@example.com'),
(47, 'contacto@transporteselrapido.com'),
(48, 'estefania.nunez@example.com'),
(49, 'fernando.zapata@example.com'),
(50, 'ventas@textilesfinos.com'),
(51, 'gisella.medina@example.com'),
(52, 'info@inversionesglobales.com'),
(53, 'hector.perez@example.com'),
(54, 'irene.gomez@example.com'),
(55, 'contacto@comercializadoradelsol.com'),
(56, 'joaquin.vargas@example.com'),
(57, 'logistica@logisticaavanzada.com'),
(58, 'karen.castro@example.com'),
(59, 'leonardo.diaz@example.com'),
(60, 'info@constructorafuturo.com'),
(61, 'maria.pia@example.com'),
(62, 'contacto@marketinginnovador.com'),
(63, 'nicolas.andres@example.com'),
(64, 'olivia.fernanda@example.com'),
(65, 'ventas@editorialelsaber.com'),
(66, 'pedro.vasquez@example.com'),
(67, 'info@consultoresbc.com'),
(68, 'renata.torres@example.com'),
(69, 'sergio.mendoza@example.com'),
(70, 'contacto@industriasdelvalle.com'),
(71, 'valeria.silva@example.com'),
(72, 'walter.carrillo@example.com'),
(73, 'info@energiasrenovables.com'),
(74, 'yolanda.huaman@example.com'),
(75, 'zoe.salazar@example.com'),
(76, 'contacto@desarrollosinmobiliarios.com'),
(77, 'alejandra.garcia@example.com'),
(78, 'finanzas@serviciosfinancierosperu.com'),
(79, 'bruno.sebastian@example.com'),
(80, 'cecilia.andrea@example.com'),
(81, 'info@graficosmodernos.com'),
(82, 'daniela.fernanda@example.com'),
(83, 'ventas@tecnologiasdelmanana.com'),
(84, 'emilio.jose@example.com'),
(85, 'contacto@exportadoraperu.com'),
(86, 'fabiola.belen@example.com'),
(87, 'medico@serviciosmedicosa1.com'),
(88, 'gonzalo.rodrigo@example.com'),
(89, 'comex@comercioexterior.com'),
(90, 'helena.sofia@example.com'),
(91, 'info@solucioneselectricas.com'),
(92, 'ignacio.felipe@example.com'),
(93, 'reservas@serviciosturisticosperu.com'),
(94, 'jimena.belen@example.com'),
(95, 'ventas@textilesandinos.com'),
(96, 'kevin.matias@example.com'),
(97, 'contacto@eventosyconciertos.com'),
(98, 'lucia.camila@example.com'),
(99, 'info@panaderialaideal.com'),
(100, 'manuel.antonio@example.com'),
(101, 'contacto@educacionvirtual.com'),
(102, 'nuria.esther@example.com'),
(103, 'contabilidad@servicioscontablesprofesionales.com'),
(104, 'oscar.raul@example.com'),
(105, 'rrh@recursoshumanosglobal.com'),
(106, 'pamela.ximena@example.com'),
(107, 'ventas@fabricademueblesmodernos.com'),
(108, 'raul.alberto@example.com'),
(109, 'info@productosagricolasdelcampo.com'),
(110, 'samantha.nicole@example.com'),
(111, 'asesoria@consultoriaambiental.com'),
(112, 'thiago.gabriel@example.com'),
(113, 'contacto@agenciadeviajesyturismo.com'),
(114, 'ursula.maria@example.com'),
(115, 'info@serviciosdelimpiezaintegral.com'),
(116, 'valeria.celeste@example.com'),
(117, 'reservas@restaurantesaborperuano.com'),
(118, 'william.ernesto@example.com'),
(119, 'citas@centromedicoespecializado.com'),
(120, 'yamileth.lizbeth@example.com'),
(121, 'farmacia@farmaciasdelpueblo.com'),
(122, 'alexandra.quispe@example.com'),
(123, 'ventas@ferreteriaelmaestro.com'),
(124, 'benito.jose@example.com'),
(125, 'info@confeccionesdelvalle.com'),
(126, 'carla.daniela@example.com'),
(127, 'contacto@vigilanciayseguridadintegral.com'),
(128, 'diego.fabian@example.com'),
(129, 'diseno@disenograficocreativo.com'),
(130, 'eliana.sofia@example.com'),
(131, 'proyectos@estudiosdearquitecturamoderna.com'),
(132, 'franco.sebastian@example.com'),
(133, 'ventas@joyeriafinaaccesorios.com'),
(134, 'gaby.estefania@example.com'),
(135, 'creativa@agenciadepublicidadcreativa.com'),
(136, 'hector.manuel@example.com'),
(137, 'info@muebleriaartesanal.com'),
(138, 'ivan.marcelo@example.com'),
(139, 'citas@clinicaveterinariaamigos.com'),
(140, 'jazmin.isabel@example.com'),
(141, 'eventos@cateringyeventosgourmet.com'),
(142, 'kevin.andres@example.com'),
(143, 'info@spacentrodebellezaarmonia.com'),
(144, 'laura.gabriela@example.com'),
(145, 'inscripciones@centrodeidiomasglobal.com'),
(146, 'mario.alejandro@example.com'),
(147, 'ventas@repuestosautomotriceselmotor.com'),
(148, 'natalia.camila@example.com'),
(149, 'contacto@emprendimientostecnologicos.com'),
(150, 'omar.david@example.com'),
(151, 'seguridad@seguridadyresguardo247.com'),
(152, 'paola.ximena@example.com'),
(153, 'limpieza@limpiezaymantenimientourbano.com'),
(154, 'renzo.daniel@example.com'),
(155, 'gestion@gestiondocumentalyarchivo.com'),
(156, 'sandra.milagros@example.com'),
(157, 'info@transportesterrestresnacionales.com'),
(158, 'tomas.leonardo@example.com'),
(159, 'impresiones@imprentaypublicidadexpress.com'),
(160, 'ursula.cristina@example.com'),
(161, 'ventas@equiposmedicosinsumos.com'),
(162, 'victor.manuel@example.com'),
(163, 'soporte@desarrollodesoftwareamedida.com'),
(164, 'wendy.carolina@example.com'),
(165, 'legal@asesorialegalycorporativa.com'),
(166, 'ximena.alexandra@example.com'),
(167, 'ventas@articulosdeoficinaypapeleria.com'),
(168, 'yadira.marisol@example.com'),
(169, 'comercial@comercioyrepresentaciones.com'),
(170, 'zulema.angelica@example.com'),
(171, 'proyectos@gestiondeproyectosyobras.com'),
(172, 'alberto.fabian@example.com'),
(173, 'jardineria@serviciosdejardineriaypaisajismo.com'),
(174, 'brenda.sofia@example.com'),
(175, 'reservas@restaurantefusioncriolla.com'),
(176, 'cristian.eduardo@example.com'),
(177, 'info@lavanderiaindustrialyhogar.com'),
(178, 'daniela.michelle@example.com'),
(179, 'eventos@eventoscorporativospremium.com'),
(180, 'emilio.rafael@example.com'),
(181, 'contacto@desarrolloswebapps.com'),
(182, 'fernanda.celeste@example.com'),
(183, 'ventas@equiposdeseguridadelectronica.com'),
(184, 'gabriela.alejandra@example.com'),
(185, 'casting@agenciademodelajeytalento.com'),
(186, 'hugo.ricardo@example.com'),
(187, 'info@serviciosdefumigacionycontroldeplagas.com'),
(188, 'isabella.victoria@example.com'),
(189, 'digital@consultoresdemarketingdigital.com'),
(190, 'juan.david@example.com'),
(191, 'contacto@libreriaybazarellector.com'),
(192, 'karen.sofia@example.com'),
(193, 'ventas@inversionesenbienesraices.com'),
(194, 'luis.fernando@example.com'),
(195, 'pedidos@productosorganicossaludables.com'),
(196, 'maria.emilia@example.com'),
(197, 'ventas@fabricaderopayaccesorios.com'),
(198, 'nicolas.alejandro@example.com'),
(199, 'info@serviciosdetraduccionprofesional.com'),
(200, 'olivia.patricia@example.com'),
(201, 'soporte@solucionesenredesytelecomunicaciones.com'),
(202, 'pedro.jose@example.com'),
(203, 'contacto@estudiosdefotografiayvideo.com'),
(204, 'quispe.maria@example.com'),
(205, 'asesoria@consultoradenegociosyestrategia.com'),
(206, 'rafael.antonio@example.com'),
(207, 'ventas@sistemasdeseguridadalarmas.com'),
(208, 'sandra.elizabeth@example.com'),
(209, 'admision@colegiobilinguesanmarcos.com'),
(210, 'tomas.gabriel@example.com'),
(211, 'citas@centroderedahilitacionfisica.com'),
(212, 'ursula.raquel@example.com'),
(213, 'aduana@agenciadeaduanasycomercioexterior.com'),
(214, 'victor.manuel@example.com'),
(215, 'info@estudioscontablesytributarios.com'),
(216, 'wendy.alexandra@example.com'),
(217, 'ventas@tienderopadeportiva.com'),
(218, 'ximena.belen@example.com'),
(219, 'eventos@serviciosdecateringybanquetes.com'),
(220, 'yadira.cecilia@example.com'),
(221, 'soporte@consultoriaentiinfraestructura.com'),
(222, 'zoe.lizbeth@example.com'),
(223, 'contacto@lavacarydetailingautomotriz.com'),
(224, 'alonso.fabian@example.com'),
(225, 'seguros@asesoriadesegurosyriesgos.com'),
(226, 'beatriz.elena@example.com'),
(227, 'ventas@distribuidoraproductosdelimpieza.com'),
(228, 'carlos.eduardo@example.com'),
(229, 'contacto@academiadebaileyarte.com'),
(230, 'daniela.michelle@example.com'),
(231, 'info@centropsicologicointegral.com'),
(232, 'elias.gabriel@example.com'),
(233, 'ventas@jugueteriaelmundofeliz.com'),
(234, 'fernanda.sofia@example.com'),
(235, 'reservas@peluqueriayspaurbano.com'),
(236, 'gustavo.andres@example.com'),
(237, 'info@estudiosdegrabacionmusical.com'),
(238, 'hilary.nicole@example.com'),
(239, 'ventas@tiendaelectronicagadgets.com'),
(240, 'isaac.mateo@example.com'),
(241, 'courier@serviciosdecouriermensajeria.com'),
(242, 'jacqueline.lizbeth@example.com'),
(243, 'ventas@comercializadoraproductosquimicos.com'),
(244, 'kevin.alexander@example.com'),
(245, 'asesoria@asesorianutricionalydeportiva.com'),
(246, 'lorena.andrea@example.com'),
(247, 'ventas@ventadearticulosparaelhogar.com'),
(248, 'marco.antonio@example.com'),
(249, 'contacto@serviciosdeplomeriaygasfiteria.com'),
(250, 'nancy.patricia@example.com');
GO

---

-- *** 11. INSERCIONES PARA CLIENTETELEFONOS ***
INSERT INTO ClienteTelefonos (id_cliente, telefono) VALUES
(1, '991234567'), (2, '982345678'), (3, '973456789'), (4, '964567890'), (5, '955678901'),
(6, '946789012'), (7, '937890123'), (8, '928901234'), (9, '919012345'), (10, '900123456');

-- Teléfonos para los 240 clientes adicionales (continuando la numeración)
INSERT INTO ClienteTelefonos (id_cliente, telefono) VALUES
(11, '900000011'), (12, '900000012'), (13, '900000013'), (14, '900000014'), (15, '900000015'),
(16, '900000016'), (17, '900000017'), (18, '900000018'), (19, '900000019'), (20, '900000020'),
(21, '900000021'), (22, '900000022'), (23, '900000023'), (24, '900000024'), (25, '900000025'),
(26, '900000026'), (27, '900000027'), (28, '900000028'), (29, '900000029'), (30, '900000030'),
(31, '900000031'), (32, '900000032'), (33, '900000033'), (34, '900000034'), (35, '900000035'),
(36, '900000036'), (37, '900000037'), (38, '900000038'), (39, '900000039'), (40, '900000040'),
(41, '900000041'), (42, '900000042'), (43, '900000043'), (44, '900000044'), (45, '900000045'),
(46, '900000046'), (47, '900000047'), (48, '900000048'), (49, '900000049'), (50, '900000050'),
(51, '900000051'), (52, '900000052'), (53, '900000053'), (54, '900000054'), (55, '900000055'),
(56, '900000056'), (57, '900000057'), (58, '900000058'), (59, '900000059'), (60, '900000060'),
(61, '900000061'), (62, '900000062'), (63, '900000063'), (64, '900000064'), (65, '900000065'),
(66, '900000066'), (67, '900000067'), (68, '900000068'), (69, '900000069'), (70, '900000070'),
(71, '900000071'), (72, '900000072'), (73, '900000073'), (74, '900000074'), (75, '900000075'),
(76, '900000076'), (77, '900000077'), (78, '900000078'), (79, '900000079'), (80, '900000080'),
(81, '900000081'), (82, '900000082'), (83, '900000083'), (84, '900000084'), (85, '900000085'),
(86, '900000086'), (87, '900000087'), (88, '900000088'), (89, '900000089'), (90, '900000090'),
(91, '900000091'), (92, '900000092'), (93, '900000093'), (94, '900000094'), (95, '900000095'),
(96, '900000096'), (97, '900000097'), (98, '900000098'), (99, '900000099'), (100, '900000100'),
(101, '900000101'), (102, '900000102'), (103, '900000103'), (104, '900000104'), (105, '900000105'),
(106, '900000106'), (107, '900000107'), (108, '900000108'), (109, '900000109'), (110, '900000110'),
(111, '900000111'), (112, '900000112'), (113, '900000113'), (114, '900000114'), (115, '900000115'),
(116, '900000116'), (117, '900000117'), (118, '900000118'), (119, '900000119'), (120, '900000120'),
(121, '900000121'), (122, '900000122'), (123, '900000123'), (124, '900000124'), (125, '900000125'),
(126, '900000126'), (127, '900000127'), (128, '900000128'), (129, '900000129'), (130, '900000130'),
(131, '900000131'), (132, '900000132'), (133, '900000133'), (134, '900000134'), (135, '900000135'),
(136, '900000136'), (137, '900000137'), (138, '900000138'), (139, '900000139'), (140, '900000140'),
(141, '900000141'), (142, '900000142'), (143, '900000143'), (144, '900000144'), (145, '900000145'),
(146, '900000146'), (147, '900000147'), (148, '900000148'), (149, '900000149'), (150, '900000150'),
(151, '900000151'), (152, '900000152'), (153, '900000153'), (154, '900000154'), (155, '900000155'),
(156, '900000156'), (157, '900000157'), (158, '900000158'), (159, '900000159'), (160, '900000160'),
(161, '900000161'), (162, '900000162'), (163, '900000163'), (164, '900000164'), (165, '900000165'),
(166, '900000166'), (167, '900000167'), (168, '900000168'), (169, '900000169'), (170, '900000170'),
(171, '900000171'), (172, '900000172'), (173, '900000173'), (174, '900000174'), (175, '900000175'),
(176, '900000176'), (177, '900000177'), (178, '900000178'), (179, '900000179'), (180, '900000180'),
(181, '900000181'), (182, '900000182'), (183, '900000183'), (184, '900000184'), (185, '900000185'),
(186, '900000186'), (187, '900000187'), (188, '900000188'), (189, '900000189'), (190, '900000190'),
(191, '900000191'), (192, '900000192'), (193, '900000193'), (194, '900000194'), (195, '900000195'),
(196, '900000196'), (197, '900000197'), (198, '900000198'), (199, '900000199'), (200, '900000200'),
(201, '900000201'), (202, '900000202'), (203, '900000203'), (204, '900000204'), (205, '900000205'),
(206, '900000206'), (207, '900000207'), (208, '900000208'), (209, '900000209'), (210, '900000210'),
(211, '900000211'), (212, '900000212'), (213, '900000213'), (214, '900000214'), (215, '900000215'),
(216, '900000216'), (217, '900000217'), (218, '900000218'), (219, '900000219'), (220, '900000220'),
(221, '900000221'), (222, '900000222'), (223, '900000223'), (224, '900000224'), (225, '900000225'),
(226, '900000226'), (227, '900000227'), (228, '900000228'), (229, '900000229'), (230, '900000230'),
(231, '900000231'), (232, '900000232'), (233, '900000233'), (234, '900000234'), (235, '900000235'),
(236, '900000236'), (237, '900000237'), (238, '900000238'), (239, '900000239'), (240, '900000240'),
(241, '900000241'), (242, '900000242'), (243, '900000243'), (244, '900000244'), (245, '900000245'),
(246, '900000246'), (247, '900000247'), (248, '900000248'), (249, '900000249'), (250, '900000250');
GO
--FIN PROVEEDORES-----------------------------------------------------------------------------

--CATEGORIA DE PRODUCTOS
INSERT INTO CategoriaProductos (nombreCategoria) VALUES --20 filas-
('Alimentos'),
('Bebidas'),
('Lácteos'),
('Limpieza'),
('Conservas'),
('Panadería'),
('Abarrotes secos'),
('Enlatados'),
('Snacks'),
('Granos y cereales'),
('Frutas y Verduras'),
('Carnes y Embutidos'),
('Pescados y Mariscos'),
('Congelados'),
('Aceites y Vinagres'),
('Salsas y Condimentos'),	
('Dulces y Postres'),
('Cuidado Personal'),
('Artículos para el Hogar'),
('Mascotas');   
		

--PRESENTACION
INSERT INTO Presentacion (nombrePresentacion) VALUES -- 26 filas--
('Bolsa'),
('Botella'),
('Caja'),
('Lata'),		
('Paquete'),
('Sachet'), 
('Bidón'),
('Tubo'),
('Roll-on'),
('Barra'),
('Ampolla'),
('Estuche'),
('Granel'),
('Envase al vacío'),
('Flow-pack'),		
('Bandeja'),
('Blíster'),
('Frasco'),
('Galón'),
('Unidad'),
('Display'),
('Doypack'),
('Pote'),
('Tarrina'),
('Fardo'),
('Six-pack');


--TIPO EMPAQUE
INSERT INTO TipoEmpaque (nombreEmpaque, material) VALUES  --38--
('Empaque plástico', 'Plástico'),
('Empaque de cartón', 'Cartón'),
('Empaque metálico', 'Metal'),
('Empaque de vidrio', 'Vidrio'),
('Empaque biodegradable', 'Fibra vegetal'),	
('Empaque laminado', 'Multicapa'),
('Empaque de papel', 'Papel'),
('Empaque flexible', 'Plástico/Aluminio'),
('Empaque al vacío', 'Plástico'),
('Empaque de tela', 'Tela'),
('Blíster de PVC', 'PVC'),
('Tarrina de PP', 'Polipropileno'),
('Botella PET', 'PET'),
('Frasco de vidrio oscuro', 'Vidrio'),
('Envase Tetrapak', 'Cartón/Aluminio/Plástico'),
('Saco de rafia', 'Polipropileno tejido'),
('Red de malla', 'Plástico'),
('Bolsa Stand-up Pouch', 'Multicapa flexible'),
('Cilindro de cartón', 'Cartón'),
('Estuche tipo blíster', 'Cartón/Plástico'),
('Cápsula de gelatina', 'Gelatina'),
('Película adherente', 'Plástico'),
('Malla elástica', 'Elastomérico'),
('Bolsa doypack con zipper', 'Multicapa flexible'),
('Tapa de rosca', 'Plástico/Metal'),
('Bote de conserva hermético', 'Metal'),
('Botella de aluminio', 'Aluminio'),
('Caja con ventana', 'Cartón/Plástico'),
('Rollo film estirable', 'Plástico'),
('Bolsa de papel kraft', 'Papel Kraft');
Go

-- Inserciones para Productos (200 productos distintos)
INSERT INTO Productos (codigo, nombre, descripcion, precio, precioventa, stock, stock_minimo, unidad_medida, id_proveedor, idCategoria, idPresentacion, idTipoEmpaque, activo,imagen_url) VALUES
-- Alimentos (idCategoria = 1)
('PROD001', 'Arroz Superior Extra', 'Arroz blanco de grano largo, ideal para todo tipo de comidas.', 5.50, 6.60, 500, 50, 'kg', 1, 1, 1, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/30568837-512-512/20349946.jpg'),
('PROD002', 'Azúcar Rubia Especial', 'Azúcar de caña, granulada, para uso diario.', 4.20, 5.04, 700, 70, 'kg', 3, 1, 1, 1, 1,'https://acdn-us.mitiendanube.com/stores/099/082/products/azucar-organica-yin-yang1-b7756c17855b19949615712460340405-1024-1024.jpg'),
('PROD003', 'Fideos Spaguetti Delgados', 'Fideos de trigo duro, cocción rápida.', 3.80, 4.56, 400, 40, 'paquete', 7, 1, 5, 2, 1,'https://vegaperu.vtexassets.com/arquivos/ids/160023/7754137001166.jpg?v=637907572249300000'),
('PROD004', 'Harina Preparada Blancaflor', 'Harina de trigo fortificada, para repostería.', 6.10, 7.32, 300, 30, 'kg', 1, 1, 5, 2, 1,'https://oechsle.vteximg.com.br/arquivos/ids/1856711-1000-1000/image-75141ec8bf96407890ed1721c03de574.jpg?v=637495322349930000'),
('PROD005', 'Arroz Jazmín Aromático', 'Arroz aromático de alta calidad.', 7.00, 8.40, 250, 25, 'kg', 2, 1, 1, 1, 1,'https://mahatmarice.com/wp-content/uploads/2019/05/2_Jasmine_Mahatma_mock.png'),
('PROD006', 'Azúcar Blanca Refinada', 'Azúcar extrafina, ideal para postres.', 4.50, 5.40, 600, 60, 'kg', 3, 1, 1, 1, 1,'https://mahatmarice.com/wp-content/uploads/2019/05/2_Jasmine_Mahatma_mock.png'),
('PROD007', 'Fideos Tornillo', 'Fideos en forma de espiral, perfectos para salsas.', 3.90, 4.68, 350, 35, 'paquete', 7, 1, 5, 2, 1,'https://benoti.pe/wp-content/uploads/2021/02/tornillo-1.png'),
('PROD008', 'Harina Sin Preparar', 'Harina de trigo sin aditivos, para panadería.', 5.80, 6.96, 280, 28, 'kg', 1, 1, 5, 2, 1,'https://plazavea.vteximg.com.br/arquivos/ids/15681712-450-450/20146331.jpg?v=637959756492270000'),
('PROD009', 'Arroz Parbolizado', 'Arroz precocido, no se pega.', 6.20, 7.44, 200, 20, 'kg', 2, 1, 1, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/27595662-450-450/58985.jpg?v=638319169668970000'),
('PROD010', 'Azúcar Light en Caja', 'Mezcla de azúcar y edulcorante.', 8.50, 10.20, 150, 15, 'caja', 3, 1, 3, 2, 1,'https://plazavea.vteximg.com.br/arquivos/ids/27479370-418-418/120154.jpg'),
-- Bebidas (idCategoria = 2)
('PROD011', 'Gaseosa Inca Kola 1.5L', 'Bebida gaseosa sabor nacional.', 7.50, 9.00, 800, 80, 'L', 11, 2, 2, 1, 1,'https://tofuu.getjusto.com/orioneat-local/resized2/z5v6tpyp9RrddKfNK-2400-x.webp'),
('PROD012', 'Jugo de Naranja 1L', 'Jugo natural de naranja, sin azúcar añadida.', 9.00, 10.80, 300, 30, 'L', 4, 2, 2, 1, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQXjzVHW8JK2xIIzQNEKFUuwvpQAQpMPLbqwQ&s'),
('PROD013', 'Agua Mineral San Mateo 600ml', 'Agua pura de manantial.', 2.00, 2.40, 1000, 100, 'ml', 6, 2, 2, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/312677-450-450/830010.jpg?v=637219605308370000'),
('PROD014', 'Gaseosa Coca Cola 2.25L', 'Bebida gaseosa clásica.', 9.00, 10.80, 750, 75, 'L', 11, 2, 2, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/529986-450-450/20100019.jpg?v=638774158092130000'),
('PROD015', 'Jugo de Durazno 1L', 'Jugo concentrado de durazno.', 8.50, 10.20, 280, 28, 'L', 4, 2, 2, 1, 1,'https://wongfood.vtexassets.com/arquivos/ids/724663/frontal-4584.jpg?v=638621159549600000'),
('PROD016', 'Agua de Mesa Cielo 2.5L', 'Agua purificada para consumo diario.', 3.50, 4.20, 900, 90, 'L', 4, 2, 2, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/29322561-450-450/1046239002.jpg?v=638593270216670000'),
('PROD017', 'Gaseosa Kola Real 3L', 'Bebida gaseosa económica.', 8.00, 9.60, 600, 60, 'L', 4, 2, 2, 1, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHYQhr9aACIll5Bk-Jb9Kwhz2H1jnhRXEc1A&s'),
('PROD018', 'Jugo de Piña en Lata', 'Jugo de piña concentrado.', 4.00, 4.80, 200, 20, 'L', 6, 2, 4, 3, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRXgmlrdZvZ4kXVB6mDPsBh4KQZdPU62_lnPQ&s'),
('PROD019', 'Agua con Gas San Luis 1.5L', 'Agua mineral con gas.', 4.50, 5.40, 400, 40, 'L', 6, 2, 2, 1, 1,'https://corporacionliderperu.com/51360-large_default/san-luis-agua-mineral-x-625-ml-con-gas.jpg'),
('PROD020', 'Bebida Energética Volt', 'Bebida energizante para mayor rendimiento.', 6.00, 7.20, 150, 15, 'ml', 4, 2, 2, 1, 1,'https://media.falabella.com/tottusPE/41450899_1/w=1500,h=1500,fit=pad')

INSERT INTO Productos (codigo, nombre, descripcion, precio, precioventa, stock, stock_minimo, unidad_medida, id_proveedor, idCategoria, idPresentacion, idTipoEmpaque, activo,imagen_url) VALUES
-- Lácteos (idCategoria = 3)
('PROD021', 'Leche Evaporada Gloria', 'Leche evaporada entera, ideal para cocinar.', 4.80, 5.76, 600, 60, 'L', 3, 3, 4, 3, 1,'https://corporacionliderperu.com/50720-large_default/gloria-leche-tarro-azul-gde-x-390-gr.jpg'),
('PROD022', 'Yogurt Batido Vainilla 1kg', 'Yogurt cremoso sabor vainilla.', 9.50, 11.40, 350, 35, 'kg', 9, 3, 2, 1, 1,'https://wongfood.vtexassets.com/arquivos/ids/364830-800-auto?v=637286400137500000&width=800&height=auto&aspect=true'),
('PROD023', 'Queso Fresco Ganadero', 'Queso fresco de vaca, suave.', 15.00, 18.00, 100, 10, 'kg', 9, 3, 16, 1, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcToEEGjISPasE25dG1BjchyAcpXZtJXjpA_lA&s'), -- Bandeja
('PROD024', 'Leche Fresca UHT Gloria', 'Leche fresca pasteurizada, larga vida.', 5.20, 6.24, 550, 55, 'L', 3, 3, 2, 1, 1,'https://media.falabella.com/tottusPE/10168696_1/w=800,h=800,fit=pad'),
('PROD025', 'Yogurt Griego Natural', 'Yogurt espeso y cremoso.', 12.00, 14.40, 200, 20, 'kg', 9, 3, 2, 1, 1,'https://pilandina.com.bo/wp-content/uploads/2023/07/YOGURT-GRECO-NATURAL-TRIPLE-CERO-BOLSA-1KG.webp'),
('PROD026', 'Mantequilla Sin Sal', 'Mantequilla pura de leche.', 7.80, 9.36, 180, 18, 'unidad', 9, 3, 3, 2, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQv_-0KxxNXaiRkhPSWxFRLSfvIvnky9BWXBw&s'),
('PROD027', 'Leche Condensada Gloria', 'Leche azucarada y concentrada.', 6.50, 7.80, 300, 30, 'L', 3, 3, 4, 3, 1,'https://plazavea.vteximg.com.br/arquivos/ids/1504479-450-450/20070084.jpg?v=637546439258970000'),
('PROD028', 'Yogurt Frutado Fresa 1kg', 'Yogurt con trozos de fresa.', 9.80, 11.76, 320, 32, 'kg', 9, 3, 2, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/22976332-512-512/20326320.jpg'),
('PROD029', 'Queso Edam Semi-duro', 'Queso holandés, sabor suave.', 25.00, 30.00, 50, 5, 'kg', 9, 3, 16, 1, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRlLSLriLcPe4rrVwpn7I8EGEB-TXhHYiKxmA&s'), -- Bandeja
('PROD030', 'Crema de Leche Gloria', 'Crema de leche para postres y salsas.', 5.00, 6.00, 250, 25, 'L', 3, 3, 4, 3, 1,'https://plazavea.vteximg.com.br/arquivos/ids/553531-1000-1000/971923.jpg?v=637426554958700000'),

-- Limpieza (idCategoria = 4)
('PROD031', 'Detergente Ariel Líquido 1L', 'Detergente concentrado para ropa.', 18.00, 21.60, 300, 30, 'L', 18, 4, 2, 1, 1,'https://vegaperu.vtexassets.com/arquivos/ids/160451-800-450?v=637931094549630000&width=800&height=450&aspect=true'),
('PROD032', 'Lejía Clorox 1L', 'Desinfectante y blanqueador.', 6.50, 7.80, 400, 40, 'L', 19, 4, 2, 1, 1,'https://production-tailoy-repo-magento-statics.s3.amazonaws.com/imagenes/872x872/productos/i/l/e/lejia-tradicional-x-1000-g-clorox-57981-default-1.jpg'),
('PROD033', 'Lavavajillas Sapolio 500ml', 'Limpiador concentrado para vajilla.', 4.20, 5.04, 500, 50, 'ml', 2, 4, 2, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/15681259-450-450/1003047005.jpg?v=637959753556270000'),
('PROD034', 'Limpiador Multiusos Poett 900ml', 'Limpiador desinfectante para superficies.', 8.00, 9.60, 350, 35, 'ml', 19, 4, 2, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/26368633-418-418/20236178.jpg'),
('PROD035', 'Jabón de Tocador Lux', 'Jabón para el cuerpo, fragancia floral.', 3.00, 3.60, 700, 70, 'unidad', 19, 4, 5, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/26368633-418-418/20236178.jpg'),
('PROD036', 'Detergente en Polvo Bolívar 1kg', 'Detergente para ropa, alto rendimiento.', 12.00, 14.40, 450, 45, 'kg', 1, 4, 5, 1, 1,'https://media.falabella.com/tottusPE/43331117_8/w=800,h=800,fit=pad'),
('PROD037', 'Suavizante Downy 800ml', 'Suavizante de ropa, aroma duradero.', 10.50, 12.60, 280, 28, 'ml', 18, 4, 2, 1, 1,'https://mercadoacasa.com/wp-content/uploads/2020/06/7501001155841.jpg'),
('PROD038', 'Desinfectante Lysol Aerosol', 'Desinfectante de ambientes y superficies.', 15.00, 18.00, 150, 15, 'unidad', 19, 4, 4, 3, 1,'https://media.falabella.com/tottusPE/42225012_1/w=1500,h=1500,fit=pad'),
('PROD039', 'Limpiador de Baños Cif', 'Limpiador potente para baños.', 9.00, 10.80, 200, 20, 'L', 19, 4, 2, 1, 1,'https://media.falabella.com/sodimacPE/2620316_01/w=1500,h=1500,fit=pad'),
('PROD040', 'Jabón Líquido para Manos', 'Jabón antibacterial para manos.', 7.00, 8.40, 300, 30, 'L', 2, 4, 2, 1, 1,'https://walmarthn.vtexassets.com/arquivos/ids/360688/Jab-n-Equate-Liquido-Para-Manos-Clear-222ml-1-3408.jpg?v=638419459905870000'),

-- Conservas (idCategoria = 5)
('PROD041', 'Atún en Aceite Florida', 'Atún desmenuzado en aceite vegetal.', 6.00, 7.20, 500, 50, 'unidad', 2, 5, 4, 3, 1,'https://wongfood.vtexassets.com/arquivos/ids/472711-800-auto?v=637675300360000000&width=800&height=auto&aspect=true'),
('PROD042', 'Sardinas en Salsa de Tomate', 'Sardinas enlatadas en salsa.', 4.50, 5.40, 400, 40, 'unidad', 2, 5, 4, 3, 1,'https://images.ctfassets.net/vkdsye91qcu6/6pp4rln2X6HJYnTDdL9w25/985bad66e04cadc731ffe1afd4fbfaad/PORTOLOA-SARDINA-TOMATE-TINAPON-AF.webp'),
('PROD043', 'Duraznos en Almíbar', 'Duraznos en mitades enlatados.', 8.00, 9.60, 300, 30, 'unidad', 2, 5, 4, 3, 1,'https://plazavea.vteximg.com.br/arquivos/ids/29362482-450-450/965773.jpg?v=638600338853900000'),
('PROD044', 'Atún en Agua Primor', 'Atún desmenuzado en agua.', 6.20, 7.44, 480, 48, 'unidad', 1, 5, 4, 3, 1,'https://plazavea.vteximg.com.br/arquivos/ids/30632038-450-450/20328065.jpg?v=638758945006370000'),
('PROD045', 'Leche de Tigre en Conserva', 'Base para ceviche, lista para usar.', 10.00, 12.00, 200, 20, 'unidad', 2, 5, 4, 3, 1,'https://heathotsauce.com/cdn/shop/files/leche-de-tigre-pepper-sauce-102821_700x700.png?v=1748589768'),
('PROD046', 'Palmitos en Rodajas', 'Palmitos tiernos en conserva.', 9.50, 11.40, 180, 18, 'unidad', 2, 5, 4, 3, 1,'https://metroio.vtexassets.com/arquivos/ids/343219-800-auto?v=638180575934370000&width=800&height=auto&aspect=true'),
('PROD047', 'Choclo Desgranado en Lata', 'Choclo tierno, listo para usar.', 5.00, 6.00, 350, 35, 'unidad', 2, 5, 4, 3, 1,'https://plazavea.vteximg.com.br/arquivos/ids/553419-450-450/20062913.jpg?v=637426551154430000'),
('PROD048', 'Arvejas Verdes en Lata', 'Arvejas frescas en conserva.', 4.80, 5.76, 320, 32, 'unidad', 2, 5, 4, 3, 1,'https://plazavea.vteximg.com.br/arquivos/ids/553437-450-450/20062912.jpg?v=637426551793130000'),
('PROD049', 'Pulpa de Tomate en Lata', 'Tomate triturado para salsas.', 5.50, 6.60, 280, 28, 'unidad', 2, 5, 4, 3, 1,'https://media.falabella.com/tottusPE/43273646_1/w=1500,h=1500,fit=pad'),
('PROD050', 'Champignones Laminados en Conserva', 'Hongos laminados en salmuera.', 7.00, 8.40, 250, 25, 'unidad', 2, 5, 4, 3, 1,'https://dojiw2m9tvv09.cloudfront.net/49572/product/champinoneslaminadosenconservalahortelana7830.jpg'),

-- Panadería (idCategoria = 6)
('PROD051', 'Pan de Molde Blanco', 'Pan suave para sándwiches.', 7.00, 8.40, 200, 20, 'paquete', 17, 6, 5, 1, 1,'https://metroio.vtexassets.com/arquivos/ids/571797-800-auto?v=638744711707530000&width=800&height=auto&aspect=true'),
('PROD052', 'Galletas Soda Field', 'Galletas saladas, ideales para el desayuno.', 3.50, 4.20, 600, 60, 'paquete', 1, 6, 5, 1, 1,'https://oechsle.vteximg.com.br/arquivos/ids/14862197-1000-1000/image-e001f659c83d4e39ace0bfd958ba4912.jpg?v=638281577045430000'),
('PROD053', 'Bizcocho Vainilla Grande', 'Bizcocho esponjoso sabor vainilla.', 12.00, 14.40, 100, 10, 'unidad', 2, 6, 3, 2, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThHQ1NLd3YiT8H6CyzoiCB-S-R-J33uYeXTA&s'),
('PROD054', 'Pan de Molde Integral', 'Pan integral con fibra.', 8.00, 9.60, 180, 18, 'paquete', 17, 6, 5, 1, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSEAlrZeL1y3x0OxgtwHahkhGs8UYUMuw0OMg&s'),
('PROD055', 'Galletas Vainilla Casino', 'Galletas dulces con crema de vainilla.', 4.00, 4.80, 550, 55, 'paquete', 1, 6, 5, 1, 1,'https://metroio.vtexassets.com/arquivos/ids/579285/348641003-01-81531.jpg?v=638791367516230000'),
('PROD056', 'Pan Baguette Precocido', 'Pan rústico, listo para hornear.', 5.00, 6.00, 150, 15, 'unidad', 2, 6, 5, 1, 1,'https://wongfood.vtexassets.com/arquivos/ids/543813-800-auto?v=637879983111700000&width=800&height=auto&aspect=true'),
('PROD057', 'Galletas de Agua', 'Galletas ligeras y crocantes.', 3.20, 3.84, 400, 40, 'paquete', 1, 6, 5, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/16382186-512-512/20256758.jpg'),
('PROD058', 'Queque Marmoleado', 'Bizcocho de vainilla y chocolate.', 15.00, 18.00, 80, 8, 'unidad', 2, 6, 3, 2, 1,'https://plazavea.vteximg.com.br/arquivos/ids/28560450-450-450/20146143.jpg?v=638382246811200000'),
('PROD059', 'Pan Ciabatta Congelado', 'Pan artesanal, ideal para acompañar.', 6.00, 7.20, 120, 12, 'unidad', 2, 6, 5, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/29585768-450-450/20189340.jpg?v=638631072569670000'),
('PROD060', 'Galletas Morochas', 'Galletas de chocolate con crema.', 4.50, 5.40, 500, 50, 'paquete', 1, 6, 5, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/342248-450-450/198967.jpg?v=637280980148500000'),

-- Abarrotes secos (idCategoria = 7)
('PROD061', 'Lenteja Baby 500gr', 'Lentejas pequeñas, cocción rápida.', 4.00, 4.80, 300, 30, 'gr', 2, 7, 1, 1, 1,'https://wongfood.vtexassets.com/arquivos/ids/503870/Lentejas-Beb-Bolsa-500-g-LENTEJ-BB-VN-500gr-1-135984909.jpg?v=637743905442300000'),
('PROD062', 'Frijol Canario 1kg', 'Frijoles secos, ideales para guisos.', 6.50, 7.80, 250, 25, 'kg', 2, 7, 1, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/30213071-512-512/20376371.jpg'),
('PROD063', 'Sal Fina Marina 1kg', 'Sal de mesa y cocina.', 2.50, 3.00, 700, 70, 'kg', 2, 7, 5, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/561008-418-418/20130448.jpg'),
('PROD064', 'Aceite Vegetal Primor 1L', 'Aceite de girasol, para freír y cocinar.', 10.00, 12.00, 500, 50, 'L', 1, 7, 2, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/30632030-450-450/20281566.jpg?v=638758944609130000'),
('PROD065', 'Arroz Extra Costeño 5kg', 'Arroz de alta calidad, para toda la familia.', 25.00, 30.00, 150, 15, 'kg', 2, 7, 1, 1, 1,'https://realplaza.vtexassets.com/arquivos/ids/20646711/image-120f38a72a3a456184945648c36cb3f5.jpg?v=637800393551500000'),
('PROD066', 'Azúcar Blanca Cartavio 5kg', 'Azúcar refinada de alta pureza.', 20.00, 24.00, 180, 18, 'kg', 2, 7, 1, 1, 1,'https://realplaza.vtexassets.com/arquivos/ids/30946627/image-3c2d6274c6e04bc88032d8e81a0bd8a3.jpg?v=638037067761470000'),
('PROD067', 'Garbanzo Seco 500gr', 'Garbanzos para guisos y ensaladas.', 4.50, 5.40, 280, 28, 'gr', 2, 7, 1, 1, 1,'https://media.falabella.com/tottusPE/10167820_1/w=800,h=800,fit=pad'),
('PROD068', 'Sal Yodada Fortificada 1kg', 'Sal con yodo, esencial para la salud.', 2.80, 3.36, 650, 65, 'kg', 2, 7, 5, 1, 1,'https://http2.mlstatic.com/D_NQ_NP_678066-MLM41891277508_052020-O.webp'),
('PROD069', 'Aceite de Palma Soya 1L', 'Aceite vegetal para uso general.', 9.00, 10.80, 400, 40, 'L', 2, 7, 2, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/4159435-512-512/107285.jpg'),
('PROD070', 'Lenteja Pardina 1kg', 'Lentejas de cocción lenta, muy sabrosas.', 5.00, 6.00, 220, 22, 'kg', 2, 7, 1, 1, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2ilRA4kVfOvwB-ppPm8qtLO5jj4FgP4DDlg&s'),

-- Enlatados (idCategoria = 8)
('PROD071', 'Leche de Coco en Lata', 'Leche de coco para postres y curries.', 7.00, 8.40, 200, 20, 'unidad', 2, 8, 4, 3, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQfH41tCORp0WhAVoM90guoRJEVEwXzqrX9IQ&s'),
('PROD072', 'Tomates Pelados Enteros', 'Tomates maduros enlatados.', 4.00, 4.80, 300, 30, 'unidad', 2, 8, 4, 3, 1,'https://http2.mlstatic.com/D_NQ_NP_887424-MLA43206363690_082020-O.webp'),
('PROD073', 'Champiñones Enteros en Lata', 'Champiñones en salmuera.', 6.50, 7.80, 250, 25, 'unidad', 2, 8, 4, 3, 1,'https://plazavea.vteximg.com.br/arquivos/ids/23048702-450-450/20326541.jpg?v=638060635530030000'),
('PROD074', 'Pimiento Morrón en Tiras', 'Pimientos rojos enlatados.', 5.80, 6.96, 220, 22, 'unidad', 2, 8, 4, 3, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOcW69heqnQyxUT5-f654RNLy0cCHG2urtkA&s'),
('PROD075', 'Maíz Dulce en Lata', 'Granos de maíz dulce.', 4.20, 5.04, 350, 35, 'unidad', 2, 8, 4, 3, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTzzE7-boCjZ7bZal6FLif0talObv9f0nNCog&s'),
('PROD076', 'Frejoles Rojos en Salsa', 'Frejoles listos para servir.', 5.20, 6.24, 280, 28, 'unidad', 2, 8, 4, 3, 1,'https://media.falabella.com/tottusPE/43423852_1/w=800,h=800,fit=pad'),
('PROD077', 'Garbanzos Cocidos en Lata', 'Garbanzos listos para usar.', 4.70, 5.64, 270, 27, 'unidad', 2, 8, 4, 3, 1,'https://plazavea.vteximg.com.br/arquivos/ids/30578623-512-512/20282632.jpg'),
('PROD078', 'Sopa de Tomate Condensada', 'Sopa concentrada de tomate.', 3.50, 4.20, 300, 30, 'unidad', 2, 8, 4, 3, 1,'https://hebmx.vtexassets.com/arquivos/ids/648865/660693_74613616.jpg?v=638520849372700000'),
('PROD079', 'Crema de Champiñones en Lata', 'Crema concentrada de champiñones.', 4.80, 5.76, 290, 29, 'unidad', 2, 8, 4, 3, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSn0tII3uz3vIc4hw9PTlF6HdimG1VB2NqUYg&s'),
('PROD080', 'Leche Evaporada Light', 'Leche evaporada baja en grasa.', 4.90, 5.88, 250, 25, 'unidad', 3, 8, 4, 3, 1,'https://media.falabella.com/tottusPE/43273631_1/w=800,h=800,fit=pad'),

-- Snacks (idCategoria = 9)
('PROD081', 'Papas Lays Clásicas 150gr', 'Papas fritas crujientes.', 4.00, 4.80, 500, 50, 'gr', 21, 9, 1, 1, 1,'https://vegaperu.vtexassets.com/arquivos/ids/167257-800-450?v=638622119937270000&width=800&height=450&aspect=true'),
('PROD082', 'Galletas Ritz Saladas', 'Galletas saladas para acompañar.', 3.80, 4.56, 400, 40, 'paquete', 21, 9, 5, 1, 1,'https://media.falabella.com/tottusPE/43113666_1/w=1500,h=1500,fit=pad'),
('PROD083', 'Maní Salado 200gr', 'Maní tostado y salado.', 6.00, 7.20, 300, 30, 'gr', 2, 9, 1, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/29321994-450-450/20237013.jpg?v=638592612125900000'),
('PROD084', 'Chifles de Plátano', 'Snack de plátano frito, típico peruano.', 3.50, 4.20, 450, 45, 'bolsa', 2, 9, 1, 1, 1,'https://selvaproduce.com/wp-content/uploads/2022/12/DHeinz5-3.jpg'),
('PROD085', 'Cancha Serrana 250gr', 'Maíz tostado, snack andino.', 3.00, 3.60, 550, 55, 'bolsa', 2, 9, 1, 1, 1,'https://wongfood.vtexassets.com/arquivos/ids/439385/Canchita-Serrana-Picante-Cuisine-Co-Pote-160-g-1-205063732.jpg?v=637571690912470000'),
('PROD086', 'Papas Pringles Original', 'Papas en forma de tubo.', 12.00, 14.40, 150, 15, 'unidad', 18, 9, 3, 2, 1,'https://media.falabella.com/tottusPE/43273652_1/public'),
('PROD087', 'Galletas Oreo Chocolate', 'Galletas de chocolate rellenas.', 4.20, 5.04, 380, 38, 'paquete', 21, 9, 5, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/29228266-1000-1000/20020807.jpg?v=638567711707500000'),
('PROD088', 'Mix de Frutos Secos', 'Mezcla de maní, pasas, almendras.', 10.00, 12.00, 100, 10, 'bolsa', 2, 9, 1, 1, 1,'https://metroio.vtexassets.com/arquivos/ids/325507/890743-1.jpg?v=638180568501270000'),
('PROD089', 'Tortillas de Maíz Nachos', 'Tortillas triangulares para dipear.', 7.00, 8.40, 250, 25, 'bolsa', 2, 9, 1, 1, 1,'https://wongfood.vtexassets.com/arquivos/ids/491379-800-auto?v=637714713635270000&width=800&height=auto&aspect=true'),
('PROD090', 'Cereal Barra de Avena', 'Barra energética de avena y frutas.', 2.50, 3.00, 600, 60, 'unidad', 6, 9, 6, 1, 1,'https://metroio.vtexassets.com/arquivos/ids/501539/BARRAS-NATURE-VALLEY-12UN-AVENA-MIEL-1-249400.jpg?v=638368766183000000'),

-- Granos y cereales (idCategoria = 10)
('PROD091', 'Quinua Blanca 500gr', 'Grano andino de alto valor nutricional.', 8.00, 9.60, 200, 20, 'gr', 2, 10, 1, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/570022-450-450/20207387.jpg?v=637431607828230000'),
('PROD092', 'Kiwicha 250gr', 'Cereal andino, fuente de proteínas.', 7.50, 9.00, 180, 18, 'gr', 2, 10, 1, 1, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwM1ium2kq7QjbMDUR491YrLauUzbwYH7h8w&s'),
('PROD093', 'Avena Instantánea 400gr', 'Avena precocida para desayuno.', 5.00, 6.00, 300, 30, 'gr', 1, 10, 5, 1, 1,'https://http2.mlstatic.com/D_NQ_NP_984140-MLA43895322328_102020-O.webp'),
('PROD094', 'Cebada Perlada 1kg', 'Cebada para sopas y guisos.', 4.00, 4.80, 250, 25, 'kg', 2, 10, 1, 1, 1,'https://cloudinary.images-iherb.com/image/upload/f_auto,q_auto:eco/images/bfn/bfn07942/y/2.jpg'),
('PROD095', 'Trigo Entero 1kg', 'Trigo para preparaciones diversas.', 4.20, 5.04, 220, 22, 'kg', 2, 10, 1, 1, 1,'https://plazavea.vteximg.com.br/arquivos/ids/30213096-512-512/20356937.jpg'),
('PROD096', 'Maca en Polvo 100gr', 'Superalimento andino.', 15.00, 18.00, 80, 8, 'gr', 2, 10, 5, 1, 1,'https://biosphare.cl/wp-content/uploads/2022/06/MACA-POLVO-X-100-GR-AVANTI.webp'),
('PROD097', 'Amaranto 250gr', 'Grano andino similar a la quinua.', 7.80, 9.36, 150, 15, 'gr', 2, 10, 1, 1, 1,'https://mushukyuyay.org/wp-content/uploads/2023/12/amaranto-1.jpg'),
('PROD098', 'Cereal de Maíz Hojuelas', 'Hojuelas de maíz para el desayuno.', 9.00, 10.80, 280, 28, 'caja', 6, 10, 3, 2, 1,'https://plazavea.vteximg.com.br/arquivos/ids/30267032-512-512/20213739.jpg'),
('PROD099', 'Granola con Frutos Secos', 'Mezcla de cereales y frutos secos.', 11.00, 13.20, 120, 12, 'bolsa', 2, 10, 1, 1, 1,'https://nutrimix.pe/wp-content/uploads/2022/12/16-Granola-con-fruto-secos-y-miel-de-abeja-bolsa-350gr-nutrimix.webp'),
('PROD100', 'Semillas de Chía 200gr', 'Semillas ricas en omega-3.', 9.50, 11.40, 100, 10, 'gr', 2, 10, 1, 1, 1,'https://metroio.vtexassets.com/arquivos/ids/372411/SEMILLAS-DE-CHIA-RENACER-X-200-GR-1-238825.jpg?v=638180588212330000'),

-- Frutas y Verduras (idCategoria = 11)
('PROD101', 'Manzana Roja Fresca', 'Manzana de temporada, dulce y crujiente.', 2.50, 3.00, 150, 15, 'kg', 27, 11, 16, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/181288-1000-1000/63609.jpg?v=636023738294230000'),
('PROD102', 'Plátano de Seda', 'Plátano maduro, ideal para consumo directo.', 1.80, 2.16, 200, 20, 'kg', 27, 11, 16, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/29450552-184-184/772631.jpg?v=638616384640530000'),
('PROD103', 'Papa Amarilla Orgánica', 'Papa de alta calidad para puré o fritura.', 3.00, 3.60, 300, 30, 'kg', 28, 11, 1, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/1265150-1000-1000/124903.jpg?v=637520242280830000'),
('PROD104', 'Tomate Redondo', 'Tomate fresco para ensaladas y guisos.', 2.20, 2.64, 250, 25, 'kg', 27, 11, 1, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/26403047-184-184/20349980.jpg?v=638205752940900000'),
('PROD105', 'Cebolla Roja Grande', 'Cebolla fresca para diversas preparaciones.', 1.50, 1.80, 400, 40, 'kg', 28, 11, 1, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/518589-184-184/844123.jpg?v=637417681771730000'),
('PROD106', 'Uva Red Globe', 'Uvas frescas sin pepa, dulces.', 8.00, 9.60, 80, 8, 'kg', 27, 16, 1, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/646260-184-184/601559.jpg?v=637443522649900000'),
('PROD107', 'Zanahoria Fresca', 'Zanahoria crujiente para ensaladas.', 1.20, 1.44, 350, 35, 'kg', 28, 11, 1, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/30249489-184-184/20426773.jpg?v=638682051884130000'),
('PROD108', 'Limón Sutil', 'Limones pequeños y jugosos.', 1.00, 1.20, 500, 50, 'kg', 27, 11, 1, 1, 1, 'https://metroio.vtexassets.com/arquivos/ids/543990-800-auto?v=638620979677000000&width=800&height=auto&aspect=true'),
('PROD109', 'Palta Fuerte', 'Palta cremosa, ideal para ensaladas y guacamole.', 6.00, 7.20, 100, 10, 'unidad', 27, 11, 16, 1, 1, 'https://wongfood.vtexassets.com/arquivos/ids/526196/3951-01-6479.jpg?v=637817098886800000'),
('PROD110', 'Lechuga Americana', 'Lechuga fresca y crujiente.', 2.00, 2.40, 120, 12, 'unidad', 28, 11, 16, 1, 1, 'https://metroio.vtexassets.com/arquivos/ids/275823/4027-1.jpg?v=638179302575670000'),

-- Carnes y Embutidos (idCategoria = 12)
('PROD111', 'Pechuga de Pollo Fresca', 'Pechuga de pollo sin hueso ni piel.', 18.00, 21.60, 50, 5, 'kg', 27, 12, 16, 9, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSqGC6KUo5WGv-135VS7w6EbkwDx9fauP9zfg&s'),
('PROD112', 'Carne Molida de Res', 'Carne de res molida, magra.', 22.00, 26.40, 40, 4, 'kg', 27, 12, 16, 9, 1, 'https://finecut.pe/wp-content/uploads/2024/07/carne-molida-especial.jpg'),
('PROD113', 'Salchicha Frankfurt', 'Salchichas de cerdo, ahumadas.', 8.50, 10.20, 60, 6, 'paquete', 27, 12, 5, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/2446146-450-450/20151584.jpg?v=637677553389100000'),
('PROD114', 'Jamón Inglés Feteado', 'Jamón cocido en lonchas.', 12.00, 14.40, 30, 3, 'paquete', 27, 12, 5, 1, 1, 'https://metroio.vtexassets.com/arquivos/ids/353796/3420-01-7837.jpg?v=638180580046870000'),
('PROD115', 'Chorizo Parrillero', 'Chorizos frescos para parrilla.', 10.00, 12.00, 35, 3, 'paquete', 27, 12, 5, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcScmQZPjyLduwXlMGsBsSA84Jbz5alzKezouw&s'),
('PROD116', 'Costilla de Cerdo', 'Costilla de cerdo para asar.', 16.00, 19.20, 25, 2, 'kg', 27, 12, 16, 9, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQY_ba7iXE5euoDG_rR2BWfHr9OtRwO2gOjng&s'),
('PROD117', 'Hamburguesa de Res', 'Hamburguesas de carne de res.', 14.00, 16.80, 45, 4, 'paquete', 27, 12, 5, 1, 1, 'https://wongfood.vtexassets.com/arquivos/ids/748317-800-auto?v=638724843786500000&width=800&height=auto&aspect=true'),
('PROD118', 'Tocino Ahumado Feteado', 'Tocino en lonchas, ahumado.', 9.00, 10.80, 20, 2, 'paquete', 27, 12, 5, 1, 1, 'https://wongfood.vtexassets.com/arquivos/ids/624948-800-auto?v=638155678913370000&width=800&height=auto&aspect=true'),
('PROD119', 'Pavo Molido', 'Carne de pavo molida, baja en grasa.', 19.00, 22.80, 30, 3, 'kg', 27, 12, 16, 9, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/16381014-450-450/20121040.jpg?v=637970148288030000'),
('PROD120', 'Mortadela Clásica', 'Embutido de cerdo, suave.', 7.00, 8.40, 50, 5, 'paquete', 27, 12, 5, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQybkcq3N0UUvvSP4ROiBDrZ8YDgKS4PzDv9Q&s'),

-- Pescados y Mariscos (idCategoria = 13)
('PROD121', 'Filete de Merluza Congelado', 'Filete de pescado sin espinas.', 20.00, 24.00, 30, 3, 'kg', 27, 13, 5, 9, 1, 'https://metroio.vtexassets.com/arquivos/ids/576238-800-auto?v=638772465941770000&width=800&height=auto&aspect=true'),
('PROD122', 'Langostinos Pelados Congelados', 'Langostinos listos para cocinar.', 28.00, 33.60, 20, 2, 'kg', 27, 13, 5, 9, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/28722534-418-418/20220600.jpg'),
('PROD123', 'Atún Fresco en Lomo', 'Lomo de atún fresco.', 35.00, 42.00, 15, 1, 'kg', 27, 13, 16, 9, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5PNyc2kVgl5Ice332ckf4HB6azIHBj6O4wg&s'),
('PROD124', 'Calamares Anillos Congelados', 'Anillos de calamar listos para freír.', 15.00, 18.00, 25, 2, 'kg', 27, 13, 5, 9, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTEPIf2WTWBAsziYxgeheSV4MjKh6ZBsprNLw&s'),
('PROD125', 'Salmón Fresco Filete', 'Filete de salmón, rico en Omega 3.', 40.00, 48.00, 10, 1, 'kg', 27, 13, 16, 9, 1, 'https://wongfood.vtexassets.com/arquivos/ids/279222-800-auto?v=636870708303870000&width=800&height=auto&aspect=true'),

-- Congelados (idCategoria = 14)
('PROD126', 'Papas Fritas Pre-fritas', 'Papas congeladas, listas para freír.', 8.00, 9.60, 100, 10, 'kg', 17, 14, 1, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRDxoQ4anPoPEEkWmVxTGRacVwUlMWzUCD7dg&s'),
('PROD127', 'Verduras Mixtas Congeladas', 'Mezcla de vegetales congelados.', 7.50, 9.00, 80, 8, 'kg', 17, 14, 1, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/330233-512-512/20149836.jpg'),
('PROD128', 'Nuggets de Pollo', 'Nuggets de pollo empanizados.', 12.00, 14.40, 70, 7, 'paquete', 17, 14, 5, 1, 1, 'https://media.falabella.com/tottusPE/10225435_11/w=1500,h=1500,fit=pad'),
('PROD129', 'Pizza Congelada Jamón y Queso', 'Pizza lista para hornear.', 15.00, 18.00, 50, 5, 'unidad', 17, 14, 5, 2, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR0mzyxtzHB5b7ZPAXaHgzeDt3U2pirMJUPHg&s'),
('PROD130', 'Helado de Vainilla 1L', 'Helado cremoso sabor vainilla.', 10.00, 12.00, 60, 6, 'L', 17, 14, 23, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/28884622-512-512/20392572-1.jpg'),

-- Aceites y Vinagres (idCategoria = 15)
('PROD131', 'Aceite de Oliva Extra Virgen 500ml', 'Aceite de oliva de primera prensa.', 25.00, 30.00, 100, 10, 'ml', 1, 15, 18, 4, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSYoAxUWH5xpqXmjD72hkUUuCGPUlG_e7wd-w&s'),
('PROD132', 'Vinagre Blanco 1L', 'Vinagre de alcohol para cocina y limpieza.', 5.00, 6.00, 150, 15, 'L', 2, 15, 2, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/28473285-418-418/20146591.jpg'),
('PROD133', 'Aceite de Girasol 3L', 'Aceite vegetal para uso general.', 28.00, 33.60, 80, 8, 'L', 1, 15, 7, 1, 1, 'https://metroio.vtexassets.com/arquivos/ids/570334/Aceite-de-Girasol-Cuisine-Co-3L-1-284909.jpg?v=638742009683230000'),
('PROD134', 'Vinagre de Manzana 750ml', 'Vinagre natural de manzana.', 8.00, 9.60, 90, 9, 'ml', 2, 15, 18, 4, 1, 'https://rimage.ripley.com.pe/home.ripley/Attachment/MKP/5200/PMP20000691180/full_image-1.png'),
('PROD135', 'Aceite de Coco Orgánico', 'Aceite de coco virgen, sólido.', 18.00, 21.60, 70, 7, 'gr', 5, 15, 23, 4, 1, 'https://organaperu.vtexassets.com/arquivos/ids/155680/606110254083.jpg?v=637618909968330000'),

-- Salsas y Condimentos (idCategoria = 16)
('PROD136', 'Mayonesa Hellmanns 500gr', 'Mayonesa cremosa para acompañar.', 9.00, 10.80, 200, 20, 'gr', 1, 16, 18, 4, 1, 'https://f.fcdn.app/imgs/ad987d/suchinasa.com/suchuy/ce4d/original/catalogo/21811_21811_1/460x460/mayonesa-hellmanns-950cc-mayonesa-hellmanns-950cc.jpg'),
('PROD137', 'Ketchup Heinz 400gr', 'Salsa de tomate clásica.', 7.50, 9.00, 180, 18, 'gr', 1, 16, 18, 4, 1, 'https://m.media-amazon.com/images/I/71w24XN4PuL._UF894,1000_QL80_.jpg'),
('PROD138', 'Mostaza Dijon', 'Mostaza picante estilo francés.', 10.00, 12.00, 80, 8, 'gr', 1, 16, 18, 4, 1, 'https://metroio.vtexassets.com/arquivos/ids/397289/Mostaza-Dij-n-American-Classic-340g-1-350549076.jpg?v=638180795457530000'),
('PROD139', 'Sal de Mesa Fina', 'Sal yodada para uso diario.', 2.00, 2.40, 500, 50, 'kg', 2, 16, 5, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/12353523-418-418/20140345.jpg'),
('PROD140', 'Pimienta Negra Molida', 'Pimienta negra en polvo.', 5.00, 6.00, 120, 12, 'gr', 2, 16, 18, 4, 1, 'https://metroio.vtexassets.com/arquivos/ids/374884-800-auto?v=638180589488470000&width=800&height=auto&aspect=true'),

-- Dulces y Postres (idCategoria = 17)
('PROD141', 'Chocolate en Barra Leche', 'Chocolate con leche, para postres.', 6.00, 7.20, 150, 15, 'unidad', 21, 17, 10, 2, 1, 'https://media.falabella.com/tottusPE/41958037_1/w=800,h=800,fit=pad'),
('PROD142', 'Mermelada de Fresa 300gr', 'Mermelada natural de fresa.', 8.00, 9.60, 100, 10, 'gr', 2, 17, 18, 4, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSSoFeD6y2sn8XpS0mDxgaildh4IMWqXLtJXw&s'),
('PROD143', 'Galletas de Chocolate Rellenas', 'Galletas con crema de chocolate.', 4.50, 5.40, 250, 25, 'paquete', 21, 17, 5, 1, 1, 'https://wongfood.vtexassets.com/arquivos/ids/696389/Galletas-Rellenas-Nestl-Choco-Cookies-Chocolate-120g-1-351672312.jpg?v=638470065772900000'),
('PROD144', 'Caramelos Surtidos Bolsa', 'Caramelos de diferentes sabores.', 3.00, 3.60, 300, 30, 'bolsa', 21, 17, 1, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/419691-512-512/20146444.jpg'),
('PROD145', 'Flan en Polvo para Preparar', 'Mezcla para flan casero.', 2.80, 3.36, 180, 18, 'sachet', 1, 17, 6, 1, 1, 'https://media.falabella.com/tottusPE/42517872_1/w=1500,h=1500,fit=pad'),
-- Cuidado Personal (idCategoria = 18)
('PROD146', 'Champú Anticaspa 400ml', 'Champú para el control de la caspa.', 15.00, 18.00, 80, 8, 'ml', 19, 18, 2, 1, 1, 'https://kamill.vteximg.com.br/arquivos/ids/156540-1000-1000/08095090000040.jpg?v=637428879287000000'),
('PROD147', 'Acondicionador Reparador 400ml', 'Acondicionador para cabello dañado.', 14.00, 16.80, 70, 7, 'ml', 19, 18, 2, 1, 1, 'https://wongfood.vtexassets.com/arquivos/ids/550710-800-auto?v=637897911836800000&width=800&height=auto&aspect=true'),
('PROD148', 'Pasta Dental Blanqueadora', 'Pasta dental para dientes más blancos.', 8.00, 9.60, 120, 12, 'unidad', 19, 18, 8, 1, 1, 'https://media.falabella.com/tottusPE/40854911_1/w=1500,h=1500,fit=pad'),
('PROD149', 'Jabón Líquido Corporal', 'Jabón para el cuerpo, hidratante.', 10.00, 12.00, 90, 9, 'L', 19, 18, 2, 1, 1, 'https://metroio.vtexassets.com/arquivos/ids/540370/982368-01-161831.jpg?v=638593725747300000'),
('PROD150', 'Desodorante Roll-on', 'Desodorante de larga duración.', 7.00, 8.40, 100, 10, 'unidad', 19, 18, 9, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxMnulwTMlbiVCnZzm-2E1ymj-qMY4Dyc7fQ&s'),

-- Artículos para el Hogar (idCategoria = 19)
('PROD151', 'Papel Higiénico Doble Hoja', 'Papel higiénico suave y resistente.', 15.00, 18.00, 100, 10, 'paquete', 25, 19, 5, 1, 1, 'https://www.ofimarket.pe/cdn/shop/files/30242657_600x600_crop_center.jpg?v=1696348294'),
('PROD152', 'Servilletas de Papel', 'Servilletas absorbentes.', 5.00, 6.00, 150, 15, 'paquete', 25, 19, 5, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/28619629-418-418/102487-1.jpg'),
('PROD153', 'Bolsas de Basura Grandes', 'Bolsas resistentes para residuos.', 8.00, 9.60, 80, 8, 'paquete', 25, 19, 5, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIP7wsCKlqzY8GZhp_7N0wmIyFcBbUbaVPkQ&s'),
('PROD154', 'Detergente para Ropa Líquido 3L', 'Detergente concentrado para lavadora.', 30.00, 36.00, 60, 6, 'L', 25, 19, 7, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/16382551-450-450/20282220.jpg?v=637970177819700000'),
('PROD155', 'Limpiador de Pisos Multiusos', 'Limpiador para todo tipo de pisos.', 12.00, 14.40, 70, 7, 'L', 25, 19, 2, 1, 1, 'https://promart.vteximg.com.br/arquivos/ids/6865172-1000-1000/image-09555014e57b48f993068668d835b64c.jpg?v=638146620158400000'),

-- Mascotas (idCategoria = 20)
('PROD156', 'Alimento para Perro Adulto 3kg', 'Alimento balanceado para perros adultos.', 35.00, 42.00, 50, 5, 'kg', 27, 20, 1, 1, 1, 'https://metroio.vtexassets.com/arquivos/ids/363950/Alimento-para-Perros-Dogui-Adulto-3kg-1-316180313.jpg?v=638180584102900000'),
('PROD157', 'Arena Sanitaria para Gato 5kg', 'Arena absorbente para gatos.', 20.00, 24.00, 40, 4, 'kg', 27, 20, 1, 1, 1, 'https://oechsle.vteximg.com.br/arquivos/ids/16108804-1000-1000/image-6c10522801e24a6e9a6b5497db3fc325.jpg?v=638296803908230000'),
('PROD158', 'Snacks para Perro Huesitos', 'Premios para perros, sabor carne.', 10.00, 12.00, 80, 8, 'paquete', 27, 20, 5, 1, 1, 'https://www.superpet.pe/on/demandware.static/-/Sites-SuperPet-master-catalog/default/dw41c9d04f/images/peque-huesitos-500g.jpg'),
('PROD159', 'Comida Húmeda para Gato Lata', 'Alimento húmedo para gatos.', 4.00, 4.80, 100, 10, 'unidad', 27, 20, 4, 3, 1, 'https://oechsle.vteximg.com.br/arquivos/ids/16483357-1000-1000/image-de1ed3caddad439dbbebab45809a80df.jpg?v=638328599140970000'),
('PROD160', 'Juguete para Perro Pelota', 'Pelota resistente para juegos.', 8.00, 9.60, 60, 6, 'unidad', 27, 20, 20, 1, 1, 'https://metroio.vtexassets.com/arquivos/ids/375123-800-auto?v=638180589621100000&width=800&height=auto&aspect=true'),

-- Productos Adicionales (mezcla de categorías)
('PROD161', 'Café Tostado y Molido 250gr', 'Café de aroma intenso.', 12.00, 14.40, 150, 15, 'gr', 1, 1, 1, 1, 1, 'https://oechsle.vteximg.com.br/arquivos/ids/19758759-1000-1000/1683082722818_a.jpg?v=638671573626670000'),
('PROD162', 'Té Filtrante Variado', 'Caja de tés de diferentes sabores.', 8.00, 9.60, 100, 10, 'caja', 1, 2, 3, 2, 1, 'https://media.falabella.com/tottusPE/42099493_1/w=800,h=800,fit=pad'),
('PROD163', 'Galletas de Arroz Integral', 'Galletas ligeras y saludables.', 5.00, 6.00, 200, 20, 'paquete', 2, 9, 5, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMdMYVrCGvKNlPU-bZFHTU7UKKiHOi2joZLQ&s'),
('PROD164', 'Miel de Abeja Pura 500gr', 'Miel natural de abeja.', 18.00, 21.60, 70, 7, 'gr', 5, 1, 18, 4, 1, 'https://florayfauna.vtexassets.com/arquivos/ids/157657-800-auto?v=637602499510370000&width=800&height=auto&aspect=true'),
('PROD165', 'Barra de Cereal Frutos Rojos', 'Barra energética con frutas.', 3.50, 4.20, 250, 25, 'unidad', 6, 9, 6, 1, 1, 'https://http2.mlstatic.com/D_Q_NP_837128-MLU74128441019_012024-O.webp'),
('PROD166', 'Mermelada de Durazno 300gr', 'Mermelada natural de durazno.', 8.00, 9.60, 90, 9, 'gr', 2, 17, 18, 4, 1, 'https://media.falabella.com/tottusPE/40765299_1/w=1500,h=1500,fit=pad'),
('PROD167', 'Atún en Aceite de Oliva', 'Atún de alta calidad en aceite de oliva.', 7.50, 9.00, 180, 18, 'unidad', 2, 5, 4, 3, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/28323677-450-450/20236262.jpg?v=638352900503230000'),
('PROD168', 'Aceitunas Verdes Deshuesadas', 'Aceitunas en salmuera.', 6.00, 7.20, 150, 15, 'frasco', 2, 5, 18, 4, 1, 'https://wongfood.vtexassets.com/arquivos/ids/434338-800-auto?v=637553964431100000&width=800&height=auto&aspect=true'),
('PROD169', 'Vinagre Tinto de Vino', 'Vinagre para ensaladas y cocina.', 6.50, 7.80, 120, 12, 'L', 2, 15, 2, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/550624-1000-1000/1243.jpg?v=637425699808300000'),
('PROD170', 'Salsa de Tomate Lista', 'Salsa para pastas, lista para usar.', 5.00, 6.00, 200, 20, 'frasco', 2, 16, 18, 4, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/15002669-512-512/20282829.jpg'),
('PROD171', 'Gelatina en Polvo Fresa', 'Gelatina para postres.', 2.00, 2.40, 300, 30, 'sachet', 1, 17, 6, 1, 1, 'https://metroio.vtexassets.com/arquivos/ids/499372/332010001-01-63003.jpg?v=638357637957400000'),
('PROD172', 'Crema Dental Sensible', 'Pasta dental para dientes sensibles.', 9.00, 10.80, 100, 10, 'unidad', 19, 18, 8, 1, 1, 'https://wongfood.vtexassets.com/arquivos/ids/707978-800-auto?v=638513915150600000&width=800&height=auto&aspect=true'),
('PROD173', 'Jabón en Barra Antibacterial', 'Jabón para manos y cuerpo.', 2.50, 3.00, 400, 40, 'unidad', 19, 18, 10, 2, 1, 'https://www.protex-soap.com/content/dam/cp-sites/personal-care/protex-relaunch/latam/products/jab%C3%B3n-antibacterial-protex-avena-110-g.jpg'),
('PROD174', 'Esponja de Limpieza Cocina', 'Esponja abrasiva para vajilla.', 1.50, 1.80, 300, 30, 'unidad', 25, 19, 20, 1, 1, 'https://promart.vteximg.com.br/arquivos/ids/7832824-1000-1000/image-3083c12effa14034afbba112058602f2.jpg?v=638429140692230000'),
('PROD175', 'Bolsas para Congelar Alimentos', 'Bolsas con cierre hermético.', 7.00, 8.40, 100, 10, 'paquete', 25, 19, 5, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/8125921-450-450/912691.jpg?v=637829559844100000'),
('PROD176', 'Alimento para Gato Adulto 1kg', 'Alimento balanceado para gatos adultos.', 15.00, 18.00, 60, 6, 'kg', 27, 20, 1, 1, 1, 'https://promart.vteximg.com.br/arquivos/ids/471824-444-444/image-0a25531fe71a49ab9c2dc462e87ccb5e.jpg?v=637287870363830000'),
('PROD177', 'Galletas para Perro Cachorro', 'Premios para cachorros.', 8.50, 10.20, 70, 7, 'paquete', 27, 20, 5, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/598002-450-450/20116585.jpg?v=637436674031530000'),
('PROD178', 'Shampoo para Mascotas', 'Shampoo suave para perros y gatos.', 12.00, 14.40, 50, 5, 'L', 27, 20, 2, 1, 1, 'https://wongfood.vtexassets.com/arquivos/ids/580012-800-auto?v=637993933650470000&width=800&height=auto&aspect=true'),
('PROD179', 'Juguete para Gato Ratón', 'Juguete interactivo para gatos.', 5.00, 6.00, 80, 8, 'unidad', 27, 20, 20, 1, 1, 'https://wongfood.vtexassets.com/arquivos/ids/516950/JUGUETE-PARA-GATOS-CATNIP-RATON-1-254617937.jpg?v=637789953707370000'),
('PROD180', 'Arroz Integral 1kg', 'Arroz con alto contenido de fibra.', 6.00, 7.20, 200, 20, 'kg', 1, 1, 1, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQpjibzv4MjRX_V7jA5ne9V4jtTP0nGYPPhw&s'),
('PROD181', 'Leche de Almendras 1L', 'Bebida vegetal sin lactosa.', 10.00, 12.00, 100, 10, 'L', 4, 2, 2, 1, 1, 'https://www.lapurita.com/cdn/shop/files/Leche_de_Almendras_La_Purita_Bebida_de_almendras_1sachet_2.jpg?v=1739808160&width=1024'),
('PROD182', 'Queso Parmesano Rallado', 'Queso para pastas y ensaladas.', 18.00, 21.60, 50, 5, 'gr', 9, 3, 23, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/28992412-450-450/27649.jpg?v=638489376318900000'),
('PROD183', 'Detergente de Ropa en Cápsulas', 'Detergente en formato de cápsulas.', 25.00, 30.00, 40, 4, 'caja', 18, 4, 3, 2, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/29252857-418-418/image-5fa77a0f431442e99a7addd0795f9cee.jpg'),
('PROD184', 'Sopa Instantánea Pollo', 'Sopa rápida de pollo.', 3.00, 3.60, 200, 20, 'sachet', 1, 1, 6, 1, 1, 'https://www.tiendaperuonline.com/cdn/shop/products/7_8544d6e2-5a89-41b2-b428-1aa50a094772.png?v=1667308158'),
('PROD185', 'Pan Integral con Semillas', 'Pan saludable con semillas.', 9.00, 10.80, 100, 10, 'paquete', 17, 6, 5, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/20143890-450-450/20283501.jpg?v=638019806388000000'),
('PROD186', 'Lentejas Rojas 500gr', 'Lentejas de cocción rápida.', 4.50, 5.40, 250, 25, 'gr', 2, 7, 1, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7GfSPlIKRinzPU6HF7wYxIs1K2EQzo6cB-Q&s'),
('PROD187', 'Espárragos en Lata', 'Espárragos verdes en conserva.', 8.00, 9.60, 120, 12, 'unidad', 2, 5, 4, 3, 1, 'https://http2.mlstatic.com/D_NQ_NP_944129-MLC49189266093_022022-O.webp'),
('PROD188', 'Papas Onduladas Sabor Queso', 'Papas fritas con sabor a queso.', 4.20, 5.04, 300, 30, 'gr', 21, 9, 1, 1, 1, 'https://http2.mlstatic.com/D_NQ_NP_966102-MLU69244434888_052023-O.webp'),
('PROD189', 'Cereal de Avena con Miel', 'Cereal para el desayuno.', 10.00, 12.00, 150, 15, 'caja', 6, 10, 3, 2, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSYcNDQuPBY-iuSaitOvLQjVjEXX5onK2kMGA&s'),
('PROD190', 'Naranjas Frescas', 'Naranjas jugosas para zumo.', 2.80, 3.36, 200, 20, 'kg', 27, 11, 1, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRula6hbT6VyBVUSfF3Smtc4sJeOBWa0kanMQ&s'),
('PROD191', 'Pechuga de Pavo Feteada', 'Pechuga de pavo cocida en lonchas.', 15.00, 18.00, 40, 4, 'paquete', 27, 12, 5, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAcUIpbcodgFMy6A1O6igdAZu24wZs-eRAHQ&s'),
('PROD192', 'Tilapia Congelada Filete', 'Filete de tilapia sin piel.', 18.00, 21.60, 25, 2, 'kg', 27, 13, 5, 9, 1, 'https://jetextramar.com/wp-content/uploads/2020/07/pechuga-de-pavo-a-cortadas.jpg'),
('PROD193', 'Brócoli Congelado', 'Brócoli en floretes congelados.', 6.00, 7.20, 90, 9, 'kg', 17, 14, 1, 1, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRL1ZwFYUbBfTYNO-6JaPoPkV6vrMzKC2GV8g&s'),
('PROD194', 'Aceite de Maíz 1L', 'Aceite vegetal ligero.', 9.50, 11.40, 120, 12, 'L', 1, 15, 2, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/31513012-450-450/20088050.jpg?v=638857745687730000'),
('PROD195', 'Salsa Picante Roja', 'Salsa de ají picante.', 7.00, 8.40, 80, 8, 'frasco', 2, 16, 18, 4, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtaR9eWLh2k3xdws9Dq0eKPKRgG4U7dFa62A&s'),
('PROD196', 'Chocolates en Caja Surtidos', 'Caja de bombones de chocolate.', 20.00, 24.00, 50, 5, 'caja', 21, 17, 3, 2, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/28885615-512-512/20127584.jpg'),
('PROD197', 'Enjuague Bucal Menta', 'Enjuague bucal refrescante.', 12.00, 14.40, 70, 7, 'ml', 19, 18, 2, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/22278099-418-418/20026852001-1.jpg'),
('PROD198', 'Limpiador de Vidrios Aerosol', 'Limpiador para cristales.', 9.00, 10.80, 60, 6, 'unidad', 25, 19, 4, 3, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTj1qH04AJnkc-UbWEuM5TgGVCEba3gnG_CfQ&s'),
('PROD199', 'Alimento para Peces Escamas', 'Comida para peces de acuario.', 5.00, 6.00, 40, 4, 'frasco', 27, 20, 18, 4, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgSSr0MGs7bnHGrAOQUHXingDONBR_hpggMA&s'),
('PROD200', 'Agua Destilada 1L', 'Agua purificada para diversos usos.', 3.00, 3.60, 100, 10, 'L', 6, 2, 2, 1, 1, 'https://plazavea.vteximg.com.br/arquivos/ids/31043703-418-418/imageUrl_1.jpg');
GO


INSERT INTO TipoPromocion (nombre_tipo) VALUES
('Descuento fijo'),
('Descuento por porcentaje'),
('2x1'),
('Producto gratis'),
('Descuento por volumen'),
('Compra X, lleva Y con descuento'),
('Combo promocional'),
('Puntos dobles'),
('Envío gratis'),
('Cupón de descuento'),
('Oferta relámpago');
GO


INSERT INTO Promociones (NombrePromocion, Descuento, FechaInicio, FechaFin, Estado, id_tipo_promocion) VALUES
-- Promociones de 2024
('Promo Enero 2024 - 10%', 10.00, '2024-01-01', '2024-01-31', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento por porcentaje')),
('Descuento Febrero - S/5', 5.00, '2024-02-01', '2024-02-29', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento fijo')),
('2x1 en Bebidas Marzo', 50.00, '2024-03-01', '2024-03-15', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = '2x1')),
('Producto Gratis Limpieza', 100.00, '2024-04-01', '2024-04-30', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Producto gratis')),
('Descuento Mayo - 12%', 12.00, '2024-05-01', '2024-05-31', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento por porcentaje')),
('Promo Junio - S/8', 8.00, '2024-06-01', '2024-06-30', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento fijo')),
('Compra X, Lleva Y Julio', 20.00, '2024-07-01', '2024-07-15', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Compra X, lleva Y con descuento')),
('Puntos Dobles Agosto', 0.00, '2024-08-01', '2024-08-31', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Puntos dobles')),
('Envío Gratis Septiembre', 0.00, '2024-09-01', '2024-09-30', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Envío gratis')),
('Cupón Octubre - 15%', 15.00, '2024-10-01', '2024-10-31', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Cupón de descuento')),
('Oferta Relámpago Noviembre', 25.00, '2024-11-10', '2024-11-10', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Oferta relámpago')),
('Descuento Diciembre - 20%', 20.00, '2024-12-01', '2024-12-31', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento por porcentaje')),
('Combo Navideño 2024', 18.00, '2024-12-10', '2024-12-25', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Combo promocional')),

-- Promociones de 2025 (hasta la fecha actual)
('Descuento Enero 2025 - 8%', 8.00, '2025-01-01', '2025-01-31', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento por porcentaje')),
('Promo Febrero - S/10', 10.00, '2025-02-01', '2025-02-28', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento fijo')),
('2x1 en Snacks Marzo', 50.00, '2025-03-01', '2025-03-15', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = '2x1')),
('Producto Gratis Panadería', 100.00, '2025-04-01', '2025-04-30', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Producto gratis')),
('Descuento Mayo - 15%', 15.00, '2025-05-01', '2025-05-31', 0, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento por porcentaje')),
('Promo Junio - S/6', 6.00, '2025-06-01', '2025-06-30', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento fijo')),
('Compra X, Lleva Y Julio', 25.00, '2025-07-01', '2025-07-15', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Compra X, lleva Y con descuento')),
('Puntos Dobles Verano', 0.00, '2025-07-01', '2025-07-31', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Puntos dobles')),
('Envío Gratis Compras Grandes', 0.00, '2025-07-01', '2025-08-31', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Envío gratis')),
('Cupón JULIO25 - 10%', 10.00, '2025-07-05', '2025-07-20', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Cupón de descuento')),
('Oferta Relámpago Arroz', 18.00, '2025-07-07', '2025-07-07', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Oferta relámpago')),
('Descuento por Volumen Bebidas', 10.00, '2025-07-01', '2025-07-31', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento por volumen')),
('Combo Parrillero', 12.00, '2025-07-01', '2025-07-31', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Combo promocional')),
('Descuento Lácteos Frescos 7%', 7.00, '2025-07-01', '2025-07-14', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Descuento por porcentaje')),
('2x1 en Yogures Seleccionados', 50.00, '2025-07-08', '2025-07-15', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = '2x1')),
('Gratis 1 Café por Compra de 2', 100.00, '2025-07-01', '2025-07-31', 1, (SELECT id_tipo_promocion FROM TipoPromocion WHERE nombre_tipo = 'Producto gratis'));
GO



INSERT INTO ComprobantesPago (tipo, serie, numero) VALUES
('factura', 'CP001', '000001'),
('factura', 'CP002', '000002'),
('boleta', 'CP003', '000003'),
('boleta', 'CP004', '000004'),
('nota_credito', 'CP005', '000005'),
('nota_credito', 'CP006', '000006'),
('factura', 'CP007', '000007'),
('boleta', 'CP008', '000008'),
('factura', 'CP009', '000009'),
('nota_credito', 'CP010', '000010');


INSERT INTO MetodosPago (nombre, descripcion) VALUES
('Efectivo', 'Pago realizado en efectivo al momento de la entrega'),
('Transferencia bancaria', 'Depósito directo a cuenta bancaria'),
('Yape', 'Pago vía Yape'),
('Plin', 'Pago vía Plin'),
('Tarjeta de débito', 'Pago con tarjeta de débito en POS'),
('Tarjeta de crédito', 'Pago con tarjeta de crédito en POS'),
('Cheque', 'Pago con cheque empresarial'),
('Pago contra entrega', 'Pago al momento de recibir el pedido'),
('Depósito en agente', 'Depósito en agente autorizado'),
('Billetera digital', 'Pago a través de billetera digital distinta a Yape/Plin');



--------------------------------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------CODIGO DE SOPORTE--------------------------------------------------



-- Variables para almacenar los ID generados
DECLARE @id1 INT, @id2 INT, @id3 INT;

-- Inserción 1
INSERT INTO Usuarios (password_hash, rol) VALUES ('hash123', 'admin');
SET @id1 = SCOPE_IDENTITY();

-- Inserción 2
INSERT INTO Usuarios (password_hash, rol) VALUES ('hash456', 'admin');
SET @id2 = SCOPE_IDENTITY();

-- Inserción 3
INSERT INTO Usuarios (password_hash, rol) VALUES ('admin123hash', 'admin');
SET @id3 = SCOPE_IDENTITY();

-- Correos para Juan
INSERT INTO UsuarioCorreos (id_usuario, email) VALUES
(@id1, 'juan.admin1@example.com'),
(@id1, 'juan.admin2@example.com');

-- Correos para Laura
INSERT INTO UsuarioCorreos (id_usuario, email) VALUES
(@id2, 'laura.admin1@example.com'),
(@id2, 'laura.admin2@example.com');

-- Correo para Anderson
INSERT INTO UsuarioCorreos (id_usuario, email) VALUES
(@id3, 'anderson.admin@example.com');
GO

--eliminar identitis--
 --DBCC CHECKIDENT ('Usuarios', RESEED, 0); 




