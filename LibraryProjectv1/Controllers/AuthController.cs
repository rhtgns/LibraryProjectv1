using LibraryProjectv1.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProjectv1.Controllers
{
    public class AuthController : Controller
    {
        static List<AuthEntity> _auths = new List<AuthEntity>()
        {
            new AuthEntity{ Id=1,Email="mail@mail.com",Password="123"}
        };
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthEntity model)
        {
            var user = _auths.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user != null)
            {                
                return RedirectToAction("Index", "Home"); 
            }

            ViewBag.ErrorMessage = "Email or password is incorrect!";
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AuthEntity model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           
            var existingUser = _auths.FirstOrDefault(x => x.Email == model.Email);
            if (existingUser != null)
            {
                ViewBag.ErrorMessage = "This email is already registered!";
                return View(model);
            }

            
            int newId = _auths.Max(x => x.Id) + 1;
            var newUser = new AuthEntity
            {
                Id = newId,
                Email = model.Email,
                Password = model.Password
            };

            _auths.Add(newUser);
            return RedirectToAction("Login");
        }


    }
}
