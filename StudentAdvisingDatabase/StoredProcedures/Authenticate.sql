----------------------------------------------------------------------------------------
--AddSemesterCourse stored procedure
----------------------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Authenticate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Authenticate]
PRINT 'Authenticate stored procedure dropped';
GO

CREATE PROCEDURE Authenticate(@Email nvarchar(10))
AS
BEGIN
DECLARE @UserDetails TABLE (StudentID int,FacultyID int,LSUID int,Email Nvarchar(20),JoiningSemesterID int,[Role] int );
  
  INSERT INTO @UserDetails
  SELECT S.PersonID ,ID,LSUID,Email,JoiningSemesterID ,1 FROM Person P INNER JOIN Student S ON P.ID = S.PersonID where Email= @Email
  
  IF NOT EXISTS(SELECT * FROM @UserDetails)
   BEGIN
     INSERT INTO @UserDetails
     SELECT 0 ,ID ,LSUID,Email ,0 ,F.[Role] FROM Person P INNER JOIN Faculty F ON P.ID =F.PersonID WHERE Email = @Email
   END
  
  SELECT * FROM @UserDetails
  
  
END

GO
PRINT 'Authenticate stored procedure updated';
GO
