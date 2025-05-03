using Compartido.DTOs;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfacesCasosUso.Rol;
using LogicaAplicacion.InterfacesCasosUso.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
	public class LoginController : Controller
	{
		
        public ILoginUsuario CULoginUsuario { get; set; }

        public LoginController(ILoginUsuario iLoginUsuario)
        {
			CULoginUsuario = iLoginUsuario;
        }
		// GET: LoginController
		public ActionResult Index()
		{
			return View();
		}

		// GET: LoginController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: LoginController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: LoginController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(LoginViewModel loginVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					LoginUserDTO loginDTO = new LoginUserDTO()
					{
						Email = loginVM.Email,
						Contrasenia = loginVM.Contrasenia
					};
					bool retorno = CULoginUsuario.Ejecutar(loginDTO);

                    if (retorno)
                    {
                        ViewBag.Mensaje = "Login correcto";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Credenciales incorrectas";
                        return View(loginVM);
                    }

                }
                return View(loginVM);

            }
            catch (Exception ex)
            {

                ViewBag.Mensaje = "Ocurrió algo inesperado" + ex.Message;
                return View(loginVM);
            }
		}

		// GET: LoginController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: LoginController/Edit/5
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

		// GET: LoginController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: LoginController/Delete/5
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
