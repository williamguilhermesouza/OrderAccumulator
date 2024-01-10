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
        public async Task<ActionResult<OrderModel?>> GetOrderById(int id)
        {
            OrderModel? order = await _orderRepository.Get(id);
            return order;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> CreateOrder([FromBody] OrderModel order)
        {
            // calling strings validation
            OrderValidator(order);

            decimal exposure = await _orderRepository.CalculateExposure(order);
            string? error = "Limite de exposição excedido";
            bool success = false;

            if (exposure <= 1000000)
            {
                OrderModel result = await _orderRepository.Create(order);
                error = null;
                success = true;
            } 
            else
            {
                exposure -= order.Price * order.Quantity;
            }
            return new ResponseDto()
            {
                Success = success,
                Exposure = exposure,
                Error = error
            };
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderModel>> UpdateOrder([FromBody] OrderModel order, int id)
        {
            // calling strings validation
            OrderValidator(order);

            OrderModel result = await _orderRepository.Update(order, id);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOrder(int id)
        {
            bool result = await _orderRepository.Delete(id);
            return result;
        }

        private void OrderValidator(OrderModel order)
        {
            // order string validation
            // improve validation with expected response format
            List<string> stockNames = new List<string> { "PETR4", "VALE3", "VIIA4" }; // if there is a new stock just add the name

            if (!stockNames.Contains(order.Name))
            {
                throw new Exception("Ativo inválido.");
            }

            // checking sell and buy string
            if ((order.Side != "C") && (order.Side != "V"))
            {
                throw new Exception("Lado inválido.");
            }
        }
    }
}
