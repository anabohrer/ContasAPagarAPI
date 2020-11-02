using AutoMapper;
using ContasAPagarAPI.Models;
using ContasAPagarAPI.Dtos;
using System.Globalization;

namespace ContasAPagarAPI.Profiles
{
    public class ContasPagasProfile : Profile
    {
        public ContasPagasProfile()
        {
            CreateMap<ContaPaga, ContaPagaReadDto>()
            .ForMember(d => d.DataPagamentoStr,
                expression => expression.MapFrom(s => s.DataPagamento.ToString("dd/MM/yyyy")))
            .ForMember(d => d.DataVencimentoStr,
                 expression => expression.MapFrom(s => s.DataVencimento.ToString("dd/MM/yyyy")))
            .ForMember(d => d.ValorOriginalStr, 
                expression => expression.MapFrom(s => string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", s.ValorOriginal)))
            .ForMember(d => d.ValorCorrigido,
                expression => expression.MapFrom(s => string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", s.ValorCorrigido)));
            CreateMap<ContaPagaCreateDto, ContaPaga>();
            CreateMap<ContaPagaUpdateDto, ContaPaga>();
        }
    }
}
