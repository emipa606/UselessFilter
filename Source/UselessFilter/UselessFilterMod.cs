using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace UselessFilter;

[StaticConstructorOnStartup]
internal class UselessFilterMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static UselessFilterMod Instance;

    private static string currentVersion;

    private static readonly Vector2 buttonSize = new(100f, 25f);

    /// <summary>
    ///     The private settings
    /// </summary>
    private UselessFilterSettings settings;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public UselessFilterMod(ModContentPack content) : base(content)
    {
        Instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal UselessFilterSettings Settings
    {
        get
        {
            settings ??= GetSettings<UselessFilterSettings>();

            return settings;
        }
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Useless Filter";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        Text.Font = GameFont.Medium;
        var headerLocation = listingStandard.Label("UsFi.SettingsHeader.label".Translate());
        Text.Font = GameFont.Small;
        listingStandard.Label("UsFi.SettingsDescription.label".Translate());
        listingStandard.GapLine();
        if (Widgets.ButtonText(
                new Rect(headerLocation.position + new Vector2(headerLocation.width - buttonSize.x, 0),
                    buttonSize),
                "UsFi.Reset.label".Translate()))
        {
            Settings.DurabilityRange = new FloatRange(0, 0.5f);
            Settings.QualityRange = new QualityRange(QualityCategory.Awful, QualityCategory.Poor);
            Settings.Tainted = true;
            Settings.Clean = false;
            return;
        }

        listingStandard.Gap();
        var rangeRect = listingStandard.GetRect(30f);
        Widgets.FloatRange(
            rangeRect,
            "DurabilityRange".GetHashCode(),
            ref Settings.DurabilityRange,
            0,
            1f,
            "UsFi.HitPoints".Translate(),
            ToStringStyle.PercentZero);
        listingStandard.Gap();
        rangeRect = listingStandard.GetRect(30f);
        Widgets.QualityRange(rangeRect, "QualityRange".GetHashCode(), ref Settings.QualityRange);
        listingStandard.Gap();
        listingStandard.CheckboxLabeled("UsFi.Tainted.label".Translate(), ref Settings.Tainted);
        listingStandard.CheckboxLabeled("UsFi.Clean.label".Translate(), ref Settings.Clean);
        listingStandard.CheckboxLabeled("UsFi.Biocoded.label".Translate(), ref Settings.Biocoded);
        listingStandard.CheckboxLabeled("UsFi.NonBiocoded.label".Translate(), ref Settings.NonBiocoded);
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("UsFi.Version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}