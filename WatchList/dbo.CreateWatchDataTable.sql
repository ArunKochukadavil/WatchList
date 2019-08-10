USE [TvWebAnimeProgressDB]
GO

ALTER TABLE [dbo].[WatchData] DROP CONSTRAINT [FK__WatchData__uid__693CA210]
GO

/****** Object:  Table [dbo].[WatchData]    Script Date: 04-08-2019 01:00:34 ******/
DROP TABLE [dbo].[WatchData]
GO

/****** Object:  Table [dbo].[WatchData]    Script Date: 04-08-2019 01:00:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[WatchData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [nvarchar](10) NULL,
	[Name] [text] NOT NULL,
	[Genre] [varchar](10) NOT NULL,
	[Season] [tinyint] NOT NULL,
	[TotalEpisodes] [int] NULL,
	[EpisodesCompleted] [int] NULL,
	[Status] [varchar](10) NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[ModificationTime] [datetime] NOT NULL,
	[reviews] [tinyint] NULL,
	[description] [text] NULL,
	[downloadLinks] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[WatchData]  WITH CHECK ADD FOREIGN KEY([uid])
REFERENCES [dbo].[UserAuthData] ([uid])
GO