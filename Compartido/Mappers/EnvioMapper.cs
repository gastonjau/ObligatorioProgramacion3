using Compartido.DTOs.Envio;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
	public class EnvioMapper
	{
		public static Comun ComunFromComunDTO(Agencia agencia, Usuario usuario)
		{
			return new Comun(agencia, usuario);
		}
	}
}
