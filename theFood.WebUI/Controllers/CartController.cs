using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using theFood.Domain.Abstract;
using theFood.Domain.Concrete;
using theFood.Domain.DbModel;
using theFood.WebUI.Abstract;
using theFood.WebUI.Models;

namespace theFood.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProduct _product;
        private readonly ICart _cart;
        private int _countCart;
        public CartController(int countCart)
        {
            _countCart = countCart;
        }

        public CartController(IProduct product, ICart cart)
        {
            _cart = cart;
            _countCart = 0;
            _product = product;
        }

        public PartialViewResult Index(string returnUrl)
        {
            
                return PartialView(new CartModel
                {
                    Cart = GetCart(),
                    ReturnUrl = returnUrl
                });
         
        }

        public ActionResult YourCart(string returnUrl)
        {
            return View(new CartModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public ActionResult AddtoCart(int productId)
        {
            var product = _product.Products.FirstOrDefault(x => x.Id == productId);
            
            if (product != null && Request.IsAjaxRequest())
            {
                GetCart().AddItem(product, 1);
                CartRepoModel.CartRepository = GetCart();
            }

            var productInCart = CartRepoModel.CartRepository.Lines.FirstOrDefault(x=>x.Product.Id==productId);
            if (productInCart != null && productInCart.Quantity == 1) 
            {
                return RedirectToAction("Index", "Cart");
            }
            return null;
        }

        private Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public void ClearCart()
        {
             
            CartRepoModel.CartRepository.Clear();
        }
        [HttpPost]
        public ActionResult RemoveProduct(int productId)
        {
            var product = _product.Products.FirstOrDefault(x => x.Id == productId);
            
            if (product != null && Request.IsAjaxRequest())
            {
                CartRepoModel.CartRepository.RemoveLine(product);
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("Index","Trouble");
        }
        
    }
}
