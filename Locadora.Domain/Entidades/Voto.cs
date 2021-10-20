namespace Locadora.Domain.Entidades
{
    public class Voto
    {
        public long VotoId { get; private set; }

        public long UsuarioId { get; private set; }

        public long FilmeId { get; private set; }

        public Voto(long votoId, long usuarioId, long filmeId)
        {
            VotoId = votoId;
            UsuarioId = usuarioId;
            FilmeId = filmeId;
        }

        public void AtualizarId(long votoId)
        {
            VotoId = votoId;
        }
    }
}
