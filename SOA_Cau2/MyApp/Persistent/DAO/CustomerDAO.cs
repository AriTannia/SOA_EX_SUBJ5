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
    public class CustomerDAO : ICustomerDAO
    {
        private readonly AppDbContext _context;

        public CustomerDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetByIdAsync(int customerId)
        {
            return await _context.Customers
                .Include(c => c.Orders) // nếu muốn load đơn hàng
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .ToListAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int customerId)
        {
            var existing = await _context.Customers.FindAsync(customerId);
            if (existing != null)
            {
                _context.Customers.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
