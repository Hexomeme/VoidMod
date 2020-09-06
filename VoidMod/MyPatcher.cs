using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace VoidMod
{
    class MyPatcher
    {
        public static void DoPatching()
        {
            
            var harmony = new Harmony("com.example.patch");
           // Harmony.DEBUG = true;
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(scriptEncounterArea))]
    [HarmonyPatch("Start")]
    class PatchReadEncounterAreas
    {
        static void Postfix(scriptEncounterArea __instance)
        {
            if (Harmony.DEBUG)
            {
                FileLog.Log("Titel: " + __instance.title);
            }
            
        }
    }

    [HarmonyPatch(typeof(scriptEncounterArea))]
    [HarmonyPatch("FillEncounterData")]
    class PatchEncounterAreas
    {
        static void Postfix(scriptEncounterArea __instance)
        {
            ModifyArea(__instance);
        }
        public static void ModifyArea(scriptEncounterArea __instance)
        {
            try
            {
                List<string> monsterlist = new List<string>();
                monsterlist.AddRange(VoidConstants.MODENCOUNTERS.GetValueSafe(__instance.title));

                for (int i = 0; i < __instance.monsters.Count() - 1; i++)
                {
                    monsterlist.Add(__instance.monsters[i]);
                }

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<scriptOWPlayer>().SetEncounterData(
                    __instance.canEncounter,   // Boolean to determine if monsters can spawn
                    monsterlist.ToArray(),     // List of monsters that are supposed to spawn
                    __instance.levelMin,       // Minimum level of wild monsters
                    __instance.levelMax,       // Maximum level of wild monsters
                    __instance.encounterDelay, // Not sure. Either the delay between the monster spawning and beginning to act or the timer inbetween spawns
                    __instance.uMonID,         // ID of the wild crossbreed
                    __instance.uMonVar,        // Crossbreed Variant
                    __instance.uMonPal);       // Color Palette of the variant 
            }
            catch (Exception e)
            {
                FileLog.Log("Titel: " + __instance.title);
                FileLog.Log(e.Message);
                FileLog.Log(e.StackTrace);
                FileLog.Log(e.InnerException.Message);
                FileLog.Log(e.InnerException.StackTrace);

            }
        }
    }
}
