using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }
        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index", "Department");
            }
            return View(department);
        }
        [HttpGet]
        public ActionResult DeleteDepartment(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        [HttpPost, ActionName("DeleteDepartment")]
        public ActionResult ConfirmDeleteDepartment(int id)
        {
            var department = db.Departments.Find(id);
            if (department != null)
            {
                db.Departments.Remove(department);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                var existingDepartment = db.Departments.Find(department.Id);
                if (existingDepartment != null)
                {
                    existingDepartment.Name = department.Name;
                    existingDepartment.Description = department.Description;
                    existingDepartment.ImageUrl = department.ImageUrl;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(department);
        }
    }
}

