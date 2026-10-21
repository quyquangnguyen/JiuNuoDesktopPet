namespace SoftMochiPet.Core;

internal static class FeibiJiubiDialogue
{
    private static readonly IReadOnlyDictionary<DialogueCue, IReadOnlyList<string>> Lines =
        new Dictionary<DialogueCue, IReadOnlyList<string>>
        {
            [DialogueCue.Startup] = ["Jiu! You came!", "Let's play!", "Where to now?", "Hehe, hi!"],
            [DialogueCue.IconsHidden] = ["Huh, all hid?", "Hide-and-seek?", "Come out!", "I saw you!"],
            [DialogueCue.PlatformLaunch] = ["Wheee—!", "Hat, hold on!", "So floaty!", "Even higher?"],
            [DialogueCue.HardLanding] = ["Ouch, bounce!", "Shoes first!", "Still bouncy!", "Jiu, not flat!"],
            [DialogueCue.ConfidentClimb] = ["Watch me go!", "What's up top?", "Strong feet!", "Go go go!"],
            [DialogueCue.CarefulClimb] = ["No slipping…", "Bit higher!", "Can I hold on?", "Hat, my eyes!"],
            [DialogueCue.ClimbSlip] = ["Oops, slippy!", "So close!", "Slippery wall.", "Hmph, again!"],
            [DialogueCue.ClimbSuccess] = ["Look, up here!", "High enough?", "Windy hat!", "All so tiny!"],
            [DialogueCue.Exploration] = ["Ooh, shiny!", "Let's peek!", "Where else?", "Feet, lead on!"],
            [DialogueCue.Sleep] = ["Heavy eyelids.", "Play… a bit…", "Let me lean…", "Dream of me?"],
            [DialogueCue.WakeNormally] = ["Hey, hi again!", "Dreamed far!", "Bedhead tuft!", "Jiu, let's go!"],
            [DialogueCue.PickedUp] = ["Up high, yay!", "Where to, jiu?", "Feet dangling!", "Swing, swing!"],
            [DialogueCue.Released] = ["Wow, floor!", "Floor, where?", "Wait, my hat!", "Jiu, gently!"],
            [DialogueCue.DragThrow] = ["Whoosh, fast!", "Hat, keep up!", "Wow, so windy!", "Fly more!"],
            [DialogueCue.TerrainHop] = ["Hop higher!", "Springy feet!", "Jiu, got it!", "One hop over!"],
            [DialogueCue.TerrainJumpDown] = ["Down I go!", "Catch my hat!", "Hop on down!", "Looks fun!"],
            [DialogueCue.EdgeSlide] = ["Zoom, slippy!", "Hold tight!", "Tickly shoes.", "Slide more!"],
            [DialogueCue.WindowMaximized] = ["Wow, squished!", "Grew so fast!", "Hat's askew!", "Huh, flying?!"],
            [DialogueCue.Home] = ["Comfy nest!", "Back here!", "Visiting you!", "Hat rests too."],
            [DialogueCue.VoiceEnabled] = ["Jiu, here!", "Look at me!", "Hello, buddy!", "Miss me?"],
            [DialogueCue.VoiceDisabled] = ["Shh, quietly.", "Tiptoeing…", "Jiu… softly.", "Secretly here."],
        };

    private static readonly IReadOnlyList<string> PlayLines = ["Play what?", "Hop with me!", "Got an idea!", "Hat's hidden."];

    public static IReadOnlyList<string> GetLines(DialogueCue cue) =>
        Lines.TryGetValue(cue, out var lines) ? lines : PlayLines;
}
