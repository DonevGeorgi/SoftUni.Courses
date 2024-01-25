SELECT 
	d.[Name] AS DistributorName
	,i.[Name] AS IngredientName
	,p.[Name] AS ProductName
	,AVG(f.Rate) AS AverageRate
FROM Distributors AS d
JOIN Ingredients AS i ON i.DistributorId = d.Id
JOIN ProductsIngredients AS pin ON pin.IngredientId = i.Id
JOIN Products AS p ON p.Id = pin.ProductId
JOIN Feedbacks AS f ON f.ProductId = p.Id
WHERE f.Rate BETWEEN 5 AND 8
GROUP BY d.[Name],i.[Name],p.[Name]
ORDER BY d.[Name],i.[Name],p.[Name]