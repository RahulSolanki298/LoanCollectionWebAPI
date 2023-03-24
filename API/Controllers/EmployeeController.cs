using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        dbLoanAppContext dbLoanAppContext;
        public EmployeeController()
        {
            dbLoanAppContext = new dbLoanAppContext();
        }

        [HttpGet("GetEmployees/{userRole}/{branchId}")]
        public async Task<IActionResult> GetEmployees(string userRole, string branchId)
        {
            var result = await dbLoanAppContext.GetEmployee(userRole, Convert.ToInt32(branchId));
            return Ok(result);
        }
    }
}
