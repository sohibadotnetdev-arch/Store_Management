using Jose;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Store.Api.Configurations;
using Store.Api.Services.AuthServices;
using Store.Api.Services.CategoryService;
using Store.Api.Services.ProductServices;
using Store.Api.Services.UserServices;
using Store.Api.Repostories;
using Store.Api.Repostories.UsersRepositories;
using Store.Api.Dal;
using System.Text;
using Store.Api.Repostories.CustomerRepositories;
using Store.Api.Repostories.PaymentsRepositories;
using Store.Api.Services.CustomServices;
using Store.Api.Services.PaymentServices;
using Store.Api.Repostories.SalesRepositories;
using Store.Api.Repostories.SelesRepositories;
using Store.Api.Repostories.SaleItemsRepositories;
using Store.Api.Services.SaleServices;
using Store.Api.Services.SaleItemServices;


namespace Story.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database
            builder.Services.ConfigureDatabase(builder.Configuration);

            // DI 
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<CustomService, CustomService>(); 
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddScoped<ISaleItemService, SaleItemService>();


            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProductRepositoy, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPaymentPepository, PaymentPepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            builder.Services.AddScoped<ISaleItemsRepository, SaleItemsRepository>();




            // JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
