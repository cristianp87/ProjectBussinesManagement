
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	Create Invoice Item 
-- =============================================
CREATE PROCEDURE spr_CreateInvoiceItem
	@IdInvoice int,
	@IdProduct int,
	@CreationDate datetime,
	@IdStatus int,
	@IdObject int
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into InvoiceItem(IdInvoice, IdProduct, CreationDate, IdStatus, IdObject)
	Values(@IdInvoice, @IdProduct, @CreationDate, @IdStatus, @IdObject)

END
GO
