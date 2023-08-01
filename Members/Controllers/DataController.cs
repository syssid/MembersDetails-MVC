using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Members.Models;

namespace Members.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View(SQLCon.GetData());
        }

        // GET: Data/Details/5
        public ActionResult Details(int id)
        {
           var result = SQLCon.GetBYid(id).FirstOrDefault();
            return View(result);
        }

        // GET: Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Data/Create
        [HttpPost]
        public ActionResult Create(Models.Members m, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null && Photo.ContentLength > 0)
                {
                    try
                    {
                        string fileName = Path.GetFileName(Photo.FileName);
                        string path = Path.Combine(Server.MapPath("~/img"), fileName);
                        Photo.SaveAs(path);

                        // Update the model with the file name only
                        m.Photo = fileName;

                        SQLCon.insertData(m);

                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {

                        ModelState.AddModelError(string.Empty, "Either You Entered Duplicate Aadhar PAN Number or Uploded File is Corrupted");
                    }
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Either You Entered Duplicate Aadhar PAN Number or Uploded File is Corrupted");
                }
            }

            return View(m);
        }
        // GET: Data/Edit/5
        public ActionResult Edit(int id)
        {
            var result = SQLCon.GetBYid(id).FirstOrDefault();
            return View(result);
        }

        // POST: Data/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Members m)
        {
            SQLCon.UpdateData(m);
            return RedirectToAction("Index");
        }

        // GET: Data/Delete/5
        public ActionResult Delete(int id)
        {
            var result = SQLCon.GetBYid(id).FirstOrDefault();
            return View(result);
        }

        // POST: Data/Delete/5
        [HttpPost]
        public ActionResult Delete(dynamic id)
        {

            SQLCon.DeleteData(id);

            return RedirectToAction("Index");
        }
    }
}
