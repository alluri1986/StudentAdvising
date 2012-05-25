USE [StudentAdvising_May]
GO
/****** Object:  UserDefinedFunction [dbo].[ExtractCourseID]    Script Date: 05/21/2012 15:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ExtractCourseID]
(
	@CourseIDs nvarchar(max)
)
RETURNS @Courses TABLE
(
	ID int IDENTITY(1,1),
	CourseID int
)
AS
BEGIN

	DECLARE
	   @Str varchar(max),
	   @Start int,
	   @Position int,
	   @ExtractedString varchar(256);
	   
	 SET @Str = @CourseIDs;
	       
	--DECLARE @Courses TABLE(ID int PRIMARY KEY IDENTITY(1,1), CourseID int);
	--SET @Str = '16,21,32,44';
	SET @Start = 0;
	SET @Position = -1;
	WHILE(@Position != 0)
	BEGIN
	   SET @Position = CHARINDEX(',', @Str, @Start);
	   IF @Position = 0
	   BEGIN
		   SET @ExtractedString = SUBSTRING(@Str, @Start, LEN(@Str) - @Start + 1);
	   END
	   ELSE
	   BEGIN
		   SET @ExtractedString = SUBSTRING(@Str, @Start, @Position - @Start);
		   SET @Start = @Position + 1;
		   --PRINT @Position;
	   END
	   --PRINT @ExtractedString;
	   INSERT INTO @Courses VALUES(@ExtractedString);
	END
	
	--SELECT * FROM @Temp;


RETURN;
END