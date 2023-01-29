using ChamberOfDeputiesApi.Data;
using ChamberOfDeputiesApi.DTO;

namespace ChamberOfDeputiesApi.BusinessObjects.Interfaces
{
    public interface IVoteManager
    {
        IList<DTOVote> GetAll();

        IList<DTOVote> Find(string searchTerm);
    }
}
