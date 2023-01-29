using ChamberOfDeputiesApi.BusinessObjects.Interfaces;
using ChamberOfDeputiesApi.Data;
using ChamberOfDeputiesApi.DTO;
using ChamberOfDeputiesApi.Repositories.Interfaces;

namespace ChamberOfDeputiesApi.BusinessObjects
{
    public class VoteManager : IVoteManager
    {
        private IVoteDataRepository _voteDataRepository;

        public VoteManager(IVoteDataRepository voteDataRepository)
        {
            _voteDataRepository = voteDataRepository;
        }

        public IList<DTOVote> GetAll()
        {
            var hlasovaniASchuze =
                from hlasovani in _voteDataRepository.Hlasovani
                join schuze in _voteDataRepository.Schuze
                on new { hlasovani.IdOrganu, hlasovani.CisloSchuze }
                equals
                new { schuze.IdOrganu, schuze.CisloSchuze }
                select new
                {
                    schuze.IdSchuze,
                    hlasovani.CisloBoduSchuze,
                    NazevHlasovani = hlasovani.NazevDlouhy,
                    schuze.SchuzeOd,
                    schuze.SchuzeDo,
                    hlasovani.Pro,
                    hlasovani.Proti,
                    hlasovani.ZdrzeliSe,
                    hlasovani.Nehlasovali,
                    hlasovani.Vysledek,
                };

            return (
                from hlasovani in hlasovaniASchuze
                join bodSchuze in _voteDataRepository.BodSchuze
                on new { hlasovani.IdSchuze, hlasovani.CisloBoduSchuze }
                equals
                new { bodSchuze.IdSchuze, bodSchuze.CisloBoduSchuze }
                select new DTOVote
                {
                    IdSchuze = hlasovani.IdSchuze,
                    CisloBoduSchuze = hlasovani.CisloBoduSchuze,
                    NazevHlasovani = hlasovani.NazevHlasovani,
                    NazevBoduHlasovani = bodSchuze.UplnyNazev,
                    CisloBodu = bodSchuze.CisloBoduSchuze,
                    SchuzeOd = hlasovani.SchuzeOd,
                    SchuzeDo = hlasovani.SchuzeDo,
                    Pro = hlasovani.Pro,
                    Proti = hlasovani.Proti,
                    ZdrzeliSe = hlasovani.ZdrzeliSe,
                    Nehlasovali = hlasovani.Nehlasovali,
                    Vysledek = hlasovani.Vysledek,
                })
                .Where(s => s.SchuzeOd > new DateTime(2022, 1, 1))
                .OrderByDescending(s => s.SchuzeOd)
                .ToList();
        }

        public IList<DTOVote> Find(string searchTerm)
        {
            return null;
        }
    }
}
