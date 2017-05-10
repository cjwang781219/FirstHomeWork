﻿using FirstHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstHomeWork.Controllers
{
    public class CustomContactController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();
        // GET: CustomContact
        public ActionResult Index()
        {
            var data = db.客戶聯絡人.ToList();
            return View(data);
        }

        // GET: CustomContact/Details/5
        public ActionResult Details(int id)
        {
            var data = db.客戶聯絡人.Find(id);
            return View(data);
        }

        // GET: CustomContact/Create
        public ActionResult Create()
        {
            var data = new 客戶聯絡人();
            return View(data);
        }

        // POST: CustomContact/Create
        [HttpPost]
        public ActionResult Create(客戶聯絡人 CustomData)
        {
            try
            {
                // TODO: Add insert logic here
                db.客戶聯絡人.Add(CustomData);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(CustomData);
            }
        }

        // GET: CustomContact/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.客戶聯絡人.Find(id);
            return View(data);
        }

        // POST: CustomContact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, 客戶聯絡人 EditedData)
        {
            try
            {
                var data = db.客戶聯絡人.Find(id);
                data.Email = EditedData.Email;
                data.客戶Id = EditedData.客戶Id;
                data.姓名 = EditedData.姓名;
                data.手機 = EditedData.手機;
                data.職稱 = EditedData.職稱;
                data.電話 = EditedData.電話;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomContact/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.客戶聯絡人.Find(id);
            db.客戶聯絡人.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
