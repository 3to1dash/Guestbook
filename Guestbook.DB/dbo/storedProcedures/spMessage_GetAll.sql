CREATE PROCEDURE [dbo].[spMessage_GetAll]
AS
begin
	select msg.Id, msg.Content, msg.CreatedAt, usr.FirstName, usr.LastName, usr.Email
	from dbo.[Message] as msg inner join dbo.[User] as usr
	on (msg.UserId = usr.Id)
	order by msg.CreatedAt desc;
end