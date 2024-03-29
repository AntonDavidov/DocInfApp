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
