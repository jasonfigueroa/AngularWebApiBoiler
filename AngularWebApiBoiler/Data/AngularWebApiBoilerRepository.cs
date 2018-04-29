using AngularWebApiBoiler.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularWebApiBoiler.Data
{
    public class AngularWebApiBoilerRepository : IAngularWebApiBoilerRepository
    {
        private readonly AngularWebApiBoilerContext _ctx;
        private readonly ILogger<AngularWebApiBoilerRepository> _logger;

        public AngularWebApiBoilerRepository(AngularWebApiBoilerContext ctx, ILogger<AngularWebApiBoilerRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            _logger.LogInformation("GetAllProducts was called");
            return _ctx.Products.OrderBy(p => p.Title).ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products.Where(p => p.Category == category).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
