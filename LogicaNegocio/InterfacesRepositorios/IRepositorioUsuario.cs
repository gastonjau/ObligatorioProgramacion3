﻿using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public bool FindByEmailAndPass(string email, string contrasenia);
<<<<<<< HEAD
        public Usuario ObtenerPorEmail(string email);
=======
>>>>>>> origin/main
    }
}
