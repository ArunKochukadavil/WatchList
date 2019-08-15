USE [TvWebAnimeProgressDB]
GO

/****** Object:  StoredProcedure [dbo].[UpdateLoginData]    Script Date: 15-08-2019 20:11:25 ******/
DROP PROCEDURE [dbo].[UpdateLoginData]
GO

/****** Object:  StoredProcedure [dbo].[UpdateLoginData]    Script Date: 15-08-2019 20:11:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdateLoginData]
@uid nvarchar(10),
@status int
AS
BEGIN
	DECLARE @LastChangeDate AS DATETIME;
	SET @LastChangeDate = CURRENT_TIMESTAMP;
	UPDATE [dbo].[UserAuthData] SET lastLoginTime=@LastChangeDate, isLoggedIn=@status;
END
GO