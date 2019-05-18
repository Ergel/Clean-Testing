USE [master]
RESTORE DATABASE [AuthenticationBase] 
FROM  DISK = N'C:\Entwicklung\Datenbanken\AuthenticationBase.bak' 
WITH  FILE = 1,  
MOVE N'AuthenticationBase' 
TO N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AuthenticationBase.mdf', 
MOVE N'AuthenticationBase_log' 
TO N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AuthenticationBase_log.ldf',  
NOUNLOAD,  REPLACE,  STATS = 5

GO
