SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 13/03/2017
-- Description:	Get List Inventory
-- =============================================
CREATE PROCEDURE spr_UpdateInventory
	@IdInventory varchar(50),
	@NameInventory varchar(50),
	@IdStatus int,
	@IdObject int
AS
BEGIN
	SET NOCOUNT ON;

	Update Inventory set NameInventory = @NameInventory, IdStatus = @IdStatus, IdObject = @IdObject
	Where IdInventory = @IdInventory
END
GO