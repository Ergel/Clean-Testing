USE [master]
GO
/****** Object:  Database [AuthenticationBase]    Script Date: 02.06.2019 21:54:05 ******/
CREATE DATABASE [AuthenticationBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AuthenticationBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AuthenticationBase2.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AuthenticationBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AuthenticationBase2_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AuthenticationBase] SET COMPATIBILITY_LEVEL = 110
GO

USE [AuthenticationBase]
GO
/****** Object:  Table [dbo].[Benutzer]    Script Date: 02.06.2019 21:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Benutzer](
	[BenutzerID] [bigint] IDENTITY(1,1) NOT NULL,
	[Vorname] [nvarchar](50) NULL,
	[Nachname] [nvarchar](50) NULL,
	[Passwort] [nchar](10) NULL,
	[Benutzername] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Benutzer] PRIMARY KEY CLUSTERED 
(
	[BenutzerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [AuthenticationBase] SET  READ_WRITE 
GO
