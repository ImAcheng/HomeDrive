create table FileAgent (
	FileId uniqueidentifier not null primary key,
	FileNo bigint identity(1, 1) not null,
	FilePath nvarchar(511) not null,
	MimeType nvarchar(127) not null,
	FileName nvarchar(255) not null,
	ShareType tinyint not null default 0,
	CreateDateTime datetimeoffset not null,
	UpdateDateTime datetimeoffset not null
)