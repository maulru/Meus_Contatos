namespace Meus_Contatos.Models
{
    public class Estado
    {
        public int Id { get; set; }

        public virtual Regiao Regiao { get; set; }

        public string? Nome { get; set; }
    }
}
