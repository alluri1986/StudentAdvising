----------------------------------------------------------------------------------------
--StudentCourseSave
----------------------------------------------------------------------------------------

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