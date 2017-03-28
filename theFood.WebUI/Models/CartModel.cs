using theFood.Domain.Concrete;

namespace theFood.WebUI.Models
{
    public class CartModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
    public static class CartRepoModel
    {
        public static Cart CartRepository { get; set; }
    }
}