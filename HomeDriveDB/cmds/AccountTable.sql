create table Account (
	AccountId uniqueidentifier not null primary key,
	AccountNo bigint identity(1, 1) not null,
	Username nvarchar(63) not null,
	Password nvarchar(255) not null,
	Nickname nvarchar(127),
	CreateDateTime datetimeoffset not null,
	UpdateDateTime datetimeoffset,
	Roles nvarchar(255) not null default '["user"]'
)