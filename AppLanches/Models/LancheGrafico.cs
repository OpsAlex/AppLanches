using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AppLanches.Models

{
    public class LancheGrafico
    {
        public string LancheNome { get; set; }
        public int LanchesQuantidade { get; set; }
        public decimal LanchesValorTotal { get; set; }
    }
}