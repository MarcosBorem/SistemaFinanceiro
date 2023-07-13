using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceSistemaFinanceiro _InterfaceSistemaFinanciero;
        private readonly ISistemaFinanceiroServico _ISistemaFinanceiro;

        public SistemaFinanceiroController(InterfaceSistemaFinanceiro interfaceSistemaFinanciero, ISistemaFinanceiroServico iSistemaFinanceiro)
        {
            _InterfaceSistemaFinanciero = interfaceSistemaFinanciero;
            _ISistemaFinanceiro = iSistemaFinanceiro;
        }
        [HttpGet("/api/ListarSistemaUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarUsuarios(string emailUsuario)
        {
            return await _InterfaceSistemaFinanciero.ListaSistemasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _ISistemaFinanceiro.AdicionarSistemaFinanceiro(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _ISistemaFinanceiro.AtualizarSistemaFinanceiro(sistemaFinanceiro);
            return Task.FromResult(sistemaFinanceiro);
        }
        [HttpGet("/api/ObterSistemaFinanceiroById")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiroById(int  id)
        {
            return await _InterfaceSistemaFinanciero.GetEntityById(id);            
        }

        [HttpDelete("/api/DeletarSistemaFinanceiroById")]
        [Produces("application/json")]
        public async Task<object> DeletarSistemaFinanceiroById(int id)
        {
            try
            {
                var sistemafinanceiro = await _InterfaceSistemaFinanciero.GetEntityById(id);
                return _InterfaceSistemaFinanciero.Delete(sistemafinanceiro);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
