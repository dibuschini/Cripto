using Dimensiona.Data;
using Dimensiona.Models;

namespace Dimensiona.Repositorio
{
    public class DimensionamentoRepositorio : IDimensionamentoRepositorio
    {

        private readonly BancoContext _bancoContext;
        public DimensionamentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public DimensionamentoModel Adicionar(DimensionamentoModel dimensionamento)
        {
            _bancoContext.Dimensionamentos.Add(dimensionamento);
            _bancoContext.SaveChanges();
            return dimensionamento;
        }
    }
}
