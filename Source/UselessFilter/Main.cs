using RimWorld;
using Verse;

namespace UselessFilter;

[StaticConstructorOnStartup]
public static class Main
{
    public static bool IsUseless(Thing thing)
    {
        if (UselessFilterMod.Instance.Settings.DurabilityRange.Includes(thing.HitPoints / (float)thing.MaxHitPoints))
        {
            return true;
        }

        if (!thing.TryGetQuality(out var p))
        {
            p = QualityCategory.Normal;
        }

        if (UselessFilterMod.Instance.Settings.QualityRange.Includes(p))
        {
            return true;
        }

        if (thing is Apparel apparel)
        {
            if (UselessFilterMod.Instance.Settings.Tainted && apparel.WornByCorpse)
            {
                return true;
            }

            if (UselessFilterMod.Instance.Settings.Clean && !apparel.WornByCorpse)
            {
                return true;
            }

            if (UselessFilterMod.Instance.Settings.Biocoded && CompBiocodable.IsBiocoded(thing))
            {
                return true;
            }

            if (UselessFilterMod.Instance.Settings.NonBiocoded && !CompBiocodable.IsBiocoded(thing))
            {
                return true;
            }
        }


        if (!thing.def.IsWeapon)
        {
            return false;
        }

        var isBiocoded = thing.TryGetComp<CompBladelinkWeapon>() == null && CompBiocodable.IsBiocoded(thing);

        if (!UselessFilterMod.Instance.Settings.Biocoded || !isBiocoded)
        {
            return UselessFilterMod.Instance.Settings.NonBiocoded && !isBiocoded;
        }

        return thing.TryGetComp<CompBiocodable>()?.CodedPawn.Faction == Faction.OfPlayerSilentFail;
    }
}