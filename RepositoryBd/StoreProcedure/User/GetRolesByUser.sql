
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 18-01-2018
-- Description:	traer los roles por usuario
-- =============================================
CREATE PROCEDURE spr_GetRolesByUser
	@IdUser as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ur.IdUser, ur.IdRole, r.NameRole
	From UserRole ur
	Inner join [Role] r on r.IdRole = ur.IdRole
	Where IdUser =  @IdUser
END
GO
