using System.Collections.Generic;
using AutoMapper;
using ContasAPagarAPI.Data;
using ContasAPagarAPI.Dtos;
using ContasAPagarAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContasAPagarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContasAPagarRepo _repositorio;
        private readonly IMapper _mapper;

        public ContasController(IContasAPagarRepo repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        [HttpGet("{id}", Name = "GetContaCadastrada")]
        public ActionResult<ContaPagaReadDto> GetContaCadastrada(int id)
        {
            var contaCadastrada = _repositorio.BuscaContaCadastrada(id);
            return Ok(_mapper.Map<ContaPagaReadDto>(contaCadastrada));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContaPagaReadDto>> GetContasCadastradas()
        {
            var contasCadastradas = _repositorio.BuscaContasCadastradas();
            return Ok(_mapper.Map<IEnumerable<ContaPagaReadDto>>(contasCadastradas));
        }

        [HttpPost]
        public ActionResult<ContaPagaReadDto> CriaContaPaga(ContaPagaCreateDto contaPagaCreateDto)
        {
            var contaPagaModel = _mapper.Map<ContaPaga>(contaPagaCreateDto);
            _repositorio.CriarConta(contaPagaModel);

            var contaPagaReadDto = _mapper.Map<ContaPagaReadDto>(contaPagaModel);
            return CreatedAtRoute(nameof(GetContaCadastrada), new { contaPagaModel.Id }, contaPagaCreateDto);
        }

        [HttpPut("{id}")]
        public ActionResult AtualizaConta(int id, ContaPagaUpdateDto contaPagaUpdateDto)
        {
            var contaCadastrada = _repositorio.BuscaContaCadastrada(id);
            if (contaCadastrada == null)
                return NotFound();

            _mapper.Map(contaPagaUpdateDto, contaCadastrada);
            _repositorio.AtualizaContaCadastrada(contaCadastrada);
            _repositorio.SalvarMudancas();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeletaConta(int id)
        {
            var contaCadastrada = _repositorio.BuscaContaCadastrada(id);
            if (contaCadastrada == null)
                return NotFound();
            _repositorio.DeletarContaCadastrada(contaCadastrada);
            _repositorio.SalvarMudancas();
            return NoContent();
        }
    }
}
