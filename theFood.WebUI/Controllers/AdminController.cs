using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using Castle.Core.Internal;
using theFood.Domain.Abstract;
using theFood.Domain.DbModel;
using theFood.WebUI.Abstract;
using theFood.WebUI.Abstract.Concrete;
using theFood.WebUI.Models;

namespace theFood.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProduct _product;
        private readonly IRecipe _recipe;
        private readonly ICategoryRecipe _categoryRecipe;
        private readonly IUser _user;
        private readonly ICategoryProduct _categoryProduct;
        private readonly IEatTime _eatTime;
        private readonly IIngridient _ingridient;
        //
        // GET: /Admin/
        public AdminController()
        {
        }

        public AdminController(IProduct product, ICategoryRecipe categoryRecipe, IRecipe recipe, IUser user, ICategoryProduct categoryProduct, IEatTime eatTime, IIngridient ingridient)
        {
            _product = product;
            _categoryRecipe = categoryRecipe;
            _recipe = recipe;
            _user = user;
            _categoryProduct = categoryProduct;
            _eatTime = eatTime;
            _ingridient = ingridient;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Product()
        {
            return View(_product.Products);
        }

        public ViewResult Recipe()
        {
            return View(_recipe.Recipes);
        }

        public ViewResult Users()
        {
            return View(_user.Users);
        }

        public ViewResult CreateProduct()
        {
            var newProduct = new ProductModel
            {
                CategoryProducts = ListItem.ToSelectListItems(_categoryProduct.CategoryProducts)
            };

            return View("EditProduct", newProduct);
        }

        public ViewResult CreateRecipe()
        {
            ICollection<ProductModel> productList = (from prod in _product.Products
                                                     select new ProductModel
                                                     {
                                                         Id = prod.Id,
                                                         Name = prod.Name,
                                                         PriceOnProduct = (decimal)prod.PriceOnProduct,
                                                         Description = prod.Description,
                                                         IsCheckBox = false
                                                     }).ToList();

            var newRecipe = new RecipeModel
            {
                Id = 0,
                CookingTime = DateTime.Now.Date,
                Products = productList,
                CategoryRecipeList = ListItem.ToSelectListItems(_categoryRecipe.CategoryRecipes),
                EatingTimeList = ListItem.ToSelectListItems(_eatTime.EatingTimes)
            };
            return View("EditRecipe", newRecipe);
        }

        public ViewResult CreateUser()
        {
            return View("EditUser", new User());
        }
        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentProduct = _product.Products.FirstOrDefault(x => x.Id == id);
           

            if (currentProduct == null)
            {
                return HttpNotFound();
            }

       
    
                var productModel = new ProductModel
                {
                    Id = currentProduct.Id,
                    Name = currentProduct.Name,
                    Description = currentProduct.Description,
                    PriceOnProduct = (decimal)currentProduct.PriceOnProduct,
                    CategoryProducts = ListItem.ToSelectListItems(currentProduct, _categoryProduct.CategoryProducts),
                    ImageData = currentProduct.ImageData,
                    ImageName = currentProduct.ImageName
                    
                };
       
            return View(productModel);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ProductModel product, string categoryId, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                
                var entityProduct = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    PriceOnProduct = product.PriceOnProduct,
                    Description = product.Description,
                    CategoryProductId = Convert.ToInt32(categoryId),
                };
                if (image!=null)
                {
                    entityProduct.ImageData = new byte[image.ContentLength];
                    entityProduct.ImageName = image.ContentType;
                    image.InputStream.Read(entityProduct.ImageData, 0, image.ContentLength);
                }

                _product.SaveProduct(entityProduct);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
            }

            return RedirectToAction("Product");
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            var deleteProduct = _product.DeleteProduct(id);
            if (deleteProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deleteProduct.Name);
            }
            return RedirectToAction("Product");
        }

        [HttpGet]
        public ActionResult EditRecipe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentRecipe = _recipe.Recipes.FirstOrDefault(x => x.Id == id);
            if (currentRecipe == null)
            {
                return HttpNotFound();
            }

            var productsForCurrentResipe =
                _ingridient.Ingridients.Where(x => x.RecipeId == id)
                                                    .Select(p => p.ProductId).ToList();

           


            ICollection<ProductModel> checkedProduct = (from p in productsForCurrentResipe
                from prod in _product.Products
                where p == prod.Id
                select new ProductModel
                {
                    Id = prod.Id, 
                    Name = prod.Name, 
                    PriceOnProduct = (decimal) prod.PriceOnProduct, 
                    Description = prod.Description, 
                    IsCheckBox = true
                }).ToList();
            
            ICollection<ProductModel> productList = new List<ProductModel>();
          
            foreach (var prod in _product.Products)
            {
                var check = checkedProduct.FirstOrDefault(x => x.Id == prod.Id);
               productList.Add(new ProductModel
               {
                   Id = prod.Id,
                   Name = prod.Name,
                   PriceOnProduct = (decimal)prod.PriceOnProduct,
                   Description = prod.Description,
                   IsCheckBox = (check!=null)
               });
            }
          

            var recipeModel = new RecipeModel
            {
                Id = currentRecipe.Id,
                Text = currentRecipe.Text,
                LikeDislike = currentRecipe.LikeDislike,
                RatingRecipe = currentRecipe.RatingRecipe,
                CookingTime = currentRecipe.CookingTime,
                Name = currentRecipe.Name,
                Price = currentRecipe.Price,
                Products = productList,
                CategoryRecipeList = ListItem.ToSelectListItems(currentRecipe,_categoryRecipe.CategoryRecipes),
                EatingTimeList=ListItem.ToSelectListItems(currentRecipe, _eatTime.EatingTimes)

            };
            
            
            return View(recipeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRecipe(RecipeModel currentRecipe, string categoryRecipeId, string eatTimeId, string[] checkedValues)
        {
            var guidValue = GenerateGUIDValue();	
            if (ModelState.IsValid)
            {
                var entityRecipe = new Recipe
                {
                    Id = currentRecipe.Id,
                    Text = currentRecipe.Text,
                    LikeDislike = currentRecipe.LikeDislike,
                    RatingRecipe = currentRecipe.RatingRecipe,
                    CookingTime = currentRecipe.CookingTime,
                    Name = currentRecipe.Name,
                    Price = currentRecipe.Price,
                    CategoryRecipeId = Convert.ToInt32(categoryRecipeId),
                    EatingTimeId = Convert.ToInt32(eatTimeId),
                    UniqueName = guidValue
                };
                _recipe.SaveRecipe(entityRecipe);
                TempData["message"] = string.Format("{0} has been saved", entityRecipe.Name);
            }

            var recipe = _recipe.Recipes.FirstOrDefault(x => x.Id == currentRecipe.Id);
            currentRecipe.CategoryRecipeList = ListItem.ToSelectListItems(recipe, _categoryRecipe.CategoryRecipes);
            currentRecipe.EatingTimeList = ListItem.ToSelectListItems(recipe, _eatTime.EatingTimes);

            var current = _recipe.Recipes.FirstOrDefault(x => x.UniqueName.Contains(guidValue));
            _ingridient.SaveIngridient(current.Id, checkedValues);

          return RedirectToAction("Recipe", "Admin"); 
        }

       

        private string GenerateGUIDValue()
        {
            return string.Concat( Convert.ToString(Guid.NewGuid()).Split('-'));	
        }
        [HttpPost]
        public ActionResult DeleteRecipe(int id)
        {
            var deleteRecipe = _recipe.DeleteRecipe(id);
            if (deleteRecipe != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deleteRecipe.Name);
            }
            return RedirectToAction("Recipe");
        }

        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var currentPUser = _user.Users.FirstOrDefault(x => x.Id == id);
            if (currentPUser == null)
            {
                return HttpNotFound();
            }
            return View(currentPUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                _user.AddUser(user);
                TempData["message"] = string.Format("{0} has been saved", user.FirstName+" "+user.SecondName);

                RedirectToAction("Users");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var deleteUser = _user.DeleteUser(id);
            if (deleteUser != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deleteUser.FirstName+" "+deleteUser.SecondName);
            }
            return RedirectToAction("Users");
        }

        public FileContentResult GetImage(int Id)
        {
            var product = _product.Products.FirstOrDefault(x => x.Id == Id);
            return product!=null ? File(product.ImageData, product.ImageName) : null;
        }

    }

   
}
