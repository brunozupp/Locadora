using Flunt.Notifications;
using Locadora.Infra.Interfaces.Commands;
using System.Text.Json.Serialization;

namespace Locadora.Domain.Commands.Inputs.Voto
{
    public class AtualizarVotoCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public long UsuarioId { get; set; }

        public long FilmeId { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id precisa ser maior que 0");

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
