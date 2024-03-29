----------------------------------------------------------------------------------------
--PersonSave stored procedure
----------------------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonSave]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PersonSave]
PRINT 'PersonSave stored procedure dropped';
GO

CREATE PROCEDURE [dbo].[PersonSave]
(
	@ID					int OUTPUT,
	@LSUID				nvarchar(50),
	@FirstName			nvarchar(200),
	@MiddleName			nvarchar(200),
	@LastName			nvarchar(200),
	@DOB				datetime,
	@Email				nvarchar(200),
	@Phone				nvarchar(200),
	@DeptID				int,
	@UserName			nvarchar(100),
	@Password			nvarchar(200),
	@TemporaryAddress	nvarchar(max),
	@HomeAddress		nvarchar(max),
	@IsActiveFL			bit,
	@CreationDate		datetime,
	@LastUpdatedDate	datetime,
	@CreatedBy			int,
	@LastUpdatedBy		int
)
AS
BEGIN
	IF EXISTS(SELECT * FROM Person WHERE ID = @ID)
	BEGIN
		
		UPDATE Person
		SET	LSUID				=	@LSUID,
			FirstName			=	@FirstName,
			MiddleName			= 	@MiddleName,
			LastName			= 	@LastName,
			DOB					= 	@DOB,
			Email				= 	@Email,
			Phone				= 	@Phone,
			DeptID				= 	@DeptID,
			UserName			=	@UserName,
			[Password]			= 	@Password,
			TemporaryAddress	= 	@TemporaryAddress,
			HomeAddress			= 	@HomeAddress,
			IsActiveFL			= 	@IsActiveFL,
			LastUpdatedDate		= 	@LastUpdatedDate,
			LastUpdatedBy		= 	@LastUpdatedBy
		WHERE ID = @ID

	END
	ELSE
	BEGIN
	
		INSERT INTO Person
		(
			LSUID,			
			FirstName,		
			MiddleName,		
			LastName,		
			DOB,				
			Email,			
			Phone,			
			DeptID,			
			UserName,		
			[Password],		
			TemporaryAddress,
			HomeAddress,		
			IsActiveFL,		
			CreationDate,	
			LastUpdatedDate,	
			CreatedBy,		
			LastUpdatedBy	
		)
		VALUES
		(
			@LSUID,
			@FirstName,
			@MiddleName,
			@LastName,
			@DOB,
			@Email,
			@Phone,
			@DeptID,
			@UserName,
			@Password,
			@TemporaryAddress,
			@HomeAddress,
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
PRINT 'PersonSave stored procedure updated';
GO