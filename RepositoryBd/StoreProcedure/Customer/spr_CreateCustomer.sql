
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 13/03/2017
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spr_CreateCustomer
	@IdTypeIdentification int,
	@NoIdentification varchar(20),
	@NameCustomer varchar(100),
	@LastNameCustomer varchar(100),
	@CreationDate datetime,
	@IdStatus int,
	@IdObject int
AS
BEGIN
	
	SET NOCOUNT ON;

	Insert Into Customer(IdTypeIdentification, NoIdentification, NameCustomer, LastNameCustomer, CreationDate, IdStatus, IdObject)
	Values(@IdTypeIdentification, @NoIdentification, @NameCustomer, @LastNameCustomer, @CreationDate, @IdStatus, @IdObject)

END
GO
