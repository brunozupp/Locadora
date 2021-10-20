using Flunt.Notifications;
using Locadora.Infra.Interfaces.Commands;

namespace Locadora.Domain.Commands.Inputs.Filme
{
    public class AdicionarFilmeCommand : Notifiable, ICommandPadrao
    {
        public string Titulo { get; set; }

        public string Diretor { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Titulo))
                    AddNotification("Titulo", "Titulo é um campo obrigatório");
                else if (Titulo.Length > 100)
                    AddNotification("Titulo", "Titulo maior que 100 caracteres");

                if (string.IsNullOrWhiteSpace(Diretor))
                    AddNotification("Diretor", "Diretor é um campo obrigatório");
                else if (Diretor.Length > 100)
                    AddNotification("Diretor", "Diretor maior que 100 caracteres");

                return Valid;

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
