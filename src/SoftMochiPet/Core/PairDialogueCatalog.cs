namespace SoftMochiPet.Core;

public readonly record struct PairDialogue(bool FeibiFirst, string First, string Reply);

public static class PairDialogueCatalog
{
    public static IReadOnlyList<PairDialogue> Exchanges { get; } =
    [
        new(true, "Nuonuo, guess what's in my hat?", "Cake…?"),
        new(true, "Let's go look over there!", "Wait for me."),
        new(true, "Did I jump high?", "So high!"),
        new(true, "There's a surprise in my hat!", "Can I eat it?"),
        new(true, "Nuonuo, wake up!", "Just a little more sleep…"),
        new(false, "What are you giggling about?", "Hehe, it's a secret!"),
        new(false, "Let me nap in your hat.", "Sure, hop in!"),
        new(false, "Slow down a little.", "Then hold my hand!"),
        new(false, "Is there cake today?", "Let me look!"),
        new(false, "No more mischief.", "Just one tiny bit!"),
    ];
}
