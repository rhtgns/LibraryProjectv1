using LibraryProjectv1.Entities;
using LibraryProjectv1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProjectv1.Controllers
{
    public class UserController : Controller
    {
        static List<UserEntity> _users = new List<UserEntity>()
        {
            new UserEntity{Id=1,FullName="Rohat Günes", Email="rohat@rohat.com", Password="12345",PhoneNumber="555655562",JoinDate=new DateTime(2023,03,03)},
            new UserEntity{Id=2,FullName="Rohat Günes", Email="rohat@rohat.com", Password="12345",PhoneNumber="555655562",JoinDate=new DateTime(2023,03,03)},
            new UserEntity{Id=3,FullName="Rohat Günes", Email="rohat@rohat.com", Password="12345",PhoneNumber="555655562",JoinDate=new DateTime(2023,03,03)},
        };
        public IActionResult List()
        {
            var listUser = _users.Where(x => x.IsDeleted == false).Select(x => new UserListViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                JoinDate = x.JoinDate,
            }).ToList();
            return View(listUser);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserAddViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = _users.Max(x => x.Id) + 1;
            var newUser = new UserEntity
            {
                Id = userId,
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                JoinDate=model.JoinDate,

            };
            _users.Add(newUser);
            return Redirect("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editUser = _users.FirstOrDefault(x => x.Id == id);  
            if(editUser is null)
            {
                return NotFound();
            }
            var editUserModel = new UserEditViewModel()
            {
                Id = editUser.Id,
                FullName = editUser.FullName,
                Email = editUser.Email,
                PhoneNumber = editUser.PhoneNumber,
                Password = editUser.Password,

            };
            return View(editUserModel);
        }

        [HttpPost]
        public IActionResult Edit(UserEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _users.FirstOrDefault(x=>x.Id == model.Id);
                if(user is null)
                {
                    return NotFound();
                }
                user.FullName = model.FullName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Password = model.Password;
                return RedirectToAction("List");
            }
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var detailUser = _users.FirstOrDefault(x=>x.Id == id);
            if(detailUser is null)
            {
                return NotFound();
            }
            return View(detailUser);
        }

        public IActionResult Delete(int id)
        {
            var userDel = _users.FirstOrDefault(_x => _x.Id == id);
            if(userDel is null)
            {
                return NotFound();
            }
            userDel.IsDeleted = true;
            return RedirectToAction("List");
        }
    }
}
