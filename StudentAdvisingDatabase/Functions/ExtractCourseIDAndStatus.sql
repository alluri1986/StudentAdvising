----------------------------------------------------------------------------------------
--ExtractCourseIDAndStatus Function
----------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExtractCourseIDAndStatus]') AND type in (N'P', N'PC'))
DROP FUNCTION [dbo].[ExtractCourseIDAndStatus];
PRINT 'ExtractCourseIDAndStatus Function dropped';
GO


CREATE FUNCTION [dbo].[ExtractCourseIDAndStatus]
(
	@CourseIDs nvarchar(max)
)
RETURNS @Courses TABLE(ID int IDENTITY(1,1),
		CourseID int ,SemesterID int , [Status] varchar(max))

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
	   DECLARE @CourseID int ;
	   DECLARE @Status varchar(max);
	   DECLARE @SemesterID int;
	   DECLARE @Position1 int =0;
	   DECLARE @Position2 int =0;
	   DECLARE @Start1 int =0;
	   
	   
		   
	   
	   SET @Position1 = CHARINDEX('-', @ExtractedString, @Start1);
	   IF @Position1 = 0
	   BEGIN
		   SET @CourseID =  SUBSTRING(@ExtractedString, @Start1, @Position1 - @Start1);
	     -- SET @Status =
	   END
	   ELSE
	   BEGIN
		   SET @CourseID   =  SUBSTRING(@ExtractedString, @Start1, @Position1 );
		   
		   SET @Position2 = CHARINDEX('-',@ExtractedString,@Position1+1);
		   
		   SET @SemesterID   =  SUBSTRING(@ExtractedString, @Position1- @Start1+1, @Position2-@Position1-1);
		   SET @Status =  SUBSTRING(@ExtractedString, @Position2 + 1, LEN(@ExtractedString));
		   
		   SET @Start1 = @Position1 + 1;
		   
	   END
	   
	   
	  IF @CourseIDs != ''
	   	   		INSERT INTO @Courses VALUES(@CourseID,@SemesterID,@Status);
	   
	   
	END	
	--SELECT * FROM @Courses;
	RETURN;
	END



GO
PRINT 'ExtractCourseIDAndStatus Function created';
GO
