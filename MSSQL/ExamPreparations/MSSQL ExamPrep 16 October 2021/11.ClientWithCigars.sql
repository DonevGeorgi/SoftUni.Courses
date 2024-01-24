CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
	BEGIN
			RETURN(SELECT COUNT(cc.ClientId)
				FROM Clients AS c
				JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
			WHERE c.FirstName = @name)
	END