CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@UserName NVARCHAR(50), 
	@Password NVARCHAR(50)
AS
begin 
	INSERT INTO Dbo.[User](FirstName, LastName, UserName, Password)
	VALUES (@FirstName, @LastName, @UserName, @Password);
end
