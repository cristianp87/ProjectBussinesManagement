
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Camilo Pachon Castañeda
-- Create date: 27-12-2017
-- Description:	Eliminar impuesto
-- =============================================
CREATE PROCEDURE spr_DeleteTaxeXProduct
	@IdTaxe as int,
	@IdProduct as int
AS
BEGIN

	SET NOCOUNT ON;
	Delete From TaxesXProduct
	Where IdTax = @IdTaxe And IdProduct = @IdProduct
END
GO
