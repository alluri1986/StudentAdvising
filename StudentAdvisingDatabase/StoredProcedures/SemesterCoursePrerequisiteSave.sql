----------------------------------------------------------------------------------------
--SemesterCoursePrerequisiteSave stored procedure
----------------------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SemesterCoursePrerequisiteSave]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SemesterCoursePrerequisiteSave]
PRINT 'SemesterCoursePrerequisiteSave stored procedure dropped';
GO


CREATE PROCEDURE [dbo].[SemesterCoursePrerequisiteSave]
(
	@SemesterCourseID		int,
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

	IF EXISTS(SELECT * FROM SemesterCoursePrerequisite WHERE SemesterCourseID = @SemesterCourseID AND PreReqID = @PreReqID AND SemesterID = @SemesterID)
	BEGIN
		
		UPDATE SemesterCoursePrerequisite
		SET  IsDependencyFL		=	@IsDependencyFL,	
			 IsActiveFL			=	@IsActiveFL,		
			 LastUpdatedDate	=	@LastUpdatedDate,
			 LastUpdatedBy		=	@LastUpdatedBy	
		WHERE SemesterCourseID = @SemesterCourseID AND PreReqID = @PreReqID AND SemesterID = @SemesterID
		
	END
	ELSE
	BEGIN
	
		INSERT INTO SemesterCoursePrerequisite
		(
			SemesterCourseID,		
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
			@SemesterCourseID,
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

GO
PRINT 'SemesterCoursePrerequisiteSave stored procuedure updated';
GO