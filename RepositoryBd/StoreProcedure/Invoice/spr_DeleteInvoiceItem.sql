
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	Delete invoice Item by Id
-- =============================================
CREATE PROCEDURE spr_DeleteInvoiceItem
	@IdInvoiceItem int
AS
BEGIN

	SET NOCOUNT ON;

	Delete From InvoiceItem
	Where IdInvoiceItem = @IdInvoiceItem

END
GO
