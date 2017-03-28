using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using theFood.Domain.Abstract;
using theFood.WebUI.Abstract;

namespace theFood.WebUI.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
       
        private readonly IProduct _product;
        private readonly IRecipe _recipe;


        public SearchController( IRecipe recipe, IProduct product)
        {
            _recipe = recipe;
            _product = product;
        }

        [HttpPost]
        public PartialViewResult Search(string searchValue)
        {
            //var resultProduct = (from product in _product.Products
            //                        where product.Name.ToLower().Contains(searchValue.ToLower()) 
            //                            select product 
            //                    ).ToList();
            if (searchValue != null && Request.IsAjaxRequest())
            {
                var resultRecipe = (from recipe in _recipe.Recipes
                    where recipe.Name.ToLower().Contains(searchValue.ToLower())
                    select recipe
                    ).ToList();

                return PartialView("~/Views/Recipe/Recipe.cshtml", resultRecipe);
            }
            return null;
        }

    }
}
