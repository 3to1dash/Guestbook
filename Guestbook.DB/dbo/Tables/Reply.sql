CREATE TABLE [dbo].[Reply]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Content] NVARCHAR(50) NOT NULL, 
    [MessageId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreatedAt] DATETIME NOT NULL, 
    CONSTRAINT [FK_Reply_Message] FOREIGN KEY ([MessageId]) REFERENCES [Message]([Id]), 
    CONSTRAINT [FK_Reply_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)

GO

CREATE INDEX [IX_Reply_MessageId_CreatedAt] ON [dbo].[Reply] ([MessageId], [CreatedAt])

GO

CREATE INDEX [IX_Reply_MessageId] ON [dbo].[Reply] ([MessageId])
