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
    public class FornecedoresRepository : IFornecedoresRepository
    {
        private readonly GestaoDeUsinasContext _context;

        public FornecedoresRepository(GestaoDeUsinasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fornecedor>> GetFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }
    }
}
