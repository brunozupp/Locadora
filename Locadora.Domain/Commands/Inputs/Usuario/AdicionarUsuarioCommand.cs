using Flunt.Notifications;
using Locadora.Infra.Interfaces.Commands;

namespace Locadora.Domain.Commands.Inputs.Usuario
{
    public class AdicionarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Nome))
                    AddNotification("Nome", "Nome é um campo obrigatório");
                else if (Nome.Length > 100)
                    AddNotification("Nome", "Nome maior que 100 caracteres");

                if (string.IsNullOrWhiteSpace(Login))
                    AddNotification("Login", "Login é um campo obrigatório");
                else if (Login.Length > 100)
                    AddNotification("Login", "Login maior que 100 caracteres");

                if (string.IsNullOrWhiteSpace(Senha))
                    AddNotification("Senha", "Senha é um campo obrigatório");
                else if (Senha.Length > 255)
                    AddNotification("Senha", "Senha maior que 100 caracteres");

                return Valid;

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
