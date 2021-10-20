namespace Locadora.Infra.Data.Repositories.Queries
{
    public class FilmeQueries
    {

        public static string Inserir = @"INSERT INTO Filmes(Titulo,Diretor) VALUES(@Titulo,@Diretor);
                                        Select SCOPE_IDENTITY();";

        public static string Atualizar = @"UPDATE Filmes SET Titulo = @Titulo, Diretor = @Diretor WHERE FilmeId = @FilmeId;";

        public static string Excluir = @"DELETE FROM Filmes WHERE FilmeId = @FilmeId;";

        public static string Listar = @"SELECT FilmeId as FilmeId,Titulo as Titulo,Diretor as Diretor FROM Filmes;";

        public static string Obter = @"SELECT FilmeId as FilmeId,Titulo as Titulo,Diretor as Diretor FROM Filmes WHERE FilmeId = @FilmeId;";

        public static string CheckId = @"Select FilmeId From Filmes Where FilmeId=@FilmeId";

    }
}
