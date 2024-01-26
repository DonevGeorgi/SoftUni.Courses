SELECT s.Username, AVG(f.Size) AS Size
FROM Users AS s
JOIN Files AS f ON f.CommitId = s.Id
JOIN Commits AS c ON c.ContributorId = s.Id
WHERE c.ContributorId IS NOT NULL
GROUP BY s.Username
ORDER BY Size DESC,s.Username