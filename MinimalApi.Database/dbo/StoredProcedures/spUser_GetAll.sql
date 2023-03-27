CREATE PROCEDURE [dbo].[spUser_GetAll]

AS
begin
	SELECT * FROM dbo.[User];
end
