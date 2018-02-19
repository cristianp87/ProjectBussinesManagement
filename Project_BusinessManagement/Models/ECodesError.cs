using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.io;

namespace Project_BusinessManagement.Models
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
    }
}