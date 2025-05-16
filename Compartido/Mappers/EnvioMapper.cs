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
		public static Comun ComunFromComunDTO(Agencia agencia, Usuario usuario, Usuario empleado, double peso)
		{
			return new Comun(agencia, usuario, empleado, peso);
		}

        public static List<ListadoEnvioDTO> ListEnvioDTOFromListEnvio(List<Envio> listaEnv)
        {
            if (listaEnv == null || !listaEnv.Any())
            {
                return new List<ListadoEnvioDTO>();
            }

            return listaEnv.Select(u => new ListadoEnvioDTO()
            {
                Id = u.Id,
                CodTracking = u.CodTracking,
                Empleado = u.Empleado?.Id ?? 0, // Default value if null
                Cliente = u.Cliente?.Id ?? 0,   // Default value if null
                PesoPaquete = u.PesoPaquete,
                Estado = u.Estado,
            }).ToList();
        }

        public static Urgente UrgenteFromUrgenteDTO(Usuario cliente, Usuario empleado, UrgenteDTO urgenteDTO)
        {
            return new Urgente(cliente, empleado, urgenteDTO.Peso, urgenteDTO.DirPostal);
        }
    }
}
