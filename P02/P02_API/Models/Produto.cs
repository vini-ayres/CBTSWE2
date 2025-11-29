namespace P02_API.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public float Preco { get; set; }
    public bool Ativo { get; set; }
    public int IdUsuarioCadastro { get; set; }
    public int IdUsuarioUpdate { get; set; }
}
