using ProductApi.Models;

namespace ProductApi.Services;

public class ProductService
{
    private readonly List<Product> _products = new()
    {
        new Product
        {
            Id = 1,
            Nome = "Suporte de celular",
            Preco = 29.90m
        },

        new Product
        {
            Id = 2,
            Nome = "Vaso decorativo",
            Preco = 45.90m
        }
    };

    public List<Product> GetProducts()
    {
        return _products;
    }

    public Product? GetProductById(int id)
    {
        return _products.FirstOrDefault(product => product.Id == id);
    }

    public Product CreateProduct(string nome, decimal preco)
    {
        var product = new Product
        {
            Id = _products.Count + 1,
            Nome = nome,
            Preco = preco
        };

        _products.Add(product);

        return product;
    }

    public Product? UpdateProduct(int id, string nome, decimal preco)
    {
        var product = _products.FirstOrDefault(product => product.Id == id);

        if (product == null)
        {
            return null;
        }

        product.Nome = nome;
        product.Preco = preco;

        return product;
    }

    public bool DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(product => product.Id == id);

        if (product == null)
        {
            return false;
        }

        _products.Remove(product);

        return true;
    }
}