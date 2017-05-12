using FirstHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstHomeWork.Controllers
{
    public class CustomBankController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();
        // GET: CustomBank
        public ActionResult Index()
        {
            var data = db.客戶銀行資訊.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string CustomName)
        {
            var data = db.客戶銀行資訊.Where(x => x.客戶資料.客戶名稱.Contains(CustomName)).ToList();
            return View(data);
        }

        // GET: CustomBank/Details/5
        public ActionResult Details(int id)
        {
            var data = db.客戶銀行資訊.Find(id);
            return View(data);
        }

        // GET: CustomBank/Create
        public ActionResult Create()
        {
            var data = new 客戶銀行資訊();
            List<SelectListItem> items = new List<SelectListItem>();
            var listid = db.客戶資料.Select(x => x.Id).ToList();
            foreach (var item in listid)
            {
                items.Add(new SelectListItem() { Text = item.ToString(), Value = item.ToString() });
            }
            ViewBag.List客戶id = items;
            return View(data);
        }

        // POST: CustomBank/Create
        [HttpPost]
        public ActionResult Create(客戶銀行資訊 CustomData)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var listid = db.客戶資料.Select(x => x.Id).ToList();
            foreach (var item in listid)
            {
                items.Add(new SelectListItem() { Text = item.ToString(), Value = item.ToString() });
            }
            ViewBag.List客戶id = items;
            if(ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    db.客戶銀行資訊.Add(CustomData);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(CustomData);
                }
            }
            return View(CustomData);
        }

        // GET: CustomBank/Edit/5
        public ActionResult Edit(int id)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var listid = db.客戶資料.Select(x => x.Id).ToList();
            foreach (var item in listid)
            {
                items.Add(new SelectListItem() { Text = item.ToString(), Value = item.ToString() });
            }
            ViewBag.List客戶id = items;
            var data = db.客戶銀行資訊.Find(id);
            return View(data);
        }

        // POST: CustomBank/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, 客戶銀行資訊 EditedData)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var listid = db.客戶資料.Select(x => x.Id).ToList();
            foreach (var item in listid)
            {
                items.Add(new SelectListItem() { Text = item.ToString(), Value = item.ToString() });
            }
            ViewBag.List客戶id = items;
            if (ModelState.IsValid)
            {
                try
                {
                    var data = db.客戶銀行資訊.Find(id);
                    data.分行代碼 = EditedData.分行代碼;
                    data.客戶Id = EditedData.客戶Id;
                    data.帳戶名稱 = EditedData.帳戶名稱;
                    data.帳戶號碼 = EditedData.帳戶號碼;
                    data.銀行代碼 = EditedData.銀行代碼;
                    data.銀行名稱 = EditedData.銀行名稱;


                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(EditedData);
                }
            }
            return View(EditedData);
        }

        // GET: CustomBank/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.客戶銀行資訊.Find(id);
            data.是否已刪除 = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
