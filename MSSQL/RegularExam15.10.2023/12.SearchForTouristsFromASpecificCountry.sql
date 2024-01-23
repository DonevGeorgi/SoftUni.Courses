CREATE PROCEDURE usp_SearchByCountry(@country NVARCHAR(50)) 
	AS 
		SELECT t.[Name],t.PhoneNumber,t.Email,COUNT(b.TouristId) AS CountOfBookings 
		FROM Tourists AS t
		JOIN Countries AS c ON c.Id = t.CountryId
		JOIN Bookings AS b ON b.TouristId = t.Id
		WHERE c.[Name] = @country
		GROUP BY t.[Name],t.PhoneNumber,t.Email
		ORDER BY t.[Name], CountOfBookings DESC