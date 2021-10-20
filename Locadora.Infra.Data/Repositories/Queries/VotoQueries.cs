namespace Locadora.Infra.Data.Repositories.Queries
{
    public class VotoQueries
    {
        public static string Inserir = @"INSERT INTO Votos(UsuarioId,FilmeId) VALUES(@UsuarioId,@FilmeId);
                                        Select SCOPE_IDENTITY();";

        public static string Excluir = @"DELETE FROM Votos WHERE VotoId = @VotoId;";

        public static string Listar = @"SELECT V.VotoId,
                                        F.FilmeId as FilmeId, F.Titulo as Titulo, F.Diretor as Diretor,
                                        U.UsuarioId as UsuarioId, U.Nome as Nome, U.Login as Login
                                        FROM Votos V
                                        INNER JOIN Filmes F ON F.FilmeId = V.FilmeId
                                        INNER JOIN Usuarios U ON U.UsuarioId = V.UsuarioId;";

        public static string ListarPorUsuario = @"SELECT V.VotoId,
                                        F.FilmeId as FilmeId, F.Titulo as Titulo, F.Diretor as Diretor
                                        FROM Votos V
                                        INNER JOIN Filmes F ON F.FilmeId = V.FilmeId
                                        WHERE V.UsuarioId = @UsuarioId;";

        public static string CheckId = @"Select VotoId From Votos Where VotoId=@VotoId";

        public static string JaFoiVotado = @"Select VotoId From Votos Where UsuarioId=@UsuarioId AND FilmeId=@FilmeId";
    }
}
