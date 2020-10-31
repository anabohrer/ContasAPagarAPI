using System.Collections.Generic;
using ContasAPagarAPI.Data;
using ContasAPagarAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContasAPagarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContasAPagarRepo _repositorio;
        public ContasController(IContasAPagarRepo repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public ActionResult <IEnumerable<ContaPaga>> GetContasCadastradas()
        {
            var contasCadastradas = _repositorio.BuscaContasCadastradas();
            return Ok(contasCadastradas);
        }
    }
}
