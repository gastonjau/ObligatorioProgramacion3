﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Agencia
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string DireccionPostal { get; set; }
		public string Ubicacion { get; set; }

		public Agencia (string nombre, string direccionPostal, string ubicacion)
		{
			Nombre = nombre;
			DireccionPostal = direccionPostal;
			Ubicacion = ubicacion;
		}

	}
}
