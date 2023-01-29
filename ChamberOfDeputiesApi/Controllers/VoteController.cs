using ChamberOfDeputiesApi.BusinessObjects.Interface;
using ChamberOfDeputiesApi.DTO;
using Microsoft.AspNetCore.Mvc;

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
    }
}
