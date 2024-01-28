SELECT CONCAT(c.FirstName, ' ' ,c.LastName) AS Client,DATEDIFF(day,j.IssueDate,'2017/04/24') AS 'Days going',j.Status
FROM Clients AS c
JOIN Jobs AS j ON j.ClientId = c.ClientId
WHERE j.Status IN ('In Progress','Pending')
ORDER BY [Days going] DESC, c.ClientId 