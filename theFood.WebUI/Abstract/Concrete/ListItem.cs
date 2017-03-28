using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using theFood.Domain.DbModel;

namespace theFood.WebUI.Abstract.Concrete
{
    public class ListItem
    {
        
     
        public static IEnumerable<SelectListItem> ToSelectListItems(Product product, IEnumerable<CategoryProduct> category)
        {
            

            return category
                .OrderBy(p => p.Name)
                        .Select(p =>
                            new SelectListItem
                            {
                                Value = p.Id.ToString(),
                                Text = p.Name,
                                Selected = (p.Id == product.CategoryProductId)
                            });
        }
        public static IEnumerable<SelectListItem> ToSelectListItems(IEnumerable<CategoryProduct> category)
        {


            return category
                .OrderBy(p => p.Name)
                        .Select(p =>
                            new SelectListItem
                            {
                                Value = p.Id.ToString(),
                                Text = p.Name,
                                Selected = false
                            });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(Recipe recipe, IEnumerable<CategoryRecipe> category)
        {


            return category
                .OrderBy(p => p.Name)
                        .Select(p =>
                            new SelectListItem
                            {
                                Value = p.Id.ToString(),
                                Text = p.Name,
                                Selected = (p.Id == recipe.CategoryRecipeId)
                            });
        }
        public static IEnumerable<SelectListItem> ToSelectListItems(IEnumerable<CategoryRecipe> category)
        {


            return category
                .OrderBy(p => p.Name)
                        .Select(p =>
                            new SelectListItem
                            {
                                Value = p.Id.ToString(),
                                Text = p.Name,
                                Selected = false
                            });
        }
        public static IEnumerable<SelectListItem> ToSelectListItems(Recipe recipe, IEnumerable<EatingTime> category)
        {


            return category
                .OrderBy(p => p.Name)
                        .Select(p =>
                            new SelectListItem
                            {
                                Value = p.Id.ToString(),
                                Text = p.Name,
                                Selected = (p.Id == recipe.EatingTimeId)
                            });
        }
        public static IEnumerable<SelectListItem> ToSelectListItems(IEnumerable<EatingTime> category)
        {


            return category
                .OrderBy(p => p.Name)
                        .Select(p =>
                            new SelectListItem
                            {
                                Value = p.Id.ToString(),
                                Text = p.Name,
                                Selected = false
                            });
        }
    }
}