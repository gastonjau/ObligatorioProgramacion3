using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class ListadoEnvioDTO
    {
        public int Id { get; set; }
        public string CodTracking { get; set; }
        public int Empleado { get; set; }
        public int Cliente { get; set; }
        public double PesoPaquete { get; set; }
        public string Estado { get; set; }
        public string Etapas { get; set; }

        //public Comentario Comentario { get; set; }

    }
}
