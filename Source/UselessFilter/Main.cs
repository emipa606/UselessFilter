using RimWorld;
using Verse;

namespace UselessFilter;

[StaticConstructorOnStartup]
public static class Main
{
    public static bool IsUseless(Thing thing)
    {
        if (UselessFilterMod.instance.Settings.DurabilityRange.Includes(thing.HitPoints / (float)thing.MaxHitPoints))
        {
            return true;
        }

        QualityCategory p;
        if (!thing.TryGetQuality(out p))
        {
            p = QualityCategory.Normal;
        }

        if (UselessFilterMod.instance.Settings.QualityRange.Includes(p))
        {
            return true;
        }

        if (thing is Apparel apparel)
        {
            if (UselessFilterMod.instance.Settings.Tainted && apparel.WornByCorpse)
            {
                return true;
            }

            if (UselessFilterMod.instance.Settings.Clean && !apparel.WornByCorpse)
            {
                return true;
            }

            if (UselessFilterMod.instance.Settings.Biocoded && CompBiocodable.IsBiocoded(thing))
            {
                return true;
            }

            if (UselessFilterMod.instance.Settings.NonBiocoded && !CompBiocodable.IsBiocoded(thing))
            {
                return true;
            }
        }


        if (thing.def.IsWeapon)
        {
            var biocoded = thing.TryGetComp<CompBladelinkWeapon>() == null && CompBiocodable.IsBiocoded(thing);

            if (UselessFilterMod.instance.Settings.Biocoded && biocoded)
            {
                return true;
            }

            if (UselessFilterMod.instance.Settings.NonBiocoded && !biocoded)
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsUseless(ThingDef thingDef)
    {
        if (!thingDef.IsApparel && !thingDef.IsWeapon)
        {
            return false;
        }

        return true;
    }
}