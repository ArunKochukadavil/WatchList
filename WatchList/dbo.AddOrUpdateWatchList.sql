USE [TvWebAnimeProgressDB]
GO

/****** Object:  StoredProcedure [dbo].[AddOrUpdateWatchList]    Script Date: 15-08-2019 20:07:17 ******/
DROP PROCEDURE [dbo].[AddOrUpdateWatchList]
GO

/****** Object:  StoredProcedure [dbo].[AddOrUpdateWatchList]    Script Date: 15-08-2019 20:07:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddOrUpdateWatchList]
@id int,
@uid nvarchar(10),
@name text,
@genre VARCHAR(10),
@season TINYINT,
@totalEpisodes INT,
@episodesCompleted INT,
@status VARCHAR(10),
@reviews tinyint = 0,
@description text = '',
@downloadLinks text = ''
AS
BEGIN
	DECLARE @LastChangeDate AS DATETIME;
	SET @LastChangeDate = CURRENT_TIMESTAMP;
	IF(ISNULL(@id,0)=-1) and (ISNULL(@uid,'')<>'')
		BEGIN
			INSERT INTO [dbo].[WatchData] VALUES(@uid,@name,@genre,@season,@totalEpisodes,@episodesCompleted,@status,@LastChangeDate,@LastChangeDate,@reviews,@description,@downloadLinks)
		END
	ELSE
		BEGIN
		IF exists(Select 1 From [dbo].[WatchData] where id=@id)
			BEGIN
				UPDATE [dbo].[WatchData] SET Name=@name, Genre=@genre, Season=@season, TotalEpisodes=@totalEpisodes, EpisodesCompleted=@episodesCompleted, Status=@status, ModificationTime=@LastChangeDate, reviews=@reviews, description=@description, downloadLinks=@downloadLinks where id=@id
			END
	END
END
GO


