﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesignWeb_Project.Areas.Admin.Models.BusinessModel;
using DesignWeb_Project.Areas.Admin.Models.DataModel;
using System.IO;

namespace DesignWeb_Project.Areas.Admin.Controllers
{
    [AuthorizeBusiness]
    public class ConfiguresController : Controller
    {
        private ConnectionDBContext db = new ConnectionDBContext();



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configure configure = db.Configures.Find(id);
            if (configure == null)
            {
                return HttpNotFound();
            }
            return View(configure);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Configure configure, HttpPostedFileBase favicon_image)
        {
            if (ModelState.IsValid)
            {

                if (favicon_image != null)
                {
                    var filename = Path.GetFileName(favicon_image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/Images"), filename);


                    favicon_image.SaveAs(path);
                    configure.Favicon = "/Upload/Images/" + favicon_image.FileName;
                }



                db.Entry(configure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = configure.ConfigID });
            }
            return View(configure);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
