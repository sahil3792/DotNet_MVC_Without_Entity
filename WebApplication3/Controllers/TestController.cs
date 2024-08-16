using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        ProductDAL pd = new ProductDAL();

        public ActionResult Index()
        {
            var data = pd.GetAllProducts();
            return View(data);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            pd.AddProduct(p);
            TempData["Success"] = "<script>alert('Product Added Successfully')</script>";
            return RedirectToAction("Index");  
        }

        public ActionResult DeleteProduct(int id)
        {
            pd.DeleteProduct(id);
            TempData["Success"] = "<script>alert('Product Added Successfully')</script>";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var data = pd.GetAllProducts().Find(x => x.Id.Equals(id));
            return View(data);
        }

        public ActionResult UpdateProduct(Product p)
        {

            pd.UpdateProduct(p);

            TempData["Success"] = "<script>alert('Product Added Successfully')</script>";
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            var data = pd.GetAllProducts().Find(x => x.Id.Equals(id));
            return View(data);
        }

        
    }
}