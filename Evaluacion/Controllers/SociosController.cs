using Evaluacion.Data;
using Evaluacion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion.Controllers
{
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SociosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Socio> ltssocio = _context.Socios.ToList();
            return View(ltssocio);
        }
        public ActionResult Details(int id)
        {
            Socio socio = _context.Socios.FirstOrDefault(x => x.Cedula == id);
            return View(socio);
        }
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(Socio socio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(socio);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(socio);
            }
        }
        public ActionResult Edit(int id)
        {
            Socio socio = _context.Socios.FirstOrDefault(x => x.Cedula == id);
            return View(socio);

        }
        [HttpPost]
        public ActionResult Edit(int id, Socio socio)
        {
            if (id != socio.Cedula)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Update(socio);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(socio);
            }
        }
        public ActionResult Delete(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Desactivar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Socio socio = _context.Socios.Where(y => y.Cedula == id).FirstOrDefault();
            try
            {
                socio.Estado = 0;
                _context.Update(socio);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public IActionResult Activar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Socio socio = _context.Socios.Where(y => y.Cedula == id).FirstOrDefault();
            try
            {
                socio.Estado = 1;
                _context.Update(socio);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
    

