using System;
using System.Threading.Tasks;
using first_devwarsztaty.Storages;
using third_devwarsztaty.Events;

namespace first_devwarsztaty.Handlers
{
    public class RecordCreatedHandler : IEventHandler<RecordCreated>
    {
        private readonly IStorage storage;

        public RecordCreatedHandler(IStorage storage)
        {
            this.storage = storage;
        }

        public async Task HandleAsync(RecordCreated @event)
        {
            Console.WriteLine($"Record: {@event.Key} was created");
            storage.Add(@event.Key);
            await Task.CompletedTask;
        }
    }
}