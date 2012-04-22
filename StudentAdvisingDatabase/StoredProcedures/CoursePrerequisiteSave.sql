----------------------------------------------------------------------------------------
--CoursePrerequisiteSave stored procedure
----------------------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CoursePrerequisiteSave]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CoursePrerequisiteSave]
PRINT 'CoursePrerequisiteSave stored procedure dropped';
GO


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

GO
PRINT 'CoursePrerequisiteSave stored procedure created'
GO