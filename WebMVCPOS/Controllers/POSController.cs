using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVCPOS.Controllers
{
    public class POSController : Controller
    {
        // GET: POSController
        public ActionResult Index()
        {
            return View();
        }

        // GET: POSController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: POSController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: POSController/Create
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

        // GET: POSController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: POSController/Edit/5
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

        // GET: POSController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: POSController/Delete/5
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
