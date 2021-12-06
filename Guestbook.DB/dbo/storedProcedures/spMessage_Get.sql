CREATE PROCEDURE [dbo].[spMessage_Get]
	@Id int
AS
begin
	select msg.Id, msg.Content, msg.CreatedAt, usr.FirstName, usr.LastName, usr.Email
	from dbo.[Message] as msg
	inner join dbo.[User] as usr
	on (msg.UserId = usr.Id)
	where msg.Id = @Id;
end