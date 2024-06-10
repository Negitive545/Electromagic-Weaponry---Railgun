using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using Unity;

namespace EMW_Railgun
{
    [DefOf]
    public static class InternalDefOf
    {
        public static HediffDef EMW_ElectromagicallyCharged;

        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }
    }
}
