using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrueEloMVC.Controllers
{
    public class SummonerController : Controller
    {
        // GET: SummonerController
        public ActionResult Index()
        {
           
            return View();
        }

        // GET: SummonerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SummonerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SummonerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SummonerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SummonerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SummonerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SummonerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
