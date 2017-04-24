
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spr_CreateInventoryItem
	@IdProduct int,
	@IdInventory int,
	@CreationDate datetime,
	@IdStatus int,
	@IdObject int
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into InventoryItem(IdProduct, IdInventory, CreationDate, IdStatus, IdObject)
	Values(@IdProduct, @IdInventory, @CreationDate, @IdStatus, @IdObject)

END
GO
