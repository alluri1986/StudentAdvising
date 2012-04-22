----------------------------------------------------------------------------------------
--SemesterCourseSave stored procedure
----------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[SemesterCourseSave]
(
	@ID						int OUTPUT,
	@SemesterID				int,
	@CourseID				int,
	@IsActiveFL				bit,
	@CreationDate			datetime,
	@LastUpdatedDate		datetime,
	@CreatedBy				int,
	@LastUpdatedBy			int
)
AS
BEGIN

	IF EXISTS(SELECT * FROM SemesterCourse WHERE ID = @ID)
	BEGIN
		
		UPDATE SemesterCourse
		SET SemesterID					=	@SemesterID,		
			CourseID					=	@CourseID,		
			IsActiveFL					=	@IsActiveFL,		
			LastUpdatedDate				=	@LastUpdatedDate,
			LastUpdatedBy				=	@LastUpdatedBy	
		WHERE ID = @ID
			
	END
	ELSE
	BEGIN
	
		INSERT INTO SemesterCourse
		(
			SemesterID,		
			CourseID,		
			IsActiveFL,		
			CreationDate,	
			LastUpdatedDate,
			CreatedBy,		
			LastUpdatedBy	
		)
		VALUES
		(
			@SemesterID,		
			@CourseID,		
			@IsActiveFL,		
			@CreationDate,	
			@LastUpdatedDate,
			@CreatedBy,		
			@LastUpdatedBy	
		)
		SET @ID = SCOPE_IDENTITY();	
			
	END

END






























