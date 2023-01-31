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
    public class ItemCompraController : Controller
    {
        private PjgContext db = new PjgContext();

        // GET: ItemCompra
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var itens = from s in db.ItemCompra
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                itens = itens.Where(s => s.CompraId.ToString().Contains(searchString)
                                    || s.Planta.ToString().Contains(searchString));

            }
            return View(itens.ToList());
        }

        // GET: ItemCompra/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCompra itemCompra = await db.ItemCompra.FindAsync(id);
            if (itemCompra == null)
            {
                return HttpNotFound();
            }
            return View(itemCompra);
        }

        // GET: ItemCompra/Create
        public ActionResult Create()
        {
            ViewBag.CompraId = new SelectList(db.Compra, "Id", "Cpf");
            ViewBag.PlantaId = new SelectList(db.Planta, "Id", "Nome");
            return View();
        }

        // POST: ItemCompra/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CompraId,PlantaId,Quantidade,Dth")] ItemCompra itemCompra)
        {
            if (ModelState.IsValid)
            {
                db.ItemCompra.Add(itemCompra);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompraId = new SelectList(db.Compra, "Id", "Cpf", itemCompra.CompraId);
            ViewBag.PlantaId = new SelectList(db.Planta, "Id", "Nome", itemCompra.PlantaId);
            return View(itemCompra);
        }

        // GET: ItemCompra/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCompra itemCompra = await db.ItemCompra.FindAsync(id);
            if (itemCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompraId = new SelectList(db.Compra, "Id", "Cpf", itemCompra.CompraId);
            ViewBag.PlantaId = new SelectList(db.Planta, "Id", "Nome", itemCompra.PlantaId);
            return View(itemCompra);
        }

        // POST: ItemCompra/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CompraId,PlantaId,Quantidade,Dth")] ItemCompra itemCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemCompra).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompraId = new SelectList(db.Compra, "Id", "Cpf", itemCompra.CompraId);
            ViewBag.PlantaId = new SelectList(db.Planta, "Id", "Nome", itemCompra.PlantaId);
            return View(itemCompra);
        }

        // GET: ItemCompra/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCompra itemCompra = await db.ItemCompra.FindAsync(id);
            if (itemCompra == null)
            {
                return HttpNotFound();
            }
            return View(itemCompra);
        }

        // POST: ItemCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ItemCompra itemCompra = await db.ItemCompra.FindAsync(id);
            db.ItemCompra.Remove(itemCompra);
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
