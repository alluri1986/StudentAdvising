--------------------------------------------------------------------------------------------
--StudentSave stored procedure
--------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[StudentSave]
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
	@AdvisorID			int,
	@ApprovalDate		datetime,
	@IsApprovedFL		bit,
	@DOJ				datetime,
	@IsTransferFL		bit,
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
		
		IF EXISTS (SELECT * FROM Student WHERE PersonID = @ID)
		BEGIN
			
			UPDATE Student
			SET	DOJ				= @DOJ,
				AdvisorID		= @AdvisorID,
				ApprovalDate	= @ApprovalDate,
				IsApprovedFL	= @IsApprovedFL,
				IsTransferFL	= @IsTransferFL,
				IsActiveFL		= @IsActiveFL,
				LastUpdatedDate = @LastUpdatedDate,
				LastUpdatedBy	= @LastUpdatedBy
			WHERE PersonID = @ID

		END
		ELSE
		BEGIN
			
			INSERT INTO Student
			(
				PersonID,
				DOJ,
				AdvisorID,	
				ApprovalDate,
				IsApprovedFL,
				IsTransferFL,
				IsActiveFL,
				CreationDate,
				LastUpdatedDate,
				CreatedBy,
				LastUpdatedBy
			)
			VALUES
			(
				@ID,
				@DOJ,
				@AdvisorID,	
				@ApprovalDate,
				@IsApprovedFL,
				@IsTransferFL,
				@IsActiveFL,
				@CreationDate,
				@LastUpdatedDate,
				@CreatedBy,
				@LastUpdatedBy
			)
		
		END
	
	END
