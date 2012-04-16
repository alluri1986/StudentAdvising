
----------------------------------------------------------------------------------------
--CourseSave
----------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CourseSave]
(
	@ID						int OUTPUT,
	@Name					nvarchar(500),
	@Abbreviation			nvarchar(20),
	@Description    		nvarchar(200),
	@Credits				int,
	@DepartmentID			int,
	@EnglishProficiencyFL		bit,
	@IsMandatoryFL			bit,
	@IsElectiveFL			bit,
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
			IsElectiveFL			=	 @IsElectiveFL,
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
			IsElectiveFL,
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
			@IsElectiveFL,
			@IsActiveFL,		
			@CreationDate,		
			@LastUpdatedDate,	
			@CreatedBy,		
			@LastUpdatedBy		
		)
		SET @ID = SCOPE_IDENTITY();
	END

END