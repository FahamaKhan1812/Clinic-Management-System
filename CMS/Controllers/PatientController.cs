using CMS.DAL;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    //[Authorize]
    public class PatientController : Controller
    {
        PatientDAL _patientDAL = new PatientDAL();
       
        // GET: Patient
        public ActionResult Index()
        {
            var patientList = _patientDAL.GetAllPatients();
            return View(patientList);
        }

        // GET: Patient/Details/5
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

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patients patients)
        {
            bool IsInserted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = _patientDAL.InsertPatient(patients);
                    if (IsInserted)
                    {
                        TempData["SuccessInfo"] = "Patient details saved";
                    }
                    else
                    {
                        TempData["ErrorInfo"] = "Patient details not saved";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorInfo"] = ex.Message;
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _patientDAL.GetPatientByID(id).FirstOrDefault();
            if (product == null)
            {
                TempData["Info"] = "No Patient is available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // POST: Patient/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(Patients patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isUpdated = _patientDAL.UpdatePatient(patient);

                    if (isUpdated)
                    {
                        TempData["SuccessInfo"] = "Patient details updated";
                    }
                    else
                    {
                        TempData["ErrorInfo"] = "Patient details not saved";

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorInfo"] = ex.Message;
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
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

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePatient(int id)
        {
            try
            {
                string result = _patientDAL.DeletePatient(id);
                if (result.Contains("Deleted"))
                {
                    TempData["SuccessInfo"] = result;
                }
                else
                {
                    TempData["ErrorInfo"] = result;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorInfo"] = ex.Message;
                return View();
            }
        }
    }
}
