namespace BO_BusinessManagement
{
    public class BoException
    {
        public string LException { get; set; }

        public string LMessageDao { get; set; }

        public string LInnerException { get; set; } = null;
    }
}
