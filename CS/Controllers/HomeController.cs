using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T362981MVC {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        public ActionResult GridViewPartial() {
           var model =  Enumerable.Range(0, 10).Select(i => new
            {
                ProductID = i,
                ProductName1 = "ProductName " + i,
                ProductName2 = "ProductName " + i,
                ProductName3 = "ProductName " + i,
                ProductName4 = "ProductName " + i,
                ProductName5 = "ProductName " + i
            });
            return PartialView(model);
        }
    }
}