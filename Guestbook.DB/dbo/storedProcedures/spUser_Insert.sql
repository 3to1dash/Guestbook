CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@PasswordHash nvarchar(50)
AS
begin
	insert into dbo.[User] (FirstName, LastName, Email, PasswordHash)
	values (@FirstName, @LastName, @Email, @PasswordHash);
end
