
CREATE TABLE LuDepartment
(
	ID int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(500) NOT NULL,
	[Description] nvarchar(200) NULL,
	Abbreviation nvarchar(20)  NULL,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime NOT NULL DEFAULT GETUTCDATE(),
	LastUpdatedDate datetime NOT NULL DEFAULT GETUTCDATE(),
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL
)

CREATE TABLE LuSemester
(
	ID int PRIMARY KEY IDENTITY(0,1),
	Name nvarchar(500) NOT NULL,
	[Year] int NOT NULL,
	[Description] nvarchar(200) NULL,
	StartDate datetime,
	EndDate datetime,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime NOT NULL DEFAULT GETUTCDATE(),
	LastUpdatedDate datetime NOT NULL DEFAULT GETUTCDATE(),
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL
	
)

CREATE TABLE Course
(
	ID int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(500) NOT NULL UNIQUE,
	Abbreviation nvarchar(20) NOT NULL,
	[Description] nvarchar(200) NULL,
	Credits int NOT NULL,
	DepartmentID int FOREIGN KEY REFERENCES LuDepartment(ID) NOT NULL,
	EnglishProficiencyFL bit DEFAULT 1 NOT NULL,
	IsMandatoryFL bit NOT NULL DEFAULT 1,
	IsElectiveAFL bit NOT NULL DEFAULT 1,
	IsElectiveBFL bit NOT NULL DEFAULT 1,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime NOT NULL DEFAULT GETUTCDATE(),
	LastUpdatedDate datetime NOT NULL DEFAULT GETUTCDATE(),
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL
)

CREATE TABLE CoursePrerequisite
(
    CourseID int FOREIGN KEY REFERENCES Course(ID) NOT NULL,
	PreReqID int FOREIGN KEY REFERENCES Course(ID) NOT NULL,
	IsDependencyFL bit DEFAULT 0 NOT NULL,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime DEFAULT GETUTCDATE() NOT NULL,
	LastUpdatedDate datetime DEFAULT GETUTCDATE() NOT NULL,
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL,
	CONSTRAINT PK_CoursePrerequisite PRIMARY KEY (CourseID,PreReqID)
)

CREATE TABLE SemesterCourse
(
	ID int PRIMARY KEY IDENTITY(1,1),
	SemesterID int FOREIGN KEY REFERENCES LuSemester(ID) NOT NULL,
	CourseID int FOREIGN KEY REFERENCES Course(ID) NOT NULL,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime DEFAULT GETUTCDATE() NOT NULL,
	LastUpdatedDate datetime DEFAULT GETUTCDATE() NOT NULL,
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL,
)

CREATE TABLE SemesterCoursePrerequisite
(
    CourseID int FOREIGN KEY REFERENCES Course(ID) NOT NULL,
	SemesterCourseID int  FOREIGN KEY REFERENCES SemesterCourse(ID),
	PreReqID int FOREIGN KEY REFERENCES Course(ID) NOT NULL,
	SemesterID int FOREIGN KEY REFERENCES LuSemester(ID) NOT NULL,
	IsDependencyFL bit DEFAULT 0 NOT NULL,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime DEFAULT GETUTCDATE() NOT NULL,
	LastUpdatedDate datetime DEFAULT GETUTCDATE() NOT NULL,
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL,
	CONSTRAINT PK_SemesterCoursePrerequiste PRIMARY KEY (CourseID,PreReqID,SemesterID)
)

CREATE TABLE Person
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	LSUID nvarchar(50) NULL UNIQUE,
	FirstName nvarchar(200) NOT NULL,
	MiddleName nvarchar(200) NULL,
	LastName nvarchar(200) NOT NULL,
	DOB datetime NULL,
	Email nvarchar(200) NULL,
	Phone nvarchar(200) NULL,
	DeptID int FOREIGN KEY REFERENCES LUDepartment(ID),
	UserName nvarchar(100)   NULL,
	[Password] nvarchar(200)   NULL,
	TemporaryAddress nvarchar(2000)NULL,
	HomeAddress nvarchar(200) NULL,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime DEFAULT GETUTCDATE() NOT NULL,
	LastUpdatedDate datetime DEFAULT GETUTCDATE() NOT NULL,
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL
)

CREATE TABLE Faculty
(
	PersonID int PRIMARY KEY FOREIGN KEY REFERENCES Person(ID),
	[Role] int ,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime DEFAULT GETUTCDATE() NOT NULL,
	LastUpdatedDate datetime DEFAULT GETUTCDATE() NOT NULL,
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL
	
)

CREATE TABLE Student
(
	PersonID int PRIMARY KEY FOREIGN KEY REFERENCES Person(ID),
	AdvisorID int REFERENCES Person(ID) NULL,
	ApprovalDate datetime NULL,
	IsApprovedFL bit DEFAULT 0,
	JoiningSemesterID int FOREIGN KEY REFERENCES LuSemester(ID)NOT NULL,
	IsTransferFL bit DEFAULT 0,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime DEFAULT GETUTCDATE() NOT NULL,
	LastUpdatedDate datetime DEFAULT GETUTCDATE() NOT NULL,
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL
)
	
CREATE TABLE StudentCourse
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	StudentID int FOREIGN KEY REFERENCES Student(PersonID),
	CourseID int FOREIGN KEY REFERENCES SemesterCourse(ID),
	SemesterCourseID int, 
	CourseName nvarchar(15),
	ElectiveID int,
	SemesterID int NOT NULL FOREIGN KEY REFERENCES LuSemester(ID),
	Credits int NOT NULL,
	[Status] nvarchar(10) NOT NULL,
	IsActiveFL bit DEFAULT 1 NOT NULL,
	CreationDate datetime DEFAULT GETUTCDATE() NOT NULL,
	LastUpdatedDate datetime DEFAULT GETUTCDATE() NOT NULL,
	CreatedBy int NOT NULL,
	LastUpdatedBy int NOT NULL,
)


CREATE TABLE LuCourseStatus
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Status nvarchar(15) 
)
----