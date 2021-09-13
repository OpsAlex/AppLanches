using AppLanches.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AppLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminImagensController(IWebHostEnvironment hostingEnvironment, IOptions<ConfigurationImagens> myConfiguration)
        {
            _hostingEnvironment = hostingEnvironment;
            _myConfig = myConfiguration.Value;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            //Security
            // Criando validações para melhor segurança do upload
            if (files == null || files.Count == 0)
            {
                ViewData["Error"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }
            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite";
                return View(ViewData);
            }
            long size = files.Sum(files => files.Length);

            var fileParthsName = new List<string>();

            //CaminhoCompleto das imagens no servidor
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg")|| formFile.FileName.Contains(".gif")|| formFile.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);
                    fileParthsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " + $"com tamanho total de: {size} bytes";

            ViewBag.Arquivos = fileParthsName;

            return View(ViewData);
        }
        public IActionResult GetImagens()
        {
            FileManagerModel model = new FileManagerModel();

            //CaminhoCompleto das imagens no servidor
            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            //Criando uma estancia e iniciando o diretorio
            DirectoryInfo dir = new DirectoryInfo(userImagesPath);

            FileInfo[] files = dir.GetFiles();

            model.PathImagesProduto = _myConfig.NomePastaImagensProdutos;

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }

            model.Files = files;

            return View(model);
        }
        public IActionResult DeleteFile(string fname)
        {
            //montando o caminho completo do arquivo
            string _imagemDeleta = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos + "\\", fname);

            //validando 
            if ((System.IO.File.Exists(_imagemDeleta)))
            {
                //deletando
                System.IO.File.Delete(_imagemDeleta);

                ViewData["Deletado"] = $"Arquivo(s) {_imagemDeleta} deletado com sucesso";
            }
            return View("index");
        }
    }
}