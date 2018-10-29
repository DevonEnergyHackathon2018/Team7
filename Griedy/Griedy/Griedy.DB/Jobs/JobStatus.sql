CREATE TABLE [Jobs].[JobStatus]
(
	[JobStatusId] INT NOT NULL,
	[Status]      NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [JobStatusKey] PRIMARY KEY ([JobStatusId])
)
