﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PJGPlantasMVC.Models;

namespace PJGPlantasMVC
{
    public class ComentarioController : Controller
    {
        private PjgContext db = new PjgContext();

        // GET: Comentario
        public ActionResult Index()
        {
            var comentario = db.Comentario.Include(c => c.Planta).Include(c => c.Usuario);
            return View(comentario.ToList());
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {
            ViewBag.PlantaId = new SelectList(db.Planta, "Id", "Nome");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Comentario/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Texto,UsuarioId,PlantaId,Dth")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantaId = new SelectList(db.Planta, "Id", "Nome", comentario.PlantaId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", comentario.UsuarioId);
            return View(comentario);
        }

        // GET: Comentario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantaId = new SelectList(db.Planta, "Id", "Nome", comentario.PlantaId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", comentario.UsuarioId);
            return View(comentario);
        }

        // POST: Comentario/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Texto,UsuarioId,PlantaId,Dth")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantaId = new SelectList(db.Planta, "Id", "Nome", comentario.PlantaId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", comentario.UsuarioId);
            return View(comentario);
        }

        // GET: Comentario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            db.Comentario.Remove(comentario);
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
