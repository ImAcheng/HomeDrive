# Database Documentation

## Table[Account]
* AccountId: represent the id of an account.
* Username: the name which users use to login.
* Password: the password which users use to login.

## Table[FileDirData]
* FileDirDataId: represent the id of a file / dir.
* AccountId: represent the owner's id.
* Type: 0: file, 1: dir.
* FileDirName: represent the name of a file / dir.
* ParentDirId: represent the id of its parent dir.
* MimeType: represent its media type.
* Status: represent its status (0: default, 1: archived, 2: deleted).
* PrivacyPolicy: represent its visibility (0: private, 1: public).
* CreateDateTime: represent the UTC datetime it was created.

## Script
```sql
IF DB_ID(N'HomeDrive') IS NULL
BEGIN
    CREATE DATABASE HomeDrive;
    USE HomeDrive;

    create table Account (
        AccountId uniqueidentifier not null primary key,
        Username nvarchar(63) not null,
        LoginPassword nvarchar(511) not null
    )

    create table FileDirData (
        FileDirDataId uniqueidentifier not null primary key,
        AccountId uniqueidentifier not null foreign key references Account(AccountId),
        Type tinyint not null check (Type in (0, 1)),
        FileDirName nvarchar(511) not null,
        ParentDirId uniqueidentifier foreign key references FileDirData(FileDirDataId),
        MimeType nvarchar(63) null,
        Status tinyint not null default 0,
        PrivacyPolicy tinyint not null default 0
        CreateDateTime datetimeoffset not null
    )
END
```