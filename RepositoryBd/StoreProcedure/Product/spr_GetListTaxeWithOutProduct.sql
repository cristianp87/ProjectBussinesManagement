
/****** Object:  StoredProcedure [dbo].[spr_GetListTaxes]    Script Date: 11/12/2017 17:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 11-12-2017
-- Description:	trae todos los impuestos que estan disponibles para el producto.
-- =============================================
CREATE PROCEDURE [dbo].[spr_GetListTaxesWithOutProduct]

	@IdProduct AS int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

	SELECT distinct Tax.IdTax, Tax.NameTax, Tax.ValueTax, Tax.IsPercent, Tax.CreationDate, Ob.IdObject, Ob.NameObject, St.IdStatus, St.NameStatus
	FROM Taxes Tax
	Inner Join [Object] Ob On Ob.IdObject = Tax.IdObject
	Inner Join [Status] St On St.IdStatus = Tax.IdStatus AND St.IdObject = Ob.IdObject
	WHERE Tax.IdTax not in(SELECT distinct T.IdTax
	FROM Taxes T
	Inner Join TaxesXProduct Tp on Tp.IdTax = T.IdTax
	Inner join Product Pr On Pr.IdProduct = Tp.IdProduct
	WHERE Tp.IdProduct = @IdProduct)

END
