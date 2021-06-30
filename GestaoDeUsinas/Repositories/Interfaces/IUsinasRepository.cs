using GestaoDeUsinas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeUsinas.Interfaces
{
    public interface IUsinasRepository
    {
        Task<IEnumerable<Usina>> GetUsinasAsync();
        IEnumerable<Usina> GetQueryableUsinas();
        Task<Usina> GetUsinaByIdAsync(int Id);
        Task<IEnumerable<Usina>> GetUsinasByFornecedorAsync(int FornecedorId);
        Task<IEnumerable<Usina>> GetUsinasByAtivoAsync(bool Ativo);
        Task<Usina> FindUsinaAsync(Usina usina);

        Task<bool> AddUsinaAsync(Usina usina);
        Task<bool> DeleteUsina(int usinaId);
        Task<bool> UpdateUsina(Usina usina);
    }
}
