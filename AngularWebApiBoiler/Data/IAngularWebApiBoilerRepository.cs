using System.Collections.Generic;
using AngularWebApiBoiler.Data.Entities;

namespace AngularWebApiBoiler.Data
{
    public interface IAngularWebApiBoilerRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}