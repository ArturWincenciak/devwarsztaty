using System.Collections.Generic;

namespace first_devwarsztaty.Storages
{
    public class InMemoryDb : IStorage
    {
        private readonly List<string> keys = new List<string>();

        public void Add(string key)
            => keys.Add(key);

        public List<string> GetAll()
            => new List<string>(keys);
    }
}