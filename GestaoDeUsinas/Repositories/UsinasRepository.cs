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

        /// <summary>
        /// Deleta uma usina do banco de dados através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUsina(int id)
        {
            var usina = await _context.Usinas.FindAsync(id);

            if (usina == null)
                return false;

            _context.Usinas.Remove(usina);
            return (await _context.SaveChangesAsync()) > 0;
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
        /// Listagem de todas as usinas do banco de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usina> GetQueryableUsinas()
        {
            return _context.Usinas.Include(us => us.Fornecedor).AsNoTracking().AsQueryable();
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

        /// <summary>
        /// Encontra uma usina no banco de dados através de uma instância
        /// </summary>
        /// <param name="usina"></param>
        /// <returns></returns>
        public async Task<Usina> FindUsinaAsync(Usina usina)
        {
            if (usina == null)
                throw new Exception("Parâmetros inválidos!");

            return await _context.Usinas.AsNoTracking().FirstOrDefaultAsync(us => us.FornecedorId == usina.FornecedorId && us.UCusina == usina.UCusina);
        }

        /// <summary>
        /// Atualiza uma usina no banco de dados
        /// </summary>
        /// <param name="usina"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUsina(Usina usina)
        {
            if (usina == null || usina.Id == 0)
                throw new Exception("Parâmetros inválidos!");

            _context.Usinas.Update(usina);
            return (await _context.SaveChangesAsync()) > 0;
        }

        /// <summary>
        /// busca usina pelo id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Usina> GetUsinaByIdAsync(int Id)
        {
            return await _context.Usinas.AsNoTracking().Include(x=>x.Fornecedor).FirstOrDefaultAsync(us=>us.Id == Id);
        }
    }
}
