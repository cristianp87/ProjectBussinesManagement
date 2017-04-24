
/****** Object:  StoredProcedure [dbo].[spr_CreateProduct]    Script Date: 15/03/2017 04:55:11 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15/03/2017
-- Description:	Update Product By Id
-- =============================================
CREATE PROCEDURE [dbo].[spr_DeleteSupplier]
	@IdSupplier as int

AS
BEGIN

	SET NOCOUNT ON;

	Delete From Supplier 
	Where IdSupplier = @IdSupplier

END
