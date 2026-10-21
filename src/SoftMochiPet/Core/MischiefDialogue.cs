namespace SoftMochiPet.Core;

public enum MischiefCue
{
    Teased,
    Sneak,
    Kick,
    Punch,
    Charge,
    Recoil,
    HideWindow,
    HoldingWindow,
    ReturnWindow,
    Burst,
    Smash,
    Tear,
    Finished,
    Interrupted,
    NoTarget,
}

public sealed class MischiefDialogueSelector
{
    private static readonly IReadOnlyDictionary<MischiefCue, IReadOnlyList<string>> Lines =
        new Dictionary<MischiefCue, IReadOnlyList<string>>
        {
            [MischiefCue.Teased] = ["Hehe, again!", "Ticklish!", "Teasing me?!", "Jiu! Got you!"],
            [MischiefCue.Sneak] = ["Shhh—", "Didn't see me.", "Sneaking in.", "Hehe, just wait!"],
            [MischiefCue.Kick] = ["Watch my foot!", "Hiyah!", "Off you go!", "A little kick!"],
            [MischiefCue.Punch] = ["Bonk!", "Tiny fists!", "Hey!", "Take that!"],
            [MischiefCue.Charge] = ["Make way!", "Charge—!", "Here I come!", "Hold tight, hat!"],
            [MischiefCue.Recoil] = ["Ow ow ow.", "Butt bump!", "Didn't happen~", "I'm steady!"],
            [MischiefCue.HideWindow] = ["Let me hide it!", "Fits in my hat!", "Hehe, mine now.", "No peeking!"],
            [MischiefCue.HoldingWindow] = ["Didn't hide it.", "Hat, behave!", "Hm? What window?", "Hehehe…"],
            [MischiefCue.ReturnWindow] = ["Here you go!", "Ta-da—!", "Right here!", "Fine, no hiding."],
            [MischiefCue.Burst] = ["Can't hold it!", "Hat, take five!", "For real now!", "Watch closely!"],
            [MischiefCue.Smash] = ["Fly away—!", "Jiu! Big foot!", "Wow, it burst!", "I'm so strong!"],
            [MischiefCue.Tear] = ["Heave—ho!", "So stretchy!", "Pull a bit more!", "Ugh, sticky!"],
            [MischiefCue.Finished] = ["Fun!", "Hat's back!", "Hehe, all fine.", "I'm so good!"],
            [MischiefCue.Interrupted] = ["Got caught!", "Okay, okay.", "Letting go.", "Play next time."],
            [MischiefCue.NoTarget] = ["Where'd toys go?", "Play later!", "Hop hop first!", "I'll rest then."],
        };

    private readonly Random _random;
    private readonly Dictionary<MischiefCue, int> _previous = [];

    public MischiefDialogueSelector(Random? random = null) => _random = random ?? Random.Shared;

    public static IReadOnlyList<string> GetLines(MischiefCue cue) => Lines[cue];

    public string Choose(MischiefCue cue)
    {
        var lines = GetLines(cue);
        var index = _random.Next(lines.Count);
        if (_previous.TryGetValue(cue, out var previous) && index == previous)
        {
            index = (index + 1) % lines.Count;
        }
        _previous[cue] = index;
        return lines[index];
    }
}
