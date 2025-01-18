using System.ComponentModel;

namespace Vortex.Manager.Application.DTOs.Input.Usuario
{
    public class CreateUsuarioDTO : LoginDTO
    {
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}
