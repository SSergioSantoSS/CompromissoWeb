﻿using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Presentation.Models
{
    public class AccountLoginModel
    {
        [EmailAddress(ErrorMessage ="Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage ="Por favor, informe o email de acesso.")]
        public string Email { get; set; }

        [MinLength(8,ErrorMessage ="Por favor, informe no minimo {1} caracteres")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres")]
        [Required(ErrorMessage ="Por favor, informe a sua senha de acesso.")]
        public string Senha { get; set; }

    }
}