using API.Interface;
using API.Repository;
using API.Services;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddCors();

            services.AddScoped<ICompnayRepository, CompanyRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerLoanManagerRepository, CustomerLoanManagerRepository>();
            //services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
