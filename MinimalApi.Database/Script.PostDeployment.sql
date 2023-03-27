IF NOT EXISTS (	SELECT 1 FROM dbo.[User])

BEGIN
	INSERT INTO dbo.[User] (FirstName, LastName, UserName, Password)
	VALUES('Braydon', 'Sutherland', 'GeoMatics', '334458'), 
	('Colin', 'Taylor', 'Colly', 'goose'), 
	('Sally', 'Sutherland', 'Salmeaux', 'cheech'), 
	('Denny', 'Ragland', 'RagDad', 'lonestar'), 
	('Daniel', 'Aguile', 'RedRain', 'gumbo'), 
	('Bobby', 'Flay', 'BBQ', 'hogtown');
END;
