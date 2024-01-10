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
        public async Task<ActionResult<OrderModel>> GetOrderById(int id)
        {
            OrderModel order = await _orderRepository.Get(id);
            return order;
        }

        [HttpPost]
        public async Task<ActionResult<OrderModel>> CreateOrder([FromBody] OrderModel order)
        {
            OrderModel result = await _orderRepository.Create(order);
            return order;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderModel>> UpdateOrder([FromBody] OrderModel order, int id)
        {
            OrderModel result = await _orderRepository.Update(order, id);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOrder(int id)
        {
            bool result = await _orderRepository.Delete(id);
            return result;
        }
    }
}
