using API.Dtos;
using API.Helpers;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly dbLoanAppContext _context;
        //private readonly ITokenService _tokenService;

        public AccountRepository()
        {
            _context = new dbLoanAppContext();
            //_tokenService = tokenService;
        }
        public async Task<ResponsesContent> ToAddOrUpdate(UserRegistration applicationUser)
        {
            AppUser register = new AppUser();
            ResponsesContent responses = new ResponsesContent();
            using var hmac = new HMACSHA512();

            if (applicationUser.Id > 0)
            {
                register = await _context.AppUsers.FindAsync(applicationUser.Id);

                register.FirstName = applicationUser.FirstName;
                register.MiddleName = applicationUser.MiddleName;
                register.LastName = applicationUser.LastName;
                register.EmailId = applicationUser.EmailId;
                register.Gender = applicationUser.Gender;
                register.BranchId = applicationUser.BranchId;
                register.IsActive = applicationUser.IsActive;
                register.DateOfBirth = applicationUser.DateOfBirth;
                register.UpdatedDate = applicationUser.UpdatedDate;
                register.UpdatedById = applicationUser.UpdatedById;
                register.WhatsAppNo = applicationUser.WhatsAppNo;
                register.MobileNo = applicationUser.MobileNo;
                register.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(applicationUser.Password));
                register.PasswordSalt = hmac.Key;
                register.UserName = applicationUser.UserName;
                _context.AppUsers.Update(register);

            }
            else
            {
                register.FirstName = applicationUser.FirstName;
                register.MiddleName = applicationUser.MiddleName;
                register.LastName = applicationUser.LastName;
                register.EmailId = applicationUser.EmailId;
                register.Gender = applicationUser.Gender;
                register.BranchId = applicationUser.BranchId;
                register.IsActive = applicationUser.IsActive;
                register.DateOfBirth = applicationUser.DateOfBirth;
                register.CreatedDate = applicationUser.CreatedDate;
                register.CreatedById = applicationUser.CreatedById;
                register.WhatsAppNo = applicationUser.WhatsAppNo;
                register.MobileNo = applicationUser.MobileNo;
                register.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(applicationUser.Password));
                register.PasswordSalt = hmac.Key;
                register.UserName = applicationUser.UserName;

                _context.AppUsers.Add(register);
            }
            await _context.SaveChangesAsync();

            var AddUserRole = await _context.AppUserRoles.Where(x => x.UserId == register.Id).FirstOrDefaultAsync();
            if (AddUserRole == null)
            {
                _context.AppUserRoles.Add(new AppUserRole()
                {
                    RoleId = await _context.AppRoles.Where(x => x.Name == applicationUser.RoleName).Select(x => x.Id).FirstOrDefaultAsync(),
                    UserId = register.Id
                });
                await _context.SaveChangesAsync();

                var checkLoanNo = await _context.AppUsers.Where(x => x.Id == register.Id).FirstOrDefaultAsync();

                if (checkLoanNo.LoanAppAccountNo == null &&
                    applicationUser.RoleName == ApplicationRole.Customer)
                {
                    checkLoanNo.LoanAppAccountNo = GenerateAccountNo() + $"{register.Id}";
                    _context.AppUsers.Update(checkLoanNo);
                    await _context.SaveChangesAsync();
                }
            }

            responses.Status = "Success";
            responses.Message = "User registration successfully.";

            return responses;
        }

        public async Task<AppUser> GetFirstOrDefault(int id) => await _context.AppUsers.FindAsync(id);

        public async Task<List<ApplicationCustomer>> GetCustomerList()
        {
            var result = await _context.ApplicationCustomers
                .FromSqlRaw("exec GetCustomerList").ToListAsync();

            return result;
        }

        public async Task<List<ApplicationEmployee>> GetEmployeeList()
        {
            var result = await _context.ApplicationEmployees
                .FromSqlRaw("exec GetEmployeeList").ToListAsync();

            return result;
        }

        public async Task<List<AppUser>> GetList() =>
            await _context.AppUsers.ToListAsync();

        public async Task<ResponsesContent> ToDelete(int id)
        {
            var response = await _context.AppUsers.FindAsync(id);
            var removeRole = await _context.AppUserRoles.Where(x => x.UserId == id).FirstOrDefaultAsync();

            if (response != null)
            {
                _context.AppUserRoles.Remove(removeRole);
                await _context.SaveChangesAsync();

                _context.AppUsers.Remove(response);
                await _context.SaveChangesAsync();

                var result = new ResponsesContent()
                {
                    Status = "Success",
                    Message = $"{response.FirstName} {response.LastName} is deleted successfully."
                };
                return result;
            }
            return new ResponsesContent()
            {
                Status = "Fail",
                Message = "Data not found. something is invalid."
            };
        }

        public async Task<ApplicationUser> Login(LoginDTO login)
        {
            var user = await (from urs in _context.AppUsers
                              join branch in _context.CompanyBranchDetails on urs.BranchId equals branch.Id
                              join role in _context.AppUserRoles on urs.Id equals role.UserId
                              join appRole in _context.AppRoles on role.RoleId equals appRole.Id
                              where urs.UserName == login.UserName
                              select new ApplicationUser
                              {
                                  Id = urs.Id,
                                  PasswordHash = urs.PasswordHash,
                                  PasswordSalt = urs.PasswordSalt,
                                  FirstName = urs.FirstName,
                                  MiddleName = urs.MiddleName,
                                  LastName = urs.LastName,
                                  Gender = urs.Gender,
                                  DateOfBirth = urs.DateOfBirth,
                                  BranchId = urs.BranchId,
                                  IsActive = urs.IsActive,
                                  MobileNo = urs.MobileNo,
                                  EmailId = urs.EmailId,
                                  UserName = urs.UserName,
                                  WhatsAppNo = urs.WhatsAppNo,
                                  CreatedById = urs.CreatedById,
                                  CreatedDate = urs.CreatedDate,
                                  BranchName=branch.Title,
                                  RoleName = appRole.Name
                              }).FirstOrDefaultAsync();


            if (user == null)
            {
                return new ApplicationUser();
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return new ApplicationUser();
            }

            return user;
        }

        private string GenerateAccountNo() =>
            $"LOAN-ACC-{DateTime.Now.Day}{DateTime.Now.Month}" +
            $"{DateTime.Now.Year}{DateTime.Now.Millisecond}";
    }
}
