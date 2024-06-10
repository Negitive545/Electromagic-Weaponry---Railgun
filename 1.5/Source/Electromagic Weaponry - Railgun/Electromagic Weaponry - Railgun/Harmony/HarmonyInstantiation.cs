using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using HarmonyLib;
using Unity;

namespace EMW_Railgun.HarmonyEMW
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            Log.Message("Instantiating Harmony for EMW_Railgun");
            var harmony = new Harmony("com.EMWRailgun");
            harmony.PatchAll();
        }
    }
}


