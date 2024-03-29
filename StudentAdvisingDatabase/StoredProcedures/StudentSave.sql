--------------------------------------------------------------------------------------------
--StudentSave stored procedure
--------------------------------------------------------------------------------------------
/****** Object:  StoredProcedure [dbo].[StudentSave]    Script Date: 04/14/2012 14:16:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudentSave]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[StudentSave]
PRINT 'StudentSave stored procedure dropped';
GO

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
	@JoiningSemesterID	int,
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
			SET	JoiningSemesterID				= @JoiningSemesterID,
				AdvisorID						= @AdvisorID,
         		IsTransferFL					= @IsTransferFL,
				IsActiveFL						= @IsActiveFL,
				LastUpdatedDate					= @LastUpdatedDate,
				LastUpdatedBy					= @LastUpdatedBy
			WHERE PersonID = @ID

		END
		ELSE
		BEGIN
			
			INSERT INTO Student
			(
				PersonID,
				JoiningSemesterID,
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
				@JoiningSemesterID,
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
GO
	PRINT 'StudentSave Stored Procedure Updated';
	GO
