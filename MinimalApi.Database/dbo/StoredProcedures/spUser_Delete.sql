CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
begin 
	delete
	FROM dbo.[User]
	where Id = @Id;
end
