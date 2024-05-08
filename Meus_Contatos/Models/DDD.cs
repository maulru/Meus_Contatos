namespace Meus_Contatos.Models
{
    public class DDD
    {
        public DDD() { }
        public DDD(int ID) { }
        public int ID { get; set; }
        public virtual Estado Estado { get; set; }
        public int CodigoDDD { get; set; }
    }
}
