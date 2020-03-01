using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFServicePeliculas.CLases;
using WCFServicePeliculas.EF;
using WebPeliculasEF_WCF_SOAP.ServiceReferencePelicula;

namespace WebPeliculasEF_WCF_SOAP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ServiceReferencePelicula.Service1Client ws = new ServiceReferencePelicula.Service1Client();
        public ActionResult Index()
        {
            try
            {
                List<PeliculaMax> ls = ws.ListaPeliculas().ToList();
                ws.Close();

                return View(ls);
            }
            catch (Exception ex)
            {

                TempData["msj"] = ex.Message;

                return View("Index", new List<PeliculaMax>());
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                List<GeneroMax> ls = ws.ListaGenero().ToList();
                ViewBag.Genero = new SelectList(ls, "IdGenero", "Descripcion");

                ws.Close();

                return View();
            }
            catch (Exception ex)
            {
                TempData["msj"] = ex.Message;

                return RedirectToAction("Index");
            }
        }

        public ActionResult Create(Pelicula p)
        {
            try
            {
                ws.Agregar(p);
                ws.Close();

                TempData["msj"] = $"Se agregó a: {p.Nombre}";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msj"] = ex.Message;

                return RedirectToAction("Create");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                PeliculaMax p = ws.Obtener(id);
                List<GeneroMax> ls = ws.ListaGenero().ToList();
                ViewBag.Genero = new SelectList(ls, "IdGenero", "Descripcion", p.Genero);
                ws.Close();

                return View(p);
            }
            catch (Exception ex)
            {

                TempData["msj"] = ex.Message;

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(Pelicula p)
        {
            try
            {
                ws.Editar(p);
                ws.Close();
                TempData["msj"] = $"Se actualizó a: {p.Nombre}";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["msj"] = ex.Message;

                return RedirectToAction("Edit", new { id = p.IdPelicula });
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                PeliculaMax p = ws.Obtener(id);
                ws.Close();

                return View(p);
            }
            catch (Exception ex)
            {

                TempData["msj"] = ex.Message;

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(Pelicula p)
        {
            try
            {
                ws.Eliminar(p);
                TempData["msj"] = $"Se eliminó a: {p.Nombre}";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["msj"] = ex.Message;

                return RedirectToAction("Delete", new { id = p.IdPelicula });
            }
        }
    }
}