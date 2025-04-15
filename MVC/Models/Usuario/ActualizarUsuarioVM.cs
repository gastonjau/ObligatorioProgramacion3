using MVC.Models.Rol;

namespace MVC.Models.Usuario
{
    public class ActualizarUsuarioVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Rol {  get; set; }

        public IEnumerable<RolViewModel> Roles { get; set; } = new List<RolViewModel>();
    }
}
