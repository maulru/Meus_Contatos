﻿namespace Meus_Contatos.Models
{
    public class Contato
    {
        public Contato() { }

        public Contato(int id) { }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
