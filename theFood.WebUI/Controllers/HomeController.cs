using System;
using System.Linq;
using System.Web.Mvc;
using theFood.Domain.Abstract;

namespace theFood.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly IProduct _product;
        public HomeController() { }
        public HomeController(IProduct product)
        {
            _product = product;
        }

        public ViewResult Index()
        {
         
          
            double sizeFrame = _product.Products.Count()/ 18.0;

            try
            {

                var countAfterPoint = Convert.ToInt32(sizeFrame.ToString().Substring(sizeFrame.ToString().IndexOf(',') + 1, 3));
                var countBehindPoint = Convert.ToInt32(sizeFrame.ToString().Substring(0, sizeFrame.ToString().IndexOf(',')));

                ViewBag.CountCarouselSlider = countAfterPoint > 0 ? countBehindPoint + 1 : countBehindPoint;
            }
            catch
            {

                ViewBag.CountCarouselSlider = sizeFrame;
            }

          
          

            return View(_product.Products);
        }



    }
}
