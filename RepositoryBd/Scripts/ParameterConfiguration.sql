
Begin Try
BEGIN TRAN
Declare @IdInvoice as int = 0
Declare @IdCusto as int = 0
Declare @IdSupp as int = 0
Declare @IdDash as int = 0
Declare @IdInventory as int = 0
Declare @IdApp as int = 0
Declare @IdInven as int = 0

declare @Ids as int = 0

Insert Into ParameterConfiguration Values(	'App',	'La raiz de todo el sistema',	GETDATE(),	null,	0,	1,	Getdate())
set @IdApp = @@IDENTITY
--Inventario
Insert Into ParameterConfiguration Values(	'App_Invent',	'Raiz de la aplicacion de inventario',	GETDATE(),	@IdApp,	0,	1,	Getdate())
set @IdInven = @@IDENTITY
	--Module Invoice
	Insert Into ParameterConfiguration Values(	'moduleInvoice',	'Modulo de Factura',	GETDATE(),	@IdInven,	0,	1,	Getdate()	)
	set @IdInvoice = @@IDENTITY
	Insert Into ParameterConfiguration
	Values('PrefixInvoice', 'Prefijo Factura', Getdate(), @IdInvoice, 1, 1, Getdate() )
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'LCD',getdate())
	Insert Into ParameterConfiguration
	Values('StartNumberInvoice', 'Inicio de numeracion Facturas', Getdate(), @IdInvoice, 1, 1, Getdate() )
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , '50',getdate())

	--module customer
	Insert Into ParameterConfiguration Values(	'moduleCustomer',	'Modulo de Cliente',	GETDATE(),	@IdInven,	0,	1,	Getdate())
	set @IdCusto = @@IDENTITY
	Insert Into ParameterConfiguration Values(	'create',	'Crear en el cliente',	GETDATE(),	@IdCusto,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Edit',	'Editar en el cliente',	GETDATE(),	@IdCusto,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Delete',	'Eliminar en el cliente',	GETDATE(),	@IdCusto,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())

	--module supplier
	Insert Into ParameterConfiguration Values(	'moduleSupplier',	'Modulo de proveedores',	GETDATE(),	@IdInven,	0,	1,	Getdate()	)
	set @IdSupp = @@IDENTITY
	Insert Into ParameterConfiguration Values(	'create',	'Crear en el cliente',	GETDATE(),	@IdSupp,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Edit',	'Editar en el cliente',	GETDATE(),	@IdSupp,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Delete',	'Eliminar en el cliente',	GETDATE(),	@IdSupp,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())

	--module DashBoard
	Insert Into ParameterConfiguration Values(	'moduleDashBoard',	'modulo del dashboard',	GETDATE(),	@IdInven,	0,	1,	Getdate()	)
	set @IdDash = @@IDENTITY
	Insert Into ParameterConfiguration Values(	'create',	'Crear en el dashboard',	GETDATE(),	@IdDash,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Edit',	'Editar en el dashboard',	GETDATE(),	@IdDash,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Delete',	'Eliminar en el dashboard',	GETDATE(),	@IdDash,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())

	--module Inventory
	Insert Into ParameterConfiguration Values(	'moduleInventory',	'modulo de inventario',	GETDATE(),	@IdInven,	0,	1,	Getdate()	)
	set @IdInventory = @@IDENTITY
	Insert Into ParameterConfiguration Values(	'create',	'Crear en el Inventario',	GETDATE(),	@IdInventory,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Edit',	'Editar en el Inventario',	GETDATE(),	@IdInventory,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Delete',	'Eliminar en el Inventario',	GETDATE(),	@IdInventory,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())

	--module RealizeOrder
	Insert Into ParameterConfiguration Values(	'moduleRealizeOrder',	'modulo realizar pedido',	GETDATE(),	@IdInven,	0,	1,	Getdate()	)

	--module Product
	Insert Into ParameterConfiguration Values(	'moduleProduct',	'modulo de producto',	GETDATE(),	@IdInven,	0,	1,	Getdate()	)
	set @IdInventory = @@IDENTITY
	Insert Into ParameterConfiguration Values(	'create',	'Crear en el producto',	GETDATE(),	@IdInventory,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Edit',	'Editar en el producto',	GETDATE(),	@IdInventory,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())
	Insert Into ParameterConfiguration Values(	'Delete',	'Eliminar en el producto',	GETDATE(),	@IdInventory,	1,	1,	Getdate())
	set @Ids = @@IDENTITY
	Insert Into ParameterConfigurationValue
	values(@Ids , 'True',getdate())

--Carrito De compras
Insert Into ParameterConfiguration Values(	'App_Carrito',	'Raiz de la aplicacion Carrito',	GETDATE(),	@IdApp,	0,	1,	Getdate())

COMMIT  TRAN;
End Try
Begin Catch
	PRINT 'ERROR NUMBER' + CAST(ERROR_NUMBER() AS VARCHAR(10))
	PRINT 'ERROR MESSAGE' + ERROR_MESSAGE()
	PRINT 'ERROR SEVERITY' + CAST(ERROR_SEVERITY() AS VARCHAR(10))
	PRINT 'ERROR STATE' + CAST(ERROR_STATE() AS VARCHAR(10))
	PRINT 'ERROR LINE' + CAST(ERROR_LINE() AS VARCHAR(10))
	PRINT 'ERROR PROC' + COALESCE(ERROR_PROCEDURE(), 'NOT WHITIN PROCEDURE')
	ROLLBACK TRAN;
End Catch