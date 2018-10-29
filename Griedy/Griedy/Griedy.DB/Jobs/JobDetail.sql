CREATE TABLE [Jobs].[JobDetail]
(
	[JobDetailId]   INT NOT NULL IDENTITY,
	[JobInstanceId] INT NOT NULL,
	[Message]       NVARCHAR(MAX),
	[TimeStamp]     DATETIME NOT NULL,
	[Severity]      NVARCHAR(10) NOT NULL,
	CONSTRAINT [JobDetailKey] PRIMARY KEY ([JobDetailId]),
	CONSTRAINT [JobDetailJobInstanceRef] FOREIGN KEY ([JobInstanceId])
		REFERENCES [Jobs].[JobInstance]([JobInstanceId]),
	CONSTRAINT [JobDetailSeverityCheck] CHECK ([Severity] = 'Info' OR [Severity] = 'Warning' OR [Severity] = 'Error')
)
