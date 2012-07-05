----------------------------------------------------------------------------------------
--GetAvailableCoursesForStudentCheckingAllPreReqChain stored procedure
----------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAvailableCoursesForStudentCheckingAllPreReqChain]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAvailableCoursesForStudentCheckingAllPreReqChain]
PRINT 'GetAvailableCoursesForStudentCheckingAllPreReqChain stored procedure dropped';
GO

CREATE PROCEDURE GetAvailableCoursesForStudentCheckingAllPreReqChain
(
--DECLARE
	@CourseIDs nvarchar(max),
	--='149274,149262,149286',
	@SemesterID int 
		
)
AS
BEGIN
	
	DECLARE	@SemesterCourse TABLE(ID int IDENTITY (1,1),CourseID int,SemCourseID int);
	DECLARE	@AvailableCourse TABLE(ID int IDENTITY(1,1),SemesterID int, CourseID int,SemCourseID int,Credits int,IsElectiveAFL bit,ISElectiveBFL bit,CourseName Nvarchar(20) ,IsActiveFL bit,CreationDate datetime, LastUpdatedDate datetime, CreatedBy int, LastUpdatedBy int)
	
	DECLARE @AllPreRequisiteCourse TABLE (ID int IDENTITY(1,1),SemesterCourseID int,ALLPreReqID int, IsDependencyFL bit);
	
	DECLARE @RegisteredCoursesWithFailedCourses TABLE (ID int ,CourseID int,SemesterID int,[Status] Nvarchar(15));
	DECLARE @RegisteredCourses TABLE (ID int IDENTITY(1,1),CourseID int,SemesterID int,[Status] Nvarchar(15));
 
	
	-- Extracting registered courses from input string
	INSERT INTO @RegisteredCoursesWithFailedCourses
	SELECT * FROM dbo.ExtractCourseIDAndStatus(@CourseIDs);

   INSERT INTO @RegisteredCourses
	SELECT CourseID,SemesterID,RCWFC.[Status] FROM @RegisteredCoursesWithFailedCourses RCWFC  WHERE Status NOT IN('Fail','Drop');

	
  --SELECT * FROm @RegisteredCourses;
	
	--All the Courses
	INSERT INTO @SemesterCourse
	SELECT CourseID,ID FROM SemesterCourse WHERE SemesterID = @SemesterID 
	 AND CourseID NOT IN(SELECT CourseID FROM @RegisteredCourses)

	--AND ID IN (SELECT SemesterCourseID FROM SemesterCoursePrerequisite WHERE SemesterID = @SemesterID)
	
	--SELECT * FROM @SemesterCourse
	
	DECLARE @CourseID int;
	DECLARE @Credits int;
	DECLARE @ISElectiveAFL bit;
	DECLARE @ISElectiveBFL bit;
	DECLARE @CourseName Nvarchar(20);
	
	DECLARE @CurrentSemesterCourseID int;
	DECLARE @CurrentPreRequisiteCourseID int;
	DECLARE @IsAvailable bit = 1;
	DECLARE @PreReqListCourseID int;
      
	WHILE( SELECT TOP 1 ID FROM @SemesterCourse) IS NOT NULL
	BEGIN
		
			 --SELECT * FROM @SemesterCourse;
			
			SELECT TOP 1 @CurrentSemesterCourseID = SemCourseID,@CourseID = CourseID FROM @SemesterCourse
			SET @IsAvailable = 1;
			
			INSERT INTO @ALLPreRequisiteCourse
			SELECT @CurrentSemesterCourseID,PreReqID,IsDependencyFL FROM SemesterCoursePrerequisite WHERE SemesterCourseID = @CurrentSemesterCourseID;
			
			
		
		-- SELECT * FROM @ALLPreRequisiteCourse;
		DECLARE @PreRequisiteCourse TABLE (ID int IDENTITY(1,1),SemesterCourseID int,PreReqID int ,IsDependencyFL bit);
		
		WHILE( SELECT TOP 1 ID FROM @ALLPreRequisiteCourse) IS NOT NULL
		BEGIN
		 
				SELECT TOP 1 @PreReqListCourseID = ALLPreReqID FROM @ALLPreRequisiteCourse ;
				 
				INSERT INTO @ALLPreRequisiteCourse
				SELECT @CurrentSemesterCourseID,PreReqID , IsDependencyFL FROM CoursePrerequisite WHERE CourseID = @PreReqListCourseID;
				
				INSERT INTO @PreRequisiteCourse 
				SELECT @CurrentSemesterCourseID,ALLPreReqID , IsDependencyFL FROM @ALLPreRequisiteCourse WHERE ALLPreReqID = @PreReqListCourseID;
				
				--SELECT * FROM @PreRequisiteCourse;
				
				DELETE FROM @ALLPreRequisiteCourse WHERE ALLPreReqID = @PreReqListCourseID;

		END
		
		
		DECLARE @IDInPreREquisiteCourse int = 1;
		
		WHILE( SELECT TOP 1 ID FROM @PreRequisiteCourse) IS NOT NULL
		BEGIN
	
		DECLARE @courseStatus Nvarchar(20)=' ';
		DECLARE @courseSemester int ;
		DECLARE @isDependencyFL bit;
		
		SELECT @courseStatus = [Status]  FROM @RegisteredCourses WHERE CourseID = (SELECT TOP 1 PreReqID FROM @PreRequisiteCourse);
		SELECT @courseSemester = ( SELECT MIN(SemesterID) FROM @RegisteredCourses WHERE CourseID = (SELECT TOP 1 PreReqID FROM @PreRequisiteCourse));
		 
        SET @isDependencyFL =(SELECT TOP 1 IsDependencyFL FROM @PreRequisiteCourse)  	
 	
          IF(@courseStatus = 'Pass' OR @courseStatus = 'Pending' OR @courseStatus = 'In Progress' )
			  BEGIN
				IF(@courseSemester < @SemesterID)
				  BEGIN
					 SET @IsAvailable  = 1;
				  END
				ELSE IF(@courseSemester = @SemesterID)
					 BEGIN
					  IF(@isDependencyFL = 1 )
					   SET @IsAvailable  = 1;
					  ELSE 
					   BEGIN
						   SET @IsAvailable  = 0; 
						   DELETE FROM @PreRequisiteCourse;
					   END
					 END  
				ELSE
				 BEGIN
				  SET @IsAvailable  = 0; 
				  DELETE FROM @PreRequisiteCourse;
				 END 
			  END
          ELSE
			  BEGIN
			   	 SET @IsAvailable  = 0;
				 DELETE FROM @PreRequisiteCourse;
			  END
          		
		DELETE  FROM @PreRequisiteCourse WHERE ID =@IDInPreREquisiteCourse;
		SET @IDInPreREquisiteCourse = @IDInPreREquisiteCourse + 1;
		END 
		
		IF(@IsAvailable = 1)
		BEGIN
		SELECT @Credits =cours.Credits  ,@ISElectiveAFL = cours.IsElectiveAFL ,@ISElectiveBFL = cours.IsElectiveBFL,@CourseName = cours.Name FROM Course cours  WHERE cours.ID =@CourseID		
		
			 INSERT INTO @AvailableCourse(SemesterID, CourseID,SemCourseID,Credits,CourseName,IsElectiveAFL,IsElectiveBFL,IsActiveFL,CreationDate
			 ,LastUpdatedDate,CreatedBy,LastUpdatedBy)
			 VALUES(@SemesterID,@CourseID,@CurrentSemesterCourseID,@Credits,@CourseName,@ISElectiveAFL,@ISElectiveBFL, 1,GETDATE(),GETDATE(),1,1)
			 
		END
		
		--SELECT * FROM @PreRequisiteCourse	
		DELETE  FROM @PreRequisiteCourse;
		
		DELETE FROM @SemesterCourse WHERE SemCourseID = @CurrentSemesterCourseID;
	END
	
	SELECT * FROM @AvailableCourse

	END




GO
PRINT 'GetAvailableCoursesForStudentCheckingAllPreReqChain stored procedure created';
GO
