using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estacionamento.Models;
using Xceed.Wpf.Toolkit;

namespace Estacionamento.Controllers
{
    public class PjuridicasController : Controller
    {
        private EstacionamentoContext db = new EstacionamentoContext();

        // GET: Pjuridicas
        public ActionResult Index()
        {
            return View(db.PessoasJuridicas.ToList());
        }

        // GET: Pjuridicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pjuridica pjuridica = db.PessoasJuridicas.Find(id);
            if (pjuridica == null)
            {
                return HttpNotFound();
            }
            return View(pjuridica);
        }

        // GET: Pjuridicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pjuridicas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Razaosocial,Cnpj,Nomefantasia,Endereco,Telefone,Email")] Pjuridica pjuridica)
        {
            if (ModelState.IsValid)
            {
                db.PessoasJuridicas.Add(pjuridica);
               
                try
                {
                    db.SaveChanges();                    
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ViewBag.Mensagem = "CNPJ informado ja existe em nosso registro";
                    return View();                 
                }               
            }
            return View(pjuridica);
        }

        // GET: Pjuridicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pjuridica pjuridica = db.PessoasJuridicas.Find(id);
            if (pjuridica == null)
            {
                return HttpNotFound();
            }
            return View(pjuridica);
        }

        // POST: Pjuridicas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Razaosocial,Cnpj,Nomefantasia,Endereco,Telefone,Email")] Pjuridica pjuridica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pjuridica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pjuridica);
        }

        // GET: Pjuridicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pjuridica pjuridica = db.PessoasJuridicas.Find(id);
            if (pjuridica == null)
            {
                return HttpNotFound();
            }
            return View(pjuridica);
        }

        // POST: Pjuridicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pjuridica pjuridica = db.PessoasJuridicas.Find(id);
            db.PessoasJuridicas.Remove(pjuridica);
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
