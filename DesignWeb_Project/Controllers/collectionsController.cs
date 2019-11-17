﻿using DesignWeb_Project.Areas.Admin.Models.BusinessModel;
using DesignWeb_Project.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignWeb_Project.Controllers
{
    public class collectionsController : Controller
    {
        private ConnectionDBContext db = new ConnectionDBContext();

        // GET: Category
        public ActionResult CollectionAll(int? page)
        {

            var model = from p in db.Products where p.Status == true orderby p.CreatedAt descending select p;
            int pagesize = 20;
            int pageNumber = (page ?? 1);

            var count_product = db.Products.Where(x => x.Status == true).Count();
            ViewBag.count_product = count_product;
            return View(model.ToPagedList(pageNumber, pagesize));
        }


        public ActionResult GetCollectionID(int? page,int CategoryID,string Alias)
        {
            var listmol = from p in db.Products
                        where p.CategoryID == CategoryID && p.Status == true orderby p.CreatedAt descending
                        select new ProductModel {
                            ProductID = p.ProductID,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            PriceSale = p.PriceSale,
                            Alias = p.Alias,
                            CategoryID = p.CategoryID,
                            MetaDescription = p.MetaDescription,
                            MetaKeyword = p.MetaKeyword,
                            DescriptShort = p.DescriptShort,
                            Author = p.Author,
                            Images = p.Images,
                            Content = p.Content
                        };

            int pagesize = 20;
            int pageNumber = (page ?? 1);


            ViewBag.count_product = listmol.Count();


            var getCate = from d in db.Categorys
                          where d.CategoryID == CategoryID
                          select new ProductModel
                          {
                              CategoryName = d.CategoryName,
                              MetaDescription=d.MetaDescription,
                              MetaKeyword=d.MetaKeyword,
                              MetaTitle=d.MetaTitle
                          };

            ViewBag.getCate = getCate;

            return View(listmol.ToPagedList(pageNumber, pagesize));
        }
    }
}