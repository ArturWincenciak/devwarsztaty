using System.Collections.Generic;
using System.Threading.Tasks;
using first_devwarsztaty.Storages;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using third_devwarsztaty.Commands;

namespace first_devwarsztaty.Controllers
{
    [Route("[controller]")]
    public class RecordsController : Controller
    {
        private readonly IBusClient busClient;
        private IStorage storage;

        public RecordsController(IBusClient busClient, IStorage storage)
        {
            this.busClient = busClient;
            this.storage = storage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<string> data = storage.GetAll();
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRecord command)
        {
            await busClient.PublishAsync(command);
            return Accepted();
        }
    }
}