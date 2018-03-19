using System;

namespace BO_BusinessManagement
{
    public class BoStatus: BoException
    {
        public string LIdStatus { get; set; }

        public string LDsEstado { get; set; }

        public DateTime LCreationDate { get; set; }

        public bool LFlActive { get; set; }

        public string LNameStatus { get; set; }
    }
}
