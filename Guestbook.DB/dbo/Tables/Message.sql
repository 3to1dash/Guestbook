CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Content] NVARCHAR(50) NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreatedAt] DATETIME NOT NULL, 
    CONSTRAINT [FK_Message_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]) ON DELETE CASCADE,
)

GO

CREATE INDEX [IX_Message_CreatedAt] ON [dbo].[Message] ([CreatedAt])
