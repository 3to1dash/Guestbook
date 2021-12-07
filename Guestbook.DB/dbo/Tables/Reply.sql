CREATE TABLE [dbo].[Reply]
(
	[ReplyId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Content] NVARCHAR(50) NOT NULL, 
    [MessageId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreatedAt] DATETIME2 CONSTRAINT [DF_Reply_CreatedAt] DEFAULT (sysdatetime()) NOT NULL, 
    CONSTRAINT [FK_Reply_Message] FOREIGN KEY ([MessageId]) REFERENCES [Message]([MessageId]), 
    CONSTRAINT [FK_Reply_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)

GO

CREATE INDEX [IX_Reply_MessageId_CreatedAt] ON [dbo].[Reply] ([MessageId], [CreatedAt])

GO

CREATE INDEX [IX_Reply_MessageId] ON [dbo].[Reply] ([MessageId])
