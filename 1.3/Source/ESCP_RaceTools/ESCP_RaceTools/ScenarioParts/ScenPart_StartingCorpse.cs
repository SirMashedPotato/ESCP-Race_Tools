using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class ScenPart_StartingCorpse : ScenPart
	{
		private FactionDef factionDef;  //pulls random pawns from that faction, using weight
		private int count = 1;
		private string countBuf;

		private static readonly List<Pair<int, float>> CorpseCountChances = new List<Pair<int, float>>
		{
			new Pair<int, float>(1, 5f),
			new Pair<int, float>(2, 10f),
			new Pair<int, float>(3, 20f),
			new Pair<int, float>(4, 5f),
			new Pair<int, float>(5, 1f),
			new Pair<int, float>(6, 1f),
			new Pair<int, float>(7, 1f),
			new Pair<int, float>(8, 1f),
			new Pair<int, float>(9, 1f),
			new Pair<int, float>(10, 0.1f),
			new Pair<int, float>(11, 0.1f),
			new Pair<int, float>(12, 0.1f),
			new Pair<int, float>(13, 0.1f),
			new Pair<int, float>(14, 0.1f)
		};

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Defs.Look<FactionDef>(ref this.factionDef, "factionDef");
			Scribe_Values.Look<int>(ref this.count, "count", 0, false);
		}

		///<Summary>
		///Basically the same as choosing a pet, but you choose a faction, pawnKinds are generated from that randomly, and then turned into corpses
		///Each generated pawnKind is randomly selected based on their selection weight from a randomly selected pawnGroupMaker in the selected facion def
		///</Summary>

		public override void DoEditInterface(Listing_ScenEdit listing)
		{
			Rect scenPartRect = listing.GetScenPartRect(this, ScenPart.RowHeight * 2f);
			Listing_Standard listing_Standard = new Listing_Standard();
			listing_Standard.Begin(scenPartRect.TopHalf());
			listing_Standard.ColumnWidth = scenPartRect.width;
			listing_Standard.TextFieldNumeric<int>(ref this.count, ref this.countBuf, 1f, 1E+09f);
			listing_Standard.End();
			if (Widgets.ButtonText(scenPartRect.BottomHalf(), this.CurrentFactionLabel().CapitalizeFirst(), true, true, true))
			{
				List<FloatMenuOption> list = new List<FloatMenuOption>();
				list.Add(new FloatMenuOption("ESCP_RandomFaction".Translate().CapitalizeFirst(), delegate ()
				{
					this.factionDef = null;
				}, MenuOptionPriority.Default, null, null, 0f, null, null, true, 0));
				foreach (FactionDef localDef2 in this.PossibleFactions())
				{
					FactionDef localDef = localDef2;
					list.Add(new FloatMenuOption(localDef.LabelCap, delegate ()
					{
						this.factionDef = localDef;
					}, MenuOptionPriority.Default, null, null, 0f, null, null, true, 0));
				}
				Find.WindowStack.Add(new FloatMenu(list));
			}
		}

		private IEnumerable<FactionDef> PossibleFactions()
		{
			return from td in DefDatabase<FactionDef>.AllDefs
				   where !td.isPlayer && td.humanlikeFaction && !td.pawnGroupMakers.NullOrEmpty()
				   select td;
		}


		private FactionDef RandomFaction()
		{
			return this.PossibleFactions().RandomElement();
		}

		private string CurrentFactionLabel()
		{
			if (this.factionDef == null)
			{
				return "ESCP_RandomFaction".TranslateSimple();
			}
			return this.factionDef.label;
		}

		public override string Summary(Scenario scen)
		{
			return ScenSummaryList.SummaryWithList(scen, "PlayerStartsWith", ScenPart_StartingThing_Defined.PlayerStartWithIntro);
		}

		public override IEnumerable<string> GetSummaryListEntries(string tag)
		{
			if (tag == "PlayerStartsWith")
			{
				yield return "ESCP_CorpseFrom".Translate() + this.CurrentFactionLabel().CapitalizeFirst() + " x" + this.count;
			}
			yield break;
		}

		public override void Randomize()
		{
			if (Rand.Value < 0.5f)
			{
				this.factionDef = null;
			}
			else
			{
				this.factionDef = this.PossibleFactions().RandomElement<FactionDef>();
			}
			this.count = ScenPart_StartingCorpse.CorpseCountChances.RandomElementByWeight((Pair<int, float> pa) => pa.Second).First;
		}

		public override bool TryMerge(ScenPart other)
		{
			ScenPart_StartingCorpse scenPart_StartingCorpse = other as ScenPart_StartingCorpse;
			if (scenPart_StartingCorpse != null && scenPart_StartingCorpse.factionDef == this.factionDef)
			{
				this.count += scenPart_StartingCorpse.count;
				return true;
			}
			return false;
		}

		public override IEnumerable<Thing> PlayerStartingThings()
		{
			int num;
			FactionDef faction;
			if (this.factionDef != null)
			{
				faction = factionDef;
			}
			else
			{
				faction = this.RandomFaction();
			}
			for (int i = 0; i < this.count; i = num + 1)
			{
				PawnKindDef kindDef;

				kindDef = faction.pawnGroupMakers.Where(x => !x.options.NullOrEmpty()).RandomElementByWeightWithFallback(x => x.commonality, faction.pawnGroupMakers.First()).options.RandomElementByWeightWithDefault(x => x.selectionWeight, 1).kind;

				Pawn pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(kindDef, FactionUtility.DefaultFactionFrom(faction) ?? null, PawnGenerationContext.NonPlayer, -1, false, false, true, false, false, false, 0f, false, true, false, true, false, false, false, false, 0f, 0f, null, 0f, null, null, null, null, null, null, null, null, null, null, null, null, null, true, false, true));
				if (!pawn.Dead)
				{
					pawn.Kill(null, null);
				}
				pawn.relations.hidePawnRelations = true;
				yield return pawn;
				num = i;
			}
			yield break;
		}
	}
}
