﻿using DesignWeb_Project.Areas.Admin.Models.BusinessModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignWeb_Project.Controllers
{
    public class searchController : Controller
    {
        private ConnectionDBContext db = new ConnectionDBContext();
        // GET: search
        public ActionResult Index(int? page, string q)
        {
            var model = from p in db.Products orderby p.ProductName ascending select p;
            int pagesize = 20;
            int pageNumber = (page ?? 1);

            if (!string.IsNullOrEmpty(q))
            {
                model = model.Where(x => x.ProductName.Contains(q) || x.Categories.CategoryName.Contains(q)).OrderBy(x => x.ProductName);
            }

            ViewBag.countresult = model.Count();
            ViewBag.keyword_search = q;

            return View(model.ToPagedList(pageNumber, pagesize));
        }

        public PartialViewResult smartsearch(string q)
        {
            var model = (from p in db.Products select p);


            if (!string.IsNullOrEmpty(q))
            {
                model = model.Where(x => x.ProductName.Contains(q) || x.Categories.CategoryName.Contains(q)).OrderBy(x => x.ProductName).Take(10);
            }

            ViewBag.countresult = model.Count();
            ViewBag.keyword_search = q;

            return PartialView(model.ToList());
        }
    }
}