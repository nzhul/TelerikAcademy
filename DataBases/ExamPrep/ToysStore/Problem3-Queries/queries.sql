-- 1. Get all toys’s name and price having type of “puzzle” and price above $10.00 ordering them by price
SELECT Name, Price FROM Toys
WHERE Type = 'puzzle' AND Price > 10
ORDER BY Price

-- 2. Get all manufacturers name and how many toys they have in the age range of 5 to 10 years, inclusive. Group the results by manufacturer
SELECT m.Name, (SELECT COUNT(*)
FROM Toys t
INNER JOIN AgeRanges ar
ON t.AgeRangeId = ar.Id
WHERE ar.MinimumAge >= 5 AND ar.MaximumAge <= 10 AND m.Id = t.ManufacturerId) as [Count]
FROM Manufacturers m

-- 3. Get all toys name, price and color from category “boys” as well as all toys without any category
SELECT t.Name, t.Price, t.Color
FROM Toys t
INNER JOIN ToysCategories tc
ON t.Id = tc.ToyId
INNER JOIN Categories c
ON c.Id = tc.CategoryId
WHERE c.Name = 'boys'