
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 14/03/2017
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spr_CreateInvoice
	@CdInvoice varchar(50),
	@CreationDate datetime,
	@IdCustomer int,
	@IdStatus int,
	@IdObject int
AS
BEGIN
	SET NOCOUNT ON;

	Insert Into Invoice(CdInvoice,CreationDate, IdCustomer, IdStatus, IdObject)
	Values(@CdInvoice, @CreationDate, @IdCustomer, @IdStatus, @IdObject)

END
GO
