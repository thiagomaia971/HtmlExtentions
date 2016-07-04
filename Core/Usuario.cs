using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Login xP")]
        public string Login { get; set; }

        public Perfil Perfil { get; set; }

    }
}
