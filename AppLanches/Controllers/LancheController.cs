using AppLanches.Models;
using AppLanches.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppLanches.ViewModels;

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

        public IActionResult List()
        {
            ViewBag.Lanche = "Lanches";
            ViewData["Categoria"] = "Categoria";

            // var lanches = _lancheRepository.Lanches;
            // return View(lanches);
            var lanchelistViewModel = new LancheListViewModel();
            lanchelistViewModel.Lanches = _lancheRepository.Lanches;
            lanchelistViewModel.CategoriaAtual = "Categoria Atual";
            return View(lanchelistViewModel);
        }
    }
}
