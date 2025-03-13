using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System.Linq;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    public class SliderController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var sliders = db.Sliders.ToList();
            return View(sliders);
        }

        [HttpGet]
        public ActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSlider(Slider slider)
        {
            if (ModelState.IsValid)
            {
                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        [HttpPost]
        public ActionResult UpdateSlider(Slider slider)
        {
            if (ModelState.IsValid)
            {
                var existingSlider = db.Sliders.Find(slider.Id);
                if (existingSlider != null)
                {
                    existingSlider.Title = slider.Title;
                    existingSlider.Description = slider.Description;
                    existingSlider.ImageUrl = slider.ImageUrl;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(slider);
        }

        public ActionResult RemoveSlider(int id)
        {
            var slider = db.Sliders.Find(id);
            if (slider != null)
            {
                db.Sliders.Remove(slider);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}