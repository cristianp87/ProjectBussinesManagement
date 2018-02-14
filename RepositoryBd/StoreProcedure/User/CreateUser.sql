
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15-01-2018
-- Description:	Insertar un usuario 
-- =============================================
CREATE PROCEDURE spr_CreateUser
	@IdTypeIdentification as int,
	@NoIdentification as varchar(50),
	@FName as varchar(50),
	@SName as varchar(50),
	@FLastName as varchar(50),
	@SLastName as varchar(50) = null,
	@IdObject as int,
	@BirthDate as DateTime,
	@User as varchar(20),
	@Password as varchar(MAX),
	@IdStatus as varchar(10),
	@IdRole as int
	
AS
BEGIN

	SET NOCOUNT ON;

	Insert Into [User](IdTypeIdentification, NoIdentification, FName, SName, FLastName, SLastName, IdObject, FechaNacimiento, Usuario, [Password], IdStatus, CreationDate, ModificationDate)
	values(@IdTypeIdentification, @NoIdentification, @FName, @SName, @FLastName, @SLastName, @IdObject, @BirthDate, @User, @Password, @IdStatus, GETDATE(), GETDATE())

	exec spr_CreateRoleForUser @@Identity, @IdRole
END
GO
