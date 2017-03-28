using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;
using theFood.WebUI.Abstract;
using theFood.WebUI.Models;

namespace theFood.WebUI.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipe _recipe;
        private readonly IIngridient _ingridient;

        public RecipeController()
        {
        }
        public RecipeController(IRecipe recipe, IIngridient ingridient)
        {
            _ingridient = ingridient;
            _recipe = recipe;
        }
        public ActionResult Recipe()
        {
          return PartialView("~/Views/Recipe/Recipe.cshtml",_recipe.Recipes);
        }

       [HttpGet]
        public ActionResult CurrentRecipe(int? Id)
        {
            var currentRecipe = _recipe.Recipes.First(x => x.Id == Id);
            return View("~/Views/Recipe/CurrentRecipe.cshtml", currentRecipe);
        }

        public PartialViewResult SearchRecipe()
        {
            try
            {
                var selectedProduct = CartRepoModel.CartRepository.Lines;
                List<Recipe> listRecipes = (from product in selectedProduct
                                            from ingr in _ingridient.Ingridients
                                            where ingr.ProductId == product.Product.Id
                                            select _recipe.Recipes.FirstOrDefault(x => x.Id == ingr.RecipeId)
                                            ).ToList();
                var list = listRecipes.Distinct();
                return PartialView("~/Views/Recipe/Recipe.cshtml",  !list.Any()?_recipe.Recipes:list);
            }
            catch 
            {

                return PartialView("~/Views/Recipe/Recipe.cshtml", _recipe.Recipes);
            }
           

          
        }
        
        
    }
}
