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
    public class HediffCompProperties_ElectromagicallyCharged : HediffCompProperties
    {
        public HediffCompProperties_ElectromagicallyCharged()
        {
            compClass = typeof(Hediff_ElectromagicallyCharged);
        }
    }


    public class Hediff_ElectromagicallyCharged : Hediff
    {
        private const float chanceToStrike = (0.1f / 60);
        private const int secondsToHeal = 60;
        private const float healSeverityReduction = ((1f / secondsToHeal) / 60);
        private int latestStrikeTick = 0;

        private int TicksSinceLastStrike()
        {
            if (latestStrikeTick != 0) {
                return GenTicks.TicksGame - latestStrikeTick;
            }
            return 9999;
        }

        public override void Tick()
        {
            base.Tick();

            Pawn target = pawn;

            bool randChance = Rand.Chance(chanceToStrike);

            // Log.Message(TicksSinceLastStrike() + " | " + randChance + " | " + chanceToStrike);

            if (TicksSinceLastStrike() >= 60 && randChance)
            {
                // Log.Message("Made it to the weather manager trigger");
                target.Map.weatherManager.eventHandler.AddEvent(new WeatherEvent_LightningStrike(target.Map, target.Position));
                latestStrikeTick = GenTicks.TicksGame;
            }

            Heal(healSeverityReduction);
        }
    }
}
