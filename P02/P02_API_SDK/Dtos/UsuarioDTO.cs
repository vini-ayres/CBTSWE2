using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_API_SDK.Dtos;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }
}
