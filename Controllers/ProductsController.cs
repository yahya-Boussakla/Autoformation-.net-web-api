using Microsoft.AspNetCore.Mvc;
using SimpleApi.Models;

namespace SimpleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> products =
    [
        new Product { Id = 1, Name = "Laptop", Price = 999.99m },
        new Product { Id = 2, Name = "Mouse", Price = 19.99m },
        new Product { Id = 3, Name = "Keyboard", Price = 49.99m }
    ];

    // GET: api/products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(products);
    }

    // GET api/products/5
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = products.Find(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    // POST api/products
    [HttpPost]
    public ActionResult<Product> Post([FromBody] Product product)
    {
        products.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }
}