using Meus_Contatos.Models;
using System.ComponentModel.DataAnnotations;

namespace Meus_Contatos.Data.Dto
{
    public class CreateContatoDbo
    {
        [Required(ErrorMessage ="O conteúdo do campo Nome é obrigatório.")]
        public string Nome { get; set; }
        public string Email {  get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}
