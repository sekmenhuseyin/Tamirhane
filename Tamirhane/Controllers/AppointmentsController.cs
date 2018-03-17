using System.Web.Mvc;
using Tamirhane.Core.Models;
using Tamirhane.Infrastructure.Repository;

namespace Tamirhane.Controllers
{
    public class AppointmentsController : Controller
    {
        private AppointmentRepository Db = new AppointmentRepository();

        // GET: Appointments
        public ActionResult Index()
        {
            return View("Index", Db.GetAll());
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var result = Db.Add(appointment);
                if (result.Status == true)
                    return RedirectToAction("Index");
            }

            return View("Create", appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int id)
        {
            Appointment appointment = Db.FindById(id);
            return View("Edit", appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var result = Db.Edit(appointment);
                if (result.Status == true)
                    return RedirectToAction("Index");
            }
            return View("Edit", appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Db.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
