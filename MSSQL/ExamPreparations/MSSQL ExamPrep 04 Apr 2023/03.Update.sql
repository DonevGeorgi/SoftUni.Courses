UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE  MONTH(DueDate) = 10 AND YEAR(DueDate) = 2022;

UPDATE Addresses 
SET StreetName = 'Industriestr',StreetNumber = 79, PostCode = 2353,City = 'Guntramsdorf',CountryId = (SELECT CountryId FROM Countries WHERE Name = 'Austria')
WHERE PostCode = 'CO';