using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estacionamento.Models;

namespace Estacionamento.Controllers
{
    public class PfisicasController : Controller
    {
        private EstacionamentoContext db = new EstacionamentoContext();

        // GET: Pfisicas
        public ActionResult Index()
        {
            return View(db.PessoasFisicas.ToList());
        }

        // GET: Pfisicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pfisica pfisica = db.PessoasFisicas.Find(id);
            if (pfisica == null)
            {
                return HttpNotFound();
            }
            return View(pfisica);
        }

        // GET: Pfisicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pfisicas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cpf,Sexo,Nascimento,Rg,Endereco,Telefone,Email")] Pfisica pfisica)
        {
            if (ModelState.IsValid)
            {
                db.PessoasFisicas.Add(pfisica);

                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    
                }
                catch (Exception ex)
                {
                    ViewBag.Mensagem = "CPF informado ja existe em nosso registro";
                    return View();
                }
            }

            return View(pfisica);
        }

        // GET: Pfisicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pfisica pfisica = db.PessoasFisicas.Find(id);
            if (pfisica == null)
            {
                return HttpNotFound();
            }
            return View(pfisica);
        }

        // POST: Pfisicas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cpf,Sexo,Nascimento,Rg,Endereco,Telefone,Email")] Pfisica pfisica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pfisica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pfisica);
        }

        // GET: Pfisicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pfisica pfisica = db.PessoasFisicas.Find(id);
            if (pfisica == null)
            {
                return HttpNotFound();
            }
            return View(pfisica);
        }

        // POST: Pfisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pfisica pfisica = db.PessoasFisicas.Find(id);
            db.PessoasFisicas.Remove(pfisica);
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
