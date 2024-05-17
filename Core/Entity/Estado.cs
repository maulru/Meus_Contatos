namespace Core.Entity
{
    public class Estado : EntityBase
    {
        public string Nome { get; set; }

        public int RegiaoId { get; set; }

        public Regiao Regiao { get; set; }

        public virtual ICollection <DDD> DDDs { get; set; }
    }
}
