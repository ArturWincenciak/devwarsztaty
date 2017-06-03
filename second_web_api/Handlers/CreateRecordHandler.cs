using System;
using System.Threading.Tasks;
using RawRabbit;
using third_devwarsztaty.Commands;
using third_devwarsztaty.Events;

namespace second_devwarsztaty.Handlers
{
    public class CreateRecordHandler : ICommandHandler<CreateRecord>
    {
        private readonly IBusClient busClient;

        public CreateRecordHandler(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        public async Task HandleAsync(CreateRecord command)
        {
            Console.WriteLine($"Received created record command: {command.Key}");

            if (string.IsNullOrWhiteSpace(command.Key))
            {
                await busClient.PublishAsync(new RecordNotCreated(
                    command.Key, 
                    "Record key can not be empty"));

                return;
            }

            await busClient.PublishAsync(new RecordCreated(command.Key));
        }
    }
}