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

		public Comun():base(){}


		public Comun(Agencia agencia, Usuario cliente, Usuario empleado, double peso) : base(cliente, empleado, peso) 
		{  
			Agencia = agencia; 
		}
	}
}
