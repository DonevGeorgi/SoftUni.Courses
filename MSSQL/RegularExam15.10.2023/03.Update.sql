UPDATE Bookings
	SET  DepartureDate = DATEADD(day,1,DepartureDate)
	WHERE MONTH(ArrivalDate) = 12 AND YEAR(ArrivalDate) = 2023 
	
	UPDATE Tourists
	SET Email = NULL
	WHERE [Name] LIKE '%MA%'