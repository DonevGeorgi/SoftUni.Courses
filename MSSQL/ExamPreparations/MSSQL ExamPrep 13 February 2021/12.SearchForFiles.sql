CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(6))
	AS 
		SELECT Id,[Name],CONCAT(Size,'KB') AS Size
		FROM Files
		WHERE [Name] LIKE(@fileExtension)
		ORDER BY Id,[Name],Size DESC