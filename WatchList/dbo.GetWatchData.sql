USE [TvWebAnimeProgressDB]
GO

/****** Object:  StoredProcedure [dbo].[GetWatchData]    Script Date: 02-08-2019 19:28:31 ******/
DROP PROCEDURE [dbo].[GetWatchData]
GO

/****** Object:  StoredProcedure [dbo].[GetWatchData]    Script Date: 02-08-2019 19:28:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetWatchData]
@uid nvarchar(10)
AS
BEGIN
	SELECT [id]
      ,[Name]
      ,[Genre]
      ,[Season]
      ,[TotalEpisodes]
      ,[EpisodesCompleted]
      ,[Status]
      ,[CreationTime]
      ,[ModificationTime]
  FROM [TvWebAnimeProgressDB].[dbo].[WatchData]
  where uid=@uid
END
GO


