----------------------------------------------------------------------------------------
--CoursePrerequisiteSave
----------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CoursePrerequisiteSave]
(
	@CourseID				int,
	@PreReqID				int,
	@IsDependencyFL			bit,
	@IsActiveFL				bit,
	@CreationDate			datetime,
	@LastUpdatedDate		datetime,
	@CreatedBy				int,
	@LastUpdatedBy			int
)
AS
BEGIN

	IF EXISTS(SELECT * FROM CoursePrerequisite WHERE CourseID = @CourseID AND PreReqID = @PreReqID)
	BEGIN
		
		UPDATE CoursePrerequisite
		SET  IsDependencyFL		=	@IsDependencyFL,	
			 IsActiveFL			=	@IsActiveFL,		
			 LastUpdatedDate	=	@LastUpdatedDate,
			 LastUpdatedBy		=	@LastUpdatedBy	
		WHERE CourseID = @CourseID AND PreReqID = @PreReqID
			  
	END
	ELSE
	BEGIN
	
		INSERT INTO CoursePrerequisite
		(
			CourseID,		
			PreReqID,		
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
			@IsDependencyFL,	
			@IsActiveFL,		
			@CreationDate,	
			@LastUpdatedDate,
			@CreatedBy,		
			@LastUpdatedBy	
		)
		
	END

END