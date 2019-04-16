BEGIN
	INSERT INTO [dbo].tblPersonalProjects(Name, Languages, Description, GitHubRepository, Demonstration)
	VALUES
	('Discord Bot', 'C#', 'Utilizes .NET Core, Discord''s API, and the Discord.Net library to create a custom bot for the Voice-Over-IP application Discord.', 'https://github.com/rickbowman/Record-Store-Bot', 'VideoEmbedLink'),
	('Image Transfer', 'C#', 'A WPF application that uses user32.dll to take any black and white image and redraw it in Microsoft Paint.', 'https://github.com/rickbowman/Image-Transfer', 'VideoEmbedLink'),
	('ToL Class Statistics', 'C#', 'A WPF application used to track the amount of times a starting class is assigned while playing the game Throne of Lies. UI chart is done with the Live Charts library.', 'https://github.com/rickbowman/ToL.ClassStats', 'VideoEmbedLink')
END