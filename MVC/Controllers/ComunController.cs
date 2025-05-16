using Compartido.DTOs.Agencia;
using Compartido.DTOs.Envio;
using Compartido.DTOs.Usuario;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.Agencia;
using LogicaAplicacion.InterfacesCasosUso.Envio;
using LogicaAplicacion.InterfacesCasosUso.Usuario;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Agencia;
using MVC.Models.Envio;

namespace MVC.Controllers
{
    public class ComunController : Controller
    {
        public IAltaComun CUAltaComun { get; set; }
        public IListadoAgencia CUListadoAgencia { get; set; }

        public IListadoEnvio CUListadoEnvio { get; set; }

        public IActualizarEnvio CUActualizarEnvio { get; set; }

        public ComunController(IAltaComun cUAltaComun, IListadoAgencia cUListadoAgencia, IListadoEnvio cUListadoEnvio, IActualizarEnvio actualizarEnvio)
        {
            CUAltaComun = cUAltaComun;
            CUListadoAgencia = cUListadoAgencia;
            CUListadoEnvio = cUListadoEnvio;
            CUActualizarEnvio = actualizarEnvio;
        }

        // GET: EnvioController
        public ActionResult Index()
        {
            List<ListadoEnvioDTO> listado = CUListadoEnvio.Ejecutar();
            List<ListarEnvioViewModel> listadoVM = new List<ListarEnvioViewModel>();

            try
            {
                listadoVM = listado.Select(listado => new ListarEnvioViewModel()
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
            return View(listadoVM);
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
        public ActionResult Create(ComunViewModel comunVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ComunDTO comunDTO = new ComunDTO()
                    {
                        Email = comunVM.Email,
                        AgenciaId = comunVM.AgenciaId,
                        EmpleadoEmail = HttpContext.Session.GetString("email"),
                        Peso = comunVM.Peso
                    };
                    CUAltaComun.Ejecutar(comunDTO);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (EnvioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en el create(post) de envio comun,";
            }
            comunVM.Agencias = CargarAgencias();
            return View(comunVM);
        }

        // GET: EnvioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnvioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CambiarEstadoViewModel estadoVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CambiarEstadoDTO envioDTO = new CambiarEstadoDTO()
                    {
                        Id = estadoVm.Id,
                        Estado = "FINALIZADO"
                    };

                    CUActualizarEnvio.Ejecutar(envioDTO);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos.";
            }
            return View();
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
