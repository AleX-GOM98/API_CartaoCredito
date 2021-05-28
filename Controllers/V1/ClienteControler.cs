using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API_CartaoCredito.Controllers
{
    [ApiController]
    [Route("V1/[controller]")]
    public class ClienteControler : ControllerBase
    {
        
        private static readonly string[] Email = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
         
       private readonly ILogger<CleinteControler> _logger;

       
    }
    [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirCliente([FromBody] ClienteContext ClienteContext)
        {
            try
            {
                var cliente = await _logger.Inserir(ClienteContext);

                return Ok(cliente);
            }
            catch (CleinteJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um cleinte com este email");
            }
        }

       
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> AtualizarCliente([FromRoute] Guid id, [FromBody] ClienteContext ClienteContext)
        {
            try
            {
                await _logger.Atualizar(id, ClienteContext);

                return Ok();
            }
            catch (ClienteNaoCadastradoException ex)
            {
                return NotFound("Não existe este cliente");
            }
        }

        
        [HttpPatch("{id:guid}/email/{email:string}")]
        public async Task<ActionResult> AtualizarCliente([FromRoute] Guid id, [FromRoute] string email)
        {
            try
            {
                await _logger.Atualizar(id,email);
                await GerarCC.AtualizarCliente();
                return Ok();
            }
            catch (ClienteNaoCadastradoException ex)
            {
                return NotFound("Não existe este Cliente");
            }
        }

       
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _logger.Remover(idJogo);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }


}
