using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using third_devwarsztaty.Commands;

namespace first_devwarsztaty.Controllers
{
    [Route("[controller]")]
    public class RecordsController : Controller
    {
        private readonly IBusClient busClient;

        public RecordsController(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRecord command)
        {
            await busClient.PublishAsync(command);
            return Accepted();
        }
    }
}