﻿CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
begin 
	SELECT Id, FirstName, LastName
	FROM dbo.[User]
	where Id = @Id;
end