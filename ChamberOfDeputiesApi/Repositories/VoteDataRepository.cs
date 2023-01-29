using ChamberOfDeputiesApi.Repositories.Interfaces;
using ChamberOfDeputiesApi.Data;

namespace ChamberOfDeputiesApi.Repositories
{
    public class VoteDataRepository : IVoteDataRepository
    {
        private static IList<Hlasovani> _allvotes;
        private static IList<Schuze> _allMeetings;
        private static IList<BodSchuze> _allTopicsOfTheMeeting;

        public IList<Hlasovani> Hlasovani => _allvotes;

        public IList<Schuze> Schuze => _allMeetings;

        public IList<BodSchuze> BodSchuze => _allTopicsOfTheMeeting;

        public VoteDataRepository()
        {
            _allvotes ??= LoadAllVotes();

            _allMeetings ??= LoadAllMeetings();

            _allTopicsOfTheMeeting ??= LoadAllTopicsOfTheMeeting();
        }

        private IList<Hlasovani> LoadAllVotes()
        {
            return
                File
                .ReadAllLines(@"D:\Moje Data\Skola\UTB FAI\I Semestr\AUIUI_AK7MT Mobilni Technologie\Data\hl-2021ps\hl2021s.unl")
                .Select(l => ParseHlasovaniFromString(l))
                .ToList();
        }

        private Hlasovani ParseHlasovaniFromString(string input)
        {
            var values = input.Split('|');

            return new Hlasovani
            {
                Id = parseInt(values[0]),
                IdOrganu = parseInt(values[1]),
                CisloSchuze = parseInt(values[2]),
                CisloHlasovani = parseInt(values[3]),
                CisloBoduSchuze = parseInt(values[4]),
                DatumHlasovani = DateTime.Parse($"{values[5]} {values[6]}:00"),
                Pro = parseInt(values[7]),
                Proti = parseInt(values[8]),
                ZdrzeliSe = parseInt(values[9]),
                Nehlasovali = parseInt(values[10]),
                Prihlaseno = parseInt(values[11]),
                Kvorum = parseInt(values[12]),
                DruhHlasovani = values[13][0],
                Vysledek = values[14][0],
                NazevDlouhy = values[15],
                NazevKratky = values[16],
            };
        }

        private IList<Schuze> LoadAllMeetings()
        {
            return
                File
                .ReadAllLines(@"D:\Moje Data\Skola\UTB FAI\I Semestr\AUIUI_AK7MT Mobilni Technologie\Data\schuze\schuze.unl")
                .Select(l => ParseSchuzeFromString(l))
                .ToList();
        }

        private Schuze ParseSchuzeFromString(string input)
        {
            var values = input.Split('|');

            return new Schuze
            {
                IdSchuze = parseInt(values[0]),
                IdOrganu = parseInt(values[1]),
                CisloSchuze = parseInt(values[2]),
                SchuzeOd = DateTime.Parse(values[3]),
                SchuzeDo = string.IsNullOrEmpty(values[4]) ? DateTime.MinValue : DateTime.Parse(values[4]),
                Aktualizace = DateTime.Parse(values[5]),
                Pozvanka = parseInt($"0{values[6]}"),
            };
        }

        private IList<BodSchuze> LoadAllTopicsOfTheMeeting()
        {
            return
                File
                .ReadAllLines(@"D:\Moje Data\Skola\UTB FAI\I Semestr\AUIUI_AK7MT Mobilni Technologie\Data\schuze\bod_schuze.unl")
                .Select(l => ParseBodSchuzeFromString(l))
                .ToList();
        }

        private BodSchuze ParseBodSchuzeFromString(string input)
        {
            var values = input.Split('|');

            return new BodSchuze
            {
                IdBod = parseInt(values[0]),
                IdSchuze = parseInt(values[1]),
                IdTisk = parseInt(values[2]),
                IdTyp = parseInt(values[3]),
                CisloBoduSchuze = parseInt(values[4]),
                UplnyNazev = values[5],
                KoncovkaNazvu = values[6],
                Poznamka = values[7],
                StavBodu = parseInt(values[8]),
                Pozvanka = parseInt($"0{values[9]}"),
                Rezim = parseInt(values[10]),
                Poznamka2 = values[11],
                DruhBodu = parseInt(values[12]),
                IdSnemovnihoDokumentu = parseInt(values[13]),
                ZkratkaBodu = values[14],
            };
        }

        private int parseInt(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            return int.Parse(input);
        }
    }
}
