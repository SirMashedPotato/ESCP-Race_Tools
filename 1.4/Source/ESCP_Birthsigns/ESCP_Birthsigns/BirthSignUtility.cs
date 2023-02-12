using Verse;

namespace ESCP_Birthsigns
{
    public static class BirthSignUtility
    {
        public static void GenerateBirthsign(Pawn pawn, BirthsignSetDef signs)
        {
            HediffDef signDef;

            if (!signs.additionalSigns.NullOrEmpty() && Rand.Chance(signs.additionalSignsChance))
            {
                signDef = signs.additionalSigns.RandomElement();
            }
            else
            {
                int quadrum = (int)pawn.ageTracker.BirthQuadrum;
                int day = pawn.ageTracker.BirthDayOfYear;
                int monthIndex = day;
                while (monthIndex - 15 > -1)    ///-1 to account for the possibility of an index of exactly 0 for 60 days
                {
                    monthIndex -= 15;
                }
                monthIndex /= 5;
                signDef = signs.birthsignHediffs[quadrum][monthIndex];
            }

            pawn.health.AddHediff(signDef);
        }
    }
}
