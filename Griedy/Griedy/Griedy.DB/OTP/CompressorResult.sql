CREATE TABLE [dbo].[CompressorResult]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CompressorId] NVARCHAR(50) NOT NULL, 
    [CompressorName] NVARCHAR(50) NOT NULL, 
    [RankedOn] DATETIME NOT NULL, 
    [RiskRanking] INT NOT NULL
)
