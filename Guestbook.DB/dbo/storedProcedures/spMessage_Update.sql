CREATE PROCEDURE [dbo].[spMessage_Update]
	@Id int,
	@Content text
AS
begin
	update dbo.[Message]
	set Content = @Content
	where MessageId = @Id;
end
