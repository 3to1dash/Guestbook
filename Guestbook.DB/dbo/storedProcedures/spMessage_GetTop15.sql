CREATE PROCEDURE [dbo].[spMessage_GetTop15]
AS
begin
	select top 15 msg.MessageId, msg.Content, msg.CreatedAt, usr.UserId, usr.FirstName, usr.LastName, usr.Email
	from dbo.[Message] as msg inner join dbo.[User] as usr
	on (msg.UserId = usr.UserId)
	order by msg.CreatedAt desc;
end