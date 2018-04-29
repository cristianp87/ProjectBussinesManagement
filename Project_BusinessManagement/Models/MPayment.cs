using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models
{
    public class MPayment
    {
        public MObject LObject { get; set; }

        public MStatus LStatus { get; set; }

        public int LIdPayment { get; set; }

        public decimal LValuePayment { get; set; }

        public decimal LCreationDate { get; set; }

        public decimal LModificationDate { get; set; }

        public MOrder LOrder { get; set; }
    }
}