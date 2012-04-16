CREATE PROCEDURE [dbo].[SearchStudent]
(
	@LastName nvarchar(100),
	@Email	  nvarchar(500)
	
)
AS
BEGIN

	SELECT s.PersonID,s.AdvisorID,s.IsApprovedFL,s.ApprovalDate,s.IsActiveFL,s.JoiningSemesterID,s.IsTransferFL,s.IsActiveFL,s.CreationDate,s.LastUpdatedDate,s.CreatedBy,s.LastUpdatedBy,p.LSUID,p.FirstName,p.LastName,p.MiddleName,p.ID,p.Email,p.Phone,p.DeptID,p.UserName,p.[Password],p.TemporaryAddress,p.HomeAddress
	FROM Student s INNER JOIN Person p ON p.ID = s.PersonID
	WHERE 
	p.LastName LIKE '%'+@LastName+'%'
	
	
END