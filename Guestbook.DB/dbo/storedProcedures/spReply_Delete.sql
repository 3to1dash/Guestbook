CREATE PROCEDURE [dbo].[spReply_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Reply]
	where Id = @Id;
end
