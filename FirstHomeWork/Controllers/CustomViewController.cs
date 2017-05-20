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
        CustomDataViewRepository rpo = RepositoryHelper.GetCustomDataViewRepository();
        // GET: CustomView
        public ActionResult Index()
        {
            var data = rpo.All();
            return View(data);
        }
    }
}