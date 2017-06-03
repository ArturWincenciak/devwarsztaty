using System;
using System.Threading.Tasks;
using third_devwarsztaty.Events;

namespace first_devwarsztaty.Handlers
{
    public class RecordNotCreatedHandler : IEventHandler<RecordNotCreated>
    {
        public async Task HandleAsync(RecordNotCreated @event)
        {
            Console.WriteLine($"Record: {@event.Key} was not created with reason: {@event.Reason}");
            await Task.CompletedTask;
        }
    }
}