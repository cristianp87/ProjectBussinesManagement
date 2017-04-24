
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15/03/2017
-- Description:	Get Supplier By Id
-- =============================================
CREATE PROCEDURE spr_GetSupplier
	@IdSupplier as int
AS
BEGIN

	SET NOCOUNT ON;

	Select Spp.IdSupplier, Spp.NameSupplier, Ti.IdTypeIdentification, Ti.TypeIdentification, Spp.NoIdentification,
	Obj.IdObject, Obj.NameObject, Spp.CreationDate, St.IdStatus, St.DsEstado
	From Supplier Spp
	Inner Join TypeIdentification Ti On Ti.IdTypeIdentification = Spp.IdTypeIdentification
	Inner Join [Object] Obj On Obj.IdObject = Spp.IdObject
	Inner Join [Status] St On St.IdStatus = Spp.IdStatus
	Where Spp.IdSupplier = @IdSupplier

END
GO
