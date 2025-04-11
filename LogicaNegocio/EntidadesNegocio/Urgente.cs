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

		public Urgente(string codTracking, Usuario empleado, Usuario cliente, double pesoPaquete, string estado, string etapas, Comentario comentario, string dirPostal,bool eficiente, DateTime tiempoEficiente) : base(codTracking, empleado, cliente, pesoPaquete, estado, etapas, comentario)
		{
			DirPostal = dirPostal;
			Eficiente = eficiente;
			TiempoEficiente = tiempoEficiente;
		}
	}
}
