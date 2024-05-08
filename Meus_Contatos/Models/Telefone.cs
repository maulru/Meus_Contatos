namespace Meus_Contatos.Models
{
    public class Telefone
    {
        public int Id { get; set; }

        public virtual Contato Contato { get; set; }

        public int DDD { get; set; }

        public string NumeroTelefone { get; set; }
    }
}
