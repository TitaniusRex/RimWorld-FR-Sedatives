// FloranRootTranquilizer
using FloranRootTranquilizer;
using RimWorld;
using Verse;

[DefOf]
public static class HediffDefTranquilizer
{
	public static HediffDef Anesthetic;
}

public class ProjectileTranquillizerBullet : Bullet
{
	public HediffDef HediffToAdd = HediffDefTranquilizer.Anesthetic;

	public ThingDefTranquillizerBullet Def => def as ThingDefTranquillizerBullet;

	protected override void Impact(Thing hitThing, bool blockedByShield = true)
	{
		base.Impact(hitThing, blockedByShield: false);
		if (Def != null && hitThing != null && hitThing is Pawn pawn)
		{
			Hediff hediff = pawn?.health?.hediffSet?.GetFirstHediffOfDef(HediffToAdd);
			if (hediff == null)
			{
				Hediff hediff2 = HediffMaker.MakeHediff(HediffToAdd, pawn);
				pawn.health.AddHediff(hediff2);
			}
		}
	}
}


public class ThingDefTranquillizerBullet : ThingDef
{
	public HediffDef HediffToAdd = HediffDefOf.Anesthetic;
}
