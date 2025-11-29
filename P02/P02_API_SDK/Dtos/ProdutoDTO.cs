using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_API_SDK.Dtos;

public class ProdutoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public float Preco { get; set; }
    public bool Ativo { get; set; }
    public int IdUsuarioCadastro { get; set; }
    public int IdUsuarioUpdate { get; set; }
}
