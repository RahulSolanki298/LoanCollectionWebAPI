using AdminSite.Dtos;
using AdminSite.Helpers;
using AdminSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdminSite.Controllers
{
    public class AccountController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public AccountController()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<IActionResult> Index()
        {
            LoginDTO loginDTO = new LoginDTO();
            return View(loginDTO);
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginDTO loginDTO)
        {
            using (HttpClient client = new HttpClient())
            {

                var url =
                    new UriBuilder($"{APIConnection.ApiPath}/api/Account/Login");

                var jsonContext = JsonConvert.SerializeObject(loginDTO);
                var requestContent = new StringContent(jsonContext, Encoding.UTF8, "application/json");

                var response =
                    await client.PostAsync(url.ToString(), requestContent);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();

                    var applicationUsers =
                        JsonConvert.DeserializeObject<ApplicationUser>(content);

                    HttpContext.Session.SetString(APIConnection.BranchName, applicationUsers.BranchName);
                    HttpContext.Session.SetString(APIConnection.LoginUserRole, applicationUsers.RoleName);
                    HttpContext.Session.SetString(APIConnection.LoginUserName, applicationUsers.FirstName + " " + applicationUsers.LastName);
                    HttpContext.Session.SetInt32(APIConnection.LoginUserId, applicationUsers.Id);
                    HttpContext.Session.SetInt32(APIConnection.BranchId, (int)applicationUsers.BranchId);
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return Json("Invalid UserName and Password");

        }

        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

    }
}
