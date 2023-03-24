using API.Dtos;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanManagerController : ControllerBase
    {
        private readonly ICustomerLoanManagerRepository _customerLoanManagerRepo;

        public LoanManagerController(ICustomerLoanManagerRepository customerLoanManagerRepository)
        {
            _customerLoanManagerRepo = customerLoanManagerRepository;
        }

        [HttpPost("CustomerLoanApply")]
        public async Task<ResponsesContent> CustomerLoanApply(CustomerLoanDTO customerLoanDTO)
        {
            var response= await _customerLoanManagerRepo.ToAddOrUpdate(customerLoanDTO);
            return response;
        }
    }
}
