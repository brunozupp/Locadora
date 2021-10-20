using Flunt.Notifications;
using Locadora.Infra.Interfaces.Commands;

namespace Locadora.Domain.Commands.Inputs.Voto
{
    public class AdicionarVotoCommand : Notifiable, ICommandPadrao
    {
        public long UsuarioId { get; set; }

        public long FilmeId { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (UsuarioId <= 0)
                    AddNotification("UsuarioId", "UsuarioId precisa ser maior que 0");

                if (FilmeId <= 0)
                    AddNotification("FilmeId", "FilmeId precisa ser maior que 0");

                return Valid;

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
