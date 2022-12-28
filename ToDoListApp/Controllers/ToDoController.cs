using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Entities;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public ToDoController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ToDoModel model)
        {
            if (ModelState.IsValid)
            {
                ToDoModel list = new()
                {
                    Id = model.Id,
                    Text = model.Text
                };
                _databaseContext.ToDoLists.Add(list);
                _databaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(Guid id)
        {
            ToDoModel list = _databaseContext.ToDoLists.Find(id);
            if (list != null)
            {
                _databaseContext.ToDoLists.Remove(list);
                _databaseContext.SaveChanges();

            }
            return RedirectToAction("Index");
        }

    }
}
