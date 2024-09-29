using LibraryProjectv1.Entities;
using LibraryProjectv1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProjectv1.Controllers
{
    public class BookController : Controller
    {
        static List<BookEntity> _books = new List<BookEntity>()
        {
            new BookEntity{Id=1,Title="Book One", AuthorId=1, Genre="Action", PublishDate=new DateTime(2020,05,23), CopiesAvailable=100, ISBN="234234234"},
            new BookEntity{Id=2,Title="Book One", AuthorId=1, Genre="Action", PublishDate=new DateTime(2020,05,23), CopiesAvailable=10, ISBN="234234234"},
            new BookEntity{Id=3,Title="Book One", AuthorId=1, Genre="Action", PublishDate=new DateTime(2020,05,23), CopiesAvailable=10, ISBN="234234234"},
            new BookEntity{Id=4,Title="Book One", AuthorId=1, Genre="Action", PublishDate=new DateTime(2020,05,23), CopiesAvailable=10, ISBN="234234234"},
            new BookEntity{Id=5,Title="Book One", AuthorId=1, Genre="Action", PublishDate=new DateTime(2020,05,23), CopiesAvailable=10, ISBN="234234234"},
        };
        public IActionResult List()
        {
            var books = _books.Where(x => x.IsDeleted == false).Select(x => new BookListViewModel 
            {
                Id = x.Id,
                Title = x.Title,
                AuthorId = x.AuthorId,
                Genre = x.Genre,
                PublishDate = x.PublishDate,
                CopiesAvailable = x.CopiesAvailable,
                ISBN = x.ISBN,
            }).ToList();
            return View(books);
        }
        
        public IActionResult Detail(int id)
        {
            var bookDetail = _books.FirstOrDefault(x => x.Id == id);
            if(bookDetail is null)
            {
                return NotFound();
            }

            return View(bookDetail);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookAddViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            int maxId = _books.Max(x => x.Id) + 1;
            var newBook = new BookEntity
            {
                Id=maxId,
                Title = model.Title,
                AuthorId = 1,
                Genre = model.Genre,
                PublishDate = model.PublishDate,
                CopiesAvailable = model.CopiesAvailable,
                ISBN = model.ISBN,
            };

            _books.Add(newBook);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bookEdit = _books.FirstOrDefault(x=>x.Id == id);
            if(bookEdit is null)
            {
                return NotFound();
            }
            var bookEditModel = new BookEditViewModel()
            {
                Id = id,
                Title = bookEdit.Title,
                Genre = bookEdit.Genre,
                PublishDate = bookEdit.PublishDate,
                ISBN = bookEdit.ISBN,
                CopiesAvailable = bookEdit.CopiesAvailable,
            };
            return View(bookEditModel);
        }

        [HttpPost]
        public IActionResult Edit(BookEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var bookEditModel = _books.FirstOrDefault(x => x.Id == model.Id);
                if(bookEditModel is null)
                {
                    return NotFound();
                }
                bookEditModel.Title = model.Title;
                bookEditModel.Genre = model.Genre;
                bookEditModel.PublishDate = model.PublishDate;
                bookEditModel.ISBN = model.ISBN;
                bookEditModel.CopiesAvailable = model.CopiesAvailable;
                return RedirectToAction("List");
            }
            return View(model);
        }


        
        public IActionResult Delete(int id)
        {
            var bookDel = _books.FirstOrDefault(x=>x.Id == id);
            if(bookDel is null)
            {
                return NotFound();  
            }
            bookDel.IsDeleted = true;
            return RedirectToAction("List");
        }
    }
}
