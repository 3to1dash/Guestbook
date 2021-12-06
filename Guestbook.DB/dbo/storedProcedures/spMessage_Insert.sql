CREATE PROCEDURE [dbo].[spMessage_Insert]
	@Content nvarchar(50),
	@UserId int
AS
begin
	insert into dbo.[Message] (Content, UserId)
	values (@Content, @UserId);
end
