CREATE TABLE [dbo].[Reminders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(10000, 1), 
    [Email] NVARCHAR(250) NOT NULL, 
    [Registration] CHAR(10) NOT NULL, 
    [Manufacturer] NVARCHAR(50) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL, 
    [MotExpiryDate] DATETIME NOT NULL, 
    [ReminderDueDate] DATETIME NOT NULL
)
