﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
	public class EnvioDTO
	{
		public string Email { get; set; }
		public string EmpleadoEmail {  get; set; }
		public double Peso {  get; set; }
	}
}
