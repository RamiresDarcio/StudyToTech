-- Script para criar o banco de dados StudyToTech
-- Execute isso no SQL Server Management Studio ou Azure Data Studio

CREATE DATABASE StudyToTech;
GO

USE StudyToTech;
GO

-- Tabela de Usuários
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    DataCadastro DATETIME DEFAULT GETDATE()
);

-- Tabela de Disciplinas
CREATE TABLE Disciplinas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT NOT NULL,
    Nome VARCHAR(100) NOT NULL,
    Descricao VARCHAR(500),
    DataCadastro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

-- Tabela de Tarefas
CREATE TABLE Tarefas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DisciplinaId INT NOT NULL,
    Titulo VARCHAR(200) NOT NULL,
    Descricao VARCHAR(1000),
    DataEntrega DATETIME,
    Concluida BIT DEFAULT 0,
    DataCadastro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (DisciplinaId) REFERENCES Disciplinas(Id) ON DELETE CASCADE
);

-- Tabela de Histórico de Atividades
CREATE TABLE HistoricoAtividades (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT NOT NULL,
    TipoAtividade VARCHAR(100),
    Descricao VARCHAR(500),
    DataAtividade DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

-- Tabela de Metas de Estudo
CREATE TABLE MetasEstudo (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT NOT NULL,
    Descricao VARCHAR(500),
    DataAlvo DATETIME,
    Concluida BIT DEFAULT 0,
    DataCadastro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

-- Tabela de Eventos do Calendário
CREATE TABLE CalendarioEventos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT NOT NULL,
    Titulo VARCHAR(200),
    DataEvento DATETIME,
    Descricao VARCHAR(500),
    DataCadastro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

-- Criar índices para melhor performance
CREATE INDEX idx_Disciplinas_UsuarioId ON Disciplinas(UsuarioId);
CREATE INDEX idx_Tarefas_DisciplinaId ON Tarefas(DisciplinaId);
CREATE INDEX idx_Historico_UsuarioId ON HistoricoAtividades(UsuarioId);
CREATE INDEX idx_Metas_UsuarioId ON MetasEstudo(UsuarioId);
CREATE INDEX idx_Calendario_UsuarioId ON CalendarioEventos(UsuarioId);
