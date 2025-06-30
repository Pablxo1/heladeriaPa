CREATE DATABASE FinalHeladeria;
GO
USE [master]
GO
CREATE LOGIN [usrfheladeria] WITH PASSWORD = N'123456',
	DEFAULT_DATABASE = [FinalHeladeria],
	CHECK_EXPIRATION = OFF,
	CHECK_POLICY = ON
GO
USE [FinalHeladeria]
GO
CREATE USER [usrfheladeria] FOR LOGIN [usrfheladeria]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrfheladeria]
GO

DROP TABLE VentaDetalle;
DROP TABLE Venta;
DROP TABLE TipoPago;
DROP TABLE Cliente;
DROP TABLE Usuario;
DROP TABLE Empleado;
DROP TABLE Cargo;
DROP TABLE Producto;
DROP TABLE Presentacion;
DROP TABLE Proveedor;
DROP TABLE Sabor;

CREATE TABLE Sabor (
  id INT PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE Proveedor (
  id INT PRIMARY KEY IDENTITY(1,1),
  razonSocial VARCHAR(100) NOT NULL UNIQUE,
  nit VARCHAR(20) NOT NULL UNIQUE,
  telefono VARCHAR(15) NOT NULL,
  direccion VARCHAR(250),
  tipoProducto VARCHAR(100) NOT NULL
);

CREATE TABLE Presentacion (
  id INT PRIMARY KEY IDENTITY(1,1),
  descripcion VARCHAR(100) NOT NULL,
);

CREATE TABLE Producto (
  id INT PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(100) NOT NULL,
  idSabor INT NOT NULL,
  idProveedor INT NOT NULL,
  idPresentacion INT NOT NULL,
  precio DECIMAL(10,2) NOT NULL CHECK (precio > 0),
  CONSTRAINT fk_Producto_Sabor FOREIGN KEY(idSabor) REFERENCES Sabor(id),
  CONSTRAINT fk_Producto_Proveedor FOREIGN KEY(idProveedor) REFERENCES Proveedor(id),
  CONSTRAINT fk_Producto_Presentacion FOREIGN KEY(idPresentacion) REFERENCES Presentacion(id)
);

CREATE TABLE Cargo (
  id INT PRIMARY KEY IDENTITY(1,1),
  descripcion VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Empleado (
  id INT PRIMARY KEY IDENTITY(1,1),
  nombres VARCHAR(100) NOT NULL,
  primerApellido VARCHAR(100),
  segundoApellido VARCHAR(100),
  telefono VARCHAR(15) NOT NULL,
  direccion VARCHAR(250) NOT NULL,
  idCargo INT NOT NULL,
  CONSTRAINT fk_Empleado_Cargo FOREIGN KEY(idCargo) REFERENCES Cargo(id)
);

CREATE TABLE Usuario (
  id INT PRIMARY KEY IDENTITY(1,1),
  idEmpleado INT NOT NULL,
  usuario VARCHAR(20) NOT NULL UNIQUE,
  clave VARCHAR(250) NOT NULL,
  CONSTRAINT fk_Usuario_Empleado FOREIGN KEY(idEmpleado) REFERENCES Empleado(id)
);

CREATE TABLE Cliente (
  id INT PRIMARY KEY IDENTITY(1,1),
  nombre VARCHAR(100) NOT NULL,
  nit VARCHAR(20) NOT NULL UNIQUE,
  celular VARCHAR(15) NOT NULL
);

CREATE TABLE TipoPago (
  id INT PRIMARY KEY IDENTITY(1,1),
  descripcion VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Venta (
  id INT PRIMARY KEY IDENTITY(1,1),
  idUsuario INT NOT NULL,
  idCliente INT NOT NULL,
  idTipoPago INT NOT NULL,
  montoTotal DECIMAL(10,2) NOT NULL,
  montoPago DECIMAL(10,2) NOT NULL,
  montoCambio DECIMAL(10,2) NOT NULL,
  CONSTRAINT fk_Venta_Usuario FOREIGN KEY(idUsuario) REFERENCES Usuario(id),
  CONSTRAINT fk_Venta_Cliente FOREIGN KEY(idCliente) REFERENCES Cliente(id),
  CONSTRAINT fk_Venta_TipoPago FOREIGN KEY(idTipoPago) REFERENCES TipoPago(id)
);

CREATE TABLE VentaDetalle (
  id INT PRIMARY KEY IDENTITY(1,1),
  idVenta INT NOT NULL,
  idProducto INT NOT NULL,
  cantidad INT NOT NULL CHECK (cantidad > 0),
  precioUnitario DECIMAL(10,2) NOT NULL,
  total DECIMAL(10,2) NOT NULL,
  CONSTRAINT fk_VentaDetalle_Venta FOREIGN KEY(idVenta) REFERENCES Venta(id),
  CONSTRAINT fk_VentaDetalle_Producto FOREIGN KEY(idProducto) REFERENCES Producto(id)
);

ALTER TABLE Sabor ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Sabor ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Sabor ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Proveedor ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Proveedor ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Proveedor ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Presentacion ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Presentacion ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Presentacion ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Producto ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Producto ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Producto ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Cargo ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Cargo ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Cargo ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Empleado ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Empleado ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Empleado ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Usuario ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Usuario ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Usuario ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Cliente ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Cliente ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Cliente ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE TipoPago ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE TipoPago ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE TipoPago ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE Venta ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Venta ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Venta ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:Eliminado, 0: Inactivo, 1: Activo

ALTER TABLE VentaDetalle ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE VentaDetalle ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE VentaDetalle ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1:NoEntergado, 0: Entregado, 1: Pendiente

-- Procedimientos Almacenados
GO
CREATE PROC paSaborListar @parametro VARCHAR(100)
AS
  SELECT * FROM Sabor
  WHERE estado<>-1 AND nombre LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY estado DESC, nombre ASC;

GO
CREATE PROC paProveedorListar @parametro VARCHAR(100)
AS
  SELECT * FROM Proveedor
  WHERE estado<>-1 AND razonSocial + nit + telefono LIKE '%'+REPLACE(@parametro,' ','%')+'%'
  ORDER BY estado DESC, razonSocial ASC;

GO
CREATE PROC paPresentacionListar @parametro VARCHAR(100)
AS
  SELECT * FROM Presentacion
  WHERE estado <> -1 AND descripcion LIKE '%'+REPLACE(@parametro, ' ', '%')+'%'
  ORDER BY estado DESC, descripcion ASC;

GO
create PROC paProductoListar @parametro VARCHAR(100)
AS
  SELECT 
    p.id, 
    p.nombre, 
    s.nombre AS sabor, 
    pr.razonSocial AS proveedor, 
    pre.descripcion AS presentacion, 
    p.precio
  FROM Producto p
  JOIN Sabor s ON p.idsabor = s.id
  JOIN Proveedor pr ON p.idproveedor = pr.id
  JOIN Presentacion pre ON p.idPresentacion = pre.id
  WHERE p.estado <> -1 
    AND (ISNULL(p.nombre, '') + ISNULL(s.nombre, '') + ISNULL(pr.razonSocial, '') + ISNULL(pre.descripcion, '')) 
        LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
  ORDER BY p.estado DESC, p.nombre ASC;

GO
create PROC paEmpleadoListar @parametro VARCHAR(100)
AS
  SELECT 
    e.id, 
    e.nombres, 
    e.primerApellido, 
    e.segundoApellido, 
    e.telefono, 
    e.direccion, 
    c.descripcion AS cargo
  FROM Empleado e
  JOIN Cargo c ON e.idCargo = c.id
  WHERE e.estado <> -1 
    AND (ISNULL(e.nombres, '') + ISNULL(e.primerApellido, '') + ISNULL(e.segundoApellido, '') + ISNULL(c.descripcion, '')) 
        LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
  ORDER BY e.estado DESC, e.nombres ASC, e.primerApellido ASC;

GO
CREATE PROC paClienteListar @parametro VARCHAR(100)
AS
  SELECT id,nombre,nit,celular
  FROM Cliente
  WHERE estado <> -1 
    AND (ISNULL(nombre, '') + ISNULL(nit, '') + ISNULL(celular, '')) 
        LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
  ORDER BY nombre ASC;

GO
CREATE PROC paVentaListar @parametro VARCHAR(100)
AS
  SELECT 
    v.id,
    tp.descripcion AS tipoPago,
    ISNULL(u.usuario, '--') AS usuario,
    c.nombre AS cliente,
    v.montoPago,
    v.montoCambio,
    v.montoTotal,
    v.fechaRegistro,
    v.estado
  FROM Venta v
  LEFT JOIN Usuario u ON v.idUsuario = u.id
  LEFT JOIN Cliente c ON v.idCliente = c.id
  JOIN TipoPago tp ON v.idTipoPago = tp.id 
  WHERE v.estado <> -1 
    AND (ISNULL(u.usuario, '') + ISNULL(tp.descripcion, '') + ISNULL(c.nombre, '')) 
        LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
  ORDER BY v.fechaRegistro DESC;


GO
CREATE PROC paVentaDetalleListar @idVenta INT
AS
  SELECT 
    vd.id, 
    p.nombre AS producto, 
    s.nombre AS sabor, 
    pr.razonSocial AS proveedor, 
    pre.descripcion AS presentacion, 
    vd.cantidad, 
    vd.precioUnitario, 
    vd.total,
    vd.fechaRegistro,
    vd.estado
  FROM VentaDetalle vd
  JOIN Producto p ON vd.idProducto = p.id
  JOIN Sabor s ON p.idSabor = s.id
  JOIN Proveedor pr ON p.idProveedor = pr.id
  JOIN Presentacion pre ON p.idPresentacion = pre.id
  WHERE vd.estado <> -1 
    AND vd.idVenta = @idVenta
  ORDER BY vd.fechaRegistro DESC;
 --DML
INSERT INTO Sabor (nombre)
VALUES ('Manzana'), ('Frutilla'), ('Naranja'), ('Banana'), ('Limón');

INSERT INTO Proveedor(razonSocial, nit, telefono, direccion, tipoProducto)
VALUES ('Frutas Frescas S.A.', '456789123', '555-111', 'Calle 1', 'Frutas Dulces');
INSERT INTO Proveedor(razonSocial, nit, telefono, direccion, tipoProducto)
VALUES ('Cítricos del Sol S.R.L.', '987654321', '555-2222', 'Avenida 2', 'Frutas Cítricas'); 
INSERT INTO Proveedor(razonSocial, nit, telefono, direccion, tipoProducto)	   
VALUES ('Exquisitas Frutas S.A.', '800654321', '555-3333', 'Boulevard 3', 'Frutas Semiácidas');
	  
--Frutas dulces: Banana, Manzana roja
--Frutas cítricas: Naranja, Limón
--Frutas semiácidas: Frutilla

INSERT INTO Presentacion (descripcion) 
VALUES ('Cono'), ('Vaso de plástico 250 ml'), ('Tarrina 1 L'), ('Vaso de plástico 500 ml');

INSERT INTO Producto (nombre, idSabor, idProveedor, idPresentacion, precio)
VALUES ('Manzana Mística', 1, 1, 2, 10.00);
INSERT INTO Producto (nombre, idSabor, idProveedor, idPresentacion, precio)
VALUES ('Frescura Frutilla', 2, 3, 1, 07.00);

INSERT INTO Cargo (descripcion)
VALUES ('Gerente'), ('Vendedor'), ('Cajero');

INSERT INTO Empleado (nombres, primerApellido, segundoApellido, telefono, direccion, idCargo)
VALUES ('Rami', 'Saigua', 'López', '72345678', 'Calle Brasil', 1);

INSERT INTO Usuario (idEmpleado, usuario, clave)
VALUES (1, 'rsaigua', '');

UPDATE Usuario SET clave = 'Fo29nhWFgz6S2F47mbGlbA==' WHERE idEmpleado = 1;

INSERT INTO Cliente (nombre, nit, celular)
VALUES ('Mateo', '987654321', '72345678');
INSERT INTO Cliente (nombre, nit, celular)
VALUES ('Ana', '123456789', '72345679');
INSERT INTO Cliente (nombre, nit, celular)
VALUES ('Carol', '789123456', '72345681');

INSERT INTO TipoPago (descripcion)
VALUES ('Efectivo'), ('Tarjeta de crédito'), ('QR');

INSERT INTO Venta (idUsuario, idCliente, idTipoPago, montoTotal, montoPago, montoCambio)
VALUES (1, 1, 1, 20.00, 50.00, 30.00);

INSERT INTO VentaDetalle (idVenta, idProducto, cantidad, precioUnitario, total)
VALUES (1, 1, 2, 10.00, 20.00);

SELECT * FROM Sabor;
SELECT * FROM Proveedor;
SELECT * FROM Presentacion;
SELECT * FROM Producto;
SELECT * FROM Empleado;
SELECT * FROM Usuario;
SELECT * FROM Cliente;
SELECT * FROM Venta;
SELECT * FROM VentaDetalle;

SELECT * FROM Producto WHERE Id = 3

SELECT Id, Nombre, Precio FROM Producto