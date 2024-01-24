UPDATE Cigars
SET PriceForSingleCigar += PriceForSingleCigar * 0.20
WHERE (
		SELECT TasteType
		FROM Tastes
		WHERE TasteType = 'Spicy'
	 ) =  'Spicy'

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL;