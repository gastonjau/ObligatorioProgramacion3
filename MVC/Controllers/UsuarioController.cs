using Compartido.DTOs.Rol;
using Compartido.DTOs.Usuario;
using LogicaAplicacion.InterfacesCasosUso.Rol;
using LogicaAplicacion.InterfacesCasosUso.Usuario;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Rol;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        public IAltaEmpleado CUAltaEmpleado { get; set; }
        public IListadoEmpleado CUListadoEmpleado { get; set; }
        public IBuscarRoles CUBuscarRoles { get; set; }
        public IActualizarEmpleado CUActualizarEmpleado { get; set; }
        public IBuscarEmpleado CUBuscarEmpelado { get; set; }
        public IEliminarEmpleado CUEliminarEmpleado { get; set; }

        public UsuarioController(IAltaEmpleado altaEmpleadoCU, IListadoEmpleado cUListadoEmpleado, IBuscarRoles buscarRoles, IActualizarEmpleado cUActualizarEmpleado, IBuscarEmpleado cUBuscarEmpelado, IEliminarEmpleado cUEliminarEmpleado)
        {
            CUAltaEmpleado = altaEmpleadoCU;
            CUListadoEmpleado = cUListadoEmpleado;
            CUBuscarRoles = buscarRoles;
            CUActualizarEmpleado = cUActualizarEmpleado;
            CUBuscarEmpelado = cUBuscarEmpelado;
            CUEliminarEmpleado = cUEliminarEmpleado;
        }

        private AltaUsuarioViewModel CargarRoles()
        {
            AltaUsuarioViewModel usuarioViewModel = new AltaUsuarioViewModel();
            List<RolDTO> rolesDTO = CUBuscarRoles.Ejecutar().ToList();
            usuarioViewModel.Roles = rolesDTO.Select(r => new RolViewModel()
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList();
            return usuarioViewModel;
        }
        private ActualizarUsuarioVM CargarRolesActualizar()
        {
            ActualizarUsuarioVM usuarioViewModel = new ActualizarUsuarioVM();
            List<RolDTO> rolesDTO = CUBuscarRoles.Ejecutar().ToList();
            usuarioViewModel.Roles = rolesDTO.Select(r => new RolViewModel()
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList();
            return usuarioViewModel;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            List<ListadoUsuarioDTO> listado = CUListadoEmpleado.Ejecutar();
            List<ListarUsuarioViewModel> listadoVM = new List<ListarUsuarioViewModel>();

            try
            {
                listadoVM = listado.Select(u => new ListarUsuarioViewModel()
                {
                    Id = u.Id,
                    Nombre = u.Nombre
                }).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error al intentar cargar listado de usuarios.";
            }
            return View(listadoVM);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            AltaUsuarioViewModel usuarioViewModel = new AltaUsuarioViewModel();
            try
            {
                usuarioViewModel = CargarRoles();
            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch
            {
                ViewBag.Mensaje = "Error al cargar los roles.";
            }
            return View(usuarioViewModel);
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaUsuarioViewModel usuarioVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioDTO usuarioDTO = new UsuarioDTO()
                    {
                        Nombre = usuarioVM.Nombre,
                        Email = usuarioVM.Email,
                        Password = usuarioVM.Password,
                        Rol = usuarioVM.Rol
                    };
                    CUAltaEmpleado.Ejecutar(usuarioDTO);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Hubo un error en los datos.";
            }
            return View();
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            ActualizarUsuarioVM usuarioVM = null;
            try
            {
                if (id < 0)
                {
                    throw new UsuarioException("El id no es valido.");
                }
                ActualizarUsuarioDTO usuarioDTO = CUBuscarEmpelado.Ejecutar(id);
                usuarioVM = CargarRolesActualizar();
                usuarioVM.Id = id;
                usuarioVM.Nombre = usuarioDTO.Nombre;
                usuarioVM.Apellido = usuarioDTO.Apellido;
                usuarioVM.Email = usuarioDTO.Email;
                usuarioVM.Password = usuarioDTO.Password;
                usuarioVM.Rol = usuarioDTO.Rol;

            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos.";
            }
            return View(usuarioVM);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ActualizarUsuarioVM usuarioVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ActualizarUsuarioDTO usuarioDTO = new ActualizarUsuarioDTO()
                    {
                        Id = id,
                        Nombre = usuarioVM.Nombre,
                        Apellido = usuarioVM.Apellido,
                        Email = usuarioVM.Email,
                        Password = usuarioVM.Password,
                        Rol = usuarioVM.Rol
                    };
                    CUActualizarEmpleado.Ejecutar(usuarioDTO);
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
            ActualizarUsuarioVM roles = CargarRolesActualizar();
            usuarioVM.Roles = roles.Roles;
            return View(usuarioVM);
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            ListarUsuarioViewModel usuarioVM = null;
            try
            {
                if (id < 0)
                {
                    throw new UsuarioException("El id no es valido.");
                }
                ActualizarUsuarioDTO usuarioDTO = CUBuscarEmpelado.Ejecutar(id);
                usuarioVM = new ListarUsuarioViewModel()
                {
                    Id = usuarioDTO.Id,
                    Nombre = usuarioDTO.Nombre
                };
            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos.";
            }

            return View(usuarioVM);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ListarUsuarioViewModel usuarioVM)
        {
            try
            {
                CUEliminarEmpleado.Ejecutar(id);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en los datos";
            }
                return View(usuarioVM);
        }
    }
}
