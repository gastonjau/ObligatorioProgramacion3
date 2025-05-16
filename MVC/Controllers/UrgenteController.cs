using Compartido.DTOs.Envio;
using LogicaAplicacion.InterfacesCasosUso.Envio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Envio;

namespace MVC.Controllers
{
    public class UrgenteController : Controller
    {
        public IListadoEnvio CUListadoEnvio { get; set; }
        public IAltaUrgente CUAltaUrgente { get; set; }

        public UrgenteController(IListadoEnvio cUListadoEnvio, IAltaUrgente cUAltaUrgente)
        {
            CUListadoEnvio = cUListadoEnvio;
            CUAltaUrgente = cUAltaUrgente;
        }

        // GET: UrgenteController
        public ActionResult Index()
        {
            List<ListadoEnvioDTO> envios = CUListadoEnvio.Ejecutar();
            List<ListarEnvioViewModel> enviosVM = new List<ListarEnvioViewModel>();
            try
            {
                enviosVM = envios.Select(listado => new ListarEnvioViewModel()
                {
                    Id = listado.Id,
                    CodTracking = listado.CodTracking,
                    Empleado = listado.Empleado,
                    Cliente = listado.Cliente,
                    PesoPaquete = listado.PesoPaquete,
                    Estado = listado.Estado,
                    Etapas = listado.Etapas
                }).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error al intentar cargar listado de usuarios.";
            }
            return View(enviosVM);
        }

        // GET: UrgenteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrgenteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrgenteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UrgenteViewModel urgenteVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UrgenteDTO urgenteDTO = new UrgenteDTO()
                    {
                        Email = urgenteVM.Email,
                        EmpleadoEmail = HttpContext.Session.GetString("email"),
                        Peso = urgenteVM.Peso,
                        DirPostal = urgenteVM.DirPostal
                    };
                    CUAltaUrgente.Ejecutar(urgenteDTO);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (EnvioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "No se pudo dar de alta el envio urgente.";
            }
            return View();
        }

        // GET: UrgenteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrgenteController/Edit/5
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

        // GET: UrgenteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrgenteController/Delete/5
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

        //[HttpPost]
        //public IActionResult AgregarComentario(ComentarioViewModel comentarioVM)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            ComentarioDTO comentarioDTO = new ComentarioDTO()
        //            {

        //            };
        //        }
        //    }
        //}
    }
}
