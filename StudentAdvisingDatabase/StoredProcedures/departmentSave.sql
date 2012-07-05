----------------------------------------------------------------------------------------
--DepartmentSave stored procedure
----------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DepartmentSave]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DepartmentSave]
PRINT 'DepartmentSave stored procedure dropped';
GO



CREATE PROCEDURE DepartmentSave(

	@ID						int OUTPUT,
	@Name					nvarchar(500),
	@Abbreviation			nvarchar(20),
	@Description    		nvarchar(200),
	@IsActiveFL				bit,
	@CreationDate			datetime,
	@LastUpdatedDate		datetime,
	@CreatedBy				int,
	@LastUpdatedBy			int
)AS
BEGIN
	IF EXISTS(SELECT * FROM LuDepartment WHERE ID = @ID)
	BEGIN
		
		UPDATE LuDepartment
		SET Name					=    @Name,
			Abbreviation			=    @Abbreviation,
			[Description]    		=    @Description,  
			IsActiveFL				=    @IsActiveFL,			
			LastUpdatedDate			=    @LastUpdatedDate,	
			LastUpdatedBy			=    @LastUpdatedBy		
		WHERE ID = @ID	
			
	END
	ELSE
	BEGIN
		INSERT INTO LuDepartment
		(
		    Name,				
			Abbreviation,
			[Description],    	
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
PRINT 'DepartmentSave stored procedure created';
GO
