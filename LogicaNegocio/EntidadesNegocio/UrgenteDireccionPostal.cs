using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class UrgenteDireccionPostal
	{
		public string Valor { get; init; }
		public UrgenteDireccionPostal(string valor)
		{
			Valor = valor;
		}
	}
}
