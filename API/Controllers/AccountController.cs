using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;
        //private readonly ITokenService _tokenService;

        public AccountController(IAccountRepository accountRepo)
        //,ITokenService tokenService)
        {
            _accountRepo = accountRepo;
            //_tokenService = tokenService;
        }

        [HttpGet("GetUsers")]
        public async Task<List<ApplicationUser>> GetAllUser()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            var result = await _accountRepo.GetList();
            var activateUsers = result.Where(x => x.IsActive == true);
            foreach (var item in activateUsers)
            {
                users.Add(new ApplicationUser()
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    BranchId = item.BranchId,
                    CreatedById = item.CreatedById,
                    CreatedDate = item.CreatedDate,
                    UpdatedById = item.UpdatedById,
                    UpdatedDate = item.UpdatedDate,
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    LastName = item.LastName,
                    DateOfBirth = item.DateOfBirth,
                    EmailId = item.EmailId,
                    MobileNo = item.MobileNo,
                    WhatsAppNo = item.WhatsAppNo,
                    //RoleName = item.RoleName,
                    Gender = item.Gender,
                    IsActive = item.IsActive,
                });
            }
            return users;

        }

        [HttpGet("GetCustomers")]
        public async Task<List<ApplicationCustomer>> GetAllCustomer() => await _accountRepo.GetCustomerList();

        [HttpGet("GetEmployees")]
        public async Task<List<ApplicationEmployee>> GetAllEmployee() => await _accountRepo.GetEmployeeList();


        [HttpGet("GetUser/{id}")]
        public async Task<AppUser> GetUser(int id) => await _accountRepo.GetFirstOrDefault(id);

        [HttpPost("Login")]
        public async Task<ActionResult<ApplicationUser>> Login(LoginDTO login)
        {
            var result = await _accountRepo.Login(login);

            if (result.Id == 0)
                return Unauthorized("Invalid UserName Or Password.");

            return Ok(result);
        }

        [HttpPost("SaveUser")]
        public async Task<ResponsesContent> SaveUser(UserRegistration applicationUser) => await _accountRepo.ToAddOrUpdate(applicationUser);

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ResponsesContent> DeleteUser(int id) => await _accountRepo.ToDelete(id);

    }
}
