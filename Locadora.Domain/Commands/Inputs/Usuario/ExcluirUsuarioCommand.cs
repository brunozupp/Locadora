using Flunt.Notifications;
using Locadora.Infra.Interfaces.Commands;
using System.Text.Json.Serialization;

namespace Locadora.Domain.Commands.Inputs.Usuario
{
    public class ExcluirUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id precisa ser maior que 0");


                return Valid;

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
