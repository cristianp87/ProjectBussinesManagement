
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 13/03/2017
-- Description:	This Update the customer
-- =============================================
CREATE PROCEDURE spr_UpdateCustomer 
	@IdTypeIdentification int,
	@NoIdentification varchar(20),
	@NameCustomer varchar(100),
	@LastNameCustomer varchar(100),
	@CreationDate datetime,
	@IdStatus int
AS
BEGIN
	SET NOCOUNT ON;

	Update Customer Set IdTypeIdentification = @IdTypeIdentification, NoIdentification = @NoIdentification,
	NameCustomer = @NameCustomer, LastNameCustomer = @LastNameCustomer, IdStatus = @IdStatus
END
GO
