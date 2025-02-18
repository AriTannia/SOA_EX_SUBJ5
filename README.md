# 📌 MyApp

\
🚀 **Mô tả**: Đây là một ứng dụng kiến trúc nhiều tầng (**N-Tier Architecture**) sử dụng C# và Entity Framework Core.

---

## 📂 Cấu trúc dự án

```
MyApp
│── Business
│   ├── CustomerObject.cs
│
│── Persistent
│   ├── DAO
│   │   ├── CustomerDAO.cs
│   │   ├── ICustomerDAO.cs
│   │   ├── IOrderDAO.cs
│   │   ├── OrderDAO.cs
│   ├── Data
│   │   ├── AppDbContext.cs
│   ├── Models
│   │   ├── Customer.cs
│   │   ├── Order.cs
│
│── Presentation
│   ├── appsettings.json
│   ├── CustomerDelegate.cs
│   ├── CustomerScreen.cs
│   ├── Program.cs
```

---

## 🔍 Các tầng kiến trúc

### 🎨 Presentation Layer

📌 **Chức năng**: Giao diện người dùng, xử lý đầu vào & hiển thị dữ liệu.

- `CustomerScreen.cs` - Giao diện chính cho khách hàng.
- `CustomerDelegate.cs` - Cầu nối giữa Presentation và Business Layer.

### 🧠 Business Layer

📌 **Chức năng**: Xử lý logic nghiệp vụ.

- `CustomerObject.cs` - Lớp đại diện cho khách hàng và đơn hàng.

### 🗄️ Persistence Layer

📌 **Chức năng**: Tương tác với cơ sở dữ liệu.

- **DAO (Data Access Object)**:
  - `CustomerDAO.cs` - Truy xuất thông tin khách hàng.
  - `OrderDAO.cs` - Truy xuất thông tin đơn hàng.
  - `ICustomerDAO.cs`, `IOrderDAO.cs` - Interface cho DAO.
- **Data**:
  - `AppDbContext.cs` - Lớp context cho Entity Framework.
- **Models**:
  - `Customer.cs`, `Order.cs` - Các model của ứng dụng.

### 🗃️ Database Layer

📌 **Chức năng**: Lưu trữ và quản lý dữ liệu.

- **Database**: Định nghĩa trong `DuLieu.sql`

---

## ⚙️ Công nghệ sử dụng

- VS Studio 2022
- SQL Server
- .NET Core 9.0

---

## 🚀 Hướng dẫn chạy dự án

1. Clone repository:
   ```sh
   git clone https://github.com/your-repo/MyApp.git
   ```
2. Cấu hình `appsettings.json` để kết nối với SQL Server.
3. Chạy lệnh sau để cập nhật database:
   ```sh
   dotnet ef database update
   ```
4. Chạy ứng dụng:
   ```sh
   dotnet run
   ```

---

## 📜 Giấy phép

🔖 **MIT License** - Tự do sử dụng và sửa đổi.

📩 **Liên hệ**: Nếu có vấn đề, vui lòng liên hệ qua [ngophucnguyen1976@gmaill.com](mailto\:ngophucnguyen1976@gmaill.com)
