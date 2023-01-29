using Microsoft.AspNetCore.Mvc;
using ChamberOfDeputiesApi.BusinessObjects.Interfaces;
using ChamberOfDeputiesApi.DTO;

namespace ChamberOfDeputiesApi.Controllers
{
    [Route("vote")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private IVoteManager _voteManager;

        public VoteController(IVoteManager voteManager)
        {
            _voteManager = voteManager;
        }

        [HttpGet("all")]
        public IList<DTOVote> GetAll()
        {
            return _voteManager.GetAll();
        }

        [HttpGet("find/{searchTerm}")]
        public IList<DTOVote> Find(string searchTerm)
        {
            return _voteManager.Find(searchTerm);
        }
    }
}
