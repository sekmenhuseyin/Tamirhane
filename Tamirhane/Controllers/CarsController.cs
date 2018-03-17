using System.Web.Mvc;
using Tamirhane.Core.Models;
using Tamirhane.Infrastructure.Repository;

namespace Tamirhane.Controllers
{
    public class CarsController : Controller
    {
        private CarRepository Db = new CarRepository();
        private UserRepository UserDb = new UserRepository();

        // GET: Cars
        public ActionResult Index()
        {
            return View("Index", Db.GetAll());
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.User_Id = new SelectList(UserDb.GetAll(), "Id", "FirstName");
            return View("Create");
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Plate,Company,Model,Year")] Car car, int User_Id)
        {
            car.User = UserDb.FindById(User_Id);
            var result = Db.Add(car);
            if (result.Status == true)
                return RedirectToAction("Index");
            ViewBag.User_Id = new SelectList(UserDb.GetAll(), "Id", "FirstName");
            return View("Create", car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {
            Car car = Db.FindById(id);
            return View("Edit", car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Plate,Company,Model,Year")] Car car)
        {
            var result = Db.Edit(car);
            if (result.Status == true)
                return RedirectToAction("Index");
            return View("Edit", car);
        }

        // POST: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            Db.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
