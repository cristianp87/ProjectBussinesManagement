
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	Update Invoice By Id
-- =============================================
CREATE PROCEDURE spr_UpdateInvoice
	@IdInvoice int,
	@CdInvoice varchar(50),
	@CreationDate datetime,
	@IdCustomer int,
	@IdStatus int
AS
BEGIN
	SET NOCOUNT ON;

	Update Invoice Set CdInvoice = @CdInvoice, IdCustomer = @IdCustomer, IdStatus = @IdStatus
	Where IdInvoice = @IdInvoice

END
GO
