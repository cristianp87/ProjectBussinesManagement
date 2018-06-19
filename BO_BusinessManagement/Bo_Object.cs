namespace BO_BusinessManagement
{
    public class BoObject : BoException
    {
        public  int LIdObject { get; set; }

        public  string LNameObject { get; set; }

        public  bool LActive { get; set; }
    }
}
