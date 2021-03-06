
/****** Object:  StoredProcedure [dbo].[spr_GetUserByUser]    Script Date: 24/01/2018 15:07:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 09-01-2018	
-- Description:	Traer Usuario por usuario y password
-- =============================================
CREATE PROCEDURE [dbo].[spr_GetUserByUser]
	@User as varchar(100)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT u.IdUser, u.NoIdentification, u.FName, u.SName, u.FLastName, u.SLastName, 
	u.Usuario, u.[Password] as PasswordHash, r.NameRole, Ob.IdObject, St.IdStatus, u.Email
	From [User] u
	Inner Join UserRole ur On ur.IdUser = u.IdUser
	Inner Join [Role] r On ur.IdRole = r.IdRole
	Inner Join [Object] Ob On Ob.IdObject = u.IdObject
	Inner Join [Status] St On St.IdStatus = u.IdStatus And St.IdObject = Ob.IdObjecT
	Where U.Usuario = @User 
END
