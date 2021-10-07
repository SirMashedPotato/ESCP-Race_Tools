using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Verse;
using RimWorld;
using AchievementsExpanded;

namespace Mashed_VanillaAchievementsExpanded
{
    /* Notes:
      * Pretty much completely custom tracker
      * Triggered when the player recruits a pawn with the specified name
      * The pawn has to have any of the specified names, null name parts get ignored
      */

    class PawnNamedTracker : PawnJoinedTracker
    {
        public ThingDef key;
        public string firstName = null;
        public string lastName = null;
        public string nickName = null;

        protected override string[] DebugText => new string[] { $"Def: {key?.defName ?? "None"}",
                                                                $"firstName: {firstName}",
                                                                $"lastName: {lastName}",
                                                                $"nickName: {nickName}" };

        public PawnNamedTracker()
        {
        }

        public PawnNamedTracker(PawnNamedTracker reference) : base(reference)
        {
            key = reference.key;
            firstName = reference.firstName;
            lastName = reference.lastName;
            nickName = reference.nickName;
        }

        public override bool UnlockOnStartup => Trigger(null);

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Defs.Look(ref key, "key");
            Scribe_Values.Look(ref firstName, "firstName");
            Scribe_Values.Look(ref lastName, "lastName");
            Scribe_Values.Look(ref nickName, "nickName");
        }

        public override bool Trigger(Pawn param)
        {
            base.Trigger(param);
            ThingDef raceDef = param?.def;
            var factionPawns = PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_OfPlayerFaction;
            if (factionPawns is null)
            {
                return false;
            }
            if (key == raceDef && param.Name != null)
            {
                NameTriple name = param.Name as NameTriple;
                if ((firstName == null || name.First == firstName) && (lastName == null || name.Last == lastName) && (nickName == null || name.Nick == nickName))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
