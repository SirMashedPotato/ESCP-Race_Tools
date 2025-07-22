using HarmonyLib;
using RimWorld;
using System.Linq;
using Verse;

namespace ESCP_RaceTools
{
    public class RomanceCheck
    {
        public static bool CanRomance(Pawn initiator, Pawn target, out string opinionExplanation)
        {
            opinionExplanation = null;
            RomanceRestriction propsInitiator = RomanceRestriction.Get(initiator.def);
            RomanceRestriction propsTarget = RomanceRestriction.Get(target.def);
            ///Both are null, so just return
            if (propsInitiator == null && propsTarget == null)
            {
                return true;
            }
            ///Yea this makes me feel a little gross
            bool propsNullFlag = false;
            bool romanceRestrictedFlag = false;

            if (propsInitiator == null)
            {
                propsNullFlag = true;
            }
            else
            {
                if (propsInitiator.restrictRomanceToTags)
                {
                    romanceRestrictedFlag = true;
                }
            }
            if (propsTarget == null)
            {
                propsNullFlag = true;
            }
            else
            {
                if (propsTarget.restrictRomanceToTags)
                {
                    romanceRestrictedFlag = true;
                }
            }

            ///Romance isn't restricted on either end
            if (!romanceRestrictedFlag)
            {
                return true;
            }

            ///Romance is restricted for one side, but other side is missing the extension
            if (romanceRestrictedFlag && propsNullFlag)
            {
                opinionExplanation = "ESCP_RomanceRestricted".Translate(initiator.def.label, target.def.label);
                return false;
            }
            ///Romance is restricted for one side, but other side has null romance tags
            if (propsInitiator.restrictedRomanceTags.NullOrEmpty() || propsTarget.restrictedRomanceTags.NullOrEmpty())
            {
                return false;
            }
            ///Check if there's any shared tag
            return propsInitiator.restrictedRomanceTags.Intersect(propsTarget.restrictedRomanceTags).Any();
        }
    }

    /// <summary>
    /// Makes it so specific races should only ever romance other specific races
    /// and can never be romanced by other races
    /// First patch is for the player forcing romances
    /// Second is for pawn controlled romance chance
    /// Third is just in case the others fail at some point
    /// </summary>
    [HarmonyPatch(typeof(RelationsUtility))]
    [HarmonyPatch("RomanceEligiblePair")]
    public static class RelationsUtility_RomanceEligiblePair_Patch
    {
        public static void Postfix(Pawn initiator, Pawn target, bool forOpinionExplanation, ref AcceptanceReport __result)
        {
            if (__result)
            {
                bool canRomance = RomanceCheck.CanRomance(initiator, target, out string opinionExplanation);
                if (!canRomance && forOpinionExplanation)
                {
                    ///I'm going to be honest here, this doesn't get used. No idea why
                    __result = opinionExplanation;
                    return;
                }
                __result = canRomance;
            }
        }
    }

    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt))]
    [HarmonyPatch("RandomSelectionWeight")]
    public static class InteractionWorker_RomanceAttempt_RandomSelectionWeight_Patch
    {
        public static void Postfix(Pawn initiator, Pawn recipient, ref float __result)
        {
            if (__result > 0f)
            {
                bool canRomance = RomanceCheck.CanRomance(initiator, recipient, out string _);
                if (!canRomance)
                {
                    __result = 0f;
                }
            }
        }
    }

    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt))]
    [HarmonyPatch("SuccessChance")]
    public static class InteractionWorker_RomanceAttempt_SuccessChance_Patch
    {
        public static void Postfix(Pawn initiator, Pawn recipient, ref float __result)
        {
            if (__result > 0f)
            {
                bool canRomance = RomanceCheck.CanRomance(initiator, recipient, out string _);
                if (!canRomance)
                {
                    __result = 0f;
                }
            }
        }
    }
}