CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
	SELECT c.CigarName,FORMAT(c.PriceForSingleCigar,'C'),t.TasteType,b.BrandName,CONCAT(s.Length,' cm'),CONCAT(s.RingRange,' cm')
	FROM Cigars AS c
	JOIN Tastes AS t ON t.Id = c.TastId
	JOIN Brands AS b ON b.Id = c.BrandId
	JOIN Sizes AS s ON s.Id = c.SizeId
	WHERE TasteType = @taste
	ORDER BY s.Length,S.RingRange DESC