using Microsoft.AspNetCore.Mvc;

namespace first_devwarsztaty.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
            => Content("Hello from DevWarsztaty API");
    }
}