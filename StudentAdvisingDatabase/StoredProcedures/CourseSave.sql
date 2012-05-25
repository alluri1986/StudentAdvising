----------------------------------------------------------------------------------------
--CourseSave stored procedure
----------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CourseSave]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CourseSave]
PRINT 'CourseSave stored procedure dropped';
GO

CREATE PROCEDURE [dbo].[CourseSave]
(
	@ID						int OUTPUT,
	@Name					nvarchar(500),
	@Abbreviation			nvarchar(20),
	@Description    		nvarchar(200),
	@Credits				int,
	@DepartmentID			int,
	@EnglishProficiencyFL	bit,
	@IsMandatoryFL			bit,
	@IsElectiveAFL			bit,
	@IsElectiveBFL			bit,
	@IsActiveFL				bit,
	@CreationDate			datetime,
	@LastUpdatedDate		datetime,
	@CreatedBy				int,
	@LastUpdatedBy			int
	

)AS
BEGIN
	IF EXISTS(SELECT * FROM Course WHERE ID = @ID)
	BEGIN
		
		UPDATE Course
		SET Name					=    @Name,
			Abbreviation			=    @Abbreviation,
			[Description]    		=    @Description,  
			Credits					=    @Credits,		
			DepartmentID			=    @DepartmentID,
			EnglishProficiencyFL		=    @EnglishProficiencyFL,
			IsMandatoryFL			=	 @IsMandatoryFL,
			IsElectiveAFL			=	 @IsElectiveAFL,
			IsElectiveBFL			=	 @IsElectiveBFL,
			IsActiveFL				=    @IsActiveFL,			
			LastUpdatedDate			=    @LastUpdatedDate,	
			LastUpdatedBy			=    @LastUpdatedBy		
		WHERE ID = @ID	
			
	END
	ELSE
	BEGIN
		INSERT INTO Course
		(
		    
			Name,				
			Abbreviation,
			[Description],    	
			Credits,		
			DepartmentID,
			EnglishProficiencyFL,
			IsMandatoryFL,
			IsElectiveAFL,
			IsElectiveBFL,
			IsActiveFL,	
			CreationDate,		
			LastUpdatedDate,		
			CreatedBy,	
			LastUpdatedBy		
		   		
		)
		VALUES
		(
			@Name,
			@Abbreviation,
			@Description,  
			@Credits,		
			@DepartmentID,
			@EnglishProficiencyFL,
			@IsMandatoryFL,
			@IsElectiveAFL,
			@IsElectiveBFL,
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
PRINT 'CourseSave stored procedure created';
GO