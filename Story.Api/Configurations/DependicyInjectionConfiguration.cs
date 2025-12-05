
using Store.Api.Repostories;
using Store.Api.Repostories.UsersRepositories;
using Store.Api.Services;
using Store.Api.Services.AuthServices;
using Store.Api.Services.CategoryService;
using Store.Api.Services.ProductServices;
using Store.Api.Services.SaleServices;
using Store.Api.Services.UserServices;

namespace Store.Api.Configurations
{
    public  static class DependicyInjectionConfiguration
    {
        public static void ConfigureDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IProductRepositoy, ProductRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();




        }
    }
}
    