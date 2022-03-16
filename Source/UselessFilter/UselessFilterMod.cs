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
    public static UselessFilterMod instance;

    private static string currentVersion;

    public static readonly Vector2 buttonSize = new Vector2(100f, 25f);

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
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.UselessFilter"));
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal UselessFilterSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<UselessFilterSettings>();
            }

            return settings;
        }
        set => settings = value;
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
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        Text.Font = GameFont.Medium;
        var headerLocation = listing_Standard.Label("UsFi.SettingsHeader.label".Translate());
        Text.Font = GameFont.Small;
        listing_Standard.Label("UsFi.SettingsDescription.label".Translate());
        listing_Standard.GapLine();
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

        listing_Standard.Gap();
        var rangeRect = listing_Standard.GetRect(30f);
        Widgets.FloatRange(
            rangeRect,
            "DurabilityRange".GetHashCode(),
            ref Settings.DurabilityRange,
            0,
            1f,
            "UsFi.HitPoints".Translate(),
            ToStringStyle.PercentZero);
        listing_Standard.Gap();
        rangeRect = listing_Standard.GetRect(30f);
        Widgets.QualityRange(rangeRect, "QualityRange".GetHashCode(), ref Settings.QualityRange);
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("UsFi.Tainted.label".Translate(), ref Settings.Tainted);
        listing_Standard.CheckboxLabeled("UsFi.Clean.label".Translate(), ref Settings.Clean);
        listing_Standard.CheckboxLabeled("UsFi.Biocoded.label".Translate(), ref Settings.Biocoded);
        listing_Standard.CheckboxLabeled("UsFi.NonBiocoded.label".Translate(), ref Settings.NonBiocoded);
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("UsFi.Version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}