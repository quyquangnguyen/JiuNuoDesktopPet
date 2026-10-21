namespace SoftMochiPet.Core;

public enum BehaviorControlAction
{
    Stop,
    Stand,
    Walk,
    Run,
    Curious,
    Explore,
    Patrol,
    Hop,
    Climb,
    SlideDown,
    JumpDown,
    Roll,
    Sleep,
    Wake,
    FreeFall,
    Toss,
    Hungry,
    LickIcon,
    EatIcon,
    Satisfied,
    Kick,
    Punch,
    Charge,
    HatStore,
    Shatter,
    Tear,
    Tease,
    FillMischief,
    ReturnWindows,
    ThrowAndRecoverHat,
}

[Flags]
public enum BehaviorControlCharacters
{
    None = 0,
    Nuonuo = 1,
    FeibiJiubi = 2,
    Both = Nuonuo | FeibiJiubi,
}

[Flags]
public enum BehaviorControlRequirements
{
    None = 0,
    SessionAvailable = 1 << 0,
    NotDragging = 1 << 1,
    Awake = 1 << 2,
    GroundSupport = 1 << 3,
    OutsideEnclosure = 1 << 4,
    ReachableClimbWindow = 1 << 5,
    WindowPlatform = 1 << 6,
    FreeAirSpace = 1 << 7,
    Sleeping = 1 << 8,
    FoodEnabled = 1 << 9,
    DesktopIcon = 1 << 10,
    EligibleWindow = 1 << 11,
    EmptyHat = 1 << 12,
    HeldWindow = 1 << 13,
    MischiefReady = 1 << 14,
}

public enum BehaviorControlKind
{
    Behavior,
    StateChange,
    AnimationPreview,
}

public sealed record BehaviorControlItem(
    BehaviorControlAction Action,
    string Group,
    string Title,
    BehaviorControlCharacters Characters,
    BehaviorControlRequirements Requirements,
    BehaviorControlKind Kind,
    string Description)
{
    public bool Supports(PetCharacterProfile character)
    {
        ArgumentNullException.ThrowIfNull(character);
        var flag = character.SupportsFood ? BehaviorControlCharacters.Nuonuo
            : character.UsesMischief ? BehaviorControlCharacters.FeibiJiubi : BehaviorControlCharacters.None;
        return (Characters & flag) != 0;
    }
}

/// <summary>
/// Menu metadata for the behavior-control build. Conditions describe the real
/// action route; the dispatcher must recheck live targets before execution.
/// </summary>
public static class BehaviorControlCatalog
{
    private const BehaviorControlCharacters Both = BehaviorControlCharacters.Both;
    private const BehaviorControlCharacters Nuonuo = BehaviorControlCharacters.Nuonuo;
    private const BehaviorControlCharacters Feibi = BehaviorControlCharacters.FeibiJiubi;
    private const BehaviorControlKind Behavior = BehaviorControlKind.Behavior;
    private const BehaviorControlKind StateChange = BehaviorControlKind.StateChange;
    private const BehaviorControlRequirements Ready = BehaviorControlRequirements.SessionAvailable |
        BehaviorControlRequirements.NotDragging;
    private const BehaviorControlRequirements Awake = Ready | BehaviorControlRequirements.Awake;
    private const BehaviorControlRequirements Ground = Awake | BehaviorControlRequirements.GroundSupport;
    private const BehaviorControlRequirements Travel = Ground | BehaviorControlRequirements.OutsideEnclosure;
    private const BehaviorControlRequirements WindowAction = Awake | BehaviorControlRequirements.OutsideEnclosure |
        BehaviorControlRequirements.EligibleWindow;
    private const BehaviorControlRequirements IconAction = Awake | BehaviorControlRequirements.OutsideEnclosure |
        BehaviorControlRequirements.FoodEnabled | BehaviorControlRequirements.DesktopIcon;

