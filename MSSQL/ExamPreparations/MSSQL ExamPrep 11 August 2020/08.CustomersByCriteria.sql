SELECT FirstName,Age,PhoneNumber,CountryId
FROM Customers
WHERE (Age >= 21 OR FirstName LIKE '%an%') OR
(PhoneNumber LIKE '%38' AND CountryId != 31)
ORDER BY FirstName,Age DESC