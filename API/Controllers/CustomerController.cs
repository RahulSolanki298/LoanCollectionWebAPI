using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        dbLoanAppContext dbLoanAppContext;
        public CustomerController()
        {
            dbLoanAppContext = new dbLoanAppContext();
        }

        [HttpGet("GetCustomers/{userRole}/{branchId}")]
        public async Task<IActionResult> GetCustomers(string userRole,string branchId)
        {
            var result=await dbLoanAppContext.GetCustomers(userRole,Convert.ToInt32(branchId));
            return Ok(result);
        }

        [HttpDelete("DeleteCustomers/{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            var result = await dbLoanAppContext.AppUsers.Where(x => x.Id ==id).FirstOrDefaultAsync();

            dbLoanAppContext.AppUsers.Remove(result);
            await dbLoanAppContext.SaveChangesAsync();

            return Ok("Customer deleted successfully.");
        }
    }
}
