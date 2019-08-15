USE [TvWebAnimeProgressDB]
GO

/****** Object:  StoredProcedure [dbo].[GetAuthData]    Script Date: 15-08-2019 20:10:38 ******/
DROP PROCEDURE [dbo].[GetAuthData]
GO

/****** Object:  StoredProcedure [dbo].[GetAuthData]    Script Date: 15-08-2019 20:10:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAuthData]
@uid nvarchar(10),
@pass nvarchar(10)
AS
BEGIN
	SELECT 1 as IsAllowed FROM [dbo].[UserAuthData] WHERE uid=@uid and password=@pass
END

GO