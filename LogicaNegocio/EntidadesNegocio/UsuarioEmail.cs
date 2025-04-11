﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class UsuarioEmail
	{
		public int Id { get; set; }
		public string Valor { get; init; }
		public UsuarioEmail(string valor)
		{
			Valor = valor;
		}
	}
}
