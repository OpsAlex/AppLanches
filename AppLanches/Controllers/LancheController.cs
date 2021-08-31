using AppLanches.Models;
using AppLanches.Repository;
using AppLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
                categoria = "Todos os Lanches";
            }
            else
            {
                if (string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(p => p.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.CategoriaNome.Equals("Natural"))
                        .OrderBy(p => p.Nome);
                }

                categoriaAtual = _categoria;

            }

            var lanchelistViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchelistViewModel);
        }
        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if (lanche == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(lanche);
        }
        public IActionResult Search(string searchstring)
        {
            string _searchString = searchstring;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(p => p.Nome.ToLower().Contains(_searchString.ToLower()));
            }
            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel { Lanches=lanches, CategoriaAtual="Todos os Lanches"});
        }
    }
}
