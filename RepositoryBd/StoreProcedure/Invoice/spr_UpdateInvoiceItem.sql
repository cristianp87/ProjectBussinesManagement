
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description: Update Invoice Item By IdInvoice
-- =============================================
CREATE PROCEDURE spr_UpdateInvoiceItem

	@IdInvoiceItem int,
	@IdProduct int,
	@IdStatus int
AS
BEGIN
	SET NOCOUNT ON;

	Update InvoiceItem Set IdProduct = @IdProduct, IdStatus = @IdStatus 
	Where IdInvoice = @IdInvoiceItem

END
GO
