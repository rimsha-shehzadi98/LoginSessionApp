using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginSessionApp.Models;

namespace LoginSessionApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login Page
        public IActionResult Index()
        {
            return View();
        }

        // POST: Handle Login
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Dummy validation for credentials
                if (model.Username == "Rimsha" && model.Password == "rim123")
                {
                    // Store user session
                    HttpContext.Session.SetString("Username", model.Username);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Message = "Invalid Username or Password!";
                }
            }
            return View(model);
        }

        // GET: Dashboard (After Login)
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session
            return RedirectToAction("Index");
        }
    }
}
