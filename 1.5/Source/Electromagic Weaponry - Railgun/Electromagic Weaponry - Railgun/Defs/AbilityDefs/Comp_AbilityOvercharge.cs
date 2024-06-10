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
    public class CompProperties_AbilityOvercharge : CompProperties_AbilityEffect
    {
        public CompProperties_AbilityOvercharge()
        {
            compClass = typeof(CompAbilityOvercharge);
        }
    }

    public class CompAbilityOvercharge : CompAbilityEffect
    {
        private new CompProperties_AbilityOvercharge Props => (CompProperties_AbilityOvercharge)props;

        private Pawn Caster => parent.pawn;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Map tarMap = GetMap(target);
            Pawn tarPawn = target.Pawn;
            IntVec3 cell = target.Cell;

            tarMap.weatherManager.eventHandler.AddEvent(new WeatherEvent_LightningStrike(tarMap, cell));
            tarPawn.health.AddHediff(EMW_Railgun.InternalDefOf.EMW_ElectromagicallyCharged);
        }

        public Map GetMap(LocalTargetInfo target)
        {
            if (target.Pawn != null)
            {
                return target.Pawn.Map;
            }
            return Caster.Map;
        }
    }
}
