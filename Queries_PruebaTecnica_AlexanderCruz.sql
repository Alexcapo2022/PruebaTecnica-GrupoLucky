CREATE DATABASE MVC_DAPPER
USE MVC_DAPPER

CREATE TABLE Productos(
	Id int IDENTITY(1,1) not NULL,
	Nombre Varchar(50),
	Precio DECIMAL(18,2)
)

CREATE PROCEDURE InsertarProducto
@Nombre Varchar(50),
@Precio DECIMAL(18,2)
AS BEGIN
INSERT INTO Productos values(@Nombre,@Precio)
END

CREATE PROCEDURE EliminarProducto
@Id int
AS BEGIN
DELETE FROM Productos WHERE Id=@Id
END

CREATE PROCEDURE ActualizarProducto
@Id int,
@Nombre varchar(50),
@Precio decimal(18,2)
AS BEGIN
UPDATE Productos set Nombre=@Nombre, Precio=@Precio WHERE Id=@Id
END

CREATE PROCEDURE ObtenerProductoPorId
@Id int 
AS BEGIN
SELECT * FROM Productos WHERE Id=@Id
END

CREATE PROCEDURE ObtenerProductos
AS BEGIN
SELECT * FROM Productos
END