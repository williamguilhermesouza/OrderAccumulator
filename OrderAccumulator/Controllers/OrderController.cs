using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAccumulator.Models;
using OrderAccumulator.Repositories.Interfaces;

namespace OrderAccumulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderModel>>> GetAllOrders()
        {
            List<OrderModel> orders = await _orderRepository.GetAll();
            return orders;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<OrderModel>>> GetAllOrders()
        {
            List<OrderModel> orders = await _orderRepository.GetAll();
            return orders;
        }

        [HttpPost]
        public async Task<ActionResult<List<OrderModel>>> GetAllOrders([FromBody] OrderModel order)
        {
            List<OrderModel> orders = await _orderRepository.GetAll();
            return orders;
        }
    }
}
