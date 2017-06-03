using System;
using System.Threading.Tasks;
using third_devwarsztaty.Events;

namespace first_devwarsztaty.Handlers
{
    public class RecordCreatedHandler : IEventHandler<RecordCreated>
    {
        public async Task HandleAsync(RecordCreated @event)
        {
            Console.WriteLine($"Record: {@event.Key} created");
            await Task.CompletedTask;
        }
    }
}