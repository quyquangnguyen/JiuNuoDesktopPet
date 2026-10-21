namespace SoftMochiPet.Core;

public enum DialogueCue
{
    Startup,
    Buffet,
    MealSpotted,
    MealQueueContinues,
    IconsHidden,
    ManualIconLick,
    CuriousIconLick,
    PlatformLaunch,
    HardLanding,
    VeryHungry,
    ABitHungry,
    ConfidentClimb,
    CarefulClimb,
    ClimbSlip,
    ClimbSuccess,
    HungryRoll,
    Suction,
    Exploration,
    Sleep,
    WakeForFood,
    WakeNormally,
    ComfortablyFull,
    IconTaste,
    FeastContinues,
    AnotherBite,
    Stuffed,
    TastedItem,
    PickedUp,
    Released,
    DragThrow,
    TerrainHop,
    TerrainJumpDown,
    EdgeSlide,
    WindowMaximized,
    HungryRequestQueued,
    Home,
    DeleteReactionEnabled,
    DeleteReactionDisabled,
    VoiceEnabled,
    VoiceDisabled,
}

/// <summary>
/// Short reactions selected from each character's own dialogue catalog.
/// </summary>
public static class PetDialogueCatalog
{
    private static readonly IReadOnlyDictionary<DialogueCue, IReadOnlyList<string>> Lines =
        new Dictionary<DialogueCue, IReadOnlyList<string>>
        {
            [DialogueCue.Startup] =
            [
                "Morning~",
                "I'm awake!",
                "What are we eating today?",
                "Let me zone out a bit.",
            ],
            [DialogueCue.Buffet] =
            [
                "So much!",
                "All mine?",
                "I can't eat it all!",
                "Hehe, time to eat.",
            ],
            [DialogueCue.MealSpotted] =
            [
                "Food!",
                "Smells yummy.",
                "Coming!",
                "Can I eat that?",
            ],
            [DialogueCue.MealQueueContinues] =
            [
                "There's more!",
                "Next one.",
                "I'll eat them all.",
                "Don't run away.",
            ],
            [DialogueCue.IconsHidden] =
            [
                "No icons…",
                "Where'd they go?",
                "Nothing to lick.",
                "All empty.",
            ],
            [DialogueCue.ManualIconLick] =
            [
                "So hungry…",
                "Just one lick first.",
                "Only a tiny bite.",
                "Is this edible?",
            ],
            [DialogueCue.CuriousIconLick] =
            [
                "What does it taste like?",
                "One little lick.",
                "Looks tasty.",
                "Just a try.",
            ],
            [DialogueCue.PlatformLaunch] =
            [
                "I'm flying!",
                "Waaah!",
                "My feet?!",
                "So high!",
            ],
            [DialogueCue.HardLanding] =
            [
                "Splat.",
                "I'm squished.",
                "Phew, made it.",
                "Round again!",
            ],
            [DialogueCue.VeryHungry] =
            [
                "Sooo hungry…",
                "Starving flat.",
                "I want food.",
                "My tummy's empty.",
            ],
            [DialogueCue.ABitHungry] =
            [
                "A little hungry.",
                "I want a bite.",
                "Got any food?",
                "Craving a snack.",
            ],
            [DialogueCue.ConfidentClimb] =
            [
                "I can make it up.",
                "Watch me.",
                "Heave-ho.",
                "Food up there?",
            ],
            [DialogueCue.CarefulClimb] =
            [
                "So high…",
                "Slowly now.",
                "Don't fall…",
                "I'll try.",
            ],
            [DialogueCue.ClimbSlip] =
            [
                "Slid back down…",
                "Missed my grip.",
                "Aww… so close.",
                "Again!",
            ],
            [DialogueCue.ClimbSuccess] =
            [
                "Made it up!",
                "Hehe.",
                "Aren't I great?",
                "It's so high here.",
            ],
            [DialogueCue.HungryRoll] =
            [
                "Hungry, hungry.",
                "Give me food.",
                "I'll roll around.",
                "Flat with hunger.",
            ],
            [DialogueCue.Suction] =
            [
                "Come here!",
                "Aaah—",
                "Into my mouth.",
                "Time to eat!",
            ],
            [DialogueCue.Exploration] =
            [
                "Where is this?",
                "Never been here.",
                "Let's look over here.",
                "So curious.",
            ],
            [DialogueCue.Sleep] =
            [
                "Time for bed.",
                "Sleepy…",
                "A little nap first.",
                "Good night.",
            ],
            [DialogueCue.WakeForFood] =
            [
                "Food?",
                "I'm up!",
                "Smells yummy!",
                "Mealtime?",
            ],
            [DialogueCue.WakeNormally] =
            [
                "Awake.",
                "Still sleepy…",
                "Slept well.",
                "Lie down a bit more?",
            ],
            [DialogueCue.ComfortablyFull] =
            [
                "All full.",
                "Round tummy.",
                "So stuffed.",
                "Not moving.",
            ],
            [DialogueCue.IconTaste] =
            [
                "Not tasty.",
                "Just tastes like icon.",
                "Empty.",
                "One more lick?",
            ],
            [DialogueCue.FeastContinues] =
            [
                "I can eat more!",
                "One more!",
                "Give me them all.",
                "Not full yet.",
            ],
            [DialogueCue.AnotherBite] =
            [
                "Next one!",
                "Any more?",
                "Keep eating.",
                "I want more.",
            ],
            [DialogueCue.Stuffed] =
            [
                "Overstuffed.",
                "Tummy's so round.",
                "Really full now.",
                "Can't move.",
            ],
            [DialogueCue.TastedItem] =
            [
                "{item} is yummy.",
                "{item} smells nice.",
                "I like {item}.",
                "This is called {item}?",
            ],
            [DialogueCue.PickedUp] =
            [
                "Caught!",
                "Gently…",
                "I'm stretching!",
                "Uuu…",
            ],
            [DialogueCue.Released] =
            [
                "Let me go!",
                "I'm falling!",
                "Where are my feet?",
                "Spinning…",
            ],
            [DialogueCue.DragThrow] =
            [
                "Flying away!",
                "Waaah—",
                "Can't stop!",
                "I got flung!",
            ],
            [DialogueCue.TerrainHop] =
            [
                "Hop!",
                "Heave-ho!",
                "I can fly.",
                "Boing!",
            ],
            [DialogueCue.TerrainJumpDown] =
            [
                "Jumping!",
                "Catch me down there!",
                "Here I go!",
                "Flying down.",
            ],
            [DialogueCue.EdgeSlide] =
            [
                "Sliding down!",
                "Slide slowly.",
                "Hold on tight.",
                "Is this a slide?",
            ],
            [DialogueCue.WindowMaximized] =
            [
                "It got big!",
                "Bounced away!",
                "Whoa, so big!",
                "The window grew!",
            ],
            [DialogueCue.HungryRequestQueued] =
            [
                "So hungry… one sec.",
                "I'll eat once I'm steady.",
                "Off to lick it soon.",
                "My tummy can't wait!",
            ],
            [DialogueCue.Home] =
            [
                "Home!",
                "Back to my nest.",
                "Nice here.",
                "Staying put.",
            ],
            [DialogueCue.DeleteReactionEnabled] =
            [
                "Deleted stuff is mine!",
                "I'll catch it.",
                "Remember to call me.",
                "Food's coming!",
            ],
            [DialogueCue.DeleteReactionDisabled] =
            [
                "No eating today.",
                "I'll hold back.",
                "Not chasing.",
                "Icons are safe now.",
            ],
            [DialogueCue.VoiceEnabled] =
            [
                "I have a voice!",
                "Can you hear me?",
                "Hehe, it's me.",
                "I'm talking!",
            ],
            [DialogueCue.VoiceDisabled] =
            [
                "I'll be quiet.",
                "Shh.",
                "No more talking.",
                "A little quieter.",
            ],
        };

    public static IReadOnlyList<string> GetLines(DialogueCue cue, PetCharacterProfile? profile = null) =>
        profile?.Id == PetCharacterProfile.FeibiJiubi.Id ? FeibiJiubiDialogue.GetLines(cue) : Lines[cue];
}

public sealed class PetDialogueSelector
{
    private readonly Random _random;
    private readonly PetCharacterProfile _profile;
    private readonly Dictionary<DialogueCue, int> _lastLineByCue = [];

    public PetDialogueSelector(Random? random = null, PetCharacterProfile? profile = null)
    {
        _random = random ?? Random.Shared;
        _profile = profile ?? PetCharacterProfile.Nuonuo;
    }

    public string Choose(DialogueCue cue, string? itemName = null)
    {
        var lines = PetDialogueCatalog.GetLines(cue, _profile);
        var index = _random.Next(lines.Count);
        if (lines.Count > 1 && _lastLineByCue.TryGetValue(cue, out var previous) && index == previous)
        {
            index = (index + 1) % lines.Count;
        }

        _lastLineByCue[cue] = index;
        return lines[index].Replace("{item}", itemName ?? "this file", StringComparison.Ordinal);
    }
}
