SELECT TOP(50) [FirstName], [LastName], t.[Name] AS [Town], [AddressText] 
FROM [Employees] AS e
JOIN [Addresses] AS a ON e.AddressID = a.AddressID
JOIN [Towns] AS t ON t.TownID = a.TownID
ORDER BY [FirstName], [LastName]
