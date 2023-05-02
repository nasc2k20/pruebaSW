CREATE DATABASE pruebaSW

USE pruebaSW;


CREATE TABLE empleados (
	idEmpleado INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	codigoEmpleado CHAR(25) NOT NULL,
	nombresEmpleado CHAR (200) NOT NULL,
	apellidosEmpleado CHAR(200) NOT NULL,
	correoEmpleado CHAR(100) NOT NULL,
	salarioEmpleado DECIMAL(12,2) NOT NULL
);

CREATE TABLE productos (
	idProducto INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	codigoProducto INT NOT NULL,
	nombreProducto CHAR (200) NOT NULL,
	precioProducto DECIMAL (12,2) NOT NULL
);

CREATE TABLE ventas (
	idVenta INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	idEmpleado INT NOT NULL,
	idProducto INT NOT NULL,
	cantidadVenta INT NOT NULL,
	precioVenta DECIMAL(12,2) NOT NULL,
	totalVenta DECIMAL(12,2) NOT NULL
);

ALTER TABLE ventas ADD CONSTRAINT fk_ventaEmpl FOREIGN KEY (idEmpleado) REFERENCES empleados(idEmpleado);
ALTER TABLE ventas ADD CONSTRAINT fk_ventaProd FOREIGN KEY (idProducto) REFERENCES productos(idProducto);

/*PROCEDIMIENTOS ALMACENADOS PARA CRUD DE TABLA EMPLEADOS*/
CREATE PROCEDURE empleado_consultar
AS
BEGIN
	SELECT * FROM empleados ORDER BY nombresEmpleado ASC
END

CREATE PROCEDURE empleado_listar
	@idEmpleado INT
AS
BEGIN
	SELECT * FROM empleados WHERE idEmpleado = @idEmpleado
END

CREATE PROCEDURE empleado_insertar
	@codigoEmpleado CHAR(25),
	@nombresEmpleado CHAR (200),
	@apellidosEmpleado CHAR(200),
	@correoEmpleado CHAR(100),
	@salarioEmpleado DECIMAL(12,2)
AS
BEGIN
	INSERT INTO empleados (codigoEmpleado, nombresEmpleado, apellidosEmpleado, correoEmpleado, salarioEmpleado) 
					VALUES (@codigoEmpleado, @nombresEmpleado, @apellidosEmpleado, @correoEmpleado, @salarioEmpleado)
END

CREATE PROCEDURE empleado_actualizar
	@idEmpleado INT,
	@codigoEmpleado CHAR(25),
	@nombresEmpleado CHAR (200),
	@apellidosEmpleado CHAR(200),
	@correoEmpleado CHAR(100),
	@salarioEmpleado DECIMAL(12,2)
AS
BEGIN
	UPDATE empleados 
	SET 
	codigoEmpleado = @codigoEmpleado, 
	nombresEmpleado = @nombresEmpleado, 
	apellidosEmpleado = @apellidosEmpleado, 
	correoEmpleado = @correoEmpleado, 
	salarioEmpleado = @salarioEmpleado 
	WHERE idEmpleado = @idEmpleado
END


CREATE PROCEDURE empleado_eliminar
	@idEmpleado INT
AS
BEGIN
	DELETE FROM empleados WHERE idEmpleado = @idEmpleado
END


/*PROCEDIMIENTOS ALMACENADOS PARA CRUD DE TABLA PRODUCTOS*/
CREATE PROCEDURE producto_consultar
AS
BEGIN
	SELECT * FROM productos ORDER BY nombreProducto ASC
END

EXEC producto_consultar
CREATE PROCEDURE producto_listar
	@idProducto INT
AS
BEGIN
	SELECT * FROM productos WHERE idProducto = @idProducto
END

CREATE PROCEDURE producto_insertar
	@codigoProducto INT,
	@nombreProducto CHAR (200),
	@precioProducto DECIMAL (12,2)
AS
BEGIN
	INSERT INTO productos (codigoProducto, nombreProducto, precioProducto) 
					VALUES (@codigoProducto, @nombreProducto, @precioProducto)
END

CREATE PROCEDURE producto_actualizar
	@idProducto INT,
	@codigoProducto INT,
	@nombreProducto CHAR (200),
	@precioProducto DECIMAL (12,2)
AS
BEGIN
	UPDATE productos 
	SET 
	codigoProducto = @codigoProducto, 
	nombreProducto = @nombreProducto, 
	precioProducto = @precioProducto 
	WHERE idProducto = @idProducto
END


CREATE PROCEDURE producto_eliminar
	@idProducto INT
AS
BEGIN
	DELETE FROM productos WHERE idProducto = @idProducto
END


/*PROCEDIMIENTOS ALMACENADOS PARA CRUD DE TABLA VENTAS*/
CREATE PROCEDURE venta_consultar
AS
BEGIN
	SELECT * FROM ventas ORDER BY idVenta ASC
END

CREATE PROCEDURE venta_listar
	@idVenta INT
AS
BEGIN
	SELECT * FROM ventas WHERE idEmpleado = @idVenta
END


CREATE PROCEDURE listarEmpleadoCombo
AS
BEGIN
	SELECT (nombresEmpleado + ' ' + apellidosEmpleado)AS NombreCompleto, idEmpleado FROM empleados ORDER BY nombresEmpleado ASC
END

CREATE PROCEDURE venta_insertar	
	@idEmpleado INT,
	@idProducto INT,
	@cantidadVenta INT,
	@precioVenta DECIMAL(12,2),
	@totalVenta DECIMAL(12,2)
AS
BEGIN
	INSERT INTO ventas(idEmpleado, idProducto, cantidadVenta, precioVenta, totalVenta) 
					VALUES (@idEmpleado, @idProducto, @cantidadVenta, @precioVenta, @totalVenta)
END

EXEC venta_consultar

CREATE PROCEDURE venta_actualizar
	@idVenta INT,
	@idEmpleado INT,
	@idProducto INT,
	@cantidadVenta INT,
	@precioVenta DECIMAL(12,2),
	@totalVenta DECIMAL(12,2)
AS
BEGIN
	UPDATE ventas 
	SET 
	cantidadVenta = @cantidadVenta, 
	precioVenta = @precioVenta, 
	totalVenta = @totalVenta
	WHERE idVenta = @idVenta
END


CREATE PROCEDURE venta_eliminar
	@idVenta INT
AS
BEGIN
	DELETE FROM ventas WHERE idVenta = @idVenta
END