if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, Email, PasswordHash)
	values ('Mahmoud', 'Ahmed', 'foo@bar.com', ''),
	('Amr', 'Ahmed', 'bez@bar.com', ''),
	('Dalia', 'Ahmed', 'dha@bar.com', '')
end

if not exists (select 1 from dbo.[Message])
begin
	insert into dbo.[Message] (Content, UserId)
	values ('This a dummy text', 1),
	('This a test', 1),
	('Hello World', 2),
	('Testing', 3)
end

if not exists (select 1 from dbo.[Reply])
begin
	insert into dbo.[Reply] (Content, MessageId, UserId)
	values ('Good morning today', 1, 2),
	('test test test test', 1, 3),
	('This is a reply', 2, 1),
	('Testing again', 3, 2)
end
