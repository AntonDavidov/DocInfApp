CREATE TABLE [dbo].[Documents](
	[Number] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Sum] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	CONSTRAINT [PK_dbo.Documents] PRIMARY KEY CLUSTERED 
	(
		[Number] ASC
	)
)
GO

CREATE TABLE [dbo].[Positions](
	[Number] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Sum] [int] NOT NULL,
	[DocumentNum] [int] NOT NULL,
	CONSTRAINT [PK_dbo.Positions] PRIMARY KEY CLUSTERED 
	(
		[Number] ASC
	),
	CONSTRAINT [FK_dbo.Positions_dbo.Documents_DocumentNum] FOREIGN KEY([DocumentNum])
	REFERENCES [dbo].[Documents] ([Number])
	ON DELETE CASCADE
)
GO