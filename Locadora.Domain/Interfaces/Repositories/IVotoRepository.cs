using Locadora.Domain.Entidades;
using Locadora.Domain.Query;
using System.Collections.Generic;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        long Inserir(Voto voto);

        void Excluir(long id);

        List<VotoQueryResult> Listar();

        List<VotoDoUsuarioQueryResult> ListarPorUsuario(long usuarioId);

        bool CheckId(long id);

        bool JaFoiVotado(long usuarioId, long filmeId);
    }
}
