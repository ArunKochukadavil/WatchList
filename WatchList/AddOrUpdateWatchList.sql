USE [TvWebAnimeProgressDB]
GO

DROP PROCEDURE [dbo].[AddOrUpdateWatchList]
GO

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


