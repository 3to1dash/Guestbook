CREATE PROCEDURE [dbo].[spUser_GetByEmail]
	@Email nvarchar(50)
AS
begin
	select UserId, FirstName, LastName, Email, PasswordHash
	from dbo.[User]
	where Email = @Email;
end
