using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskList.Models;

namespace TaskList.Controllers
{
    public class TarefasController : Controller
    {
        private TodosDBContext db = new TodosDBContext();

        // GET: Tarefas
        public ActionResult Index()
        {
            return View(db.Todo.ToList());
        }

        // GET: Todos/Detalhes
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Todo.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // GET: Todos/Inserir
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Inserir
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Data,Meta,Status")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                db.Todo.Add(tarefas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarefas);
        }

        // GET: Todos/Editar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Todo.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // POST: Tarefas/Editar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Data,Meta,Status")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarefas);
        }

        // GET: Todos/Excluir
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Todo.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // POST: Todos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefas tarefas = db.Todo.Find(id);
            db.Todo.Remove(tarefas);
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
