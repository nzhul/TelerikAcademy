-- TIP: You can run specific query by simply selecting it and press F5.
-- 		That way only the selected query will be executed instead of the whole document.

-- PLEASE RUN Create-Bank-Database.sql

-- 01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. Write a stored procedure that selects the full names of all persons.
CREATE PROC bank_SelectFullname
AS
	SELECT FirstName + ' ' + LastName as FullName
	FROM Persons
GO

-- Usage: 
EXEC bank_SelectFullname

-- 02. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC bank_SelectFullname(@minMoney money = 1000)
AS
	SELECT p.FirstName + ' ' + p.LastName, a.Balance
	FROM Persons p JOIN Accounts a
	ON p.person_id = a.person_id
	WHERE a.Balance > @minMoney
GO
-- Usage:
EXEC dbo.bank_filterByMinBalanceValue 1800;

-- 03. Create a function that accepts as parameters – sum, yearly interest rate and number of months. It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
CREATE FUNCTION bankFn_calculateInterest
(@sum money, @interestRate float, @months float)
RETURNS float
AS
	BEGIN
		RETURN (@sum * (@interestRate / 100) * (@months / 12)) + @sum 
	END
GO

-- Usage:
SELECT dbo.bankFn_calculateInterest(1000, 6.5, 12)

-- 04. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month. It should take the AccountId and the interest rate as parameters.
CREATE PROC bank_GiveInterest(@accountId int, @interestRate float)
AS
	UPDATE Accounts SET Balance = dbo.bankFn_calculateInterest(Balance, @interestRate, 1)
	WHERE account_id = @accountId
GO

-- Usage:
EXEC dbo.bank_GiveInterest 1, 6.4
GO

