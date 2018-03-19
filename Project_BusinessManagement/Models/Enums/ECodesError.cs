namespace Project_BusinessManagement.Models.Enums
{   
    public static class CodesError
    {
        public const string LMsgValidateDdl = "No es válido la selección";
        public const string LMsgValidateName = "El Nombre es requerido";
        public const string LMsgValidateLastName = "El Apellido es requerido";
        public const string LMsgValidateNoIdentification = "El Numero de Identificación es requerido";
        public const string LMsgValidateFormatDatetime = "Formato de fecha invalido";
        public const string LMsgValidateValueSupplier = "El valor del proveedor es requerido.";
        public const string LMsgValidateCodeProduct = "El Codigo es requerido";
        public const string LMsgErroDao= " ErrorDao! ";
        public const string LMsgError = " Error! ";
        public const string LMsgClientDontExists = "El Cliente no existe en la base de datos";
        public const string LMsgProductDontExists = "El Producto no existe en la base de datos";
    }
}