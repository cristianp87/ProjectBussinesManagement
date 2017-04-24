
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	Update InventoryItem
-- =============================================
CREATE PROCEDURE spr_UpdateInventoryItem
	@IdInventoryItem int,
	@IdInventory int,
	@IdStatus int,
	@IdObject int
AS
BEGIN
	SET NOCOUNT ON;

	Update InventoryItem Set  IdInventory = @IdInventory,  
	IdStatus = @IdStatus, IdObject = @IdObject
	Where IdInventoryItem = @IdInventoryItem

END
GO
