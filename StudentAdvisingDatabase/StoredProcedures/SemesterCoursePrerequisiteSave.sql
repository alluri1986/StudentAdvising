----------------------------------------------------------------------------------------
--SemesterCoursePrerequisiteSave
----------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[SemesterCoursePrerequisiteSave]
(
	@CourseID				int,
	@PreReqID				int,
	@SemesterID				int,
	@IsDependencyFL			bit,
	@IsActiveFL				bit,
	@CreationDate			datetime,
	@LastUpdatedDate		datetime,
	@CreatedBy				int,
	@LastUpdatedBy			int
)
AS
BEGIN

	IF EXISTS(SELECT * FROM SemesterCoursePrerequisite WHERE CourseID = @CourseID AND PreReqID = @PreReqID AND SemesterID = @SemesterID)
	BEGIN
		
		UPDATE SemesterCoursePrerequisite
		SET  IsDependencyFL		=	@IsDependencyFL,	
			 IsActiveFL			=	@IsActiveFL,		
			 LastUpdatedDate	=	@LastUpdatedDate,
			 LastUpdatedBy		=	@LastUpdatedBy	
		WHERE CourseID = @CourseID AND PreReqID = @PreReqID
		
	END
	ELSE
	BEGIN
	
		INSERT INTO SemesterCoursePrerequisite
		(
			CourseID,		
			PreReqID,
			SemesterID,	
			IsDependencyFL,	
			IsActiveFL,	
			CreationDate,	
			LastUpdatedDate,
			CreatedBy,		
			LastUpdatedBy	
		)
		VALUES
		(
			@CourseID,
			@PreReqID,		
			@SemesterID,
			@IsDependencyFL,	
			@IsActiveFL,		
			@CreationDate,	
			@LastUpdatedDate,
			@CreatedBy,		
			@LastUpdatedBy	
		)
		
	END

END