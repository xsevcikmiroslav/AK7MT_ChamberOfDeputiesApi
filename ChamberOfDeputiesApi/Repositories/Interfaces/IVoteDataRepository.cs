using ChamberOfDeputiesApi.Data;

namespace ChamberOfDeputiesApi.Repositories.Interfaces
{
    public interface IVoteDataRepository
    {
        IList<Hlasovani> Hlasovani { get; }

        IList<Schuze> Schuze { get; }

        IList<BodSchuze> BodSchuze { get; }
    }
}
