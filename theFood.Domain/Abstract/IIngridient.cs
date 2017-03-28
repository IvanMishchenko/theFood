using System.Linq;
using theFood.Domain.DbModel;

namespace theFood.Domain.Abstract
{
    public interface IIngridient
    {
        IQueryable<Ingridient> Ingridients { get; }
        void SaveIngridient(int recipeId, string[] checkedValues);
        Ingridient DeleteIngridient(int id);

    }
}
