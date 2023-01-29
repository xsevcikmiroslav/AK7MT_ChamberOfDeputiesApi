using ChamberOfDeputiesApi.BusinessObjects.Interface;
using ChamberOfDeputiesApi.DTO;
using System.Text;

namespace ChamberOfDeputiesApi.BusinessObjects
{
    public class VoteManager : IVoteManager
    {
        private static IList<DTOVote> _allvotes;

        public VoteManager()
        {
            if (_allvotes == null)
            {
                _allvotes = LoadAllVotes();
            }
        }

        private IList<DTOVote> LoadAllVotes()
        {
            var allvotes = new List<DTOVote>();
            
            var inputFilelines = File.ReadAllLines(@"D:\Moje Data\Skola\UTB FAI\I Semestr\AUIUI_AK7MT Mobilni Technologie\hl-2021ps\hl2021s.unl");

            foreach (var line in inputFilelines)
            {
                allvotes.Add(ParseFromString(line));
            }

            return allvotes;
        }

        private DTOVote ParseFromString(string input)
        {
            var values = input.Split('|');

            return new DTOVote
            {
                Id = int.Parse(values[0]),
                IdOrganu = int.Parse(values[1]),
                CisloSchuze = int.Parse(values[2]),
                CisloHlasovani = int.Parse(values[3]),
                IdBodPoraduSchuze = int.Parse(values[4]),
                DatumHlasovani = DateTime.Parse($"{values[5]} {values[6]}:00"),
                Pro = int.Parse(values[7]),
                Proti = int.Parse(values[8]),
                ZdrzeliSe = int.Parse(values[9]),
                Nehlasovali = int.Parse(values[10]),
                Prihlaseno = int.Parse(values[11]),
                Kvorum = int.Parse(values[12]),
                DruhHlasovani = values[13][0],
                Vysledek = values[14][0],
                NazevDlouhy = values[15],
                NazevKratky = values[16],
            };
        }

        public IList<DTOVote> GetAll()
        {
            return _allvotes;
        }
    }
}
