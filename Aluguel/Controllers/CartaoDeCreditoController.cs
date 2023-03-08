using Aluguel.Data;
using Aluguel.Data.Dao.Cartao;
using Aluguel.Data.Dtos.Cartao;
using Aluguel.Models;
using Aluguel.Validacao.Cartao;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Aluguel.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CartaoDeCreditoController : ControllerBase
    {
        private readonly AluguelContexto contexto;
        private readonly CartaoDeCreditoDao store;
        private IMapper mapper;
        public CartaoDeCreditoController(AluguelContexto ctxt, IMapper map)
        {
            contexto = ctxt;
            store = new CartaoDeCreditoDao(ctxt);
            mapper = map;
        }

        [HttpGet("{idCiclista}")]
        public IActionResult GetCartaoDeCredito([FromRoute] string idCiclista)
        {
            try {

                Guid idTransformado = Guid.Parse(idCiclista);

                var cartaoAchado = store.BuscarPorIdCiclista(idTransformado);
                if(cartaoAchado == null) {
                    //Novo Erro
                    return NotFound();
                }

                var cartaoDto = mapper.Map<ReadCartaoDto>(cartaoAchado);
            
                return Ok(cartaoDto);
            }
            catch(FormatException formEx) {
                return UnprocessableEntity();
            }
            catch(Exception e) {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        [HttpPut("{idCiclista}")]
        public IActionResult PutCartaoDeCredito([FromRoute] string idCiclista, [FromBody] UpdateCartaoDeCreditoDto novosDados)
        {
            try {
                Guid idTransformado = Guid.Parse(idCiclista);

                CartaoDeCredito? cartaoAchado = store.BuscarPorIdCiclista(idTransformado);
                if(cartaoAchado == null) {
                    //retornar erro
                    return NotFound();
                }

                var classeValidadora = new UpdateCartaoDeCreditoValidation();
                if(!classeValidadora.ValidaUpdateCartao(novosDados)) {
                    //retornar erro
                    return UnprocessableEntity();
                }

                CartaoDeCredito novosDadosMapeados = mapper.Map<CartaoDeCredito>(novosDados);

                store.AlterarCartaoPorIdCiclista(idTransformado, novosDadosMapeados);

                return CreatedAtAction(nameof(GetCartaoDeCredito), new { idCiclista = idCiclista }, novosDados);

            }
            catch(FormatException formEx) {
                return UnprocessableEntity();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
    }
}
