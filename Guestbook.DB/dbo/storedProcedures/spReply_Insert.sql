CREATE PROCEDURE [dbo].[spReply_Insert]
	@Content text,
	@MessageId int,
	@UserId int
AS
begin
	insert into dbo.[Reply] (Content, MessageId, UserId)
	values (@Content, @MessageId, @UserId);
end
