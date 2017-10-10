
Declare @Ids as int

Insert Into ParameterConfiguration
Values('moduleInvoice', 'Modulo de Factura', Getdate(), null, 0, 1, Getdate() )

select @Ids = @@IDENTITY

Insert Into ParameterConfiguration
Values('PrefixInvoice', 'Prefijo Factura', Getdate(), 1, 1, 1, Getdate() )

select @Ids = @@IDENTITY

Insert Into ParameterConfigurationValue
values(@Ids , 'LCD',getdate())


Insert Into ParameterConfiguration
Values('StartNumberInvoice', 'Inicio de numeracion Facturas', Getdate(), 1, 1, 1, Getdate() )

select @Ids = @@IDENTITY

Insert Into ParameterConfigurationValue
values(@Ids , '50',getdate())