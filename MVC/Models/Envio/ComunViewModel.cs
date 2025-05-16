using Compartido.DTOs.Agencia;
using MVC.Models.Agencia;

namespace MVC.Models.Envio
{
    public class ComunViewModel
    {
        public string Email { get; set; }
        public int AgenciaId { get; set; }
        public double Peso { get; set; }
        public IEnumerable<DatoAgenciaViewModel> Agencias { get; set; } = new List<DatoAgenciaViewModel>();
    }
}
