
BEGIN TRY
BEGIN TRAN
declare @IdentityObject as int
declare @IdentityUser as int
declare @IdentityRole as int

Insert into [Object] values(	'INVEN',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto inventario',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'SUPP',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto Proveedor',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto proveedor',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'CUST',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto cliente',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto cliente',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'PRDT',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto producto',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto producto',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'INVITE',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto inventario item',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto inventario item',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'VOID',	@IdentityObject,'ANULADO',	'ANULADO para objeto inventario item',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'TAXE',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto impuesto',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto impuesto',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'ORDER',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto pedido',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto pedido',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'VOID',	@IdentityObject,'ANULADO',	'ANULADO para objeto pedido',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'INPRO',	@IdentityObject,'EN PROGRESO',	'Pedido en progreso',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'ORDITEM',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto item de pedido',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto item de pedido',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'VOID',	@IdentityObject,'ANULADO',	'ANULADO para objeto item de pédido',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'INVOI',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto factura',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto factura',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'VOID',	@IdentityObject,'ANULADO',	'ANULADO para objeto factura',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'INVOITEM',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto factura item',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto item de factura',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'VOID',	@IdentityObject,'ANULADO',	'ANULADO para objeto item de factura',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'PAYMEN',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject,'APROBADO',	'Estado Aprobado para el objeto pagos.',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'CANC',	@IdentityObject,'CANCELADO',	'Cancelado para objeto pagos.',	GETDATE(),	1,	GETDATE()	)

Insert into [Object] values(	'USER',	getdate(),	1	)
set @IdentityObject = @@IDENTITY
Insert into [Status] values(	'APPRO',	@IdentityObject, 'APROBADO',	'Estado Aprobado para el objeto Usuario',	GETDATE(),	1,	GETDATE()	)
Insert into [Status] values(	'VOID',	@IdentityObject,'ANULADO',	'ANULADO para objeto usuario',	GETDATE(),	1,	GETDATE()	)

Insert Into [User]
values(2, '516423',	'Admin', null, 'Negocio', null, 'admin@gestiondigital.net.co',	
'1990-12-08 00:00:00.000',	'admin', 'AC+0STy9bRX7RsHtwpWli8BWzwgphBePDZoPr+jnebC5tu7SthbvQd/z4316EFHIWw==',
'APPRO', @IdentityObject,GETDATE(), GETDATE())
set @IdentityUser = @@IDENTITY
Insert Into [Role](NameRole, flActive)
Values('Administrador', 1)
set @IdentityRole = @@Identity
Insert Into [UserRole](IdUser, IdRole)
Values(@IdentityUser, @IdentityRole)

COMMIT  TRAN;
END TRY
BEGIN CATCH
	PRINT 'ERROR NUMBER' + CAST(ERROR_NUMBER() AS VARCHAR(10))
	PRINT 'ERROR MESSAGE' + ERROR_MESSAGE()
	PRINT 'ERROR SEVERITY' + CAST(ERROR_SEVERITY() AS VARCHAR(10))
	PRINT 'ERROR STATE' + CAST(ERROR_STATE() AS VARCHAR(10))
	PRINT 'ERROR LINE' + CAST(ERROR_LINE() AS VARCHAR(10))
	PRINT 'ERROR PROC' + COALESCE(ERROR_PROCEDURE(), 'NOT WHITIN PROCEDURE')
	ROLLBACK TRAN;
END CATCH






