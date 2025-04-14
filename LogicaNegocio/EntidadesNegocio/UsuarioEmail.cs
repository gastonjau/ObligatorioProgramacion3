using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	[Owned]
	public class UsuarioEmail
	{
		public string Valor { get; init; }
		public UsuarioEmail(string valor)
		{
			Valor = valor;
		}
	}
}
