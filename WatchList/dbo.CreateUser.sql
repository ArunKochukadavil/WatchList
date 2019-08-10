USE [TvWebAnimeProgressDB]
GO

/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 02-08-2019 18:45:51 ******/
DROP PROCEDURE [dbo].[CreateUser]
GO

/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 02-08-2019 18:45:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateUser]
@uid nvarchar(10),
@pass nvarchar(10)
AS
BEGIN
	DECLARE @LastChangeDate AS DATETIME;
	SET @LastChangeDate = CURRENT_TIMESTAMP;
	IF(ISNULL(@uid,'')<>'' ) and (ISNULL(@pass,'')<>'')
	BEGIN
		INSERT INTO [dbo].[UserAuthData] VALUES(@uid,@pass,@LastChangeDate, @LastChangeDate, @LastChangeDate,1)
	END
END
GO