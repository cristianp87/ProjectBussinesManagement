
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	Get List Items by IdInvoice
-- =============================================
CREATE PROCEDURE spr_GetListInvoiceItem
	@IdInvoice int
AS
BEGIN
	SET NOCOUNT ON;

	Select IdInvoiceItem, IdInvoice, IdProduct,CreationDate, IdStatus, IdObject 
	From InvoiceItem
	Where IdInvoice = @IdInvoice

END
GO
