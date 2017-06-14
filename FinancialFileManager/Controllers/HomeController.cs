using FinancialFileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FinancialFileManager.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.Message = "Escolha o arquivo";

            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var arquivo = new Arquivo();
                    arquivo.DataHora = DateTime.Now;
                    arquivo.Nome = fileName;
                    arquivo.UsuarioId = 1;

                    using (StreamReader sr = new StreamReader(file.InputStream, System.Text.Encoding.GetEncoding(850)))
                    {
                        while (!sr.EndOfStream)
                        {
                            var linha = new Linha();
                            linha.ArquivoId = arquivo.ArquivoId;
                            linha.Conteudo = sr.ReadLine();
                            db.Linha.Add(linha);
                        }
                    }

                    db.Arquivo.Add(arquivo);
                    db.SaveChanges();
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Uploads");
            }
        }

        public ActionResult Downloads()
        {
            var dir = new System.IO.DirectoryInfo("C:\\Arquivos");
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();

            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }

            return View(items);
        }

        public FileResult Download(string FileName)
        {
            return File("C:\\Arquivos" + FileName, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}
