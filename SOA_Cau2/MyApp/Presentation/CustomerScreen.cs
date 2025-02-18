using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class CustomerScreen
    {
        private readonly CustomerDelegate _customerDelegate;

        public CustomerScreen(CustomerDelegate customerDelegate)
        {
            _customerDelegate = customerDelegate;
        }

        public async Task ShowMenuAsync()
        {
            // Đặt mã hóa đầu ra của Console thành UTF-8 để hiển thị tiếng Việt và icon
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("📋 MENU KHÁCH HÀNG");
                Console.WriteLine("────────────────────────");
                Console.WriteLine("1. 👀 Xem danh sách khách hàng");
                Console.WriteLine("2. ➕ Thêm khách hàng mới");
                Console.WriteLine("3. 🔄 Cập nhật khách hàng");
                Console.WriteLine("4. ❌ Xóa khách hàng");
                Console.WriteLine("────────────────────────");
                Console.WriteLine("5. 📦 Xem danh sách đơn hàng");
                Console.WriteLine("6. ➕ Thêm đơn hàng mới");
                Console.WriteLine("7. 🔄 Cập nhật đơn hàng");
                Console.WriteLine("8. ❌ Xóa đơn hàng");
                Console.WriteLine("────────────────────────");
                Console.WriteLine("9. 🚪 Thoát");
                Console.Write("Chọn: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var customers = await _customerDelegate.GetAllCustomersAsync();
                            Console.WriteLine("\nDanh sách khách hàng:");
                            foreach (var customer in customers)
                                Console.WriteLine($"🔹 {customer.CustomerId}: {customer.Name} - {customer.Email} - {customer.Phone}");
                            break;
                        case "2":
                            Console.Write("Nhập tên: ");
                            string name = Console.ReadLine();
                            Console.Write("Nhập email: ");
                            string email = Console.ReadLine();
                            Console.Write("Nhập số điện thoại: ");
                            string phone = Console.ReadLine();
                            await _customerDelegate.CreateCustomerAsync(name, email, phone);
                            Console.WriteLine("✅ Thêm khách hàng thành công!");
                            break;
                        case "3":
                            Console.Write("Nhập ID khách hàng cần cập nhật: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Nhập tên mới: ");
                            name = Console.ReadLine();
                            Console.Write("Nhập email mới: ");
                            email = Console.ReadLine();
                            Console.Write("Nhập số điện thoại mới: ");
                            phone = Console.ReadLine();
                            await _customerDelegate.UpdateCustomerAsync(id, name, email, phone);
                            Console.WriteLine("✅ Cập nhật thành công!");
                            break;
                        case "4":
                            Console.Write("Nhập ID khách hàng cần xóa: ");
                            id = int.Parse(Console.ReadLine());
                            await _customerDelegate.DeleteCustomerAsync(id);
                            Console.WriteLine("✅ Xóa thành công!");
                            break;
                        case "5":
                            var orders = await _customerDelegate.GetAllOrdersAsync();
                            Console.WriteLine("\nDanh sách đơn hàng:");
                            foreach (var order in orders)
                                Console.WriteLine($"📦 Order {order.OrderId}: Khách hàng {order.CustomerId}, Ngày: {order.OrderDate}, Tổng tiền: {order.TotalAmount}");
                            break;
                        case "6":
                            Console.Write("Nhập ID khách hàng: ");
                            int customerId = int.Parse(Console.ReadLine());
                            Console.Write("Nhập tổng tiền: ");
                            decimal totalAmount = decimal.Parse(Console.ReadLine());
                            await _customerDelegate.CreateOrderAsync(customerId, totalAmount);
                            Console.WriteLine("✅ Thêm đơn hàng thành công!");
                            break;
                        case "7":
                            Console.Write("Nhập ID đơn hàng cần cập nhật: ");
                            id = int.Parse(Console.ReadLine());
                            Console.Write("Nhập tổng tiền mới: ");
                            totalAmount = decimal.Parse(Console.ReadLine());
                            await _customerDelegate.UpdateOrderAsync(id, totalAmount);
                            Console.WriteLine("✅ Cập nhật thành công!");
                            break;
                        case "8":
                            Console.Write("Nhập ID đơn hàng cần xóa: ");
                            id = int.Parse(Console.ReadLine());
                            await _customerDelegate.DeleteOrderAsync(id);
                            Console.WriteLine("✅ Xóa thành công!");
                            break;
                        case "9":
                            Console.WriteLine("🚪 Thoát chương trình...");
                            return;
                        default:
                            Console.WriteLine("⚠️ Lựa chọn không hợp lệ!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❗ Đã xảy ra lỗi: {ex.Message}");
                }

                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }
    }
}