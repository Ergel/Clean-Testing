USE [master]
ALTER DATABASE [AuthenticationBase] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
BACKUP LOG [AuthenticationBase] TO  
DISK = N'C:\Entwicklung\Datenbanken\AuthenticationBase_LogBackup_2018-06-04_15-25-07.bak' WITH NOFORMAT, NOINIT, 
NAME = N'AuthenticationBase_LogBackup_2018-06-04_15-25-07', NOSKIP, NOREWIND, NOUNLOAD,  NORECOVERY ,  STATS = 5
RESTORE DATABASE [AuthenticationBase] FROM  DISK = N'C:\Entwicklung\Datenbanken\AuthenticationBase.bak' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 5
ALTER DATABASE [AuthenticationBase] SET MULTI_USER

GO


