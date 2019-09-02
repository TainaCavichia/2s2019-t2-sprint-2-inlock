USE M_InLock;

SELECT * FROM Usuarios;

SELECT * FROM Estudios;

SELECT * FROM Jogos;

SELECT J.*, E.NomeEstudio
FROM Jogos J
JOIN Estudios E
ON J.EstudioId = E.EstudioId;

SELECT E.*, J.*
FROM Estudios E 
FULL JOIN Jogos J
ON J.EstudioId = E.EstudioId;

SELECT U.*
FROM Usuarios U
WHERE Email = 'admin@admin.com' AND Senha = 'admin';

SELECT J.*
FROM Jogos J
WHERE J.JogosId = 1;

SELECT E.*
FROM Estudios E
WHERE E.EstudioId = 1;
