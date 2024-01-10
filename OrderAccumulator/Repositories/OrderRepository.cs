using Microsoft.EntityFrameworkCore;
using OrderAccumulator.Data;
using OrderAccumulator.Models;
using OrderAccumulator.Repositories.Interfaces;

namespace OrderAccumulator.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        // must create exposition function for all stocks and improve with cache
        private readonly OrdersDbContext _dbContext;
        public OrderRepository(OrdersDbContext ordersDbContext) 
        {
            _dbContext = ordersDbContext;
        }
        public async Task<List<OrderModel>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }
        public async Task<OrderModel?> Get(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<OrderModel> Create(OrderModel orderModel)
        {
            OrderModel order = orderModel;
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }
        public async Task<OrderModel> Update(OrderModel order, int id)
        {
            OrderModel? orderModel = await Get(id);

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

        public async Task<decimal> CalculateExposure(OrderModel order)
        {
            List<OrderModel> allOrders = await GetAll();

            var filterByStock = allOrders.Where(listOrder => listOrder.Name == order.Name);

            // exposure begins with the order exposure
            decimal exposure = 0;
            if (order.Side == "C") 
            {
                exposure = order.Quantity * order.Price; 
            }
            else
            {
                exposure = -(order.Quantity * order.Price);
            }

            foreach (var item in filterByStock)
            {
                if (item.Side == "C")
                {
                    exposure += (item.Quantity * item.Price);
                }
                else
                {
                    exposure -= (item.Quantity * item.Price);
                }
            }

            return exposure;

        }
    }
}
