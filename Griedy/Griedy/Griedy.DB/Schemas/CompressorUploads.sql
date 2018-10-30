CREATE TABLE [dbo].[CompressorUploads]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CompressorId] VARCHAR(50) NOT NULL, 
    [CompressorName] VARCHAR(50) NOT NULL, 
    [RankedOn] DATETIME NOT NULL, 
    [RiskRanking] INT NOT NULL
)
