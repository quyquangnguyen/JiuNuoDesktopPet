namespace SoftMochiPet.Core;

public static class FeibiVoiceCatalog
{
    public const string BurstCallFileName = "feibijiubi_feiba_jiubi.wav";

    private static readonly string[] NumberedFiles =
    [
        "feibijiubi_001.wav", "feibijiubi_004.wav", "feibijiubi_006.wav", "feibijiubi_014.wav",
        "feibijiubi_017.wav", "feibijiubi_034.wav", "feibijiubi_039.wav", "feibijiubi_041.wav", "feibijiubi_047.wav",
    ];

    private static readonly IReadOnlyDictionary<VoiceCue, string[]> Daily = new Dictionary<VoiceCue, string[]>
    {
        [VoiceCue.Neutral] =
        [
            "feibijiubi_normal.wav", "feibijiubi_quiet_calm_mumble.wav", "feibijiubi_feiba_jiubi.wav",
            .. NumberedFiles,
        ],
        [VoiceCue.Affirmative] = ["feibijiubi_positive.wav", "feibijiubi_playful.wav"],
        [VoiceCue.Sad] = ["feibijiubi_heartbroken.wav", "feibijiubi_dejected_hushed.wav"],
        [VoiceCue.Positive] = ["feibijiubi_positive.wav", "feibijiubi_excited.wav"],
        [VoiceCue.Scream] = NumberedFiles,
        [VoiceCue.Panic] = NumberedFiles,
        [VoiceCue.Calm] = ["feibijiubi_sleepy.wav"],
        [VoiceCue.Aggrieved] = ["feibijiubi_aggrieved.wav", "feibijiubi_dejected_hushed.wav"],
        [VoiceCue.Question] = ["feibijiubi_puzzled.wav"],
        [VoiceCue.Landing] = ["feibijiubi_aggrieved.wav", "feibijiubi_quiet_calm_mumble.wav"],
    };

    private static readonly IReadOnlyDictionary<MischiefCue, string[]> Pranks = new Dictionary<MischiefCue, string[]>
    {
        [MischiefCue.Teased] = ["feibijiubi_playful_quiet.wav", "feibijiubi_quiet_playful.wav", "feibijiubi_feiba_jiubi.wav"],
        [MischiefCue.Sneak] = ["feibijiubi_whisper.wav", "feibijiubi_quiet_playful.wav"],
        [MischiefCue.Kick] = ["feibijiubi_positive.wav", "feibijiubi_playful.wav"],
        [MischiefCue.Punch] = ["feibijiubi_positive.wav", "feibijiubi_gritting_teeth.wav"],
        [MischiefCue.Charge] = ["feibijiubi_excited.wav", "feibijiubi_positive.wav"],
        [MischiefCue.Recoil] = ["feibijiubi_aggrieved.wav", "feibijiubi_quiet_calm_mumble.wav"],
        [MischiefCue.HideWindow] = ["feibijiubi_whisper.wav", "feibijiubi_playful_quiet.wav"],
        [MischiefCue.HoldingWindow] = ["feibijiubi_quiet_playful.wav", "feibijiubi_playful_quiet.wav"],
        [MischiefCue.ReturnWindow] = ["feibijiubi_normal.wav", "feibijiubi_positive.wav", "feibijiubi_playful.wav"],
        [MischiefCue.Burst] = [BurstCallFileName],
        [MischiefCue.Smash] = ["feibijiubi_excited.wav", "feibijiubi_positive.wav"],
        [MischiefCue.Tear] = ["feibijiubi_gritting_teeth.wav"],
        [MischiefCue.Finished] = ["feibijiubi_playful.wav", "feibijiubi_feiba_jiubi.wav"],
        [MischiefCue.Interrupted] = ["feibijiubi_aggrieved.wav", "feibijiubi_dejected_hushed.wav"],
        [MischiefCue.NoTarget] = ["feibijiubi_puzzled.wav", "feibijiubi_heartbroken.wav", "feibijiubi_dejected_hushed.wav"],
    };

    public static IReadOnlyList<string> GetFileNames(VoiceCue cue) => Daily[cue];
    public static IReadOnlyList<string> GetFileNames(MischiefCue cue) => Pranks[cue];

    public static IReadOnlyList<string> AllFileNames { get; } = Daily.Values.Concat(Pranks.Values)
        .SelectMany(files => files).Distinct(StringComparer.OrdinalIgnoreCase)
        .OrderBy(file => file, StringComparer.OrdinalIgnoreCase).ToArray();
}
