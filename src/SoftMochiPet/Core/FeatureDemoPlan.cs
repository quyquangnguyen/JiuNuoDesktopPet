namespace SoftMochiPet.Core;

public enum FeatureDemoAction
{
    Kick, Punch, Charge, HatStoreReturn, Tease,
    Shatter, Tear, HatlessInterruption,
}

public sealed record FeatureDemoStep(FeatureDemoAction Action, string Title, double TimeoutSeconds)
{
    public string Id => Action.ToString();
    public bool RequiresWindowTarget => Action != FeatureDemoAction.Tease;
    public bool RequiresManualRestore => Action is FeatureDemoAction.HatStoreReturn or FeatureDemoAction.Shatter
        or FeatureDemoAction.Tear or FeatureDemoAction.HatlessInterruption;
    public FeatureDemoAction CompletionAction => Action == FeatureDemoAction.HatlessInterruption
        ? FeatureDemoAction.Shatter : Action;
}

public sealed record FeatureDemoManualCheck(string Id, string Title);

public static class FeatureDemoPlan
{
    public const int Revision = 6;
    public const double RestoreTimeoutSeconds = 20;
    public static IReadOnlyList<FeatureDemoStep> Steps { get; } = Array.AsReadOnly(new[]
    {
        new FeatureDemoStep(FeatureDemoAction.Kick, "Kick the test window away", 20),
        new FeatureDemoStep(FeatureDemoAction.Punch, "Punch the test window flying", 20),
        new FeatureDemoStep(FeatureDemoAction.Charge, "Charge over and ram it", 20),
        new FeatureDemoStep(FeatureDemoAction.HatStoreReturn, "Hide the window; wait for a right-click return", 40),
        new FeatureDemoStep(FeatureDemoAction.Tease, "Tease her so the mischief bar fills up", 10),
        new FeatureDemoStep(FeatureDemoAction.Shatter, "Shatter it into the hat; wait for a right-click restore", 60),
        new FeatureDemoStep(FeatureDemoAction.Tear, "Tear it into the hat; wait for a right-click restore", 60),
        new FeatureDemoStep(FeatureDemoAction.HatlessInterruption, "Hatless interruption and hat pickup; wait for a right-click restore", 60),
    });

    public static IReadOnlyList<FeatureDemoManualCheck> ManualChecks { get; } = Array.AsReadOnly(new[]
    {
        new FeatureDemoManualCheck("PrankAppearance", "Check that torn edges are intact, shards go into the hat opening, and pieces reassemble after the right-click hat release"),
        new FeatureDemoManualCheck("PrankTakeover", "After stashing, no shards remain on the desktop, the window stays hidden until right-click restore, and control stops when the user takes over"),
        new FeatureDemoManualCheck("PrankVoice", "Character-specific voice lines, instant stop on mute, and no overlapping voices across consecutive actions"),
    });

    public static string FailureHint(string reason) => reason switch
    {
        "foreground_window" => "The test window is in the foreground: click an empty spot on the desktop, then right-click Retry This Step",
        "occluded" or "window_occluded" => "The test window is covered: move the covering window away, then right-click Retry This Step",
        "elevated_process" => "Exit the pet that is running as administrator and start it normally",
        "test_window_closed" => "The test window was closed; right-click Retry This Step to create it again",
        "step_timeout" => "This step did not finish in time; check the report, then Retry This Step",
        "unexpected_restore_before_manual_request" => "The window hold ended before any right-click request; check the report, then retry",
        "manual_restore_identity_mismatch" => "The restore request does not match the current test window; check the report, then retry",
        _ => $"This step is paused ({reason}); right-click Retry This Step",
    };

    public static string ManualRestoreHint(double elapsedSeconds)
    {
        var elapsed = double.IsFinite(elapsedSeconds) ? Math.Max(0, Math.Floor(elapsedSeconds)) : 0;
        return $"Waiting for a right-click restore (waited {elapsed:0}s)";
    }

    public static string ConfirmedStepResult(FeatureDemoAction action, bool hatlessInterruptionObserved,
        bool? remainsStoredBeforeReturn = null) =>
        (action == FeatureDemoAction.HatlessInterruption && !hatlessInterruptionObserved) ||
        (action is FeatureDemoAction.Shatter or FeatureDemoAction.Tear or FeatureDemoAction.HatlessInterruption &&
            remainsStoredBeforeReturn == false) ? "NeedsReview" : "Completed";
}
