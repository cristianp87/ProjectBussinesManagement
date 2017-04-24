
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 13/03/2017
-- Description:	Delete the customer
-- ==========================================
CREATE PROCEDURE spr_DeleteCustomer
	@IdCustomer int
AS
BEGIN
	SET NOCOUNT ON;

	Delete From Customer
	Where IdCustomer = @IdCustomer

END
GO
