namespace Locadora.Infra.Data.Repositories.Queries
{
    public class UsuarioQueries
    {
        public static string Inserir = @"INSERT INTO Usuarios(Nome,Login,Senha) VALUES(@Nome,@Login,@Senha);
                                        Select SCOPE_IDENTITY();";

        public static string Atualizar = @"UPDATE Usuarios SET Nome = @Nome, Login = @Login, Senha = @Senha WHERE UsuarioId = @UsuarioId;";

        public static string Excluir = @"DELETE FROM Usuarios WHERE UsuarioId = @UsuarioId;";

        public static string Listar = @"SELECT UsuarioId as UsuarioId,Nome as Nome,Login as Login, Senha as Senha FROM Usuarios;";

        public static string Obter = @"SELECT UsuarioId as UsuarioId,Nome as Nome,Login as Login, Senha as Senha FROM Usuarios WHERE UsuarioId = @UsuarioId;";

        public static string CheckId = @"Select UsuarioId From Usuarios WHERE UsuarioId=@UsuarioId";

        public static string Autenticar = @"Select UsuarioId From Usuarios WHERE Login=@Login AND Senha=@Senha";
    }
}
