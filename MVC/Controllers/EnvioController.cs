using Compartido.DTOs.Agencia;
using LogicaAplicacion.InterfacesCasosUso.Agencia;
using LogicaAplicacion.InterfacesCasosUso.Envio;
using LogicaAplicacion.InterfacesCasosUso.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Agencia;
using MVC.Models.Envio;

namespace MVC.Controllers
{
    public class EnvioController : Controller
    {
        public IAltaComun CUAltaComun { get; set; }
        public IListadoAgencia CUListadoAgencia { get; set; }

        public EnvioController(IAltaComun cUAltaComun, IListadoAgencia cUListadoAgencia)
        {
            CUAltaComun = cUAltaComun;
            CUListadoAgencia = cUListadoAgencia;
        }

        // GET: EnvioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EnvioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private List<DatoAgenciaViewModel> CargarAgencias()
        {
            IEnumerable<DatoAgenciaDTO> agenciasDTO = CUListadoAgencia.Ejecutar().ToList();
            List<DatoAgenciaViewModel> agenciasVM = agenciasDTO.Select(a => new DatoAgenciaViewModel()
            {
                Id = a.Id,
                Nombre = a.Nombre
            }).ToList();
            return agenciasVM;
        }

        // GET: EnvioController/Create
        public ActionResult Create()
        {
            ComunViewModel comunVM = new ComunViewModel();
            try
            {
                comunVM.Agencias = CargarAgencias();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View(comunVM);
        }

        // POST: EnvioController/Create
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

        // GET: EnvioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnvioController/Edit/5
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

        // GET: EnvioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnvioController/Delete/5
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
