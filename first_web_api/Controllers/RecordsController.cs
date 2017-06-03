using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using third_devwarsztaty.Commands;

namespace first_devwarsztaty.Controllers
{
    [Route("[controller]")]
    public class RecordsController : Controller
    {
        public async Task<IActionResult> Post([FromBody] CreateRecord command)
        {
            return Accepted();
        }
    }
}