namespace Core.Entity
{
    public class Regiao :EntityBase
    {
        public string Nome { get; set; }

        public Estado Estado { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
