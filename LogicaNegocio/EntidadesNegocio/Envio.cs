﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
	public class Envio
	{
		public int Id { get; set; }
		public string CodTracking { get; set; }
		public Usuario Empleado { get; set; }
		public Usuario Cliente { get; set; }
		public double PesoPaquete {get; set;}
		public string Estado { get; set; }
		public string Etapas { get; set; }

		public Comentario Comentario { get; set; }


		public Envio (string codTracking, Usuario empleado, Usuario cliente, double pesoPaquete, string estado, string etapas, Comentario comentario)
		{
			CodTracking = codTracking;
			Empleado = empleado;
			Cliente = cliente;
			PesoPaquete = pesoPaquete;
			Estado = estado;
			Etapas = etapas;
			Comentario = comentario;
		}
	}
}
