using FirstHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstHomeWork.Controllers
{
    public class CustomContactController : Controller
    {
        //客戶資料Entities db = new 客戶資料Entities();
        客戶聯絡人Repository rpo = RepositoryHelper.Get客戶聯絡人Repository();
        客戶資料Repository rpoBasic = RepositoryHelper.Get客戶資料Repository();
        // GET: CustomContact
        public ActionResult Index()
        {
            var data = rpo.get客戶聯絡人();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string CustomName)
        {
            var data = rpo.Where(x => x.客戶資料.客戶名稱.Contains(CustomName)).ToList();
            return View(data);
        }

        // GET: CustomContact/Details/5
        public ActionResult Details(int id)
        {
            var data = rpo.get客戶聯絡人ByID(id);
            return View(data);
        }

        // GET: CustomContact/Create
        public ActionResult Create()
        {
            var data = new 客戶聯絡人();
            List<SelectListItem> items = new List<SelectListItem>();
            var listid = rpoBasic.get客戶資料();
            foreach (var item in listid)
            {
                items.Add(new SelectListItem() { Text = item.客戶名稱.ToString(), Value = item.Id.ToString() });
            }
            ViewBag.List客戶id = items;
            return View(data);
        }

        // POST: CustomContact/Create
        [HttpPost]
        public ActionResult Create(客戶聯絡人 CustomData)
        {
            var data = new 客戶聯絡人();
            List<SelectListItem> items = new List<SelectListItem>();
            var listid = rpoBasic.get客戶資料();
            foreach (var item in listid)
            {
                items.Add(new SelectListItem() { Text = item.客戶名稱.ToString(), Value = item.Id.ToString() });
            }
            ViewBag.List客戶id = items;
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    rpo.Add(CustomData);
                    rpo.UnitOfWork.Commit();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(CustomData);
                }
            }
            return View(CustomData);
        }

        // GET: CustomContact/Edit/5
        public ActionResult Edit(int id)
        {
            var data = new 客戶聯絡人();
            List<SelectListItem> items = new List<SelectListItem>();
            var listid = rpoBasic.get客戶資料();
            foreach (var item in listid)
            {
                items.Add(new SelectListItem() { Text = item.客戶名稱.ToString(), Value = item.Id.ToString() });
            }
            ViewBag.List客戶id = items;
            return View(data);
        }

        // POST: CustomContact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, 客戶聯絡人 EditedData)
        {
            var data2 = new 客戶聯絡人();
            List<SelectListItem> items = new List<SelectListItem>();
            var listid = rpoBasic.get客戶資料();
            foreach (var item in listid)
            {
                items.Add(new SelectListItem() { Text = item.客戶名稱.ToString(), Value = item.Id.ToString() });
            }
            ViewBag.List客戶id = items;
            if (ModelState.IsValid)
            {
                try
                {
                    var data = rpo.get客戶聯絡人ByID(id);
                    data.Email = EditedData.Email;
                    data.客戶Id = EditedData.客戶Id;
                    data.姓名 = EditedData.姓名;
                    data.手機 = EditedData.手機;
                    data.職稱 = EditedData.職稱;
                    data.電話 = EditedData.電話;
                    rpo.Edit(data);
                    rpo.UnitOfWork.Commit();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(EditedData);
                }
            }
            return View(EditedData);
        }

        // GET: CustomContact/Delete/5
        public ActionResult Delete(int id)
        {
            var data = rpo.get客戶聯絡人ByID(id);
            data.是否已刪除 = true;
            rpo.Edit(data);
            rpo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
        
    }
}
