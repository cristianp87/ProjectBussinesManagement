
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 11-12-2017
-- Description:	Create Taxe XP Product
-- =============================================
CREATE PROCEDURE spr_CreateTaxeXProduct
	@IdProduct as int,
	@IdTaxe as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Insert Into TaxesXProduct(IdTax, IdProduct)
	Values(@IdTaxe, @IdProduct)
END
GO
