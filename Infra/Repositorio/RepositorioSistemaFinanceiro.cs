using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioSistemaFinanceiro : RepositoryGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {

        private readonly DbContextOptions<ContextoBase> _OptionsBuilder;

        public RepositorioSistemaFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextoBase>();
        }

        public async Task<IList<SistemaFinanceiro>> ListaSistemasUsuario(string emailUsuario)
        {
            using (var banco = new ContextoBase(_OptionsBuilder))
            {
                return await
                   (from s in banco.SistemaFinanceiro
                    join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                    where us.EmailUsuario.Equals(emailUsuario)
                    select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