-- 05. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
CREATE PROC bank_WithdrawMoney(@accountId int, @money money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @money
		WHERE account_id = @accountId
	COMMIT TRAN
GO

-- Usage:
EXEC dbo.bank_WithdrawMoney 1, 50
GO

CREATE PROC bank_DepositMoney(@accountId int, @money money)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @money
		WHERE account_id = @accountId
	COMMIT TRAN
GO

-- Usage:
EXEC dbo.bank_DepositMoney 1, 50
GO

-- 06. Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs(
  log_id int NOT NULL PRIMARY KEY IDENTITY,
  account_id int FOREIGN KEY
	REFERENCES Accounts(account_id),
  oldSum money NOT NULL,
  newSum money NOT NULL)
GO

CREATE TRIGGER bankTr_BalanceChange ON Accounts FOR UPDATE
AS
	INSERT INTO Logs (oldSum, newSum, account_id)
	SELECT d.Balance, i.Balance, d.account_id
	FROM deleted d, inserted i
	WHERE d.account_id = i.account_id
GO

-- Usage:
EXEC dbo.bank_DepositMoney 1, 250
GO

SELECT * FROM Logs
GO


-- 07. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
--folowing 12 lines gives access to OLE Functions in SQL Server
sp_configure 'show advanced options', 1  
GO   
RECONFIGURE;  
GO  
sp_configure 'Ole Automation Procedures', 1  
GO   
RECONFIGURE;  
GO   
sp_configure 'show advanced options', 1  
GO   
RECONFIGURE; 
GO

--function for RegEx using VBScript.RegExp
CREATE FUNCTION dbo.regexFind
	(@source varchar(5000),@regexp varchar(1000),@ignoreCase bit = 0)
	RETURNS bit AS
BEGIN
	DECLARE @hr integer
	DECLARE @objRegExp integer
	DECLARE @results bit
	
	SET @results = 0

	EXECUTE @hr = sp_OACreate 'VBScript.RegExp', @objRegExp OUTPUT
	IF @hr <> 0 
	BEGIN
		EXEC @hr = sp_OADestroy @objRegExp
	RETURN NULL
	END
	EXECUTE @hr = sp_OASetProperty @objRegExp, 'Pattern', @regexp
	IF @hr <> 0 
	BEGIN
		EXEC @hr = sp_OADestroy @objRegExp
	RETURN NULL
	END
	EXECUTE @hr = sp_OASetProperty @objRegExp, 'Global', false
	IF @hr <> 0 
	BEGIN
		EXEC @hr = sp_OADestroy @objRegExp
	RETURN NULL
	END
	EXECUTE @hr = sp_OASetProperty @objRegExp, 'IgnoreCase', @ignoreCase
	IF @hr <> 0 
	BEGIN
		EXEC @hr = sp_OADestroy @objRegExp
	RETURN NULL
	END	
	EXECUTE @hr = sp_OAMethod @objRegExp, 'Test', @results OUTPUT, @source
	IF @hr <> 0 
	BEGIN
		EXEC @hr = sp_OADestroy @objRegExp
	RETURN NULL
	END
	EXECUTE @hr = sp_OADestroy @objRegExp
	IF @hr <> 0 
	BEGIN
		RETURN NULL
	END
	
	RETURN @results
END
GO

--returns all employees with given town AND 
--(first name OR last name OR middle name)
CREATE FUNCTION fn_Find 
	( @regularExpression nvarchar(30) )
	RETURNS TABLE
AS
RETURN 
	SELECT e.FirstName, e.MiddleName, e.LastName, t.Name AS Town
	FROM TelerikAcademy.dbo.Employees e, TelerikAcademy.dbo.Addresses a, TelerikAcademy.dbo.Towns t
	WHERE e.AddressID = a.AddressID
	AND a.TownID = t.TownID
	AND 1 = dbo.regexFind(LOWER(t.Name), @regularExpression,1)
	AND (1 = dbo.regexFind(LOWER(e.FirstName), @regularExpression,1)
		OR 1 = dbo.regexFind(LOWER(ISNULL(e.MiddleName, '')), @regularExpression,1)
		OR 1 = dbo.regexFind(LOWER(e.LastName), @regularExpression,1))
GO

-- Usage:
SELECT * FROM fn_Find('^[oistmiahf]+$')
GO

-- 08. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.

DECLARE empCursor CURSOR READ_ONLY FOR 
	SELECT e.FirstName, e.LastName, t.Name,
                o.FirstName, o.LastName
        FROM TelerikAcademy.dbo.Employees e
                INNER JOIN Addresses a
                        ON a.AddressID = e.AddressID
                INNER JOIN Towns t
                        ON t.TownID = a.TownID,
        TelerikAcademy.dbo.Employees o
                INNER JOIN Addresses a1
                        ON a1.AddressID = o.AddressID
                INNER JOIN Towns t1
                        ON t1.TownID = a1.AddressID 
	
	OPEN empCursor
        DECLARE @firstName1 NVARCHAR(50)
        DECLARE @lastName1 NVARCHAR(50)
        DECLARE @town NVARCHAR(50)
        DECLARE @firstName2 NVARCHAR(50)
        DECLARE @lastName2 NVARCHAR(50)
        FETCH NEXT FROM empCursor
                INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
 
        WHILE @@FETCH_STATUS = 0
                BEGIN
					PRINT @firstName1 + ' ' + @lastName1 +
					      '     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
					FETCH NEXT 
						FROM empCursor
                        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
                END
 
        CLOSE empCursor
        DEALLOCATE empCursor	
GO

-- 09. * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
		-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
		-- Ottawa -> Jose Saraiva
		-- …
USE TelerikAcademy
DECLARE empCursor CURSOR READ_ONLY FOR
SELECT Name FROM Towns
OPEN empCursor
DECLARE @townName VARCHAR(50), @userNames VARCHAR(MAX)
FETCH NEXT FROM empCursor INTO @townName 
 
WHILE @@FETCH_STATUS = 0
	BEGIN
		BEGIN
		DECLARE nameCursor CURSOR READ_ONLY FOR
		SELECT a.FirstName, a.LastName
		FROM Employees a
		JOIN Addresses adr
		ON a.AddressID = adr.AddressID
		JOIN Towns t1
		ON adr.TownID = t1.TownID
		WHERE t1.Name = @townName
		OPEN nameCursor
		
		DECLARE @firstName VARCHAR(50), @lastName VARCHAR(50)
		FETCH NEXT FROM nameCursor INTO @firstName,  @lastName
		WHILE @@FETCH_STATUS = 0
		    BEGIN
		            SET @userNames = CONCAT(@userNames, @firstName, ' ', @lastName, ', ')
		            FETCH NEXT FROM nameCursor
		            INTO @firstName,  @lastName
		    END
		    CLOSE nameCursor
		    DEALLOCATE nameCursor
		            END
		            SET @userNames = LEFT(@userNames, LEN(@userNames) - 1)
		PRINT @townName + ' -> ' + @userNames
		FETCH NEXT FROM empCursor
		INTO @townName
	END
CLOSE empCursor
DEALLOCATE empCursor
 
GO

-- 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','. For example the following SQL statement should return a single string:
	-- SELECT StrConcat(FirstName + ' ' + LastName)
	-- FROM Employees
	
 -- You can find the solution here: http://www.mssqltips.com/sqlservertip/2022/concat-aggregates-sql-server-clr-function/
 -- Sorry not enough time to solve this task.