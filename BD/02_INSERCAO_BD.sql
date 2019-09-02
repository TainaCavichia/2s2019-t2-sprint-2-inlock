USE M_InLock;

INSERT INTO Usuarios	(Email, Senha, Permissao)
	VALUES				('admin@admin.com','admin','ADMINISTRADOR')
						,('cliente@cliente.com','cliente','CLIENTE');

INSERT INTO Estudios	(NomeEstudio, PaisOrigem, DataCriacao, UsuarioId)
	VALUES				('Blizzard','Estados Unidos',GETDATE(),1)
						,('Rockstar Studios','Estados Unidos',GETDATE(),1)
						,('Square Enix','Japão',GETDATE(),1);

INSERT INTO Jogos		(NomeJogo, Descricao, DataLancamento, Valor, EstudioId)
	VALUES				('Diablo 3','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','2012-05-15', 99.00, 1)
						,('Red Dead Redempition II','jogo eletrônico de ação-aventura western.','2018-10-26', 120.00, 2);