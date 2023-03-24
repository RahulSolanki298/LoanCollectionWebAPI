using API.Dtos;
using API.Models;

namespace API.Interface
{
    public interface IAccountRepository
    {
        Task<List<AppUser>> GetList();

        Task<List<ApplicationCustomer>> GetCustomerList();
        Task<List<ApplicationEmployee>> GetEmployeeList();        
        Task<AppUser> GetFirstOrDefault(int id);
        Task<ResponsesContent> ToAddOrUpdate(UserRegistration applicationUser);
        Task<ResponsesContent> ToDelete(int id);
        Task<ApplicationUser> Login(LoginDTO login);
    }
}
