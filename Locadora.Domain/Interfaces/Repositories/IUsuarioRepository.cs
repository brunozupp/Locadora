using Locadora.Domain.Entidades;
using Locadora.Domain.Query;
using System.Collections.Generic;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        long Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Excluir(long id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult Obter(long id);
        bool CheckId(long id);

        bool Autenticar(string login, string senha);
    }
}
