namespace third_devwarsztaty.Events
{
    public class RecordNotCreated
    {
        public string Key { get; }
        public string Reason { get; }

        protected RecordNotCreated()
        {

        }

        public RecordNotCreated(string key, string reason)
        {
            Key = key;
            Reason = reason;
        }

    }
}