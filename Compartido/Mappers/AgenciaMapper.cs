using Compartido.DTOs.Agencia;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
	public class AgenciaMapper
	{

		public static IEnumerable<DatoAgenciaDTO> ListDatoAgenciaDTOFromListAgencia(IEnumerable<Agencia> agencias)
		{
			return agencias.Select(a => new DatoAgenciaDTO()
			{
				Id = a.Id,
				Nombre = a.Nombre
			});
		}
	}
}
