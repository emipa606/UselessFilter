﻿using Verse;

namespace UselessFilter;

public class SpecialThingFilterWorker_UselessFilter : SpecialThingFilterWorker
{
    public override bool Matches(Thing t)
    {
        return Main.IsUseless(t);
    }

    public override bool CanEverMatch(ThingDef def)
    {
        return def.IsApparel || def.IsWeapon;
    }
}