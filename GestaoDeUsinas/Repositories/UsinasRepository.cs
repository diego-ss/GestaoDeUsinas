using GestaoDeUsinas.Context;
using GestaoDeUsinas.Interfaces;
using GestaoDeUsinas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoDeUsinas.Repositories
{
    public class UsinasRepository : IUsinasRepository
    {
        private readonly GestaoDeUsinasContext _context;

        public UsinasRepository(GestaoDeUsinasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona uma nova instância de usina ao banco de dados
        /// </summary>
        /// <param name="usina">usina a ser adicionada</param>
        /// <returns></returns>
        public async Task<bool> AddUsinaAsync(Usina usina)
        {
            await _context.Usinas.AddAsync(usina);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public Task<bool> DeleteUsina(Usina usina)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listagem de todas as usinas do banco de dados
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Usina>> GetUsinasAsync()
        {
            return await _context.Usinas.Include(us=>us.Fornecedor).ToListAsync();
        }

        /// <summary>
        /// Listagem de todas as usinas classificadas como ativas no banco de dados
        /// </summary>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Usina>> GetUsinasByAtivoAsync(bool Ativo)
        {
            return await _context.Usinas.AsNoTracking().Where(us => us.Ativo).ToListAsync();
        }

        /// <summary>
        /// Listagem de todas as usinas com um determinado fornecedor 
        /// </summary>
        /// <param name="FornecedorId">Identificação do fornecedor</param>
        /// <returns></returns>
        public async Task<IEnumerable<Usina>> GetUsinasByFornecedorAsync(int FornecedorId)
        {
            return await _context.Usinas.AsNoTracking().Where(us => us.FornecedorId == FornecedorId).ToListAsync();
        }

        public async Task<Usina> FindUsinaAsync(Usina usina)
        {
            return await _context.Usinas.AsNoTracking().FirstOrDefaultAsync(us => us.FornecedorId == usina.FornecedorId && us.UCusina == usina.UCusina);
        }

        public Task<bool> UpdateUsina(Usina usina)
        {
            throw new NotImplementedException();
        }
    }
}
