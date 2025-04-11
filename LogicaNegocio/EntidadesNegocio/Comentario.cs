using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Comentario
	{
		public DateTime Fecha { get; set; }
		public Usuario Empleado { get; set; }
		public Usuario Usuario { get; set; }

		public Comentario(DateTime fecha, Usuario empleado, Usuario usuario)
		{
			Fecha = fecha;
			Empleado = empleado;
			Usuario = usuario;
		}

	}
}