    public static IReadOnlyList<BehaviorControlItem> All { get; } = Array.AsReadOnly(new[]
    {
        new BehaviorControlItem(BehaviorControlAction.Stop, "Behavior Control", "Stop Current Action", Both,
            BehaviorControlRequirements.None, StateChange, "Stops the current behavior and wraps up safely; windows already stashed in her hat can still be returned manually."),
        new BehaviorControlItem(BehaviorControlAction.Stand, "Poses and Moods", "Stand", Both,
            Ground, Behavior, "Returns to a supported spot and stays standing idle."),
        new BehaviorControlItem(BehaviorControlAction.Curious, "Poses and Moods", "Look Around Curiously", Both,
            Ground, Behavior, "Looks around curiously on the spot."),
        new BehaviorControlItem(BehaviorControlAction.Walk, "Walking and Exploring", "Take a Walk", Both,
            Travel, Behavior, "Walks along the current support surface to a nearby spot."),
        new BehaviorControlItem(BehaviorControlAction.Run, "Walking and Exploring", "Go for a Run", Both,
            Travel, Behavior, "Actually runs along the support surface instead of just playing the running frames in place."),
        new BehaviorControlItem(BehaviorControlAction.Explore, "Walking and Exploring", "Explore Nearby", Both,
            Travel, Behavior, "Walks somewhere nearby to explore, then looks around curiously on arrival."),
        new BehaviorControlItem(BehaviorControlAction.Patrol, "Walking and Exploring", "Patrol Around", Both,
            Travel, Behavior, "Keeps roaming along the support surface; at an edge, the terrain decides what she does next."),
        new BehaviorControlItem(BehaviorControlAction.Hop, "Jumping and Terrain", "Do a Hop", Both,
            Travel | BehaviorControlRequirements.FreeAirSpace, Behavior, "Hops up from the support surface and comes back down under gravity."),
        new BehaviorControlItem(BehaviorControlAction.Climb, "Jumping and Terrain", "Climb onto a Window", Both,
            Travel | BehaviorControlRequirements.ReachableClimbWindow, Behavior, "Walks to the edge of a real, climbable window and tries to climb up; she may slip."),
        new BehaviorControlItem(BehaviorControlAction.SlideDown, "Jumping and Terrain", "Slide Down a Window", Both,
            Travel | BehaviorControlRequirements.WindowPlatform, Behavior, "Walks along a real window's top edge to its end, slides down the side, then lands."),
        new BehaviorControlItem(BehaviorControlAction.JumpDown, "Jumping and Terrain", "Jump Down from a Window", Both,
            Travel | BehaviorControlRequirements.WindowPlatform | BehaviorControlRequirements.FreeAirSpace,
            Behavior, "Jumps down from the current window's top edge and finishes by the real landing rules."),
        new BehaviorControlItem(BehaviorControlAction.Roll, "Jumping and Terrain", "Do a Roll", Both,
            Ground, Behavior, "Rolls on the support surface; Feibi can try it manually too, with no hunger state attached."),
        new BehaviorControlItem(BehaviorControlAction.FreeFall, "Jumping and Terrain", "Free Fall", Both,
            Awake | BehaviorControlRequirements.FreeAirSpace, Behavior, "Lets go of the character from a spot with room to fall so she lands under gravity, without operating the system mouse."),
        new BehaviorControlItem(BehaviorControlAction.Toss, "Jumping and Terrain", "Toss Her Up", Both,
            Awake | BehaviorControlRequirements.FreeAirSpace, Behavior, "Gives the character an upward initial velocity to show the physics of being tossed and landing."),
        new BehaviorControlItem(BehaviorControlAction.Sleep, "Sleeping and Waking", "Go to Sleep", Both,
            Ready | BehaviorControlRequirements.GroundSupport, Behavior, "Falls asleep on the support surface, playing the fall-asleep and breathing loop."),
        new BehaviorControlItem(BehaviorControlAction.Wake, "Sleeping and Waking", "Wake Up", Both,
            Ready | BehaviorControlRequirements.Sleeping | BehaviorControlRequirements.GroundSupport,
            Behavior, "Wakes up from sleep, then returns to her everyday standing pose."),
        new BehaviorControlItem(BehaviorControlAction.Hungry, "Nuonuo Interactions", "Get Hungry", Nuonuo,
            Ground | BehaviorControlRequirements.FoodEnabled, StateChange, "Enters the hungry state and says she's hungry; unavailable in Fasting Mode."),
        new BehaviorControlItem(BehaviorControlAction.LickIcon, "Nuonuo Interactions", "Lick an Icon", Nuonuo,
            IconAction, Behavior, "Runs to a visible desktop icon and licks it, without changing the icon or file."),
        new BehaviorControlItem(BehaviorControlAction.EatIcon, "Nuonuo Interactions", "Slurp an Icon Copy", Nuonuo,
            IconAction, Behavior, "Uses a copy that looks like the real icon: she runs over, slurps it up and ends satisfied; does not delete the real file."),
        new BehaviorControlItem(BehaviorControlAction.Satisfied, "Animation Preview", "Satisfied (Animation Preview)", Nuonuo,
            Ground, BehaviorControlKind.AnimationPreview, "Shows the after-meal satisfied animation on its own; does not pretend a file was eaten and does not add a meal record."),
        new BehaviorControlItem(BehaviorControlAction.Kick, "Feibi's Mischief", "Kick a Window", Feibi,
            WindowAction, Behavior, "Kicks a real window that meets the safety conditions; still works when her hat already holds something."),
        new BehaviorControlItem(BehaviorControlAction.Punch, "Feibi's Mischief", "Punch a Window", Feibi,
            WindowAction, Behavior, "Punches a real window that meets the safety conditions; still works when her hat already holds something."),
        new BehaviorControlItem(BehaviorControlAction.Charge, "Feibi's Mischief", "Charge a Window", Feibi,
            WindowAction, Behavior, "Charges at a real window that meets the safety conditions; on impact the window slides and slows down."),
        new BehaviorControlItem(BehaviorControlAction.HatStore, "Feibi's Mischief", "Stash a Window in Her Hat", Feibi,
            WindowAction | BehaviorControlRequirements.EmptyHat, Behavior, "Stashes a snapshot of the window in her hat; the real window is minimized until you choose to return it."),
        new BehaviorControlItem(BehaviorControlAction.Shatter, "Feibi's Mischief", "Shatter a Window", Feibi,
            WindowAction | BehaviorControlRequirements.EmptyHat, Behavior, "Kicks a window snapshot to shatter it, then collects the shards in her hat; apps and files are not harmed."),
        new BehaviorControlItem(BehaviorControlAction.Tear, "Feibi's Mischief", "Tear a Window in Half", Feibi,
            WindowAction | BehaviorControlRequirements.EmptyHat, Behavior, "Grows bigger, tears a window snapshot into top and bottom halves, then stashes them in her hat; the original window can be returned intact."),
        new BehaviorControlItem(BehaviorControlAction.Tease, "Feibi Interactions", "Tease Her", Feibi,
            Awake | BehaviorControlRequirements.MischiefReady, StateChange, "Raises the mischief value under the existing tease rules; repeated teasing and the safety cooldown still keep their intervals."),
        new BehaviorControlItem(BehaviorControlAction.FillMischief, "Feibi Interactions", "Fill the Mischief Bar", Feibi,
            Awake, StateChange, "Sets the mischief value to a full bar; does not bypass real-window safety conditions or automatically return anything already stashed."),
        new BehaviorControlItem(BehaviorControlAction.ReturnWindows, "Hat Interactions", "Give the Windows Back", Feibi,
            Ready | BehaviorControlRequirements.HeldWindow, Behavior, "Plays the retrieve-and-reassemble sequence, then confirms the original window has actually been restored."),
        new BehaviorControlItem(BehaviorControlAction.ThrowAndRecoverHat, "Hat Interactions", "Throw Her Hat and Pick It Up", Feibi,
            Travel | BehaviorControlRequirements.EmptyHat | BehaviorControlRequirements.FreeAirSpace,
            Behavior, "Throws her hat, runs over to pick it up and puts it back on as one full sequence, never playing the hatless in-between frames on their own."),
    });

    private static readonly IReadOnlyList<BehaviorControlItem> NuonuoItems =
        Array.AsReadOnly(All.Where(item => item.Supports(PetCharacterProfile.Nuonuo)).ToArray());
    private static readonly IReadOnlyList<BehaviorControlItem> FeibiItems =
        Array.AsReadOnly(All.Where(item => item.Supports(PetCharacterProfile.FeibiJiubi)).ToArray());

    public static IReadOnlyList<BehaviorControlItem> ForCharacter(PetCharacterProfile character)
    {
        ArgumentNullException.ThrowIfNull(character);
        return character.UsesMischief ? FeibiItems : NuonuoItems;
    }

    public static BehaviorControlItem Get(BehaviorControlAction action) =>
        All.FirstOrDefault(item => item.Action == action) ?? throw new ArgumentOutOfRangeException(nameof(action), action, null);
}
