USE master
GO

IF EXISTS(select * from sys.databases where name='DB_LegalPro')
DROP DATABASE DB_LegalPro
GO

CREATE DATABASE DB_LegalPro
GO

USE DB_LegalPro
GO

-- Tabla de Usuarios (Corregida con INT)
CREATE TABLE Usuarios (
    UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(256) NOT NULL UNIQUE,
    Clave NVARCHAR(MAX) NOT NULL,
    Rol NVARCHAR(50) NOT NULL,
	FechaCreacion DATETIME2 DEFAULT GETUTCDATE(),
	Activo BIT DEFAULT 1
);

-- Tabla de Casos (Corregida)
CREATE TABLE Casos (
    CasoId INT IDENTITY(1,1) PRIMARY KEY,
    NumeroCaso NVARCHAR(20) UNIQUE NOT NULL,
    ClienteId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
    AbogadoId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
    TipoCaso NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(MAX),
    FechaInicio DATETIME2 NOT NULL,
    FechaFin DATETIME2,
    Estado NVARCHAR(20) NOT NULL, -- 'Activo', 'En Proceso', 'Cerrado'
    FechaCreacion DATETIME2 DEFAULT GETUTCDATE(),
    Activo BIT DEFAULT 1
);

-- Tabla de Tareas (Corregida)
CREATE TABLE Tareas (
    TareaId INT IDENTITY(1,1) PRIMARY KEY,
    CasoId INT FOREIGN KEY REFERENCES Casos(CasoId),
    ResponsableId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
    Titulo NVARCHAR(200) NOT NULL,
    Descripcion NVARCHAR(MAX),
    FechaVencimiento DATETIME2 NOT NULL,
    Prioridad NVARCHAR(20) NOT NULL, -- 'Alta', 'Media', 'Baja'
    Estado NVARCHAR(20) NOT NULL, -- 'Pendiente', 'En Proceso', 'Completada'
    FechaCreacion DATETIME2 DEFAULT GETUTCDATE(),
    Activo BIT DEFAULT 1
);

-- Tabla de Documentos (Corregida)
CREATE TABLE Documentos (
    DocumentoId INT IDENTITY(1,1) PRIMARY KEY,
    CasoId INT FOREIGN KEY REFERENCES Casos(CasoId),
    Nombre NVARCHAR(255) NOT NULL,
    Ruta NVARCHAR(500) NOT NULL,
    TipoDocumento NVARCHAR(50) NOT NULL,
    SubidoPor INT FOREIGN KEY REFERENCES Usuarios(UsuarioId),
    FechaSubida DATETIME2 DEFAULT GETUTCDATE(),
    Activo BIT DEFAULT 1
);

-- Tabla de Eventos (Corregida)
CREATE TABLE Eventos (
    EventoId INT IDENTITY(1,1) PRIMARY KEY,
    CasoId INT FOREIGN KEY REFERENCES Casos(CasoId),
    Titulo NVARCHAR(200) NOT NULL,
    Descripcion NVARCHAR(MAX),
    FechaInicio DATETIME2 NOT NULL,
    FechaFin DATETIME2 NOT NULL,
    TipoEvento NVARCHAR(50) NOT NULL, -- 'Audiencia', 'Plazo', 'Reunión'
    RecordatorioEnviado BIT DEFAULT 0,
    Activo BIT DEFAULT 1,
    CreadoPor INT FOREIGN KEY REFERENCES Usuarios(UsuarioId)
);