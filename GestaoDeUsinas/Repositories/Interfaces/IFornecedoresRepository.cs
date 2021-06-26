using GestaoDeUsinas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeUsinas.Interfaces
{
    public interface IFornecedoresRepository
    {
        Task<IEnumerable<Fornecedor>> GetFornecedores();
    }
}
