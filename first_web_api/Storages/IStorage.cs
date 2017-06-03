using System.Collections.Generic;

namespace first_devwarsztaty.Storages
{
    public interface IStorage
    {
        void Add(string key);
        List<string> GetAll();
    }
}