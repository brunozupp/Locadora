namespace Locadora.Domain.Entidades
{
    public class Filme
    {
        public long FilmeId { get; private set; }

        public string Titulo { get; private set; }

        public string Diretor { get; private set; }

        public Filme(long filmeId, string titulo, string diretor)
        {
            FilmeId = filmeId;
            Titulo = titulo;
            Diretor = diretor;
        }

        public void AtualizarId(long filmeId)
        {
            FilmeId = filmeId;
        }

    }
}
