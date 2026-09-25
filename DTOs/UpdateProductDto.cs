namespace ProductApi.DTOs;

public class UpdateProductDto
{
    public string Nome { get; set; } = string.Empty;

    public decimal Preco { get; set; }
}