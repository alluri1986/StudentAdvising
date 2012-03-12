--------------------------------------------------------------------------------------------
--StudentSave stored procedure
--------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[FacultySave]
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

		 EXEC PersonSave
			@ID					= @ID OUTPUT,
			@LSUID				= @LSUID,
			@FirstName			= @FirstName,
			@MiddleName			= @MiddleName,
			@LastName			= @LastName,
			@DOB				= @DOB,
			@Email				= @Email,
			@Phone				= @Phone,
			@DeptID				= @DeptID,
			@UserName			= @UserName,
			@Password			= @Password,
			@TemporaryAddress	= @TemporaryAddress,
			@HomeAddress		= @HomeAddress,
			@IsActiveFL			= @IsActiveFL,
			@CreationDate		= @CreationDate,
			@LastUpdatedDate	= @LastUpdatedDate,
			@CreatedBy			= @CreatedBy,
			@LastUpdatedBy		= @LastUpdatedBy
		
		IF EXISTS (SELECT * FROM Faculty WHERE PersonID = @ID)
		BEGIN
			
			UPDATE Faculty
			SET	IsActiveFL		= @IsActiveFL,
				LastUpdatedDate = @LastUpdatedDate,
				LastUpdatedBy	= @LastUpdatedBy
			WHERE PersonID = @ID

		END
		ELSE
		BEGIN
			
			INSERT INTO Faculty
			(
				PersonID,
				IsActiveFL,
				CreationDate,
				LastUpdatedDate,
				CreatedBy,
				LastUpdatedBy
			)
			VALUES
			(
				@ID,
				@IsActiveFL,
				@CreationDate,
				@LastUpdatedDate,
				@CreatedBy,
				@LastUpdatedBy
			)
		
		END
	
	END
	

