using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Telefone : EntityBase
    {
        public int ContatoId { get; set; }
        public Contato Contato { get; set; }

        public int NumeroDDD { get; set; }

        public string NumeroTelefone { get; set; }
    }
}
