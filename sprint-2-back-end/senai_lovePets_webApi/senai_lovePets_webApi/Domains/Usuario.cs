using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_lovePets_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pets = new HashSet<Pet>();
            Veterinarios = new HashSet<Veterinario>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "O campo e-mail é Obrigatorio!")]
        public string Email { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "O campo senha é Obrigatorio!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo senha dever ter de 5 a 100 Caracteres!")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Veterinario> Veterinarios { get; set; }
    }
}
