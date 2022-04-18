using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Presentation.Models.Validations
{
    /// <summary>
    /// Classe de validação para campos de senha
    /// </summary>
    public class PasswordValidation : ValidationAttribute
    {
        /// <summary>
        /// MÉTODO PARA IMPLEMENTAR A REGRA DE VALIDAÇÃO
        /// </summary>
        /// <param name="value">REPRESNTA O VALOR DO CAMPO QUE SERÁ VALIDADO</param>
        /// <returns>TRUE OU FALSE. DEPENDENDO DO RESULTADO DA VALIDAÇÃO</returns>
        public override bool IsValid(object? value)
        {
            //VERIFICAR SE O VALOR RECEBIDO É VAZIO
            if (value != null)
            {
                //converter o valor para string
                var senha = value.ToString();

                //Verificando o conteúdo da senha
                return senha.Any(s => char.IsLower(s))//pelo menos uma letra é minúscula.
                    && senha.Any(s => char.IsUpper(s))//pelo menos uma letra é maiúscula.
                    && senha.Any(s => char.IsDigit(s))//pelo menos um número.
                    && (
                    senha.Contains("@") || //
                    senha.Contains("$") || // 
                    senha.Contains("#") || // Pelo menos uma dessas opções é verdadeira
                    senha.Contains("%")    //
                    );
            }       
            return false;
        }
    }
}
