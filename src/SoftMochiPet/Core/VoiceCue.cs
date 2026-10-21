namespace SoftMochiPet.Core;

public enum VoiceCue
{
    Neutral,
    Affirmative,
    Sad,
    Positive,
    Scream,
    Panic,
    Calm,
    Aggrieved,
    Question,
    Landing,
}

public enum VoicePriority
{
    Ambient,
    Normal,
    Important,
    Critical,
}

public static class VoiceCueCatalog
{
    private static readonly IReadOnlyDictionary<VoiceCue, string[]> Files =
        new Dictionary<VoiceCue, string[]>
        {
            [VoiceCue.Neutral] =
            [
                "nuonuo_002.wav",
                "nuonuo_015.wav",
                "nuonuo_017.wav",
                "nuonuo_018.wav",
                "nuonuo_019.wav",
                "nuonuo_024.wav",
                "nuonuo_030.wav",
                "nuonuo_normal.wav",
                "nuonuo_normal02.wav",
                "nuonuo_normal03.wav",
                "nuonuo_normal04.wav",
            ],
            [VoiceCue.Affirmative] = ["nuonuo_affirming.wav"],
            [VoiceCue.Sad] = ["nuonuo_super_sad.wav"],
            [VoiceCue.Positive] = ["nuonuo_positive.wav"],
            [VoiceCue.Scream] =
            [
                "nuonuo_quick.wav",
                "nuonuo_015.wav",
                "nuonuo_017.wav",
                "nuonuo_024.wav",
                "nuonuo_normal.wav",
                "nuonuo_normal03.wav",
                "nuonuo_slightly_aggrieved.wav",
            ],
            [VoiceCue.Panic] = ["nuonuo_panicked_losing_control.wav"],
            [VoiceCue.Calm] = ["nuonuo_calm.wav"],
            [VoiceCue.Aggrieved] = ["nuonuo_aggrieved.wav", "nuonuo_slightly_aggrieved.wav"],
            [VoiceCue.Question] = ["nuonuo_questioning.wav"],
            [VoiceCue.Landing] = ["nuonuo_soft.wav", "nuonuo_slightly_aggrieved.wav"],
        };

    public static IReadOnlyList<string> GetFileNames(VoiceCue cue, PetCharacterProfile? character = null) =>
        character?.UsesMischief == true ? FeibiVoiceCatalog.GetFileNames(cue) : Files[cue];

    public static IReadOnlyList<string> AllFileNamesFor(PetCharacterProfile character) =>
        character.UsesMischief ? FeibiVoiceCatalog.AllFileNames : AllFileNames;

    public static IReadOnlyList<string> AllFileNames { get; } = Files.Values
        .SelectMany(fileNames => fileNames)
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .OrderBy(fileName => fileName, StringComparer.OrdinalIgnoreCase)
        .ToArray();
}
