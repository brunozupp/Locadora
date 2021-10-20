namespace Locadora.Infra.Data.Repositories.Queries
{
    public class VotoQueries
    {
        public static string Inserir = @"INSERT INTO Votos(UsuarioId,FilmeId) VALUES(@UsuarioId,@FilmeId);
                                        Select SCOPE_IDENTITY();";

        public static string Excluir = @"DELETE FROM Votos WHERE VotoId = @VotoId;";

        public static string Listar = @"SELECT V.VotoId,
                                        F.FilmeId as FilmeId, F.Titulo as Titulo, F.Diretor as Diretor,
                                        U.UsuarioId, U.Nome, U.Login
                                        FROM Votos V
                                        INNER JOIN Filmes F ON F.FilmeId = V.FilmeId
                                        INNER JOIN Usuarios U ON U.UsuarioId = V.UsuarioId;";

        public static string CheckId = @"Select VotoId From Votos Where VotoId=@VotoId";
    }
}
