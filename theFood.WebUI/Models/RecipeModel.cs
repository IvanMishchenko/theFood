using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using theFood.Domain.DbModel;

namespace theFood.WebUI.Models
{
    public class RecipeModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public int LikeDislike { get; set; }
        public int RatingRecipe { get; set; }
        //[DataType(DataType.Time)]
        public DateTime CookingTime { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<ProductModel> Products { get; set; } 
        public IEnumerable<SelectListItem> CategoryRecipeList { get; set; }
        public IEnumerable<SelectListItem> EatingTimeList { get; set; }
    }
}