USE master;
GO

DROP DATABASE IF EXISTS prueba_2;
GO

CREATE DATABASE prueba_2;
GO

USE prueba_2;
GO

CREATE TABLE Alumno (
    codigo INT PRIMARY KEY,
    nombres NVARCHAR(100),
    carrera NVARCHAR(100),
    domicilio NVARCHAR(200)
);
GO
-- Insertar un nuevo alumno
--INSERT INTO Alumno (codigo, nombres, carrera, domicilio)
--VALUES (1, 'Juan Perez', 'Ingeniería', 'Calle Falsa 123');
--GO

--INSERT INTO Alumno (codigo, nombres, carrera, domicilio)
--VALUES (2, 'Maria Lopez', 'Medicina', 'Avenida Siempre Viva 456');
--GO

-- select * from Alumno

-- Procedimiento para insertar un nuevo alumno
CREATE PROCEDURE InsertarAlumno
    @Codigo INT,
    @Nombres NVARCHAR(100),
    @Carrera NVARCHAR(100),
    @Domicilio NVARCHAR(200)
AS
BEGIN
    INSERT INTO Alumno (codigo, nombres, carrera, domicilio)
    VALUES (@Codigo, @Nombres, @Carrera, @Domicilio);
END;
GO

-- Procedimiento para obtener todos los alumnos
CREATE PROCEDURE ObtenerAlumnos
AS
BEGIN
    SELECT * FROM Alumno;
END;
GO

-- Procedimiento para actualizar un alumno existente
CREATE PROCEDURE ActualizarAlumno
    @Codigo INT,
    @Nombres NVARCHAR(100),
    @Carrera NVARCHAR(100),
    @Domicilio NVARCHAR(200)
AS
BEGIN
    UPDATE Alumno
    SET nombres = @Nombres, carrera = @Carrera, domicilio = @Domicilio
    WHERE codigo = @Codigo;
END;
GO

-- Procedimiento para eliminar un alumno
CREATE PROCEDURE EliminarAlumno
    @Codigo INT
AS
BEGIN
    DELETE FROM Alumno
    WHERE codigo = @Codigo;
END;
GO

-- Insertar un nuevo alumno
--EXEC InsertarAlumno @Codigo = 1, @Nombres = 'Juan Perez', @Carrera = 'Ingeniería', @Domicilio = 'Calle Falsa 123';
--GO

--EXEC InsertarAlumno @Codigo = 2, @Nombres = 'Maria Lopez', @Carrera = 'Medicina', @Domicilio = 'Avenida Siempre Viva 456';
--GO

-- Obtener todos los alumnos
--EXEC ObtenerAlumnos;
--GO

-- Actualizar un alumno existente
--EXEC ActualizarAlumno @Codigo = 1, @Nombres = 'Juan Pérez', @Carrera = 'Ingeniería de Sistemas', @Domicilio = 'Avenida Siempre Viva 456';
--GO

-- Eliminar un alumno
--EXEC EliminarAlumno @Codigo = 1;
--GO