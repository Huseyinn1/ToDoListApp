using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class GetTasksController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public GetTasksController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            List<ToDoModel> tasks = _databaseContext.ToDoLists.ToList();
            return View(tasks);
           
        }
        public IActionResult Delete(Guid id)
        {
            ToDoModel list = _databaseContext.ToDoLists.Find(id);

            _databaseContext.ToDoLists.Remove(list);
            _databaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public IActionResult Edit(Guid id)
        {
            ToDoModel model = _databaseContext.ToDoLists.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Guid id,ToDoModel model)
        {
            if (ModelState.IsValid)
            {
                ToDoModel x=_databaseContext.ToDoLists.Find(id);
                x.Id=model.Id;
                x.Text=model.Text;
                _databaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
