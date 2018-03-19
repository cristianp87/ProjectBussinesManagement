using System;

namespace BO_BusinessManagement
{
    public class BoConfigurationValue:BoException
    {
        public int LIdParameter { get; set; } = 0;

        public string LValueParameter { get; set; } = null;

        public DateTime LCreationDate { get; set; } = DateTime.Now;
    }
}
