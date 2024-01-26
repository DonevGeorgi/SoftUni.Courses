SELECT Id,[Name],CONCAT(Size,'KB') AS Size
FROM Files
WHERE ParentId IS NULL
ORDER BY Id,[Name],Size DESC