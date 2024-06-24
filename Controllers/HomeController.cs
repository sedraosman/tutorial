using Microsoft.AspNetCore.Mvc;
using sedra_0sman.Models;
using System.Diagnostics;
using System.Linq;
namespace sedra_0sman.Controllers
{
    public class HomeController : Controller
    {
       

        [HttpGet]

        public IActionResult Index()
        {
             SdrContext db = new SdrContext();
           var Message= db.ContactUs.ToList();
            return View(Message);

          
        }


       

       

        public IActionResult Jewellery()
        {
            SdrContext db = new SdrContext();
           var Jewellery= db.Products.ToList();
            return View(Jewellery);
        }

        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SaveContact(ContactU model)
        {
            SdrContext db = new SdrContext();
            db.ContactUs.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BuyNow()
        {

            return View();
        }
      
        public IActionResult SaveContact(BuyNow modl)
        {
            SdrContext db = new SdrContext();
            db.BuyNow.Add(modl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Jewellery(int productId)
        {
            SdrContext db = new SdrContext();
            db.Products.Find(productId);
           

            var cartItem = new Cart
            {
                Productid = productId,
               
            };

            db.Carts.Add(cartItem);
            db.SaveChanges();

            return RedirectToAction("Jewellery");
        }
        public IActionResult About()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
