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

	public class DefWithNames : IExposable
	{
		public ThingDef key = null;
		public int value = 1;
		public string firstName = null;
		public string lastName = null;
		public string nickName = null;

        public void ExposeData()
        {
			Scribe_Defs.Look(ref key, "key");
			Scribe_Values.Look(ref value, "value");
			Scribe_Values.Look(ref firstName, "firstName");
			Scribe_Values.Look(ref lastName, "lastName");
			Scribe_Values.Look(ref nickName, "nickName");
		}
    }

	public class PawnNamedTracker_WithList : PawnJoinedTracker
    {
		public List<DefWithNames> namesList = new List<DefWithNames>();

		protected override string[] DebugText
		{
			get
			{
				List<string> text = new List<string>();
				foreach (DefWithNames race in namesList)
				{
					string entry = $"Race: {race.key?.defName ?? "None"} Count: {race.value} firstName: {race.firstName} lastName: {race.lastName} nickName: {race.nickName}" ;
					text.Add(entry);
				}
				text.Add($"Require all in list: {requireAll}");
				return text.ToArray();
			}
		}

		public PawnNamedTracker_WithList()
		{
		}

		public PawnNamedTracker_WithList(PawnNamedTracker_WithList reference) : base(reference)
		{
			namesList = reference.namesList;
			if (namesList.EnumerableNullOrEmpty())
				Log.Error($"namesList list for RaceDefTracker_WithName cannot be Null or Empty");
		}

		public override bool UnlockOnStartup => Trigger(null);

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Collections.Look(ref namesList, "namesList", LookMode.Deep);
		}

		public override bool Trigger(Pawn param)
		{
			base.Trigger(param);
			bool trigger = true;
			ThingDef raceDef = param?.def;
			var factionPawns = PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_OfPlayerFaction;
			if (factionPawns is null)
			{
				return false;
			}
			foreach (DefWithNames set in namesList)
			{
				Log.Message(": " + set.firstName);
				var count = 0;
				if (set.key == raceDef && param.Name != null)
				{
					if (CheckName(param, set))
					{
						
						count += 1;
					}
				}

				if (requireAll)
				{
					if (factionPawns.Where(f => f.def.defName == set.key.defName && CheckName(f, set)).Count() + count < set.value)
					{
						trigger = false;
					}
				}
				else
				{
					trigger = false;
					if (factionPawns.Where(f => f.def.defName == set.key.defName && CheckName(f, set)).Count() + count >= set.value)
					{
						return true;
					}
				}
			}
			return trigger;
		}

		public static bool CheckName(Pawn pawn, DefWithNames set)
        {
			NameTriple name = pawn.Name as NameTriple;
			Log.Message("Pawn " + name.First + ", " + name.Nick + ", " + name.Last + ": Checking for " + set.firstName);
			return (set.firstName == null || name.First == set.firstName) && (set.lastName == null || name.Last == set.lastName) && (set.nickName == null || name.Nick == set.nickName);
		}
	}
}