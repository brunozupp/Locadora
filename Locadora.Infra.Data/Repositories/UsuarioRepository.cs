using Dapper;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Query;
using Locadora.Infra.Data.DataContexts;
using Locadora.Infra.Data.Repositories.Queries;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Locadora.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _parameters.Add("UsuarioId", usuario.UsuarioId, DbType.Int64);
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);

                _dataContext.SqlServerConexao.Execute(UsuarioQueries.Atualizar, _parameters);

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public bool Autenticar(string login, string senha)
        {
            try
            {
                _parameters.Add("Login", login, DbType.String);
                _parameters.Add("Senha", senha, DbType.String);

                return _dataContext.SqlServerConexao.Query<bool>(UsuarioQueries.Autenticar, _parameters).FirstOrDefault();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("UsuarioId", id, DbType.Int64);

                return _dataContext.SqlServerConexao.Query<bool>(UsuarioQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public void Excluir(long id)
        {
            try
            {
                _parameters.Add("UsuarioId", id, DbType.Int64);

                _dataContext.SqlServerConexao.Execute(UsuarioQueries.Excluir, _parameters);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public long Inserir(Usuario usuario)
        {
            try
            {
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);

                return _dataContext.SqlServerConexao.ExecuteScalar<long>(UsuarioQueries.Inserir, _parameters);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public List<UsuarioQueryResult> Listar()
        {
            try
            {
                var usuarios = _dataContext.SqlServerConexao.Query<UsuarioQueryResult>(UsuarioQueries.Listar).ToList();
                return usuarios;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public UsuarioQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("UsuarioId", id, DbType.Int64);

                var usuario = _dataContext.SqlServerConexao.Query<UsuarioQueryResult>(UsuarioQueries.Obter, _parameters).FirstOrDefault();
                return usuario;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
