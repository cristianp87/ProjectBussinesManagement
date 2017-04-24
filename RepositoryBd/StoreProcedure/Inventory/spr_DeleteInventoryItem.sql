
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	Delete Item
-- =============================================
CREATE PROCEDURE spr_DeleteInventoryItem
	@IdInventoryItem int
AS
BEGIN
	SET NOCOUNT ON;

	Delete From InventoryItem 
	Where IdInventoryItem = @IdInventoryItem

END
GO
