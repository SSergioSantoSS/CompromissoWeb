using AgendaWeb.Presentation.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Presentation.Models
{
    public class AccountRegisterModel
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no minimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage ="Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public string Email { get; set; }
        
        [PasswordValidation(ErrorMessage ="Por favor, informe uma senha com no minimo 1 letra minúscula, 1 letra maiúscula, um digito numérico e um caractere especial (@, #, $, %")]
        [MinLength(8, ErrorMessage = "Por favor, informe no minimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme a senha de acesso.")]
        public string SenhaConfirmacao { get; set; }

    }
}
