CREATE TABLE SchoolClasses (
	Id uniqueidentifier not null primary key,
	ClassName nvarchar(20) not null,
	TeacherId nvarchar(450) not null,
	Created date not null
)
GO

CREATE TABLE SchoolClassStudent (
	StudentId nvarchar(450)  not null primary key,
	SchoolClassId uniqueidentifier not null references SchoolClasses(Id),
	Created date not null
)
GO