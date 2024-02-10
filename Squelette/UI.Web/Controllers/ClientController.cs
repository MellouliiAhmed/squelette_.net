using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Web.Controllers
{

    
    public class ClientController : Controller
    {


        IClientService sc;
        IConseillerService sco;

        public ClientController(IClientService sc, IConseillerService sco)
        {
            this.sc = sc;
            this.sco = sco;
        }



        // GET: ClientController
        public ActionResult Index(String? name)
        {
            if (name == null)
                return View(sc.GetAll());
            else  return View(sc.GetMany(x => x.Login.Equals(name)));
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            ViewBag.ConseillerFK = new SelectList(sco.GetAll() , "ConseillerId" , "Nom");
            return View();
            // new SelectList(lista  mta tous les consiller  , “primary key “, “display prop”)
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client C)
        {
            try
            {
                sc.Add(C);
                sc.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ConseillerFK = new SelectList(sco.GetAll(), "ConseillerId", "Nom");
            //sc.GetById(id);
            return View(sc.GetById(id));
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Client c)
        {
            try
            {
                sc.Update(c);
                sc.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sc.GetById(id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                sc.Delete(sc.GetById(id));
                sc.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
