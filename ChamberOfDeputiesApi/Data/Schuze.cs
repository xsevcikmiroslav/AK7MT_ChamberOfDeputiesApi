using System.Text.Json.Serialization;

namespace ChamberOfDeputiesApi.Data
{
    public class Schuze
    {
        //Identifikátor schůze, není to primární klíč, je nutno používat i položku schuze:pozvanka. Záznamy schůzí stejného orgánu a stejného čísla (tj. schuze:id_org a schuze:schuze), mají stejné schuze:id_schuze a liší se pouze v schuze:pozvanka.
        public int IdSchuze { get; set; }

        //Identifikátor orgánu, viz org:id_org.
        public int IdOrganu { get; set; }

        //Číslo schůze.
        public int CisloSchuze { get; set; }

        //Předpokládaný začátek schůze; viz též tabulka schuze_stav
        public DateTime SchuzeOd { get; set; }

        //Konec schůze. V případě schuze:pozvanka == 1 se nevyplňuje.
        public DateTime SchuzeDo { get; set; }

        //Datum a čas poslední aktualizace.
        public DateTime Aktualizace { get; set; }

        //Druh záznamu: null - schválený pořad, 1 - navržený pořad.
        public int Pozvanka { get; set; }
    }
}
