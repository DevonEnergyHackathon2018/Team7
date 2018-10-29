CREATE TABLE [Jobs].[JobInstance]
(
	[JobInstanceId] INT NOT NULL IDENTITY,
	[JobTypeId]     INT NOT NULL,
	[BeginOn]       DATETIME NOT NULL,
	[EndOn]         DATETIME NULL,
	[JobStatusId]   INT NOT NULL,
	[Message]       NVARCHAR(MAX),
	CONSTRAINT [JobInstanceKey] PRIMARY KEY ([JobInstanceId]),
	CONSTRAINT [JobInstanceJobStatusRef] FOREIGN KEY ([JobStatusId])
		REFERENCES [Jobs].[JobStatus] ([JobStatusId]),
	CONSTRAINT [JobInstanceJobTypeRef] FOREIGN KEY ([JobTypeId])
		REFERENCES [Jobs].[JobType] ([JobTypeId])
)
