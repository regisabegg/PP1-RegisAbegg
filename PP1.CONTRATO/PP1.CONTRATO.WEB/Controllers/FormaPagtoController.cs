using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Controllers
{
    public class FormaPagtoController : Controller
    {
        // GET: FormaPagto
        public ActionResult Index()
        {
            return View();
        }

        // GET: FormaPagto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FormaPagto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaPagto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FormaPagto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FormaPagto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FormaPagto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FormaPagto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
