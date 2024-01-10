using OrderAccumulator.Models;

namespace OrderAccumulator.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> GetAll();
        Task<OrderModel?> Get(int id);
        Task<OrderModel> Create(OrderModel model);
        Task<OrderModel> Update(OrderModel model, int id);
        Task<bool> Delete(int id);
        Task<decimal> CalculateExposure(OrderModel order);
    }
}
