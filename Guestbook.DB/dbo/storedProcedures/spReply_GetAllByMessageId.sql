CREATE PROCEDURE [dbo].[spReply_GetAllByMessageId]
	@MessageId int
AS
begin
	select rply.ReplyId, rply.Content, rply.CreatedAt, usr.UserId, usr.FirstName, usr.LastName, usr.Email
	from (select *
		  from dbo.[Reply]
		  where MessageId = @MessageId) as rply
	inner join dbo.[User] as usr
	on rply.UserId = usr.UserId
	order by rply.CreatedAt desc;
end
