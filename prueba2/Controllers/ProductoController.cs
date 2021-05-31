using prueba2.prueba.Business;
using prueba2.prueba.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba2.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index()
        {
            var biz = new ProductoBiz();
            var model = biz.Listar();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto model)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var biz = new ProductoBiz();
                biz.Agregar(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                /// Que pasa con el error -> Bitacoras
                Console.WriteLine(e);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var biz = new ProductoBiz();
            var model = biz.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Producto model)
        {
            var biz = new ProductoBiz();
            biz.Eliminar(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var biz = new ProductoBiz();
            var model = biz.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Producto model)
        {
            var biz = new ProductoBiz();
            biz.Update(model);
            return RedirectToAction("Index");
        }
    }
}