--TASK 1 Create a table in SQL Server with 10 000 000 log entries (date + text).
--Search in the table by date range. Check the speed (without caching).

CREATE DATABASE HW11_Performance
GO

DROP TABLE Logs

USE HW11_Performance

CREATE TABLE Logs(
  LogId int NOT NULL PRIMARY KEY IDENTITY,
  LogDate datetime,
  LogText nvarchar(50)
)

--Check name of generated PK constraint in order to drop it....
--SELECT CONSTRAINT_NAME
--FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
--WHERE CONSTRAINT_TYPE='PRIMARY KEY' AND TABLE_SCHEMA='dbo' AND TABLE_NAME='Logs'

ALTER TABLE Logs
ADD CONSTRAINT PK_Logs_LogId PRIMARY KEY(LogId)

DECLARE @Counter int = 0
WHILE @Counter < 10000000
BEGIN
INSERT INTO Logs(LogDate, LogText)
VALUES(GETDATE(), 'Text' + CONVERT(varchar, @Counter))
Print @Counter
SET @Counter = @Counter + 1
END


SELECT * FROM Logs
WHERE LogDate >= '2014-09-04 13:13:54.667' AND LogDate <= '2014-09-04 13:13:54.710'

--TASK 2 Add an index to speed-up the search by date. Test the search speed
--(after cleaning the cache).


USE HW11_Performance;
GO
CHECKPOINT;
GO
DBCC DROPCLEANBUFFERS;
GO

CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)

SELECT * FROM Logs
WHERE LogDate >= '2014-09-04 13:15:54.667' AND LogDate <= '2014-09-04 13:15:54.710'

--TASK 3 Add a full text index for the text column. Try to search with and without the
--full-text index and compare the speed.
SELECT * FROM Logs
WHERE LogText > 'Text1' AND LogText < 'Text3'

CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs_LogId
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO

SELECT * FROM Logs
WHERE LogText > 'Text1' AND LogText < 'Text3'
