--01 Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE salary = (SELECT MIN(Salary) FROM Employees)

--02 Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, Salary
FROM Employees
WHERE Salary < (SELECT MIN(Salary) * 1.1 FROM Employees)
ORDER BY Salary;

--03 Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName as EmployeeFullname, d.Name as DepartmentName, e.Salary
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
	(
		SELECT MIN(Salary) 
		FROM Employees 
		WHERE DepartmentID = d.DepartmentID
	)


--04 Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) as AverageSalary
FROM Employees
WHERE DepartmentID = 1;

--05 Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(e.Salary) as AverageSalary
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales';

--06 Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(e.EmployeeID)
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--07 Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NOT NULL

--08 Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL

--09 Write a SQL query to find all departments and the average salary for each of them.
SELECT Name, AVG(Salary) as AverageSalaryForDepartment
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

--10 Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name, t.Name, COUNT(EmployeeID) as EmployeeCount
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses ad
ON e.AddressID = ad.AddressID
JOIN Towns t
ON t.TownID = ad.TownID
GROUP BY d.Name, t.Name

--11 Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT e.FirstName + ' ' + e.LastName as Manager
FROM Employees e
WHERE 5 = 
	(
		SELECT COUNT(*) FROM Employees m WHERE m.ManagerID = e.ManagerID 
	)


--12 Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT m.FirstName + ' ' + m.LastName as Subordinate, COALESCE(e.FirstName, '(no manager)') as Manager
FROM Employees e RIGHT OUTER JOIN Employees m
ON e.EmployeeID = m.ManagerID

--13 Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT FirstName + ' ' + LastName as FullName 
FROM Employees
WHERE LEN(LastName) = 5


--14 Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
SELECT convert(varchar, getdate(), 100)
 


--15 Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users (
  UserID int IDENTITY,
  Username nvarchar(100) NOT NULL UNIQUE,
  Password_name nvarchar(30) NOT NULL,
  Last_login_date date GETDATE(),
  CONSTRAINT PK_Cities PRIMARY KEY(UserID),
  CONSTRAINT LN_Pass CHECK (LEN(Password_name) >= 5)
)


--16 Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. Test if the view works correctly.
CREATE VIEW AllUsers AS
SELECT * FROM Users

--17 Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). Define primary key and identity column.
CREATE TABLE Groups (
  GroupID int IDENTITY,
  Name nvarchar(30) NOT NULL UNIQUE,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID),
)

--18 Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column and as well in the Groups table. Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users
ADD GroupID int;
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID);
 
--19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users(Username, Password_name, Last_login_date)
VALUES ('Petar', 'password', GETDATE()),
('HellSlayer', 'password1', GETDATE()),
('Dagon', 'password2', GETDATE()),
('Gosho', 'password3', GETDATE())
INSERT INTO Groups(Name)
VALUES ('GroupName1'),
('GroupName2'),
('GroupName3'),
('GroupName4'),
('GroupName5'),
('GroupName6'),
('GroupName7');

--20 Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Password_name = 'CoolPassword'
WHERE Username = 'Petar'

UPDATE Groups
SET Name = 'NewGroupName'
WHERE GroupID = 1

--21 Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users 
WHERE UserID = 3

DELETE FROM Groups 
WHERE GroupID = 2

--22 Write SQL statements to insert in the Users table the names of all employees from the Employees table. Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). Use the same for the password, and NULL for last login time.
INSERT INTO Users(Username, Password_name, Last_login_date)
  SELECT SUBSTRING(FirstName, 0, 4) + '' + LOWER(LastName) + 'Magic', SUBSTRING(FirstName, 0, 1) + '' + LOWER(LastName) + 'Magic', NULL
  FROM Employees

--23 Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET Password_name = NULL
WHERE Last_login_date < '10/03/2020';

--24 Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users 
WHERE Password_name is null;

--25 Write a SQL query to display the average employee salary by department and job title.
SELECT JobTitle, Name, AVG(Salary) AS AverageSalary
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY JobTitle, Name
ORDER BY AverageSalary

--26 Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.


--27 Write a SQL query to display the town where maximal number of employees work.


--28 Write a SQL query to display the number of managers from each town.


--29 Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). Don't forget to define  identity, primary key and appropriate foreign key. 
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. For each change keep the old record data, the new record data and the command (insert / update / delete).


--30 Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.


--31 Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?


--32 Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
