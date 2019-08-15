USE [TvWebAnimeProgressDB]
GO

/****** Object:  Table [dbo].[UserAuthData]    Script Date: 15-08-2019 20:09:59 ******/
DROP TABLE [dbo].[UserAuthData]
GO

/****** Object:  Table [dbo].[UserAuthData]    Script Date: 15-08-2019 20:09:59 ******/
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