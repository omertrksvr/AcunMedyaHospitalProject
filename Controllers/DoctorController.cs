using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using AcunMedyaHospitalProject.Helpers;
using System.Linq;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var doctors = db.Doctors.ToList();
            return View(doctors);
        }

        [HttpGet]
        public ActionResult CreateDoctor()
        {
            TempData["Departments"] = DepartmentHelper.GetDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult CreateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index", "Doctor");
            }
            TempData["Departments"] = DepartmentHelper.GetDepartments();
            return View(doctor);
        }

        public ActionResult DeleteDoctor(int id)
        {
            var doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index", "Doctor");
        }

        [HttpGet]
        public ActionResult UpdateDoctor(int id)
        {
            var doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            TempData["Departments"] = DepartmentHelper.GetDepartments();
            return View(doctor);
        }

        [HttpPost]
        public ActionResult UpdateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var existingDoctor = db.Doctors.Find(doctor.Id);
                if (existingDoctor != null)
                {
                    existingDoctor.FirstName = doctor.FirstName;
                    existingDoctor.LastName = doctor.LastName;
                    existingDoctor.ImageUrl = doctor.ImageUrl;
                    existingDoctor.DepartmentId = doctor.DepartmentId;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            TempData["Departments"] = DepartmentHelper.GetDepartments();
            return View(doctor);
        }
    }
}
