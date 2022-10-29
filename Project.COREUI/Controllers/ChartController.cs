using Microsoft.AspNetCore.Mvc;
using Project.COREUI.Models;
using System.Collections.Generic;

namespace Project.COREUI.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductChart()
        {
            List<Product> productClasses = new List<Product>();

            productClasses.Add(new Product
            {
                productname = "Buğday",
                productvalue = 850
            });

            productClasses.Add(new Product
            {
                productname = "Mercimek",
                productvalue = 480
            });

            productClasses.Add(new Product
            {
                productname = "Arpa",
                productvalue = 250
            });

            productClasses.Add(new Product
            {
                productname = "Pirinç",
                productvalue = 120
            });

            productClasses.Add(new Product
            {
                productname = "Domates",
                productvalue = 960
            });

            return Json(new { jsonlist = productClasses });

        }
    }
}
