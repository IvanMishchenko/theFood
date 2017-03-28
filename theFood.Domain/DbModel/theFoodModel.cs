namespace theFood.Domain.DbModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class theFoodModel : DbContext
    {
        
        public theFoodModel()
            : base("name=Model_theFoodDbContainer")
        {
        }

        public virtual DbSet<User> UserSet { get; set; }
        public virtual DbSet<Recipe> RecipeSet { get; set; }
        public virtual DbSet<CategoryRecipe> CategoryRecipeSet { get; set; }
        public virtual DbSet<EatingTime> EatingTimeSet { get; set; }
        public virtual DbSet<Comment> CommentSet { get; set; }
        public virtual DbSet<Product> ProductSet { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProductSet { get; set; }
        public virtual DbSet<Ingridient> IngridientSet { get; set; }
        public virtual DbSet<UserRecipe> UserRecipeSet { get; set; }
        public virtual DbSet<UserPost> UserPostSet { get; set; }
        public virtual DbSet<Subscriber> SubscriberSet { get; set; }
        public virtual DbSet<Picture> PictureSet { get; set; }
        public virtual DbSet<UserFavoritRecipe> UserFavoritRecipeSet { get; set; }



    }

}