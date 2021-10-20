using Flunt.Notifications;
using Locadora.Infra.Interfaces.Commands;

namespace Locadora.Domain.Commands.Inputs.Autenticacao
{
    public class AutenticacaoCommand : Notifiable, ICommandPadrao
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Login))
                    AddNotification("Login", "Login é obrigatório.");

                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha é obrigatório.");

                return Valid;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
