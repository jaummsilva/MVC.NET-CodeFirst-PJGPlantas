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
    public class CartaoController : Controller
    {
        private PjgContext db = new PjgContext();

        // GET: Cartao
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var cartaos = from s in db.Cartao
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                cartaos = cartaos.Where(s => s.Usuario.ToString().Contains(searchString)
                                       || s.NomeTitular.Contains(searchString)
                );

            }
            return View(cartaos.ToList());
        }

        // GET: Cartao/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = await db.Cartao.FindAsync(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            return View(cartao);
        }

        // GET: Cartao/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Cartao/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NomeTitular,Validade,CVV,Numero,UsuarioID")] Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                db.Cartao.Add(cartao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Usuario, "Id", "Nome", cartao.UsuarioID);
            return View(cartao);
        }

        // GET: Cartao/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = await db.Cartao.FindAsync(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuario, "Id", "Nome", cartao.UsuarioID);
            return View(cartao);
        }

        // POST: Cartao/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NomeTitular,Validade,CVV,Numero,UsuarioID")] Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuario, "Id", "Nome", cartao.UsuarioID);
            return View(cartao);
        }

        // GET: Cartao/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cartao cartao = await db.Cartao.FindAsync(id);
            if (cartao == null)
            {
                return HttpNotFound();
            }
            return View(cartao);
        }

        // POST: Cartao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cartao cartao = await db.Cartao.FindAsync(id);
            db.Cartao.Remove(cartao);
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
