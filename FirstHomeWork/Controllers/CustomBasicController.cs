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
        //客戶資料Entities db = new 客戶資料Entities();
        客戶資料Repository rpo = RepositoryHelper.Get客戶資料Repository();
        //[Authorize]
        // GET: CustomBasic
        public ActionResult Index()
        {
            var data = rpo.get客戶資料();
            return View(data);
        }

        //[Authorize]
        [HttpPost]
        public ActionResult Index(string CustomName)
        {
            var data = rpo.get客戶資料().Where(x=> x.客戶名稱.Contains(CustomName)).ToList();
            return View(data);
        }

        //[Authorize]
        // GET: CustomBasic/Details/5
        public ActionResult Details(int id)
        {
            var data = rpo.get客戶資料ByID(id);
            return View(data);
        }

        // GET: CustomBasic/Create
        //[Authorize]
        public ActionResult Create()
        {
            var data = new 客戶資料();
            return View(data);
        }

        // POST: CustomBasic/Create
        //[Authorize]
        [HttpPost]
        public ActionResult Create(客戶資料 CustomData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    rpo.Add(CustomData);
                    rpo.UnitOfWork.Commit();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(CustomData);
                }
            }
            return View(CustomData);
        }

        // GET: CustomBasic/Edit/5
        public ActionResult Edit(int id)
        {
            var data = rpo.get客戶資料ByID(id);
            return View(data);
        }

        // POST: CustomBasic/Edit/5
        //[Authorize]
        [HttpPost]
        public ActionResult Edit(int id, 客戶資料 EditedData)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var data = rpo.get客戶資料ByID(id);
                    data.Email = EditedData.Email;
                    data.傳真 = EditedData.傳真;
                    data.地址 = EditedData.地址;
                    data.客戶名稱 = EditedData.客戶名稱;
                    data.統一編號 = EditedData.統一編號;
                    data.電話 = EditedData.電話;
                    rpo.Edit(data);
                    rpo.UnitOfWork.Commit();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(id);
                }
            }
            return View(id);
        }

        // GET: CustomBasic/Delete/5
        //[Authorize]
        public ActionResult Delete(int id)
        {
            var data = rpo.get客戶資料ByID(id);
            data.是否已刪除 = true;
            rpo.Edit(data);
            rpo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
        
    }
}
