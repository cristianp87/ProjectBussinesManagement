SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cristian Pachon
-- Create date: 12/03/2017
-- Description:	Get List Customer
-- =============================================
CREATE PROCEDURE [dbo].[spr_GetListAllCustomer] 

AS
BEGIN

	SET NOCOUNT ON;

    Select Ct.IdCustomer, Ti.IdTypeIdentification, Ti.TypeIdentification, Ct.NoIdentification, Ct.NameCustomer, Ct.LastNameCustomer, Ct.CreationDate, 
	St.IdStatus, St.DsEstado, Ob.IdObject, Ob.NameObject
	From Customer Ct
	Inner Join TypeIdentification Ti On Ti.IdTypeIdentification = Ct.IdTypeIdentification
	Inner Join [Status] St On St.IdStatus = Ct.IdStatus
	inner Join [Object] Ob On Ob.IdObject = Ct.IdObject
END