using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System.Linq;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var services = db.Services.ToList();
            return View(services);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            if (ModelState.IsValid)
            {
                var existingService = db.Services.Find(service.Id);
                if (existingService != null)
                {
                    existingService.Name = service.Name;
                    existingService.Description = service.Description;
                    existingService.IconName = service.IconName;
                    existingService.ButtonName = service.ButtonName;
                    existingService.ButtonLink = service.ButtonLink;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(service);
        }

        public ActionResult RemoveService(int id)
        {
            var service = db.Services.Find(id);
            if (service != null)
            {
                db.Services.Remove(service);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}