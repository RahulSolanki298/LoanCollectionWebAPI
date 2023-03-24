using AdminSite.Helpers;
using AdminSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminSite.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        List<ApplicationEmployee> applicationUsers = new List<ApplicationEmployee>();

        public EmployeeController()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View("~/Admin/Views/Employee/Index.cshtml");
        }

        public async Task<IActionResult> EmployeeList()
        {
            applicationUsers = new List<ApplicationEmployee>();

            using (HttpClient client = new HttpClient())
            {
                var userRole = HttpContext.Session.GetString(APIConnection.LoginUserRole);
                var branchId = HttpContext.Session.GetInt32(APIConnection.BranchId);

                var url =
                    new UriBuilder($"{APIConnection.ApiPath}/api/Employee/GetEmployees/{userRole}/{branchId}");
                var response =
                    await client.GetAsync(url.ToString()).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var data =
                        await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    applicationUsers =
                        Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApplicationEmployee>>(data);
                }
            }
            return View("~/Admin/Views/Employee/EmployeeList.cshtml", applicationUsers);
        }
    }
}
