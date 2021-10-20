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

        bool CheckId(long id);
    }
}
