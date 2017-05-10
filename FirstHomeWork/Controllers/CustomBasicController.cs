using FirstHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstHomeWork.Controllers
{
    public class CustomBasicController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();
        // GET: CustomBasic
        public ActionResult Index()
        {
            var data = db.客戶資料.ToList();
            return View(data);
        }

        // GET: CustomBasic/Details/5
        public ActionResult Details(int id)
        {
            var data = db.客戶資料.Find(id);
            return View(data);
        }

        // GET: CustomBasic/Create
        public ActionResult Create()
        {
            var data = new 客戶資料();
            return View(data);
        }

        // POST: CustomBasic/Create
        [HttpPost]
        public ActionResult Create(客戶資料 CustomData)
        {
            try
            {
                // TODO: Add insert logic here
                db.客戶資料.Add(CustomData);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(CustomData);
            }
        }

        // GET: CustomBasic/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.客戶資料.Find(id);
            return View(data);
        }

        // POST: CustomBasic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, 客戶資料 EditedData)
        {
            try
            {
                var data = db.客戶資料.Find(id);
                data.Email = EditedData.Email;
                data.傳真 = EditedData.傳真;
                data.地址 = EditedData.地址;
                data.客戶名稱 = EditedData.客戶名稱;
                data.統一編號 = EditedData.統一編號;
                data.電話 = EditedData.電話;
                

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomBasic/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.客戶資料.Find(id);
            db.客戶資料.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
