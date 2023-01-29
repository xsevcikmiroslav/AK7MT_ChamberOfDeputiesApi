using System.Text.Json.Serialization;

namespace ChamberOfDeputiesApi.DTO
{
    public class DTOVote
    {
        //Identifikátor hlasování
        [JsonIgnore]
        public int Id { get; set; }

        //Identifikátor orgánu
        [JsonIgnore]
        public int IdOrganu { get; set; }

        //Číslo schůze
        public int CisloSchuze { get; set; }

        //Číslo hlasování
        public int CisloHlasovani { get; set; }

        //Bod pořadu schůze; je-li menší než 1, pak jde o procedurální hlasování nebo o hlasování k bodům, které v době hlasování neměly přiděleno číslo.
        public int IdBodPoraduSchuze { get; set; }

        //Datum a čas hlasování
        public DateTime DatumHlasovani { get; set; }
        
        //Počet hlasujících pro
        public int Pro { get; set; }

        //Počet hlasujících proti
        public int Proti { get; set; }

        //Počet hlasujících zdržel se, tj. stiskl tlačítko X
        public int ZdrzeliSe { get; set; }

        //Počet přihlášených, kteří nestiskli žádné tlačítko
        public int Nehlasovali { get; set; }

        //Počet přihlášených poslanců
        public int Prihlaseno { get; set; }

        // nejmenší počet hlasů k přijetí návrhu
        public int Kvorum { get; set; }

        //N - normální, R - ruční (nejsou známy hlasování jednotlivých poslanců), E - vinou technické závady nejsou dostupná všechna data k hlasování, např. výsledky hlasování jednotlivých poslanců.
        public char DruhHlasovani { get; set; }

        //Výsledek: A - přijato, R - zamítnuto, jinak zmatečné hlasování
        public char Vysledek { get; set; }

        //Dlouhý název bodu hlasování
        public string NazevDlouhy { get; set; }

        //Krátký název bodu hlasování
        public string NazevKratky { get; set; }
    }
}
