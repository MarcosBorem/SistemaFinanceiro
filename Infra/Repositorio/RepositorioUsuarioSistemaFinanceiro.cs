using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextoBase> _OptionsBuilder;

        public RepositorioUsuarioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextoBase>();
        }

        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int IdSistema)
        {
            using (var banco = new ContextoBase(_OptionsBuilder))
            {
                return await
                    banco.UsuarioSistemaFinanceiro
                    .Where(s => s.IdSistema == IdSistema).AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var banco = new ContextoBase(_OptionsBuilder))
            {
                var usuario = await banco.UsuarioSistemaFinanceiro.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));

                if (usuario != null)
                {
                    return usuario;
                }
                else
                {                   
                    throw new Exception("Usuário não encontrado.");
                }
            }
        }

        public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var banco = new ContextoBase(_OptionsBuilder))
            {
                banco.UsuarioSistemaFinanceiro
               .RemoveRange(usuarios);

                await banco.SaveChangesAsync();
            }
        }
    }
}
