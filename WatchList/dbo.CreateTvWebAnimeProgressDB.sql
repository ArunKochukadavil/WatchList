USE [master]
GO
/****** Object:  Database [TvWebAnimeProgressDB]    Script Date: 02-08-2019 17:39:22 ******/
CREATE DATABASE [TvWebAnimeProgressDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TvWebAnimeProgressDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TvWebAnimeProgressDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TvWebAnimeProgressDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TvWebAnimeProgressDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TvWebAnimeProgressDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET  MULTI_USER 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TvWebAnimeProgressDB]
GO
/****** Object:  Table [dbo].[UserAuthData]    Script Date: 02-08-2019 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAuthData](
	[uid] [nvarchar](10) NOT NULL,
	[password] [nvarchar](10) NOT NULL,
	[creationtime] [datetime] NOT NULL,
	[modifiedtime] [datetime] NOT NULL,
	[lastLoginTime] [datetime] NOT NULL,
	[isLoggedIn] [int] NULL,
 CONSTRAINT [PK_UserAuthData] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WatchData]    Script Date: 02-08-2019 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WatchData](
	[uid] [nvarchar](10) NOT NULL,
	[Name] [text] NOT NULL,
	[Genre] [varchar](10) NOT NULL,
	[Season] [tinyint] NOT NULL,
	[TotalEpisodes] [int] NULL,
	[EpisodesCompleted] [int] NULL,
	[Status] [varchar](10) NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[ModificationTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[WatchData]  WITH CHECK ADD FOREIGN KEY([uid])
REFERENCES [dbo].[UserAuthData] ([uid])
GO
ALTER TABLE [dbo].[WatchData]  WITH CHECK ADD FOREIGN KEY([uid])
REFERENCES [dbo].[UserAuthData] ([uid])
GO
ALTER TABLE [dbo].[WatchData]  WITH CHECK ADD FOREIGN KEY([uid])
REFERENCES [dbo].[UserAuthData] ([uid])
GO
/****** Object:  StoredProcedure [dbo].[AddOrUpdateWatchList]    Script Date: 02-08-2019 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddOrUpdateWatchList]
@uid varchar(4),
@name text,
@genre VARCHAR(10),
@season TINYINT,
@totalEpisodes INT,
@episodesCompleted INT,
@status VARCHAR(10)
AS
BEGIN
	DECLARE @LastChangeDate AS DATETIME;
	SET @LastChangeDate = CURRENT_TIMESTAMP;
	IF(ISNULL(@uid,'')<>'')
		BEGIN
			INSERT INTO [dbo].[WatchData] VALUES(@uid,@name,@genre,@season,@totalEpisodes,@episodesCompleted,@status,@LastChangeDate,@LastChangeDate)
		END
	ELSE
		BEGIN
		IF exists(Select 1 From [dbo].[WatchData] where uid=@uid)
			BEGIN
				UPDATE [dbo].[WatchData] SET Name=@name, Genre=@genre, Season=@season, TotalEpisodes=@totalEpisodes, EpisodesCompleted=@episodesCompleted, Status=@status, ModificationTime=@LastChangeDate where uid=@uid
			END
	END
END
GO
USE [master]
GO
ALTER DATABASE [TvWebAnimeProgressDB] SET  READ_WRITE 
GO
