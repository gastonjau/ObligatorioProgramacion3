using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class UsuarioContrasenia
	{
		public int Id { get; set; }
		public string Valor { get; init; }
		public UsuarioContrasenia(string valor)
		{
			Valor = valor;
		}
	}
}
