CREATE PROCEDURE [dbo].[spMessage_Insert]
	@Content text,
	@UserId int
AS
begin
	insert into dbo.[Message] (Content, UserId)
	values (@Content, @UserId);
end
