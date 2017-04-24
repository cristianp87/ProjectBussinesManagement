
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15/03/2017
-- Description:	Update Product by Id
-- =============================================
CREATE PROCEDURE spr_UpdateProduct
	@IdProduct as Int,
	@NameProduct as int,
	@IdUnit as int,
	@Price as Numeric(18,4),
	@IdSupplier as int,
	@PriceSupplier as Numeric(18,4),
	@IdObject as Int,
	@IdStatus as Int
AS
BEGIN

	SET NOCOUNT ON;

	Update Product Set NameProduct = @NameProduct,  IdUnit = @IdUnit, Price = @Price, IdSupplier = @IdSupplier, 
	PriceSupplier = @PriceSupplier, IdObject = @IdObject, IdStatus = @IdStatus
	Where IdProduct = @IdProduct
	 

END
GO
