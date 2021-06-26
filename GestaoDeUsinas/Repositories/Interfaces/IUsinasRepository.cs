using GestaoDeUsinas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeUsinas.Interfaces
{
    public interface IUsinasRepository
    {
        Task<IEnumerable<Usina>> GetUsinas();
        Task<IEnumerable<Usina>> GetUsinasByFornecedor(int FornecedorId);
        Task<IEnumerable<Usina>> GetUsinasByAtivo(bool Ativo);

        Task<bool> AddUsina(Usina usina);
        Task<bool> DeleteUsina(Usina usina);
        Task<bool> UpdateUsina(Usina usina);
    }
}
