CREATE FUNCTION udf_RoomsWithTourists(@name NVARCHAR(80))
	RETURNS INT
		BEGIN
			DECLARE @total INT = 0
				SELECT @total += (b.AdultsCount + b.ChildrenCount)
				FROM Rooms AS r
				JOIN Bookings AS b ON b.RoomId = r.Id
				WHERE r.[Type] = @name

			RETURN @total
		END;