using FirstHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstHomeWork.Controllers
{
    public class CustomViewController : Controller
    {
        // GET: CustomView
        public ActionResult Index()
        {
            客戶資料Entities db = new 客戶資料Entities();
            var data = db.CustomDataView.ToList();
            return View(data);
        }
    }
}