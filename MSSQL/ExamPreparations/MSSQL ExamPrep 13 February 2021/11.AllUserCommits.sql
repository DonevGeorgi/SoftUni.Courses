CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
	RETURNS INT 
		BEGIN
			RETURN (SELECT COUNT(ContributorId)
			FROM Commits
			WHERE ContributorId = (		
				SELECT Id FROM Users WHERE Username = @username
			))
		END;
