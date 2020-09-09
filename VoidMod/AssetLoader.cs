using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VoidMod
{
    public sealed class AssetLoader
    {
        private static readonly AssetLoader instance = new AssetLoader();



        private AssetBundle abModmons;
        private AssetBundle abModEggs;
        private AssetBundle abModFollowmons;    

        static AssetLoader() 
        {
        }

        private AssetLoader()
        {
        }

        public static AssetLoader Instance
        {
            get
            {
                return instance;            
            }
        }

        public void loadAssets(string assetpath)
        {            
            abModmons = AssetBundle.LoadFromFile(assetpath+"monster");                       
            abModEggs = AssetBundle.LoadFromFile(assetpath + "egg");            
            abModFollowmons = AssetBundle.LoadFromFile(assetpath + "followMonster");                        
        }

        public Sprite[] getMonSprites()
        {
            return abModmons.LoadAllAssets<Sprite>();
        }

        public Sprite[] getEggSprites()
        {
            return abModEggs.LoadAllAssets<Sprite>();
        }

        public Sprite[] getFollowSprites()
        {
            return abModFollowmons.LoadAllAssets<Sprite>();
        }
    }
}
