using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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

            //harmony.Patch(
            //    typeof(scriptEncounterArea).GetMethod("FillEncounterData"),
            //    new HarmonyMethod(typeof(PatchEncounterAreas).GetMethod("Postfix")));
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
                GameObject global = GameObject.FindGameObjectWithTag("Global");

                if (Harmony.DEBUG)
                {
                    FileLog.Log("Anzahl Sprites: " + global.GetComponent<scriptMonsters>().dSprites.Length);
                    foreach (Sprite ds in global.GetComponent<scriptMonsters>().dSprites)
                    {
                        FileLog.Log("Sprite Name: " + ds.name);
                    }
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
    [HarmonyPatch(typeof(scriptMasterLoader))]
    [HarmonyPatch("Update")]
    class PatchMasterLoader
    {

        
        static void Postfix (scriptMasterLoader __instance, ref string ___assetPath, ref int ___phase)
        {
            try
            {              
                if (___phase == 1)
                {
                    FileLog.LogBuffered("Current Phase: " + ___phase.ToString());
                    FileLog.LogBuffered("assetpath: " + ___assetPath);
                    String modpath = ___assetPath;                    
                    FileLog.LogBuffered("modpath: " + modpath);
                    modpath += "Mods/";
                    FileLog.LogBuffered("modpath2: " + modpath);


                    if(Harmony.DEBUG)
                    {
                        FileLog.FlushBuffer();
                    }
                    FileLog.Reset();
                    AssetLoader loader =  AssetLoader.Instance;
                    loader.loadAssets(modpath);
                    FileLog.Log("Assets loaded");
                } else if (___phase == 13)
                { 
                    GameObject global = GameObject.FindGameObjectWithTag("Global");

                    FileLog.Log("Number of monster sprites: " + global.GetComponent<scriptMonsters>().dSprites.Length);
                    FileLog.Log("Number of follower sprites: " + global.GetComponent<scriptMonsters>().followMon.Length);
                    FileLog.Log("Number of egg sprites: " + global.GetComponent<scriptMonsters>().dEggSprites.Length);
                }
                
            }
            catch (Exception e)
            {
                FileLog.Log(e.Message);
                FileLog.Log(e.StackTrace);
                FileLog.Log(e.InnerException.Message);
                FileLog.Log(e.InnerException.StackTrace);
                }
            
        }
    }

    [HarmonyPatch(typeof(scriptMonsters))]
    [HarmonyPatch("LoadBinaryData")]
    class PatchBinaryDataLoad
    {
        static bool Prefix(scriptMonsters __instance)
        {
            try
            {
                AssetLoader loader = AssetLoader.Instance;
                List<Sprite> spriteList = new List<Sprite>();
                spriteList.AddRange(loader.getMonSprites());
                spriteList.AddRange(Resources.LoadAll<Sprite>("monsters"));
                __instance.dSprites = spriteList.ToArray();
                spriteList.Clear();
                spriteList.AddRange(loader.getFollowSprites());
                spriteList.AddRange(Resources.LoadAll<Sprite>("followMonsters"));
                __instance.followMon = spriteList.ToArray();
                spriteList.Clear();
                spriteList.AddRange(loader.getEggSprites());
                spriteList.AddRange(Resources.LoadAll<Sprite>("eggs"));
                __instance.dEggSprites = spriteList.ToArray();
                return false;
            }
            catch (Exception e)
            {
                FileLog.Log("Modding Monsters Failed!: ");
                FileLog.Log(e.Message);
                FileLog.Log(e.StackTrace);
                FileLog.Log(e.InnerException.Message);
                FileLog.Log(e.InnerException.StackTrace);
                return true;
            }


        }
    }
}
