using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace theFood.WebUI.Models
{
    public class ProductModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceOnProduct { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public IEnumerable<SelectListItem> CategoryProducts { get;set;}
        public bool IsCheckBox { get; set; }
        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageName { get; set; }

    }
}