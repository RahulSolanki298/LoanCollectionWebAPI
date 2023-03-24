using AdminSite.Helpers;
using AdminSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminSite.Controllers
{
    public class CustomerController : Controller
    {

        HttpClientHandler httpClientHandler = new HttpClientHandler();
        List<ApplicationCustomer> applicationUsers = new List<ApplicationCustomer>();

        public CustomerController()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View("~/Views/Customer/Index.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> CustomerRegistration(int? id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CustomerRegistration(ApplicationCustomer applicationCustomer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return View();
        }

        public async Task<IActionResult> CustomerList()
        {
            applicationUsers = new List<ApplicationCustomer>();

            using (HttpClient client = new HttpClient())
            {
                var userRole = HttpContext.Session.GetString(APIConnection.LoginUserRole);
                var branchId = HttpContext.Session.GetInt32(APIConnection.BranchId);

                var url =
                    new UriBuilder($"{APIConnection.ApiPath}/api/Customer/GetCustomers/{userRole}/{branchId}");
                var response =
                    await client.GetAsync(url.ToString()).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var data =
                        await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    applicationUsers =
                        Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApplicationCustomer>>(data);
                }
            }
            return View(applicationUsers);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            applicationUsers = new List<ApplicationCustomer>();

            using (HttpClient client = new HttpClient())
            {
                var url =
                    new UriBuilder($"{APIConnection.ApiPath}/api/Customer/DeleteCustomers/{id}");

                var response =
                    await client.DeleteAsync(url.ToString()).ConfigureAwait(false);

                TempData["Success"] = "Customer deleted successfully";
                //if (response.IsSuccessStatusCode)
                //{

                //}
            }
            return RedirectToAction("Index");
        }
    }
}
