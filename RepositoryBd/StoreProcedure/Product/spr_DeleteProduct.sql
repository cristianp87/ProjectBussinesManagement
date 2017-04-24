
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 15/03/2017
-- Description:	Delete Product by Id
-- =============================================
CREATE PROCEDURE spr_DeleteProduct
	@IdProduct as Int
AS
BEGIN

	SET NOCOUNT ON;

	Delete From Product 
	Where IdProduct = @IdProduct
	 

END
GO
