using CMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class AppoitmentController : Controller
    {
        PatientDAL _patientDAL = new PatientDAL();

        // GET: Appoitment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Appoitment/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var patient = _patientDAL.GetPatientByID(id).FirstOrDefault();
                if (patient == null)
                {
                    TempData["Info"] = "No Patient are available with ID " + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(patient);
            }
            catch (Exception ex)
            {
                TempData["ErrorInfo"] = ex.Message;
                return View();
            }
        }

        // GET: Appoitment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appoitment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appoitment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appoitment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appoitment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appoitment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
