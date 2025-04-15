using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Rol
	{
		public int Id { get; set; }
		public string Nombre { get; set; }

		public Rol(int id)
		{
			Id = id;
		}
	}
}
