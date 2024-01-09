using Microsoft.EntityFrameworkCore;
using OrderAccumulator.Data;
using OrderAccumulator.Models;
using OrderAccumulator.Repositories.Interfaces;

namespace OrderAccumulator.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersDbContext _dbContext;
        public OrderRepository(OrdersDbContext ordersDbContext) { }
        public async Task<List<OrderModel>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }
        public async Task<OrderModel> Get(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<OrderModel> Create(OrderModel order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }
        public async Task<OrderModel> Update(OrderModel order, int id)
        {
            OrderModel orderModel = await Get(id);

            if (orderModel == null)
            {
                throw new Exception($"User for ID: {id} not found.");
            }

            orderModel.Name = order.Name;
            orderModel.Side = order.Side;
            orderModel.Quantity = order.Quantity;
            orderModel.Price = order.Price;

            _dbContext.Orders.Update(orderModel);
            await _dbContext.SaveChangesAsync();

            return orderModel;
        }
        public async Task<bool> Delete(int id)
        {
            OrderModel orderModel = await Get(id);

            if (orderModel == null)
            {
                throw new Exception($"User for ID: {id} not found.");
            }

            _dbContext.Orders.Remove(orderModel);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
