
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15/03/2017
-- Description:	Create Product
-- =============================================
CREATE PROCEDURE spr_CreateProduct
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

	Insert Into Product(NameProduct, CreationDate, IdUnit, Price, IdSupplier, PriceSupplier, IdObject, IdStatus)
	Values(@NameProduct, GETDATE(), @IdUnit, @Price, @IdSupplier, @PriceSupplier, @IdObject, @IdStatus) 

END
GO
