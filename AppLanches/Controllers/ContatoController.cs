using AppLanches.Models;
using AppLanches.Repository;
using AppLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppLanches.Controllers
{
    public class ContatoController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}
