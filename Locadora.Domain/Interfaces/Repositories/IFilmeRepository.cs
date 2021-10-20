using Locadora.Domain.Entidades;
using Locadora.Domain.Query;
using System.Collections.Generic;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        long Inserir(Filme filme);
        void Atualizar(Filme filme);
        void Excluir(long id);
        List<FilmeQueryResult> Listar();
        FilmeQueryResult Obter(long id);
        bool CheckId(long id);

    }
}
