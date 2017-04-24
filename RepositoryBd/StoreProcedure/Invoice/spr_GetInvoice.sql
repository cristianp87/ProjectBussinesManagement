
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	Get Invoice by Id
-- =============================================
CREATE PROCEDURE spr_GetInvoice
	@IdInvoice int
AS
BEGIN
	SET NOCOUNT ON;

	Select I.IdInvoice, I.CdInvoice, I.CreationDate, Ct.IdCustomer, Ct.NameCustomer + Ct.LastNameCustomer, I.IdStatus, I.IdObject 
	From Invoice I
	Inner Join Customer Ct On Ct.IdCustomer = I.IdCustomer
	Where IdInvoice = @IdInvoice

END
GO
