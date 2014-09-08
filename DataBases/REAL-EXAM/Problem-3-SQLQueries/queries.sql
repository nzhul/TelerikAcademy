-- 1. Get the full name (first name + “ “ + last name)  of every employee and its salary, for each employee with salary between $100 000 and $150 000, inclusive. Sort the results by salary in ascending order.

SELECT FirstName + ' ' + LastName as FullName, Salary 
FROM Employees
WHERE Salary BETWEEN 100000 AND 150000
ORDER BY Salary DESC

-- 2. Get all departments and how many employees there are in each one. Sort the result by the number of employees in descending order.
SELECT d.Name as DepartmentName, COUNT(e.Id) as EmployeeCount
FROM Employees e INNER JOIN Departments d
ON e.DepartmentId = d.Id
GROUP BY d.Name

-- 3. Get each employee’s full name (first name + “ “ + last name), project’s name, department’s name, starting and ending date for each employee in project. Additionally get the number of all reports, which time of reporting is between the start and end date. Sort the results first by the employee id, then by the project id. (This query is slow, be patient!)
SELECT e.FirstName + ' ' + e.LastName as EmployeeFullName, 
p.Name as ProjectName, d.Name as DepartmentName,
ep.StartingDate, ep.EndingDate, ((SELECT COUNT(*) FROM Reports rep WHERE rep.CreatedOn BETWEEN 2014-09-05 AND 2014-09-08)) as ReportsCount
FROM Employees e
INNER JOIN Projects p
ON p.EmployeeId = e.Id
INNER JOIN Departments d
ON d.Id = e.DepartmentId
INNER JOIN EmployeeProject ep
ON ep.EmployeeId = p.Id