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
    public class PixController : Controller
    {
        private PjgContext db = new PjgContext();

        // GET: Pix
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var pixs = from s in db.Pix
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                pixs = pixs.Where(s => s.Email.Contains(searchString)
                                       || s.Banco.Contains(searchString));
            }
            return View(pixs.ToList());
        }

        // GET: Pix/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pix pix = await db.Pix.FindAsync(id);
            if (pix == null)
            {
                return HttpNotFound();
            }
            return View(pix);
        }

        // GET: Pix/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pix/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Cnpj,Email,Banco")] Pix pix)
        {
            if (ModelState.IsValid)
            {
                db.Pix.Add(pix);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pix);
        }

        // GET: Pix/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pix pix = await db.Pix.FindAsync(id);
            if (pix == null)
            {
                return HttpNotFound();
            }
            return View(pix);
        }

        // POST: Pix/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Cnpj,Email,Banco")] Pix pix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pix).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pix);
        }

        // GET: Pix/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pix pix = await db.Pix.FindAsync(id);
            if (pix == null)
            {
                return HttpNotFound();
            }
            return View(pix);
        }

        // POST: Pix/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pix pix = await db.Pix.FindAsync(id);
            db.Pix.Remove(pix);
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
