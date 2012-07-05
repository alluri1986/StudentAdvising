
----------------------------------------------------------------------------------------
--UpDateStudentCourses stored procedure
----------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpDateStudentCourses]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpDateStudentCourses]
PRINT 'UpDateStudentCourses stored procedure dropped';
GO


ALTER PROCEDURE [dbo].[UpDateStudentCourses]
(@CourseIDs nvarchar(max))AS
BEGIN

DECLARE @RegisteredCourses TABLE (ID int ,SemesterCourseID int);

DECLARE @RegisteredCourseID  int;
DECLARE	@SemesterCourse TABLE(ID int IDENTITY (1,1),CourseID int,SemCourseID int);


-- Extracting registered courses from input string
	INSERT INTO @RegisteredCourses
	SELECT * FROM dbo.ExtractCourseID(@CourseIDs);

DECLARE @CourseName Nvarchar(20);

WHILE( SELECT TOP 1 SemesterCourseID FROM @RegisteredCourses) IS NOT NULL
	BEGIN
		
		SELECT  TOP 1 @RegisteredCourseID = SemesterCourseID FROM @RegisteredCourses;


with A(courseid,PreReqID) As 
(Select courseid,PreReqID from CoursePrerequisite 
 WHERE PreReqID=@RegisteredCourseID
	UNION ALL
	SELECT B.courseid,B.PreReqID from CoursePrerequisite as B,A
	WHERE A.courseid=B.PreReqID)
	SELECT courseid,PreReqID   from A

END
END  

GO
PRINT 'UpDateStudentCourses stored procedure created';
GO
