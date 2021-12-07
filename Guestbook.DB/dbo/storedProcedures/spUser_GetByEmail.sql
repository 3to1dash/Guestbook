CREATE PROCEDURE [dbo].[spUser_GetByEmail]
	@Email nvarchar(50)
AS
begin
	select FirstName, LastName, Email
	from dbo.[User]
	where Email = @Email;
end
