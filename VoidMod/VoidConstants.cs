using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoidMod
{
    /*
     * Collection of readonly variables required for the mod to work
     *      
     */
    static class VoidConstants
    {
        public static readonly Dictionary<string, string[]> MODENCOUNTERS
            = new Dictionary<string, string[]>
            {
                /* The first value is the name of the EncounterArea. 
                 * 
                 * The second value is an array of IDs of monsters you want to spawn in ADDITION to the preexistent set of spawns. 
                 */
                {"Windy Province", new string[] {"51"}},
                {"Riverbed", new string[] {"42", "60"}}
            };
    }
}
