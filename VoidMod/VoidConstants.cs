using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoidMod
{
    /**
     * Collection of readonly variables required for the mod to work
     *      
     */
    static class VoidConstants
    {
        //Begin Area Constants
        public static readonly string AREA_WINDY_PROV = "Windy Province";
        public static readonly string AREA_RIVERBED = "Riverbed";
        public static readonly string AREA_DESPERADO_PROV = "Desperado Province";
        public static readonly string AREA_DESPERADO_PROV2 = "Desperado Prov";
        public static readonly string AREA_OCEANVIEW_BEACH = "Oceanview Beach";        
        public static readonly string AREA_ROAD_1 = "Road 1"; // Collures Forest?
        public static readonly string AREA_HUMANISM = "Humanism Kingdom";
        public static readonly string AREA_UNDERGROWTH = "Undergrowth Pass";
        public static readonly string AREA_PLAINS_PROV = "Plains Province";
        public static readonly string AREA_HEWSTON_CITY = "Hewston City";
        public static readonly string AREA_DARK_CASTLE = "Dark Castle";
        public static readonly string AREA_WETLAND_PROV = "Wetland Province";
        public static readonly string AREA_DEEP_CHASM = "Deep Chasm";
        public static readonly string AREA_NIOKIO_CITY = "Nio Kio City";
        public static readonly string AREA_UNDERWATER_PASS = "Underwater Pass";
        public static readonly string AREA_DUCHESS_TOWER = "Duchess's Tower"; // That's not how 's works!
        public static readonly string AREA_DEW_CAVE = "Dew Cave";
        public static readonly string AREA_FLOWERING_PROV = "Flowering Province";
        public static readonly string AREA_SCARRED_PROV = "Scarred Province";
        public static readonly string AREA_OCEANVIEW_WOODS = "Oceanview Woods";
        public static readonly string AREA_RED_SANDS_PROV = "Red Sands Province";
        public static readonly string AREA_DRAGON_CLIFF_PROV = "Dragon Cliff Province";
        public static readonly string AREA_CROSSROADS_TOWN = "Crossroads Town";
        public static readonly string AREA_FROST_PROV = "Frost Province";
        public static readonly string AREA_MILLDEW = "Mill - Dew"; // Area inbetween Mill Town and Dew Cave
        public static readonly string AREA_FROBEC_CITY = "Frobec City";
        public static readonly string AREA_MILL_TOWN = "Mill Town";
        public static readonly string AREA_DEEP_WOODS = "Deep Woods";
        public static readonly string AREA_APO_PLATEAU = "Apo Plateau"; // Can I spawn a bunch of Tanukrook here, please?
        public static readonly string AREA_FARM = "The Farm";
        public static readonly string AREA_FROBEC_CAVERN = "Frobec Cavern";
        public static readonly string AREA_FROBEC_MOUNTAIN = "Frobec Mountain";
        public static readonly string AREA_KINGDOM_CRYPT = "Kingdom Crypt";
        public static readonly string AREA_APPENTON_CITY = "Appenton City";
        public static readonly string AREA_RAPTOR_MT = "Raptor Mt."; // Would've preferred Raptor MC, really. 
        public static readonly string AREA_CHARITY_KINGDOM = "Charity Kingdom";
        public static readonly string AREA_DUCHESS_GARDEN = "Duchess's Garden"; // Someone really has to teach dev how 's works...
        public static readonly string AREA_NIOKIO_CHAMBER = "Nio Kio Chamber";
        public static readonly string AREA_BESTS_RANCH = "Best's Ranch"; // Now that is how an 's works.
        public static readonly string AREA_APPENTON_CRYPT = "Appenton Crypt";
        public static readonly string AREA_EMPATHY_KINGDOM = "Empathy Kingdom";
        // End of Area Constants. Ducking finally.


        /**
         * Dictionary of encounter alterations by area
         */
        public static readonly Dictionary<string, string[]> MODENCOUNTERS
            = new Dictionary<string, string[]>
            {
                /* The first value is the name of the EncounterArea. 
                 * 
                 * The second value is an array of IDs of monsters you want to spawn in ADDITION to the preexistent set of spawns. 
                 */
                {AREA_WINDY_PROV, new string[] {"51"}},
                {AREA_RIVERBED, new string[] {"42", "60"}}

            };
    }
}
