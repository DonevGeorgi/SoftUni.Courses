SELECT h.[Name] AS HotelName, r.Price AS RoomPrice
FROM Bookings AS b
LEFT JOIN Hotels AS h ON h.Id = b.HotelId
LEFT JOIN Rooms AS r ON r.Id = b.RoomId
LEFT JOIN Tourists AS t ON t.Id = b.TouristId
WHERE t.[Name] NOT LIKE '%EZ'
ORDER BY r.Price DESC