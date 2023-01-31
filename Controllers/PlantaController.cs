using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PJGPlantasMVC.Models;

namespace PJGPlantasMVC
{
    public class PlantaController : Controller
    {
        private PjgContext db = new PjgContext();

        // GET: Planta
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var plantas = from s in db.Planta
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                plantas = plantas.Where(s => s.Nome.Contains(searchString)
                                       || s.Preco.ToString().Contains(searchString));
            }
            return View(plantas.ToList());
        }

        // GET: Planta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = await db.Planta.FindAsync(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // GET: Planta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planta/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Preco,Descricao")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                db.Planta.Add(planta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(planta);
        }

        // GET: Planta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = await db.Planta.FindAsync(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // POST: Planta/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Preco,Descricao")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(planta);
        }

        // GET: Planta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = await db.Planta.FindAsync(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // POST: Planta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Planta planta = await db.Planta.FindAsync(id);
            db.Planta.Remove(planta);
            await db.SaveChangesAsync();
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
