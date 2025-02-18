using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistent.Data;
using Persistent.DAO;
using Business;
using Presentation;

class Program
{
    static async Task Main(string[] args)
    {
        // Load cấu hình từ appsettings.json
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Đăng ký DbContext với SQL Server từ appsettings.json
                string connectionString = context.Configuration.GetConnectionString("MyApp");
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

                // Đăng ký Repository
                services.AddScoped<ICustomerDAO, CustomerDAO>();
                services.AddScoped<IOrderDAO, OrderDAO>();

                // Đăng ký Business Layer
                services.AddScoped<CustomerObject>();

                // Đăng ký Presentation Layer
                services.AddScoped<CustomerDelegate>();
                services.AddScoped<CustomerScreen>();
            })
            .Build();

        // Resolve CustomerScreen từ DI container
        using var scope = builder.Services.CreateScope();
        var customerScreen = scope.ServiceProvider.GetRequiredService<CustomerScreen>();

        // Chạy chương trình
        await customerScreen.ShowMenuAsync();
    }
}
