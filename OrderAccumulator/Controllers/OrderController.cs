using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAccumulator.Models;

namespace OrderAccumulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<OrderModel>> GetAllOrders()
        {
            return Ok();
        }
    }
}
