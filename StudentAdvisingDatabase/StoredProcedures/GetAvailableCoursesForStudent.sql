----------------------------------------------------------------------------------------
--GetAvailableCoursesForStudent stored procedure
----------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAvailableCoursesForStudent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAvailableCoursesForStudent]
PRINT 'GetAvailableCoursesForStudent stored procedure dropped';
GO


ALTER PROCEDURE [dbo].[GetAvailableCoursesForStudent]
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
	DECLARE @PreRequisiteCourse TABLE (ID int IDENTITY(1,1),CourseID int);
	DECLARE @RegisteredCourses TABLE (ID int ,CourseID int);
 
	
	-- Extracting registered courses from input string
	INSERT INTO @RegisteredCourses
	SELECT * FROM dbo.ExtractCourseID(@CourseIDs);
	
	--SELECT * FROm @RegisteredCourses;
	
	--All the Courses
	INSERT INTO @SemesterCourse
	SELECT CourseID,ID FROM SemesterCourse WHERE SemesterID = @SemesterID AND CourseID NOT IN(SELECT CourseID FROM SemesterCourse where ID IN(SELECT CourseID FROM @RegisteredCourses))

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
	

	WHILE( SELECT TOP 1 ID FROM @SemesterCourse) IS NOT NULL
	BEGIN
		
		SELECT  TOP 1 @CurrentSemesterCourseID = SemCourseID,@CourseID = CourseID FROM @SemesterCourse 
		SET @IsAvailable = 1;
		INSERT INTO @PreRequisiteCourse
		SELECT PreReqID FROM SemesterCoursePrerequisite WHERE SemesterCourseID = @CurrentSemesterCourseID;
		
		--SELECT * FROM @PreRequisiteCourse	
		
		WHILE( SELECT TOP 1 ID FROM @PreRequisiteCourse) IS NOT NULL
		BEGIN
		
			SELECT TOP 1 @CurrentPreRequisiteCourseID =  CourseID FROM @PreRequisiteCourse;
  
  
			-- Need to check whether the course is completed previously or not AND ISDependency
			--IF  NOT EXISTS (SELECT SemesterCourse.CourseID  FROM @RegisteredCourses RegCourse INNER JOIN SemesterCourse ON SemesterCourse.ID = RegCourse.CourseID WHERE SemesterCourse.CourseID = @CurrentPreRequisiteCourseID OR @SemesterID = (SELECT SemesterID FROM SemesterCourse WHERE ID =RegCourse.CourseID AND 1=(SELECT  IsDependencyFL FROM SemesterCoursePrerequisite WHERE CourseID = RegCourse.CourseID)))
			IF  NOT EXISTS (SELECT SemesterCourse.CourseID  FROM @RegisteredCourses RegCourse INNER JOIN SemesterCourse ON 
			SemesterCourse.ID = RegCourse.CourseID WHERE SemesterCourse.CourseID = @CurrentPreRequisiteCourseID AND 
				(@SemesterID >(SELECT SemesterID FROM SemesterCourse WHERE ID = RegCourse.CourseID) OR (@SemesterID = 
				(SELECT SC.SemesterID FROM SemesterCourse SC INNER JOIN SemesterCoursePrerequisite SCP ON SC.ID = SCP.SemesterCourseID 
				WHERE SC.ID =RegCourse.CourseID AND SCP.IsDependencyFL =1
				))))
			BEGIN
				DELETE FROM @PreRequisiteCourse;
				SET @IsAvailable = 0;
			END
			
			DELETE FROM @PreRequisiteCourse WHERE CourseID = @CurrentPreRequisiteCourseID;
		
		END
		
		IF(@IsAvailable = 1)
		BEGIN

		
		SELECT @Credits =cours.Credits  ,@ISElectiveAFL = cours.IsElectiveAFL ,@ISElectiveBFL = cours.IsElectiveBFL,@CourseName = cours.Name FROM Course cours  WHERE cours.ID =@CourseID		
		
			 INSERT INTO @AvailableCourse(SemesterID, CourseID,SemCourseID,Credits,CourseName,IsElectiveAFL,IsElectiveBFL,IsActiveFL,CreationDate
			 ,LastUpdatedDate,CreatedBy,LastUpdatedBy)
			 VALUES(@SemesterID,@CourseID,@CurrentSemesterCourseID,@Credits,@CourseName,@ISElectiveAFL,@ISElectiveBFL, 1,GETDATE(),GETDATE(),1,1)
			 
		END
		
		
		DELETE FROM @PreRequisiteCourse;
		DELETE FROM @SemesterCourse WHERE SemCourseID = @CurrentSemesterCourseID;
	END
	
	SELECT * FROm @AvailableCourse

END

GO
PRINT 'GetAvailableCoursesForStudent stored procedure updated';

GO