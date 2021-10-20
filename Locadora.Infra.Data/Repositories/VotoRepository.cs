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
    public class VotoRepository : IVotoRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContext _dataContext;

        public VotoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("VotoId", id, DbType.Int64);

                return _dataContext.SqlServerConexao.Query<bool>(VotoQueries.CheckId, _parameters).FirstOrDefault();
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
                _parameters.Add("VotoId", id, DbType.Int64);

                _dataContext.SqlServerConexao.Execute(VotoQueries.Excluir, _parameters);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public long Inserir(Voto voto)
        {
            try
            {
                _parameters.Add("FilmeId", voto.FilmeId, DbType.Int64);
                _parameters.Add("UsuarioId", voto.UsuarioId, DbType.Int64);

                return _dataContext.SqlServerConexao.ExecuteScalar<long>(VotoQueries.Inserir, _parameters);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public List<VotoQueryResult> Listar()
        {
            try
            {
                return _dataContext.SqlServerConexao.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                    VotoQueries.Listar,
                    map: ((voto, usuario, filme) =>
                    {
                        voto.Filme = filme;
                        voto.Usuario = usuario;

                        return voto;
                    }),
                        splitOn: "VotoId,FilmeId,UsuarioId"
                    ).ToList();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
