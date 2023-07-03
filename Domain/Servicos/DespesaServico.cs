using Domain.Interfaces.IDepesa;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class DespesaServico : IDespesaServico
    {
        private readonly InterfaceDespesa _interfaceDespesa;

        public DespesaServico(InterfaceDespesa interfaceDespesa)
        {
            _interfaceDespesa = interfaceDespesa;
        }
        public async Task AdicionarDespesa(Despesa despesa)
        {
            despesa.DataCadastro = DateTime.UtcNow;
            despesa.Ano = DateTime.UtcNow.Year;
            despesa.Mes = DateTime.UtcNow.Month;
            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
            {
                await _interfaceDespesa.Add(despesa);
            }
        }
        public async Task AtualizarDespesa(Despesa despesa)
        {
            despesa.DataAlteracao = DateTime.UtcNow;
            if (despesa.Pago)
            {
                despesa.DataPagamento = DateTime.UtcNow;
            }
            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
            {
                await _interfaceDespesa.Update(despesa);
            }
        }
    }
}
