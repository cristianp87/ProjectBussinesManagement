
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15/03/2017
-- Description:	Get Product By Id
-- =============================================
CREATE PROCEDURE spr_GetProduct
	@IdProduct as int
AS
BEGIN

	SET NOCOUNT ON;

	Select Pr.IdProduct, Pr.NameProduct, Pr.CreationDate, Un.IdUnit, Pr.Price, Sup.IdSupplier, Pr.PriceSupplier,
	Obj.IdObject, Obj.NameObject, St.IdStatus, St.DsEstado 
	From Product Pr
	Inner Join Unit Un On Un.IdUnit = Pr.IdUnit
	Inner Join Supplier Sup On Sup.IdSupplier = Pr.IdSupplier
	Inner Join [Object] Obj On Obj.IdObject = Pr.IdObject 
	Inner Join [Status] St On St.IdStatus = Pr.IdStatus

END
GO
