using Microsoft.AspNetCore.Mvc;
using ProductApi.Services;
using ProductApi.DTOs;


namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productService.GetProducts();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto dto)
    {
        var product = _productService.CreateProduct(
            dto.Nome,
            dto.Preco
        );

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            product
        );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, UpdateProductDto dto)
    {
        var product = _productService.UpdateProduct(
            id,
            dto.Nome,
            dto.Preco
        );

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var deleted = _productService.DeleteProduct(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}