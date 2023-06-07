using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IDepesa
{
    public interface InterfaceDespesa : InterfaceGeneric<Despesa>
    {
        Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario);
        Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}
