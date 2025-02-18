using Microsoft.EntityFrameworkCore;
using Persistent.Data;
using Persistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistent.DAO
{
    public class OrderDAO : IOrderDAO
    {
        private readonly AppDbContext _context;

        public OrderDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId)
        {
            var existing = await _context.Orders.FindAsync(orderId);
            if (existing != null)
            {
                _context.Orders.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
