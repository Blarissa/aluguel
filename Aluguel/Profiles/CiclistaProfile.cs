using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Pais;
using Aluguel.Data.Dtos.Passaporte;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using AutoMapper;

namespace Aluguel.Profiles
{
    public class CiclistaProfile : Profile 
    { 
        public CiclistaProfile()
        {
            CreateMap<ReadPaisDto, Pais>();

            CreateMap<Pais, ReadPaisDto>();

            CreateMap<CreatePassaporteDto, Passaporte>();

            CreateMap<CreatePassaporteDto, Passaporte>();

            CreateMap<Passaporte, CreatePassaporteDto>();
            
            CreateMap<CreateCiclistaDto, Ciclista>();

            CreateMap<CreateMeioDePagamentoDto, CartaoDeCredito>();

            CreateMap<ReadCiclistaDto, Ciclista>();

            CreateMap<Ciclista, ReadCiclistaDto>();
        }
    }
}