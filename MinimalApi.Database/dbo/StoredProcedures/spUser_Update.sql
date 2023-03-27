CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int, 
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@UserName NVARCHAR(50), 
	@Password NVARCHAR(50)
AS
BEGIN
	UPDATE dbo.[User]
	SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, Password = @Password
	WHERE Id = @Id;
END
