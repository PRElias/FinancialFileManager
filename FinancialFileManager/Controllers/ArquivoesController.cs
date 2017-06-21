using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinancialFileManager.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace FinancialFileManager.Controllers
{
    public class ArquivoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Arquivoes
        public ActionResult Index()
        {
            return View(db.Arquivo.Include("ApplicationUser").ToList());
        }

        // GET: Arquivoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquivo arquivo = db.Arquivo.Find(id);
            if (arquivo == null)
            {
                return HttpNotFound();
            }

            var linhas = db.Linha.Where(a => a.ArquivoId == arquivo.ArquivoId).ToList();
            ViewBag.Conteudo = String.Empty;

            foreach (var item in linhas)
            {
                ViewBag.Conteudo += item.Conteudo + "\n";
            }

            return View(arquivo);
        }

        // GET: Arquivoes/Create
        public ActionResult Create()
        {
            ViewBag.Message = "Escolha o arquivo";

            return View("Upload");
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
                    arquivo.UsuarioId = User.Identity.GetUserId();


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
                return RedirectToAction("Index");
            }
        }

        // GET: Arquivoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquivo arquivo = db.Arquivo.Find(id);
            if (arquivo == null)
            {
                return HttpNotFound();
            }
            return View(arquivo);
        }

        // POST: Arquivoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Arquivo arquivo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(arquivo).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(arquivo);
        //}

        // GET: Arquivoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquivo arquivo = db.Arquivo.Find(id);
            if (arquivo == null)
            {
                return HttpNotFound();
            }
            return View(arquivo);
        }

        // POST: Arquivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arquivo arquivo = db.Arquivo.Find(id);
            db.Arquivo.Remove(arquivo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
