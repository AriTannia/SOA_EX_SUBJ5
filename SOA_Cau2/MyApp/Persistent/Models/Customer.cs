using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistent.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Mối quan hệ 1-n: Một khách hàng có thể có nhiều đơn hàng
        public ICollection<Order> Orders { get; set; }
    }
}
