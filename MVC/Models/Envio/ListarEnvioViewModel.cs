namespace MVC.Models.Envio
{
    public class ListarEnvioViewModel
    {
        public int Id { get; set; }
        public string CodTracking { get; set; }
        public int Empleado { get; set; }
        public int Cliente { get; set; }
        public double PesoPaquete { get; set; }
        public string Estado { get; set; }
        public string Etapas { get; set; }


    }
}
