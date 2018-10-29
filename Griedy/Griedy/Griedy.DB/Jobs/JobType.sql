CREATE TABLE [Jobs].[JobType]
(
	[JobTypeId] INT NOT NULL,
	[Title]     NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [JobTypeKey] PRIMARY KEY ([JobTypeId])
)
