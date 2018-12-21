CREATE TABLE [dbo].Trainee
(
	[id] NCHAR(10) NOT NULL PRIMARY KEY, 
    [Firstname] NCHAR(10) NOT NULL, 
    [Surname] NCHAR(10) NOT NULL, 
    [Address] TEXT NOT NULL, 
    [HomePhone] TEXT NOT NULL, 
    [CellPhone] TEXT NOT NULL, 
    [EMail] TEXT NOT NULL, 
    [Birthdate] DATE NOT NULL, 
    [Comment] TEXT NOT NULL, 
    [TrainDays] TEXT NOT NULL
)