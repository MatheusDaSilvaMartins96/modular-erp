namespace ProductApi.DTOs;

public class CreateProductDto
{
    public string Nome { get; set; } = string.Empty;

    public decimal Preco { get; set; }
}