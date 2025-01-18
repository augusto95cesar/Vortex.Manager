using System.ComponentModel;

namespace Vortex.Manager.Application.DTOs.Input.Usuario
{
    public class LoginDTO
    {
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        public string Password { get; set; }
    }
}
