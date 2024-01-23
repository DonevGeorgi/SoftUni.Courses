SELECT t.Id,t.[Name],t.PhoneNumber 
FROM Tourists AS t
LEFT JOIN Bookings AS b ON b.TouristId = t.Id
WHERE b.Id IS NULL
ORDER BY t.[Name]