using System.ComponentModel.DataAnnotations;

namespace Meus_Contatos.Data.Dto
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<ReadContatoDbo> Contatos { get; set; }

    }
}
