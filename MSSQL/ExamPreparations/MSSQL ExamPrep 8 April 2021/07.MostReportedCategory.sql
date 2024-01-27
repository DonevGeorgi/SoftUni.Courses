SELECT TOP(5) c.[Name],COUNT(r.Id) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC,c.[Name]