using Verse;
using RimWorld;

namespace ESCP_Birthsigns_Abilities
{
    public class CompAbilityEffect_CreateQuest : CompAbilityEffect
    {
        public new CompProperties_AbilityCreateQuest Props
        {
            get
            {
                return (CompProperties_AbilityCreateQuest)this.props;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            if (Props.questScript != null)
            {
                Quest quest = QuestUtility.GenerateQuestAndMakeAvailable(Props.questScript, StorytellerUtility.DefaultSiteThreatPointsNow());
                QuestUtility.SendLetterQuestAvailable(quest);
            }
        }
    }
}
