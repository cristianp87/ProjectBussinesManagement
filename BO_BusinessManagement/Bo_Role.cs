using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Role : Bo_Exception
    {
        public int LIdRole { get; set; }
        public string LNameRole { get; set; }
        public bool LFlActive { get; set; }
    }
}
