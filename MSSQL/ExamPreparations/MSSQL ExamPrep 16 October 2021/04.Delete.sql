DELETE FROM ClientsCigars
WHERE ClientId IN (SELECT c.Id
                    FROM Addresses AS a
                    JOIN Clients AS c ON c.AddressId = a.Id
                    WHERE a.Country LIKE 'C%'
                    );
 
DELETE FROM Clients
WHERE AddressId IN (SELECT Id
                    FROM Addresses
                    WHERE Country LIKE 'C%'
                    );
 
DELETE FROM Addresses
WHERE Country LIKE 'C%'