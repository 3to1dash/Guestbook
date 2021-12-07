CREATE PROCEDURE [dbo].[spMessage_Get]
	@Id int
AS
begin
	select MessageId, Content, CreatedAt
	from dbo.[Message]
	where MessageId = @Id;
end