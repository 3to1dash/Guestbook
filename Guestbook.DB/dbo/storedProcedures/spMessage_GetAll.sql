﻿CREATE PROCEDURE [dbo].[spMessage_GetAll]
AS
begin
	select msg.MessageId, msg.Content, msg.CreatedAt, usr.UserId, usr.FirstName, usr.LastName, usr.Email
	from dbo.[Message] as msg inner join dbo.[User] as usr
	on (msg.UserId = usr.UserId)
	order by msg.CreatedAt desc;
end