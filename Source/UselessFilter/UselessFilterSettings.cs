using RimWorld;
using Verse;

namespace UselessFilter;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class UselessFilterSettings : ModSettings
{
    public bool Biocoded = true;
    public bool Clean;
    public FloatRange DurabilityRange = new FloatRange(0, 0.5f);
    public bool NonBiocoded;
    public QualityRange QualityRange = new QualityRange(QualityCategory.Awful, QualityCategory.Poor);
    public bool Tainted = true;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref DurabilityRange, "DurabilityRange", new FloatRange(0, 0.5f));
        Scribe_Values.Look(ref QualityRange, "QualityRange",
            new QualityRange(QualityCategory.Awful, QualityCategory.Poor));
        Scribe_Values.Look(ref Tainted, "Tainted", true);
        Scribe_Values.Look(ref Clean, "Clean");
        Scribe_Values.Look(ref Biocoded, "Biocoded", true);
        Scribe_Values.Look(ref NonBiocoded, "NonBiocoded");
    }
}