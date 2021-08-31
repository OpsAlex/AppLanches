using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using AppLanches.Models;
using Microsoft.AspNetCore.Mvc;
using AppLanches.ViewModels;
using AppLanches.Repository;

namespace AppLanches.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);

            return View(categorias);
        }
    }
}