CREATE DATABASE M_InLock;

USE M_InLock;

CREATE TABLE Usuarios
(
	UsuarioId	INT PRIMARY KEY IDENTITY
	,Email		VARCHAR(255) NOT NULL UNIQUE
	,Senha		VARCHAR(255) NOT NULL
	,Permissao	VARCHAR(255) NOT NULL
);

CREATE TABLE Estudios
(
	EstudioId			INT PRIMARY KEY IDENTITY
	,NomeEstudio		VARCHAR(255) NOT NULL UNIQUE
	,PaisOrigem			VARCHAR(255) NOT NULL
	,DataCriacao		DATE NOT NULL
	,UsuarioId			INT FOREIGN KEY REFERENCES Usuarios (UsuarioId) NOT NULL
);

CREATE TABLE Jogos
(
	JogosId				INT PRIMARY KEY IDENTITY
	,NomeJogo			VARCHAR(255) NOT NULL
	,Descricao			TEXT NOT NULL
	,DataLancamento		DATE NOT NULL
	,Valor				FLOAT NOT NULL
	,EstudioId			INT FOREIGN KEY REFERENCES Estudios(EstudioId) NOT NULL
);