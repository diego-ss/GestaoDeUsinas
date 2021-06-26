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
        public async Task<bool> AddUsina(Usina usina)
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
        public async Task<IEnumerable<Usina>> GetUsinas()
        {
            return await _context.Usinas.ToListAsync();
        }

        /// <summary>
        /// Listagem de todas as usinas classificadas como ativas no banco de dados
        /// </summary>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Usina>> GetUsinasByAtivo(bool Ativo)
        {
            return await _context.Usinas.AsNoTracking().Where(us => us.Ativo).ToListAsync();
        }

        /// <summary>
        /// Listagem de todas as usinas com um determinado fornecedor 
        /// </summary>
        /// <param name="FornecedorId">Identificação do fornecedor</param>
        /// <returns></returns>
        public async Task<IEnumerable<Usina>> GetUsinasByFornecedor(int FornecedorId)
        {
            return await _context.Usinas.AsNoTracking().Where(us => us.FornecedorId == FornecedorId).ToListAsync();
        }

        public Task<bool> UpdateUsina(Usina usina)
        {
            throw new NotImplementedException();
        }
    }
}
