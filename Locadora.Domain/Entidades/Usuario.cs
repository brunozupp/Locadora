namespace Locadora.Domain.Entidades
{
    public class Usuario
    {
        public long UsuarioId { get; private set; }

        public string Nome { get; private set; }

        public string Login { get; private set; }

        public string Senha { get; private set; }

        public Usuario(long usuarioId, string nome, string login, string senha)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public void AtualizarId(long usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}
