----------------------------------------------------------------------------------------
--GetAllDependenciesChain stored procedure
----------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllDependenciesChain]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllDependenciesChain]
PRINT 'GetAllDependenciesChain stored procedure dropped';
GO

CREATE PROCEDURE [dbo].[GetAllDependenciesChain](@CheckSemesterCourseID int,@CourseIDs nvarchar(max),@ToRemove nvarchar(max) OUTPUT)
AS
BEGIN

DECLARE @RegisteredCourses TABLE (ID int ,CourseID int);
DECLARE @AllPreReqS  TABLE (ID int IDENTITY (1,1),SemesterCourseID int ,CourseID int);
DECLARE @AllPossibleDependents TABLE (ID int IDENTITY (1,1),SemesterCourseID int );


-- Extracting registered courses from input string
	INSERT INTO @RegisteredCourses
	SELECT * FROM dbo.ExtractCourseID(@CourseIDs);


-- listing all the immediate dependents. If Status changed as Fail or Drop then dependency is not listed
IF EXISTS(SELECT * FROM @RegisteredCourses WHERE CourseID = @CheckSemesterCourseID)
		BEGIN
			INSERT INTO @AllPreReqS SELECT SCP.SemesterCourseID,SC.CourseID FROM SemesterCoursePrerequisite SCP INNER JOIN SemesterCourse SC 
							 ON SCP.SemesterCourseID = SC.ID   WHERE PreReqID = (SELECT CourseID FROM SemesterCourse WHERE ID = @CheckSemesterCourseID)  AND SCP.IsDependencyFL = 0
		END
ELSE
	BEGIN
          INSERT INTO @AllPreReqS SELECT SCP.SemesterCourseID,SC.CourseID FROM SemesterCoursePrerequisite SCP INNER JOIN SemesterCourse SC 
							 ON SCP.SemesterCourseID = SC.ID   WHERE PreReqID = (SELECT CourseID FROM SemesterCourse WHERE ID = @CheckSemesterCourseID)
	END

WHILE( SELECT TOP 1 ID FROM @AllPreReqS) IS NOT NULL
   BEGIN
    DECLARE  @CurrentPreReqID int;
    SELECT  TOP 1 @CurrentPreReqID = CourseID FROM @AllPreReqS
    
    IF EXISTS(SELECT * FROM @RegisteredCourses WHERE CourseID = @CheckSemesterCourseID)
    BEGIN
    INSERT INTO @AllPreReqS SELECT SCP.SemesterCourseID,SC.CourseID FROM SemesterCoursePrerequisite SCP INNER JOIN SemesterCourse SC 
             ON SCP.SemesterCourseID = SC.ID   WHERE PreReqID = @CurrentPreReqID AND
             SC.SemesterID != (SELECT SemesterID FROM SemesterCourse WHERE ID = @CheckSemesterCourseID)
    END
    ELSE
     BEGIN
		   INSERT INTO @AllPreReqS SELECT SCP.SemesterCourseID,SC.CourseID FROM SemesterCoursePrerequisite SCP INNER JOIN SemesterCourse SC 
                				 ON SCP.SemesterCourseID = SC.ID   WHERE PreReqID = @CurrentPreReqID
                        
     END       
  		   INSERT INTO @AllPossibleDependents(SemesterCourseID) ( SELECT SemesterCourseID FROM @AllPreReqS WHERE CourseID = @CurrentPreReqID )
	             
           DELETE FROM @AllPreReqS WHERE CourseID = @CurrentPreReqID

        
   END
--SELECT * FROM @AllPossibleDependents
DECLARE @RegisteredCourse int;
SET @ToRemove='';
WHILE( SELECT TOP 1 ID FROM @RegisteredCourses) IS NOT NULL
BEGIN
    SELECT TOP 1 @RegisteredCourse = CourseID FROM @RegisteredCourses
    
   IF EXISTS( SELECT SemesterCourseID FROM @AllPossibleDependents WHERE SemesterCourseID = @RegisteredCourse)
  BEGIN
   DECLARE @remove nvarchar(max);
   SET @remove =@RegisteredCourse ;
   SET @ToRemove = @ToRemove + @remove ;
   SET @ToRemove = @ToRemove +',' ;
   END
   
   DELETE FROM @RegisteredCourses WHERE CourseID = @RegisteredCourse
   
END


   
END




GO
PRINT 'GetAllDependenciesChain stored procedure created';
GO
