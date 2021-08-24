using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppLanches.Models;
using AppLanches.Context;

namespace AppLanches.Repository

{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}