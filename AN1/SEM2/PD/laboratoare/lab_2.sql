CREATE DATABASE grupa1
USE grupa1

CREATE TABLE Student (
    CodS CHAR(5) PRIMARY KEY,
    Nume VARCHAR(15),
    Prenume VARCHAR(25),
    Data_inceput DATE,
    Data_sfarsit DATE,
    Situatie CHAR(1),
    Inv CHAR(1),
    Sex CHAR(1) DEFAULT 'B' CHECK (Sex IN ('B', 'F')),
    Jud CHAR(2)
);

CREATE TABLE Note (
    CodS CHAR(5),
    Curs VARCHAR(15),
    Nota NUMERIC(4,2),
    An CHAR(1),
    Taxa NUMERIC
    PRIMARY KEY (CodS, Curs, An),
    FOREIGN KEY (CodS) REFERENCES Student(CodS)
);

INSERT INTO Student (CodS, Nume, Prenume, Data_inceput, Data_sfarsit, Situatie, Inv, Sex, Jud)
VALUES
    ('001', 'Banu', 'Andrei', '1990-10-01', '1995-06-15', 'B', 'Z', 'B', 'BV'),
    ('002', 'Manta', 'Andrei', '2010-10-01', NULL, 'B', 'S', 'B', 'BV'),
    ('003', 'Dima', 'Cristina', '1992-10-01', '1997-06-15', 'N', 'Z', 'F', 'CJ'),
    ('004', 'Stroie', 'Camelia', '1995-10-01', '2000-06-15', 'N', 'S', 'F', 'BC'),
    ('005', 'Radu', 'Tiberiu', '2009-10-01', NULL, 'N', 'S', 'B', 'IS'),
    ('006', 'Dima', 'Carmen', '2010-10-01', NULL, 'B', 'Z', 'F', 'BV'),
    ('007', 'Stroie', 'Aurelia', '2005-10-01', '2009-06-15', 'B', 'S', 'F', 'CV'),
    ('008', 'Manta', 'Silviu', '2008-10-01', NULL, 'N', 'Z', 'B', 'BV');

INSERT INTO Note (CodS, Curs, Nota, An, Taxa)
VALUES
    ('005', 'Fizica', 6.00, '1', 35.5),
    ('005', 'Chimie', 5.00, '1', NULL),
    ('002', 'Fizica', 10.00, '1', 25.75),
    ('002', 'Chimie', 9.00, '1', 25.75),
    ('005', 'Istorie', 7.00, '1', 35.5),
    ('005', 'Engleza', 7.00, '1', NULL),
    ('006', 'PC I', 10.00, '1', NULL),
    ('006', 'P.C. II', 9.00, '1', NULL);


SELECT * 
INTO #TempTable
FROM Note
WHERE CodS = '006';
DELETE FROM Note
WHERE CodS = '006';
INSERT INTO Note
SELECT * FROM #TempTable;
DROP TABLE #TempTable;

ALTER TABLE Student
ADD Jud CHAR(2);


UPDATE Student SET Jud = 'BV' WHERE CodS IN ('001', '002', '006');
UPDATE Student SET Jud = 'CJ' WHERE CodS = '003';
UPDATE Student SET Jud = 'BC' WHERE CodS = '004';
UPDATE Student SET Jud = 'IS' WHERE CodS = '005';
UPDATE Student SET Jud = 'CV' WHERE CodS = '007';
UPDATE Student SET Jud = 'BV' WHERE CodS = '008';

DROP TABLE Note;

CREATE TABLE Note (
    CodS CHAR(5),
    Curs VARCHAR(15),
    Nota NUMERIC(4,2),
    An CHAR(1),
    Taxa NUMERIC,
    PRIMARY KEY (CodS, Curs, An),
    FOREIGN KEY (CodS) REFERENCES Student(CodS)
);