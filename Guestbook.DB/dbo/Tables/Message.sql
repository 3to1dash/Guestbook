CREATE TABLE [dbo].[Message]
(
	[MessageId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Content] TEXT NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreatedAt] DATETIME2 CONSTRAINT [DF_Message_CreatedAt] DEFAULT (sysdatetime()) NOT NULL, 
    CONSTRAINT [FK_Message_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]) ON DELETE CASCADE,
)

GO

CREATE INDEX [IX_Message_CreatedAt] ON [dbo].[Message] ([CreatedAt])
