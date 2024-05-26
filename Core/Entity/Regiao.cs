namespace Core.Entity
{
    public class Regiao : EntityBase
    {
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public ICollection<DDD> DDDs { get; set; }
    }
}
