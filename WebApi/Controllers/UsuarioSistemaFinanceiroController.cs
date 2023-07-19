using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _InterfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _UsuarioSistemaFinanceiro;

        public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro,
            IUsuarioSistemaFinanceiroServico usuarioSistemaFinanceiro)
        {
            _InterfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _UsuarioSistemaFinanceiro = usuarioSistemaFinanceiro;
        }
        [HttpGet("/api/ListarUsuarioSistema")]
        [Produces("application/json")]
        public async Task<object> ListarUsuarioSistema(int idSistema)
        {
            return await _InterfaceUsuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }

        [HttpPost("/api/CadastrarUsuarioSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _UsuarioSistemaFinanceiro.CadastrarUsuarioNoSistema(new UsuarioSistemaFinanceiro
                {
                    IdSistema = idSistema,
                    EmailUsuario = emailUsuario,
                    Administrador = false,
                    SistemaAtual = true,
                });
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        [HttpDelete("/api/DeletarUsuarioSistemaFinanceiroById")]
        [Produces("application/json")]
        public async Task<object> DeletarUsuarioSistemaFinanceiroById(int id, string emailUsuario)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _InterfaceUsuarioSistemaFinanceiro.GetEntityById(id);

                await _InterfaceUsuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }
            return Task.FromResult(true);

        }
    }
}
