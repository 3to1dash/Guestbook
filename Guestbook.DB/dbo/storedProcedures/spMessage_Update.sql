CREATE PROCEDURE [dbo].[spMessage_Update]
	@Id int,
	@Content nvarchar(50)
AS
begin
	update dbo.[Message]
	set Content = @Content
	where Id = @Id;
end
