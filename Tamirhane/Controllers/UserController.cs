using System.Web.Mvc;
using Tamirhane.Core.Models;
using Tamirhane.Infrastructure.Repository;

namespace Tamirhane.Controllers
{
    public class UserController : Controller
    {
        private UserRepository Db = new UserRepository();

        // GET: User
        public ActionResult Index()
        {
            return View("Index", Db.GetAll());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            User user = Db.FindById(id);
            return View("Details", user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Tel")] User user)
        {
            if (ModelState.IsValid)
            {
                var result = Db.Add(user);
                if (result.Status == true)
                    return RedirectToAction("Index");
            }

            return View("Create", user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            User user = Db.FindById(id);
            return View("Edit", user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Tel")] User user)
        {
            if (ModelState.IsValid)
            {
                var result = Db.Edit(user);
                if (result.Status == true)
                    return RedirectToAction("Index");
            }
            return View("Edit", user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Db.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
