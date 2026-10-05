CREATE DATABASE LAB3
CREATE TABLE Note(
	CodS INT,
    Curs VARCHAR(100),
    Nota INT,
    An INT,
	Taxa NUMERIC(7,2)
);

CREATE TABLE Studenti (
    CodS INT PRIMARY KEY,
    nume VARCHAR(50),
    prenume VARCHAR(50),
    incheiat_studii VARCHAR(3)
);

SELECT * FROM Note;

SELECT nume, prenume 
FROM Studenti 
WHERE incheiat_studii = 'Nu';

DELETE FROM Note;
INSERT INTO Note (CodS, Curs, Nota, An, Taxa) VALUES 
('005', 'Fizica', 6, 1, 35.5),
('005', 'Chimie', 5, 1, NULL),
('002', 'Fizica', 10, 1, NULL),
('002', 'Chimie', 9, 1, 25.75),
('005', 'Istorie', 7, 1, 35.5),
('005', 'Engleza', 7, 1, NULL),
('006', 'P.C. I', 10, 1, NULL),
('006', 'P.C. II', 9, 1, NULL);

SELECT s.nume, s.prenume 
FROM Studenti s
INNER JOIN Note n ON s.CodS = n.CodS
WHERE n.Taxa IS NOT NULL;

SELECT s.nume, s.prenume, n.Curs, n.Nota 
FROM Studenti s
INNER JOIN Note n ON s.CodS = n.CodS;

SELECT DISTINCT prenume 
FROM Studenti;

SELECT n.Curs, n.Nota 
FROM Studenti s
INNER JOIN Note n ON s.CodS = n.CodS
WHERE s.nume = 'Radu' AND s.prenume = 'Tiberiu';

SELECT CodS, Curs, Nota, An, ISNULL(Taxa, 0) + 10 AS Taxa_Marita 
FROM Note;

SELECT CodS, Curs, Nota, An, ISNULL(Taxa, 0) * 0.75 AS Taxa_Reducere 
FROM Note;

SELECT CodS, Curs, Nota, An, ISNULL(Taxa, 0) * 1.1 AS Taxa_Marita 
FROM Note;

UPDATE Note
SET Taxa = ISNULL(Taxa, 0) * 1.1
WHERE CodS = (SELECT CodS FROM Studenti WHERE nume = 'Radu' AND prenume = 'Tiberiu');

SELECT CONCAT(nume, ' ', prenume) AS Nume_Complet 
FROM Studenti;

SELECT s.nume, s.prenume, n.Curs 
FROM Studenti s
INNER JOIN Note n ON s.CodS = n.CodS
WHERE n.An = 1;

ALTER TABLE Note DROP COLUMN Taxa;

ALTER TABLE Note ADD Taxa NUMERIC(5, 2);

UPDATE Note
SET Taxa = CASE 
    WHEN CodS = '005' AND Curs = 'Fizica' THEN 35.5
    WHEN CodS = '002' AND Curs = 'Chimie' THEN 25.75
    WHEN CodS = '005' AND Curs = 'Istorie' THEN 35.5
    ELSE NULL
END;

UPDATE Note
SET Taxa = ISNULL(Taxa, 0) * 1.1
WHERE CodS = (SELECT CodS FROM Studenti WHERE nume = 'Radu' AND prenume = 'Tiberiu');

SELECT CodS, Curs, Nota, An, Taxa 
FROM Note 
WHERE CodS = (SELECT CodS FROM Studenti WHERE nume = 'Radu' AND prenume = 'Tiberiu');


DELETE FROM Note; -- stergem toate inregistrarile din tabelul Note

INSERT INTO Note (CodS, Curs, Nota, An, Taxa) VALUES
('005', 'Fizica', 6, 1, 35.5),
('005', 'Chimie', 5, 1, NULL),
('002', 'Fizica', 10, 1, NULL),
('002', 'Chimie', 9, 1, 25.75),
('005', 'Istorie', 7, 1, 35.5),
('005', 'Engleza', 7, 1, NULL),
('006', 'P.C. I', 10, 1, NULL),
('006', 'P.C. II', 9, 1, NULL);

SELECT nume, prenume
FROM Studenti
WHERE prenume = 'Andrei';

SELECT nume, prenume
FROM Studenti
WHERE prenume <> 'Cristina';

SELECT nume, prenume
FROM Studenti
WHERE prenume IN ('Andrei', 'Cristina');

SELECT nume, prenume
FROM Studenti
WHERE nume LIKE 'B%';

SELECT nume, prenume
FROM Studenti
WHERE nume LIKE '%A';

SELECT nume, prenume
FROM Studenti
WHERE nume LIKE '%T%';

SELECT DISTINCT s.nume, s.prenume
FROM Studenti s
INNER JOIN Note n ON s.CodS = n.CodS
WHERE n.Taxa BETWEEN 20 AND 40;

SELECT DISTINCT s.nume, s.prenume
FROM Studenti s
INNER JOIN Note n ON s.CodS = n.CodS
WHERE n.Taxa < 20 OR n.Taxa > 40;

SELECT nume, prenume
FROM Studenti
WHERE nume LIKE '[a-i]%'
ORDER BY nume, prenume;

SELECT nume, prenume
FROM Studenti
WHERE CodS BETWEEN (SELECT MIN(CodS) FROM Note) AND (SELECT MAX(CodS) FROM Note)
ORDER BY nume, prenume;

SELECT DISTINCT s.nume, s.prenume
FROM Studenti s
INNER JOIN Note n ON s.CodS = n.CodS;

SELECT nume, prenume
FROM Studenti
WHERE oras IN ('Brașov', 'Iași', 'Covasna');

SELECT nume, prenume
FROM Studenti
WHERE oras <> 'Brașov';

SELECT DISTINCT s.nume, s.prenume
FROM Studenti s
INNER JOIN Note n ON s.CodS = n.CodS
WHERE n.Nota > 7

UNION

SELECT DISTINCT s.nume, s.prenume
FROM Studenti s
INNER JOIN Note n ON s.CodS = n.CodS
WHERE n.Nota = 5;


