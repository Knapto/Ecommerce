using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> products;

        public ProductController(ApplicationDbContext context)
        {
            products = new Repository<Product>(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await products.GetAllAsync());
        }
    }
}
