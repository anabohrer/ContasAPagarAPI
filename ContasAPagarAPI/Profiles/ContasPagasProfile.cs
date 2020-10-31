using AutoMapper;
using ContasAPagarAPI.Models;
using ContasAPagarAPI.Dtos;

namespace ContasAPagarAPI.Profiles
{
    public class ContasPagasProfile : Profile
    {
        public ContasPagasProfile()
        {
            CreateMap<ContaPaga, ContaPagaReadDto>()
            .ForMember(d => d.DataPagamento,
                expression => expression.MapFrom(s => s.DataPagamento.ToString("dd/MM/yyyy")))
            .ForMember(d => d.DataVencimento,
                 expression => expression.MapFrom(s => s.DataVencimento.ToString("dd/MM/yyyy")));
            CreateMap<ContaPagaCreateDto, ContaPaga>();
            CreateMap<ContaPagaUpdateDto, ContaPaga>();
        }
    }
}
