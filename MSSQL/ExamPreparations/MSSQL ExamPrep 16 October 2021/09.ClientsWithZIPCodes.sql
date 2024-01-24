SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName,a.Country,a.ZIP,FORMAT(MAX(ci.PriceForSingleCigar),'C')
FROM Clients AS c
JOIN Addresses AS a ON a.Id = c.AddressId
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS ci ON ci.Id = cc.CigarId
WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY c.FirstName,c.LastName,a.Country,a.ZIP
ORDER BY FullName;