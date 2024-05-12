using AutoMapper;
using Meus_Contatos.Data.Dto;
using Meus_Contatos.Models;

namespace Meus_Contatos.Profiles
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile() {
            CreateMap<CreateContatoDbo, Contato>();
            CreateMap<Contato,ReadContatoDbo>();
        }
    }
}
