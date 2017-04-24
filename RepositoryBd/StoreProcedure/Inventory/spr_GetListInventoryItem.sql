
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	Get List Inventory Item
-- =============================================
CREATE PROCEDURE spr_GetListInventoryItem
	@IdInventory int
AS
BEGIN
	SET NOCOUNT ON;

	Select Ii.IdInventoryItem, Prd.IdProduct, Prd.NameProduct, Inv.IdInventory, Inv.NameInventory, 
	Ii.CreationDate, Ii.IdStatus, Ii.IdObject 
	From InventoryItem Ii
	Inner Join Inventory Inv On Inv.IdInventory = Ii.IdInventory
	Inner Join Product Prd On Prd.IdProduct = Ii.IdProduct
	Where Inv.IdInventory = @IdInventory
END
GO
