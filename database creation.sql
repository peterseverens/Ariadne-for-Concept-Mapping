

/* BUILD SQL DATABASE AND TABLES ARIADNE 


/* IMPORTANT!!

/* this is not the aspnet authentication database you also need. This database is build according a standard, look on the web: 

/* https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/authentication-in-sql-server#login-types
 
/* look for SQL Server login. 

/* also check this page: https://www.c-sharpcorner.com/blogs/create-install-asp-net-membership-database 

/* the connection strings to the databases in this application are written in Config.sys!

/* to open th applicationL click on the .sln file (to open in visual studio)


USE [master]
GO

/****** Object:  Database [ariadne_international]    Script Date: 04/08/2021 12:23:02 ******/
CREATE DATABASE [ariadne_international] ON  PRIMARY 
( NAME = N'ariadne_international', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ariadne_international.mdf' , SIZE = 394240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ariadne_international_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ariadne_international_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [ariadne_international] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ariadne_international].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ariadne_international] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ariadne_international] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ariadne_international] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ariadne_international] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ariadne_international] SET ARITHABORT OFF 
GO

ALTER DATABASE [ariadne_international] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ariadne_international] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [ariadne_international] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ariadne_international] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ariadne_international] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ariadne_international] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ariadne_international] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ariadne_international] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ariadne_international] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ariadne_international] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ariadne_international] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ariadne_international] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ariadne_international] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ariadne_international] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ariadne_international] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ariadne_international] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ariadne_international] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ariadne_international] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ariadne_international] SET  READ_WRITE 
GO

ALTER DATABASE [ariadne_international] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ariadne_international] SET  MULTI_USER 
GO

ALTER DATABASE [ariadne_international] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ariadne_international] SET DB_CHAINING OFF 
GO

USE [ariadne_international]
GO

/****** Object:  Table [dbo].[backups]    Script Date: 04/08/2021 12:24:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[backups](
	[organizerId] [uniqueidentifier] NULL,
	[projectId] [uniqueidentifier] NULL,
	[projectName] [nvarchar](max) NULL,
	[version] [nvarchar](max) NULL,
	[created] [datetime] NULL
) ON [PRIMARY]

GO
USE [ariadne_international]
GO

/****** Object:  Table [dbo].[excerpts]    Script Date: 04/08/2021 12:24:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[excerpts](
	[excerptid] [uniqueidentifier] NULL,
	[title] [nvarchar](100) NULL,
	[excerptshort] [nvarchar](300) NULL,
	[excerpt] [nvarchar](2000) NULL,
	[author] [nvarchar](100) NULL
) ON [PRIMARY]

GO
USE [ariadne_international]
GO

/****** Object:  Table [dbo].[Items]    Script Date: 04/08/2021 12:25:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Items](
	[organizerId] [uniqueidentifier] NULL,
	[projectId] [uniqueidentifier] NULL,
	[itemId] [uniqueidentifier] NULL,
	[itemtext] [nvarchar](199) NULL,
	[created] [datetime] NULL,
	[x] [float] NULL,
	[y] [float] NULL
) ON [PRIMARY]

GO
USE [ariadne_international]
GO

/****** Object:  Table [dbo].[LinkProjectParticipant]    Script Date: 04/08/2021 12:25:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LinkProjectParticipant](
	[organizerId] [uniqueidentifier] NULL,
	[projectId] [uniqueidentifier] NULL,
	[participantId] [uniqueidentifier] NULL,
	[itemsortdata] [varchar](max) NULL,
	[itemratedata1] [varchar](max) NULL,
	[itemratedata2] [varchar](max) NULL,
	[itemratedata3] [varchar](max) NULL,
	[itemratedata4] [varchar](max) NULL,
	[itemratedata5] [varchar](max) NULL,
	[created] [datetime] NULL,
	[xcoord] [varchar](max) NULL,
	[ycoord] [varchar](max) NULL,
	[clusternames] [nvarchar](max) NULL,
	[items_selected] [varchar](max) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ariadne_international]
GO

/****** Object:  Table [dbo].[organizer]    Script Date: 04/08/2021 12:25:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[organizer](
	[organizerId] [uniqueidentifier] NULL,
	[name] [nvarchar](max) NULL,
	[pass] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL
) ON [PRIMARY]

GO

USE [ariadne_international]
GO

/****** Object:  Table [dbo].[participant]    Script Date: 04/08/2021 12:26:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[participant](
	[organizerId] [uniqueidentifier] NULL,
	[projectId] [uniqueidentifier] NULL,
	[participantId] [uniqueidentifier] NULL,
	[Firstname] [nvarchar](max) NULL,
	[Lastname] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[created] [datetime] NULL,
	[username] [nvarchar](max) NULL,
	[passname] [nvarchar](max) NULL,
	[var1] [nvarchar](max) NULL,
	[var2] [nvarchar](max) NULL,
	[var3] [nvarchar](max) NULL,
	[var4] [nvarchar](max) NULL,
	[var5] [nvarchar](max) NULL,
	[Jobfunction] [nvarchar](max) NULL,
	[Organisation] [nvarchar](max) NULL
) ON [PRIMARY]

GO

USE [ariadne_international]
GO

/****** Object:  Table [dbo].[projects]    Script Date: 04/08/2021 12:26:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[projects](
	[organizerId] [uniqueidentifier] NULL,
	[projectId] [uniqueidentifier] NULL,
	[projectName] [nvarchar](max) NULL,
	[projectDescription] [nvarchar](999) NULL,
	[projectType] [int] NULL,
	[created] [datetime] NULL,
	[locktype] [nvarchar](max) NULL,
	[max_item_n] [int] NULL,
	[itemratedefenition1] [nvarchar](max) NULL,
	[itemratedefenition2] [nvarchar](max) NULL,
	[itemratedefenition3] [nvarchar](max) NULL,
	[itemratedefenition4] [nvarchar](max) NULL,
	[itemratedefenition5] [nvarchar](max) NULL
) ON [PRIMARY]

GO

USE [ariadne_international]
GO

/****** Object:  Table [dbo].[selections]    Script Date: 04/08/2021 12:26:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[selections](
	[projectId] [uniqueidentifier] NULL,
	[selectionId] [uniqueidentifier] NULL,
	[selection] [varchar](max) NULL,
	[analysesinfo] [int] NULL,
	[subtitle] [nvarchar](max) NULL,
	[clusterlabels] [nvarchar](max) NULL,
	[dimensionlabels] [nvarchar](max) NULL,
	[date] [datetime] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [ariadne_international]
GO

/****** Object:  Table [dbo].[usage]    Script Date: 04/08/2021 12:26:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[usage](
	[visitid] [uniqueidentifier] NULL,
	[opendate] [datetime] NULL,
	[ip] [nvarchar](99) NULL,
	[username] [nvarchar](199) NULL,
	[organiser] [bit] NULL,
	[useronly] [bit] NULL,
	[project_name] [nvarchar](199) NULL,
	[username_name] [nvarchar](199) NULL,
	[organizer_name] [nvarchar](199) NULL,
	[pagevisited] [nvarchar](299) NULL
) ON [PRIMARY]

GO





