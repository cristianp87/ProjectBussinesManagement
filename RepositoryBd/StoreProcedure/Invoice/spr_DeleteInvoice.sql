
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	Delete Invoice by id
-- =============================================
CREATE PROCEDURE spr_DeleteInvoice
	@IdInvoice int
AS
BEGIN
	SET NOCOUNT ON;

	Delete From Invoice
	Where IdInvoice = @IdInvoice

END
GO
