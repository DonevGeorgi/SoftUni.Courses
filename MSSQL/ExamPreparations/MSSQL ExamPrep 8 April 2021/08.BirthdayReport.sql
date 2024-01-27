SELECT u.Username,c.[Name]
FROM Reports AS r
JOIN Users AS u ON u.Id = r.UserId
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE MONTH(OpenDate) = MONTH(Birthdate) AND DAY(OpenDate) = DAY(Birthdate)
ORDER BY u.Username,c.[Name]