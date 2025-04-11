using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Comun : Envio
	{
		public Agencia Agencia { get; set; }

		public Comun(string codTracking, Usuario empleado, Usuario cliente, double pesoPaquete, string estado, string etapas,Comentario comentario, Agencia agencia ) :base(codTracking, empleado, cliente, pesoPaquete, estado, etapas, comentario)
		{
			Agencia = agencia;
		}
	}
}
