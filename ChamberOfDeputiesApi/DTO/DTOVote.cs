namespace ChamberOfDeputiesApi.DTO
{
    public class DTOVote
    {
        public string NazevHlasovani { get; set; }

        public string NazevBoduHlasovani { get; set; }

        public int CisloBodu { get; set; }

        public DateTime SchuzeOd { get; set; }

        public DateTime SchuzeDo { get; set; }

        public int Pro { get; set; }

        public int Proti { get; set; }

        public int ZdrzeliSe { get; set; }

        public int Nehlasovali { get; set; }

        public char Vysledek { get; set; }

        public int IdSchuze { get; set; }

        public int CisloBoduSchuze { get; set; }
    }
}
