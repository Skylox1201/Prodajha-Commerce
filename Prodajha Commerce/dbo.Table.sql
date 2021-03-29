CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [mail] NVARCHAR(MAX) NOT NULL, 
    [password] NVARCHAR(MAX) NOT NULL, 
    [creationDate] DATETIME NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'User',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Table',
    @level2type = NULL,
    @level2name = NULL