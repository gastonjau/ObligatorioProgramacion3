using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	[Owned]
	public class UsuarioContrasenia
	{
		public string Valor { get; init; }
		public UsuarioContrasenia(string valor)
		{
			Valor = valor;
		}
	}
}
