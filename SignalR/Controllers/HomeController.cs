using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Business;
using SignalR.Hubs;
using System.Runtime.CompilerServices;

namespace SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MyBusiness _myBusiness;
        private readonly IHubContext<MyHub> _myHubContext;

        public HomeController(MyBusiness myBusiness, IHubContext<MyHub> myHubContext)
        {
            _myBusiness = myBusiness;
            _myHubContext = myHubContext;
        }

        [HttpGet("index/{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }


        [HttpGet("salam/{messages}")]
        public async Task<IActionResult> Salam(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }


    }
}
