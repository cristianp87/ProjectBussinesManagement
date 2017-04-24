
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 13/03/2017
-- Description:	Insert Inventory
-- =============================================
CREATE PROCEDURE spr_CreateInventory
	@NameInventory varchar(50),
	@CreationDate datetime,
	@IdStatus int,
	@IdObject int
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into Inventory(NameInventory, CreationDate, IdStatus, IdObject)
	values(@NameInventory, @CreationDate, @IdStatus, @IdObject)

END
GO
