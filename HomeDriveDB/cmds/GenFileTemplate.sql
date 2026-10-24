INSERT INTO FileDirData ([FileDirDataId]
      ,[AccountId]
      ,[Type]
      ,[FileDirName]
      ,[ParentDirId]
      ,[MimeType]
      ,[Status]
      ,[PrivacyPolicy]
      ,[CreateDateTime])

SELECT
    NEWID(),
    '772A8410-AD9C-47D3-8CEF-818046576759',
    0,
    'File0.json',
    NULL,
    'application/json',
    0,
    0,
    SYSDATETIMEOFFSET()