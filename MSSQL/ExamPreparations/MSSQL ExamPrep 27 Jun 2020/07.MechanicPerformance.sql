SELECT CONCAT(m.FirstName, ' ' ,m.LastName) AS Client,AVG(DATEDIFF(day,j.IssueDate,j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
GROUP BY m.FirstName, m.LastName,m.MechanicId
ORDER BY m.MechanicId