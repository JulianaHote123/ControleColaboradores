using JulianaHote20171222.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JulianaHote20171222.Models;

namespace JulianaHote20171222.Controllers
{
    public class ColaboradorsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Colaboradors
        public ActionResult Index()
        {
            var colaborador = db.Colaborador.Include(c => c.Empresa).Include(c => c.Pessoa);
            return View(colaborador.ToList());
        }

        // GET: Colaboradors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.Colaborador.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // GET: Colaboradors/Create
        public ActionResult Create()
        {
            ViewBag.ControleEMP = new SelectList(db.Empresa, "ControleEMP", "NomeEMP");
            ViewBag.ControlePES = new SelectList(db.Pessoa, "ControlePES", "NomePES");
            return View(new Colaborador() {Status = "ATIVO" });
        }

        // POST: Colaboradors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ControleCOL,ControlePES,ControleEMP,Salario,Status,CargoColaborador,DataDemissao")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                colaborador.DataCadastro = DateTime.Now;
                if (colaborador.DataDemissao != null)
                {
                    colaborador.Status = "INATIVO";
                }
                db.Colaborador.Add(colaborador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ControleEMP = new SelectList(db.Empresa, "ControleEMP", "NomeEMP", colaborador.ControleEMP);
            ViewBag.ControlePES = new SelectList(db.Pessoa, "ControlePES", "NomePES", colaborador.ControlePES);
            return View(colaborador);
        }

        // GET: Colaboradors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.Colaborador.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            ViewBag.ControleEMP = new SelectList(db.Empresa, "ControleEMP", "NomeEMP", colaborador.ControleEMP);
            ViewBag.ControlePES = new SelectList(db.Pessoa, "ControlePES", "NomePES", colaborador.ControlePES);
            return View(colaborador);
        }

        // POST: Colaboradors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ControleCOL,ControlePES,ControleEMP,Salario,Status,CargoColaborador,DataCadastro,DataDemissao")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaborador).State = EntityState.Modified;
                if (colaborador.DataDemissao != null)
                {
                    colaborador.Status = "INATIVO";
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ControleEMP = new SelectList(db.Empresa, "ControleEMP", "NomeEMP", colaborador.ControleEMP);
            ViewBag.ControlePES = new SelectList(db.Pessoa, "ControlePES", "NomePES", colaborador.ControlePES);
            return View(colaborador);
        }

        // GET: Colaboradors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.Colaborador.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: Colaboradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaborador colaborador = db.Colaborador.Find(id);
            db.Colaborador.Remove(colaborador);
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
