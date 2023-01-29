namespace ChamberOfDeputiesApi.Data
{
    public class BodSchuze
    {
        //Identifikátor bodu pořadu schůze, není to primární klíč, je nutno používat i položku bod_schuze:pozvanka. Záznamy se stejným id_bod odkazují na stejný bod, i když číslo bodu může být rozdílné (během schvalování pořadu schůze se pořadí bodů může změnit).
        public int IdBod { get; set; }

        //Identifikátor schůze, viz schuze:id_schuze a též schuze:pozvanka.
        public int IdSchuze { get; set; }

        //Identifikátor tisku, pokud se bod k němu vztahuje. V tomto případě lze využít bod_schuze:uplny_kon.
        public int IdTisk { get; set; }

        //Typ bodu, resp. typ projednávání. Kromě bod_schuze:id_typ == 6, se jedná o typ stavu, viz stavy:id_typ a tabulka níže. Je-li bod_schuze:id_typ == 6, jedná se o jednotlivou odpověď na písemnou interpelaci a tento záznam se obykle nezobrazuje (navíc má stejné id_bodu jako bod odpovědi na písemné interpelace a může mít různé číslo bodu).
        public int IdTyp { get; set; }

        //Číslo bodu. Pokud je menší než jedna, pak se při výpisu číslo bodu nezobrazuje.
        public int CisloBoduSchuze { get; set; }

        //Úplný název bodu.
        public string UplnyNazev { get; set; }

        //Koncovka názvu bodu s identifikací čísla tisku nebo čísla sněmovního dokumentu, pokud jsou používány, viz bod_schuze:id_tisk a bod_schuze:id_sd.
        public string KoncovkaNazvu { get; set; }

        //Poznámka k bodu - obvykle obsahuje informaci o pevném zařazení bodu.
        public string Poznamka { get; set; }

        //Stav bodu pořadu, viz bod_stav:id_bod_stav. U bodů návrhu pořadu se nepoužije.
        public int StavBodu { get; set; }

        //Rozlišení záznamu, viz schuze:pozvanka
        public int Pozvanka { get; set; }
        
        //Režim dle par. 90, odst. 2 jednacího řádu.
        public int Rezim { get; set; }

        //Poznámka k bodu, zkrácený zápis
        public string Poznamka2 { get; set; }

        //Druh bodu: 0 nebo null: normální, 1: odpovědi na ústní interpelace, 2: odpovědi na písemné interpelace, 3: volební bod
        public int DruhBodu { get; set; }

        //Identifikátor sněmovního dokumentu, viz sd_dokument:id_dokument. Pokud není null, při výpisu se zobrazuje bod_schuze:uplny_kon.
        public int IdSnemovnihoDokumentu { get; set; }

        //Zkrácený název bodu, neoficiální.
        public string ZkratkaBodu { get; set; }
    }
}
