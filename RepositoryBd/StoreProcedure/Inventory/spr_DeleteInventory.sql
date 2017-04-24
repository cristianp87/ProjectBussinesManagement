SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 13/03/2017
-- Description:	Delete Inventory
-- =============================================
CREATE PROCEDURE spr_DeleteInventory
	@IdInventory int

AS
BEGIN
	SET NOCOUNT ON;

	Delete From Inventory
	Where IdInventory = @IdInventory

END
GO