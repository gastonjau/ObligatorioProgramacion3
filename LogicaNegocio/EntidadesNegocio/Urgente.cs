using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Urgente : Envio
	{
		public string DirPostal { get; set; }
		public bool Eficiente { get; set; }
		public DateTime TiempoEficiente { get; set; }

		public Urgente() : base() { }

	}
}
