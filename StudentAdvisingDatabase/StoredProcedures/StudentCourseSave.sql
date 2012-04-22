----------------------------------------------------------------------------------------
--StudentCourseSave stored procedure
----------------------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentCourseSave]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[StudentCourseSave]
PRINT 'StudentCourseSave stored procedure dropped';
GO


CREATE PROCEDURE [dbo].[StudentCourseSave]
(
	@ID						int OUTPUT,
	@StudentID				int,
	@CourseID				int,
	@SemesterID				int,
	@Status					nvarchar(10),
	@IsActiveFL				bit,
	@CreationDate			datetime,
	@LastUpdatedDate		datetime,
	@CreatedBy				int,
	@LastUpdatedBy			int
)
AS
BEGIN

	IF EXISTS(SELECT * FROM StudentCourse WHERE ID = @ID)
	BEGIN
		
		UPDATE StudentCourse
		SET	 StudentID					=	@StudentID,	
			 CourseID					=	@CourseID,		
			 SemesterID					=	@SemesterID,		
			 [Status]					=	@Status,			
			 IsActiveFL					=	@IsActiveFL,		
			 LastUpdatedDate			=	@LastUpdatedDate,
			 LastUpdatedBy				=	@LastUpdatedBy
		WHERE ID = @ID
		
	END
	ELSE
	BEGIN
	
		INSERT INTO StudentCourse
		(
			StudentID,		
			CourseID,		
			SemesterID,		
			[Status],			
			IsActiveFL,		
			CreationDate,	
			LastUpdatedDate,
			CreatedBy,		
			LastUpdatedBy	
		)
		VALUES
		(
			@StudentID,		
			@CourseID,		
			@SemesterID,		
			@Status,			
			@IsActiveFL,		
			@CreationDate,	
			@LastUpdatedDate,
			@CreatedBy,		
			@LastUpdatedBy	
		)
		SET @ID = SCOPE_IDENTITY();
		
	END

END

GO
PRINT 'StudentCourseSave stored procedure updated';
GO