namespace BO_BusinessManagement.Enums
{
    public static class BoErrors
    {
        public const string MsgErrorGetSql = "Hubo un problema en la consulta, contacte al administrador.";
        public const string MsgMsgError = " Message: ";
        public const string MsgCommitException = "Commit Exception Type: ";
        public const string MsgRollbackException = " Rollback Exception Type: ";
        public const string MsgEmptyProductWithcode = "No hay mas del producto con el codigo {code} en el inventario";
        public const string ReplaceInString1 = "{code}";
        public const string MsgRollbackInvoice = "No se ingreso la factura al sistema, contacte con el administrador";
        public const string MsgRollbackOrder = "No se pudo ingresar la orden.";
        public const string MsgErrorFacade = "La fachada invocada es invalida";
    }
}
