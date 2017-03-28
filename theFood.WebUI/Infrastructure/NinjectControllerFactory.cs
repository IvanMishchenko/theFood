using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using theFood.Domain;
using theFood.Domain.Abstract;
using theFood.Domain.Concrete;
using theFood.Domain.DbModel;
using theFood.WebUI.Abstract.Concrete;
using theFood.WebUI.Abstract.Infrastructure;

namespace theFood.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBinding();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _ninjectKernel.Get(controllerType);
        }

        private void AddBinding()
        {
            //Mock<IEatTime> mock = new Mock<IEatTime>();
            //mock.Setup(m => m.EatingTimes).Returns(new List<EatingTime>
            //{
            //    new EatingTime {Id = 1, Name = "Blabla"},
            //      new EatingTime {Id = 2, Name = "oloolol"}
            //}.AsQueryable());
            _ninjectKernel.Bind<IProduct>().To<ProductRepository>(); //ToConstant(mock.Object);
            _ninjectKernel.Bind<ICategoryRecipe>().To<CategoryRecipeRepository>();
            _ninjectKernel.Bind<IEatTime>().To<EatTimeRepository>();
            _ninjectKernel.Bind<IRecipe>().To<RecipeRepository>();
            _ninjectKernel.Bind<IUser>().To<UserRepository>();
            _ninjectKernel.Bind<ICategoryProduct>().To<CategoryProductRepository>();
            _ninjectKernel.Bind<IAuthenticationProvider>().To<FormAuthenticationProvider>();
            _ninjectKernel.Bind<IIngridient>().To<IngridientRepository>();
            _ninjectKernel.Bind<ICart>().To<Cart>();
        }
    }
}