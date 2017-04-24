
/****** Object:  StoredProcedure [dbo].[spr_CreateInvoice]    Script Date: 15/03/2017 04:49:55 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15/03/2017
-- Description:	Create Supplier
-- =============================================
CREATE PROCEDURE [dbo].[spr_CreateSupplier]
	@NameSupplier as varchar(50),
	@IdTypeIdentification as int,
	@NoIdentification as varchar(20),
	@IdStatus as int,
	@IdObject as int
AS
BEGIN

	SET NOCOUNT ON;

	Insert Into Supplier(NameSupplier,IdTypeIdentification, NoIdentification, CreationDate, IdStatus, IdObject)
	Values(@NameSupplier, @IdTypeIdentification, @NoIdentification, GETDATE(), @IdStatus, @IdObject)

END
