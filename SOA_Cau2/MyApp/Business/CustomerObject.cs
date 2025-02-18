using Persistent.DAO;
using Persistent.Models;

namespace Business
{
    public class CustomerObject
    {
        private readonly ICustomerDAO _customerRepo;
        private readonly IOrderDAO _orderRepo;

        public CustomerObject(ICustomerDAO customerRepo, IOrderDAO orderRepo)
        {
            _customerRepo = customerRepo;
            _orderRepo = orderRepo;
        }

        // === CÁC HÀM LIÊN QUAN ĐẾN CUSTOMERDAO ===
        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _customerRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepo.GetAllAsync();
        }

        public async Task CreateCustomerAsync(string name, string email, string phone)
        {
            var customer = new Customer
            {
                Name = name,
                Email = email,
                Phone = phone,
                Orders = new List<Order>() // Khách hàng mới chưa có đơn hàng
            };
            await _customerRepo.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, string name, string email, string phone)
        {
            var customer = await _customerRepo.GetByIdAsync(id);
            if (customer == null) throw new KeyNotFoundException("Khách hàng không tồn tại!");

            customer.Name = name;
            customer.Email = email;
            customer.Phone = phone;

            await _customerRepo.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepo.DeleteAsync(id);
        }


        // === CÁC HÀM LIÊN QUAN ĐẾN ORDERDAO ===
        public async Task<Order> GetOrderAsync(int id)
        {
            return await _orderRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepo.GetAllAsync();
        }

        public async Task CreateOrderAsync(int customerId, decimal totalAmount)
        {
            // Kiểm tra xem khách hàng có tồn tại không
            var customer = await _customerRepo.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new KeyNotFoundException("Khách hàng không tồn tại!");
            }

            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = totalAmount
            };
            await _orderRepo.AddAsync(order);
        }

        public async Task UpdateOrderAsync(int id, decimal totalAmount)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null) throw new KeyNotFoundException("Đơn hàng không tồn tại!");

            order.TotalAmount = totalAmount;
            await _orderRepo.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepo.DeleteAsync(id);
        }
    }
}
