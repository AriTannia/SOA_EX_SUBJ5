# 📌 MyApp

🚀 **Mô tả**: 
MyApp là một ứng dụng theo kiến trúc **N-Tier Architecture**, sử dụng **C#** và **Entity Framework Core**, giúp quản lý khách hàng và đơn hàng với giao diện dòng lệnh.

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
│
│── Data
│   ├── Database.sql
```

---

## 🔍 Kiến trúc tầng

### 🎨 Presentation Layer (Giao diện người dùng)
📌 **Chức năng**: Xử lý tương tác người dùng, hiển thị dữ liệu qua giao diện dòng lệnh.
- `CustomerScreen.cs` - Hiển thị menu, nhận và xử lý đầu vào.
- `CustomerDelegate.cs` - Cầu nối với Business Layer.
- `Program.cs` - Cấu hình Dependency Injection và chạy ứng dụng.

### 🧠 Business Layer (Xử lý nghiệp vụ)
📌 **Chức năng**: Chứa các logic xử lý dữ liệu.
- `CustomerObject.cs` - Xử lý nghiệp vụ liên quan đến khách hàng và đơn hàng.

### 🗄️ Persistence Layer (Truy xuất dữ liệu)
📌 **Chức năng**: Tương tác với cơ sở dữ liệu SQL Server.
- **DAO (Data Access Object)**:
  - `CustomerDAO.cs`, `OrderDAO.cs` - Thực hiện truy vấn dữ liệu.
  - `ICustomerDAO.cs`, `IOrderDAO.cs` - Interface định nghĩa các phương thức DAO.
- **Data**:
  - `AppDbContext.cs` - Context của Entity Framework Core.
- **Models**:
  - `Customer.cs`, `Order.cs` - Định nghĩa mô hình dữ liệu.

### 🗃️ Data Layer (Cơ sở dữ liệu)
📌 **Chức năng**: Lưu trữ dữ liệu bằng SQL Server.
- **Database.sql**: Chứa script khởi tạo database.
- **SQL Schema**:
   ```sql
   CREATE DATABASE SOAShopC2;
   GO
   
   USE SOAShopC2;
   GO
   
   CREATE TABLE Customers (
       CustomerId INT PRIMARY KEY IDENTITY(1,1),
       Name NVARCHAR(100) NOT NULL,
       Email NVARCHAR(100) NOT NULL,
       Phone NVARCHAR(20) NULL
   );
   
   CREATE TABLE Orders (
       OrderId INT PRIMARY KEY IDENTITY(1,1),
       CustomerId INT NOT NULL,
       OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
       TotalAmount DECIMAL(18, 2) NOT NULL,
       FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
   );
   GO
   ```

---

## ⚙️ Công nghệ sử dụng

- 🎯 **C#**, **.NET Core 9.0**
- 🛢 **SQL Server** (Entity Framework Core)
- 🖥 **Visual Studio 2022**

---

## 🚀 Hướng dẫn chạy dự án

1. Clone repository:
   ```sh
   git clone https://github.com/your-repo/MyApp.git
   ```
2. Cấu hình `appsettings.json` để kết nối SQL Server.
3. Chạy lệnh để cập nhật database:
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

📩 **Liên hệ**: Vui lòng liên hệ qua [ngophucnguyen1976@gmaill.com](mailto:ngophucnguyen1976@gmaill.com)
