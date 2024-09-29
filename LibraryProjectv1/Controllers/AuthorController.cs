using LibraryProjectv1.Entities;
using LibraryProjectv1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProjectv1.Controllers
{
    public class AuthorController : Controller
    {
        static List<AuthorEntity> _authors = new List<AuthorEntity>()
        {
            new AuthorEntity{ Id=1,FirstName="John",LastName="Doe", DateOfBirth = new DateTime(1987,03,03)},
            new AuthorEntity{ Id=2,FirstName="David",LastName="Casper", DateOfBirth = new DateTime(1987,03,03)},
            new AuthorEntity{ Id=3,FirstName="Marko",LastName="Doe", DateOfBirth = new DateTime(1987,03,03)},
        };
        public IActionResult List()
        {
            var authorList = _authors.Where(x => x.IsDeleted == false).Select(x => new AuthorListViewModel 
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
            }).ToList();
            return View(authorList);
        }

        public IActionResult Detail(int id)
        {
            var authorDetail = _authors.FirstOrDefault(x=>x.Id == id);
            if(authorDetail is null)
            {
                return NotFound();
            }
            return View(authorDetail);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuthorAddViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var authorId = _authors.Max(x=>x.Id) + 1;

            var authorModel = new AuthorEntity
            {
                Id = authorId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
            };
            _authors.Add(authorModel);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var authorEdit = _authors.FirstOrDefault(x=>x.Id == id);
            if(authorEdit is null)
            {
                return NotFound();
            }
            var editModel = new AuthorEditViewModel
            {
                Id = authorEdit.Id,
                FirstName = authorEdit.FirstName,
                LastName = authorEdit.LastName,
                DateOfBirth=authorEdit.DateOfBirth,
            };
            return View(editModel);
        }

        [HttpPost]
        public IActionResult Edit(AuthorEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var authorEdit = _authors.FirstOrDefault(y=>y.Id == model.Id);
                if(authorEdit is null)
                {
                    return NotFound();
                }
                authorEdit.FirstName = model.FirstName;
                authorEdit.LastName = model.LastName;
                authorEdit.DateOfBirth = model.DateOfBirth;
                return RedirectToAction("List");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var authorDel = _authors.FirstOrDefault(x=>x.Id ==id);
            if(authorDel is null)
            {
                return NotFound();
            }
            authorDel.IsDeleted = true;
            return RedirectToAction("List");
        }
    }
}
