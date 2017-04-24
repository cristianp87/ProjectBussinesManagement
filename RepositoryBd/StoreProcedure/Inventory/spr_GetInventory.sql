
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 13/03/2017
-- Description:	Get Inventory BY Id
-- =============================================
CREATE PROCEDURE spr_GetInventory
	@IdInventory as int
AS
BEGIN
	SET NOCOUNT ON;

	Select IdInventory, NameInventory, CreationDate, IdStatus, IdObject 
	From Inventory
	Where IdInventory = @IdInventory
END
GO
