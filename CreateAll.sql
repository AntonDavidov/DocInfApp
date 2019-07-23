CREATE DATABASE [DocInfBase]
GO

USE [DocInfBase]
GO

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

CREATE LOGIN DocInfBaseUser WITH PASSWORD='1q2w3e4r5'
CREATE USER DocInfBaseUser FOR LOGIN DocInfBaseUser WITH DEFAULT_SCHEMA=[dbo]
GRANT select TO DocInfBaseUser
GRANT update TO DocInfBaseUser
GRANT insert TO DocInfBaseUser
GRANT delete TO DocInfBaseUser
DENY UPDATE ON OBJECT::[Documents] ([Sum]) TO [DocInfBaseUser]


USE [DocInfBase]
GO
CREATE TRIGGER [dbo].[position_trigger] 
ON [dbo].[Positions]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
DECLARE @sum int;
SELECT @sum = SUM(Sum) FROM [Positions] WHERE DocumentNum = (select TOP(1) DocumentNum from inserted)
IF(@sum IS NULL)
	SELECT @sum = SUM(Sum) FROM [Positions] WHERE DocumentNum = (select TOP(1) DocumentNum from deleted)
IF(@sum IS NULL)
	SELECT @sum = 0;
IF(@sum IS NOT NULL)
	UPDATE [Documents] SET Sum = @sum
	WHERE Number = (select TOP(1) DocumentNum from inserted) OR
		  Number = (select TOP(1) DocumentNum from deleted)
END

