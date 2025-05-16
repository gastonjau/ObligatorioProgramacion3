using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Envio
	{
		public int Id { get; set; }
		public string CodTracking { get; set; }
		public Usuario Empleado { get; set; }
		public Usuario Cliente { get; set; }
		public double PesoPaquete {get; set;}
		public string Estado { get; set; }

		public Envio() { }

		public Envio(Usuario cliente, Usuario empleado, double peso)
		{
			Cliente = cliente;
			Estado = "EN_PROCESO";
			Empleado = empleado;
			PesoPaquete = peso;
		}
	}
}
