USE [TvWebAnimeProgressDB]
GO

ALTER TABLE [dbo].[WatchData] DROP CONSTRAINT [FK__WatchData__uid__60A75C0F]
GO

ALTER TABLE [dbo].[WatchData] DROP CONSTRAINT [FK__WatchData__uid__5FB337D6]
GO

ALTER TABLE [dbo].[WatchData] DROP CONSTRAINT [FK__WatchData__uid__5EBF139D]
GO

/****** Object:  Table [dbo].[WatchData]    Script Date: 02-08-2019 17:35:14 ******/
DROP TABLE [dbo].[WatchData]
GO

/****** Object:  Table [dbo].[WatchData]    Script Date: 02-08-2019 17:35:14 ******/
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


