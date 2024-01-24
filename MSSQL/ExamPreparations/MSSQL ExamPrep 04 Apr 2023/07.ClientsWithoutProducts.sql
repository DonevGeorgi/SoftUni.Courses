SELECT c.Id,c.Name AS Client,CONCAT_WS(', ',a.StreetName,a.City,a.PostCode,co.Name) AS Address
FROM Clients AS c
JOIN Addresses AS a ON a.Id = c.AddressId
JOIN Countries AS co ON co.Id = a.CountryId
JOIN ProductsClients AS pc ON c.Id = pc.ClientId
WHERE pc.ProductId IS NULL
ORDER BY c.Name;