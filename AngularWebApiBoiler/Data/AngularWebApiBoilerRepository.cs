using AngularWebApiBoiler.Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Order> GetAllOrders()
        {
            // Include & ThenInclude are used to avoid a null return of items & products associated with the orders
            return _ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            // Good example of the logger being leveraged
            try
            {
                _logger.LogInformation("GetAllProducts was called");
                return _ctx.Products.OrderBy(p => p.Title).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.Id == id)
                .FirstOrDefault();
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
