using Marketplace.main.Domain;
using Marketplace.main.Infrastructure;

using Microsoft.AspNetCore.Mvc;

namespace Marketplace.main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketplaceController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public MarketplaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Ping")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Ping()
        {
            return Ok("pong");
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetAllProducten()
        {
            IEnumerable<Product> model = _context.Products.ToList();
            //IEnumerable<Product> model = new List<Product>
            //{
            //    new(){ Id = 101, Naam="Marker", Prijs=1.30M },
            //    new(){ Id = 102, Naam="Muis", Prijs=11.99M },
            //};
            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}