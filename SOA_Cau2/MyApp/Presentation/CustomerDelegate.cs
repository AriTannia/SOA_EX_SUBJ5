using Business;
using Persistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class CustomerDelegate
    {
        private readonly CustomerObject _customerObject;

        public CustomerDelegate(CustomerObject customerObject)
        {
            _customerObject = customerObject;
        }

        // === CÁC HÀM LIÊN QUAN ĐẾN CUSTOMER ===
        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _customerObject.GetCustomerAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerObject.GetAllCustomersAsync();
        }

        public async Task CreateCustomerAsync(string name, string email, string phone)
        {
            await _customerObject.CreateCustomerAsync(name, email, phone);
        }

        public async Task UpdateCustomerAsync(int id, string name, string email, string phone)
        {
            await _customerObject.UpdateCustomerAsync(id, name, email, phone);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerObject.DeleteCustomerAsync(id);
        }

        // === CÁC HÀM LIÊN QUAN ĐẾN ORDER ===
        public async Task<Order> GetOrderAsync(int id)
        {
            return await _customerObject.GetOrderAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _customerObject.GetAllOrdersAsync();
        }

        public async Task CreateOrderAsync(int customerId, decimal totalAmount)
        {
            await _customerObject.CreateOrderAsync(customerId, totalAmount);
        }

        public async Task UpdateOrderAsync(int id, decimal totalAmount)
        {
            await _customerObject.UpdateOrderAsync(id, totalAmount);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _customerObject.DeleteOrderAsync(id);
        }
    }
}
