using CadastroUsuario.Core.Base.Model;
using System.ComponentModel.DataAnnotations;

namespace CadastroUsuario.Model
{
    public enum Escolaridade
    {
        INFANTIL = 1,
        FUNDAMENTAL = 2,
        MEDIO = 3,
        SUPERIOR = 4
    }
    public class UsuarioModel : BaseModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }
}
