USE [TvWebAnimeProgressDB]
GO

/****** Object:  StoredProcedure [dbo].[GetWatchData]    Script Date: 10-08-2019 18:27:25 ******/
DROP PROCEDURE [dbo].[GetWatchData]
GO

/****** Object:  StoredProcedure [dbo].[GetWatchData]    Script Date: 10-08-2019 18:27:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetWatchData]
@uid nvarchar(10),
@id INT = 0
AS
BEGIN
	DECLARE @sqlQuery nvarchar(600);
	SET @sqlQuery = 'SELECT [id],
		[Name],
		[Genre],
		[Season],
		ISNULL([TotalEpisodes],0) as TotalEpisodes,
		ISNULL([EpisodesCompleted],0) as EpisodesCompleted,
		[Status],
		[CreationTime],
		[ModificationTime],
		ISNULL([reviews],0) as reviews,
		ISNULL([description],'''') as description,
		ISNULL([downloadLinks] ,'''') as downloadLinks
		 FROM [TvWebAnimeProgressDB].[dbo].[WatchData] where uid='''+@uid+'''';
		
	IF(@id<>0)
	BEGIN
	SET @sqlQuery = @sqlQuery + ' and id='+CONVERT(nvarchar,@id);
	END

	EXEC (@sqlQuery);
END
GO