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
    public class CompraController : Controller
    {
        private PjgContext db = new PjgContext();

        // GET: Compra
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var compras = from s in db.Compra
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                compras = compras.Where(s => s.Endereco.ToString().Contains(searchString)
                                    || s.UsuarioId.ToString().Contains(searchString));

            }
            return View(compras.ToList());
        }

        // GET: Compra/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compra.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            ViewBag.BoletoId = new SelectList(db.Boleto, "Id", "Nome");
            ViewBag.CartaoId = new SelectList(db.Cartao, "Id", "NomeTitular");
            ViewBag.PixId = new SelectList(db.Pix, "Id", "Cnpj");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Compra/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Cpf,Rg,Endereco,Complemento,UsuarioId,BoletoId,PixId,CartaoId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compra.Add(compra);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BoletoId = new SelectList(db.Boleto, "Id", "Nome", compra.BoletoId);
            ViewBag.CartaoId = new SelectList(db.Cartao, "Id", "NomeTitular", compra.CartaoId);
            ViewBag.PixId = new SelectList(db.Pix, "Id", "Cnpj", compra.PixId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", compra.UsuarioId);
            return View(compra);
        }

        // GET: Compra/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compra.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoletoId = new SelectList(db.Boleto, "Id", "Nome", compra.BoletoId);
            ViewBag.CartaoId = new SelectList(db.Cartao, "Id", "NomeTitular", compra.CartaoId);
            ViewBag.PixId = new SelectList(db.Pix, "Id", "Cnpj", compra.PixId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", compra.UsuarioId);
            return View(compra);
        }

        // POST: Compra/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Cpf,Rg,Endereco,Complemento,UsuarioId,BoletoId,PixId,CartaoId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BoletoId = new SelectList(db.Boleto, "Id", "Nome", compra.BoletoId);
            ViewBag.CartaoId = new SelectList(db.Cartao, "Id", "NomeTitular", compra.CartaoId);
            ViewBag.PixId = new SelectList(db.Pix, "Id", "Cnpj", compra.PixId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", compra.UsuarioId);
            return View(compra);
        }

        // GET: Compra/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compra.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Compra compra = await db.Compra.FindAsync(id);
            db.Compra.Remove(compra);
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
