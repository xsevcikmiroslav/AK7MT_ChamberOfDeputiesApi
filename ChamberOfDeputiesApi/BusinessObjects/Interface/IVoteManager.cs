using ChamberOfDeputiesApi.DTO;

namespace ChamberOfDeputiesApi.BusinessObjects.Interface
{
    public interface IVoteManager
    {
        IList<DTOVote> GetAll();
    }
}
