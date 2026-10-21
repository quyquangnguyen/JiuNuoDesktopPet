# Features

This document describes the capabilities JiuNuo Desktop Pet currently implements, its behavior boundaries, and the parts that still need hands-on verification. The repository home page keeps only quick-start information; this document and the source code are authoritative on implementation status. Character configuration, asset sources and the progress of the current character phase are maintained centrally in [Characters](CHARACTERS.md).

## Status labels

| Label | Meaning |
| --- | --- |
| Stable | Covered by automated logic tests and verified in ordinary desktop environments |
| Experimental | Works, but is sensitive to monitor layout, window type or system behavior |
| Awaiting hands-on test | Implementation and applicable offline checks are done; awaiting user acceptance on a Windows desktop |
| Awaiting verification | In implementation or asset production, without this phase's acceptance completed; not to be considered a stable capability |
| Planned | Not implemented yet; not to be considered a current capability |

## Character selection

| Capability | Status | Notes |
| --- | --- | --- |
| Nuonuo / Feibi Jiubi switching | Awaiting verification | In single-pet mode it switches the current character; in coexistence mode, choosing a character first ends the companion window and then switches. See Characters for asset and acceptance progress |
| Both-pets coexistence and synced settings | Awaiting hands-on test | One process shows both characters, sharing one tray icon and the size, mute, Quiet and Infinite Mode settings; each keeps its own state and exclusive behaviors. See [Characters](CHARACTERS.md#both-pets-coexistence-and-synced-settings-adopted-2026-09-23-awaiting-hands-on-acceptance) |
| Two-pet relay for deleted icons | Awaiting hands-on test | When both pets are available and the desktop icon position is clear, Feibi kicks the original fake icon and Nuonuo opens her mouth to catch it; when position or state is unsuitable, it falls back to the single-pet slurp. Real file operations remain Windows' responsibility; for timing and boundaries see [Two-pet interactions](INTERACTION_PLAN.md#two-pet-relay-for-deleted-icons) |
| Separate progress saves | Awaiting verification | Nuonuo's old save is unchanged; Feibi separately saves sleepiness, curiosity and mischief state and adds no meal records; size, mute and Quiet Mode are shared |
| Feibi Jiubi's personality | Awaiting hands-on test | A livelier tendency to move, explore and jump, together with her own recordings; sleepiness, terrain limits and life modes still take priority |
| Feibi Jiubi's window mischief | Awaiting verification | Kicking, punching and charging windows, stashing and returning them via the hat, and with a full bar throwing her hat to shatter/tear; the code is wired in, but the complete new assets and the real desktop effect are not yet accepted |
| Feibi Jiubi's character isolation | Awaiting verification | Does not eat or lick icons, does not start the food-consumption watcher, has no hunger bar or Fasting Mode menu; the bar above her head is a mischief bar instead |
| Feibi Jiubi's voice | Wired in, awaiting manual test | Uses the dedicated recordings the user provided, for everyday rotation and emotional/mischief responses; for the mapping and acceptance status see [Characters](CHARACTERS.md#feibis-dedicated-voice) |

If no character has ever been chosen, Nuonuo is the default; after a successful switch, the last choice is saved. Switch requests while dragging or during the current swallowing or satisfied animation are delayed; clicking the still-checked current character cancels a pending switch. If assets are incomplete, the current character and the menu check mark stay as they are, and the log records the reason for rejection; the menu check mark only indicates a character that is actually in effect. For switching boundaries and the acceptance checklist, see [Characters](CHARACTERS.md) and [Manual tests](../SELF_TEST.md#04-character-switching-and-isolation).

Speech bubbles above the head have their own switch in the right-click menu, off by default for old settings; when on, they show short status lines, and with both pets together they can take turns talking automatically or manually. The bubbles never show test hints and do not replace voices, Nuonuo's hunger bar or Feibi's mischief bar. For timing and boundaries see [Two-pet interactions](INTERACTION_PLAN.md#speech-bubbles-above-the-head). Status: awaiting hands-on test.

Switching to Feibi clears Nuonuo's pending meal queue and fake icons and does not hand over eating tasks; switching away from Feibi first ends window mischief and tries to return any held windows. Old image-generation results are kept for traceability and do not mean the current character still supports food behavior.

## Feibi Jiubi's window mischief

Feibi's own menu provides "Allow Autonomous Mischief", "Make Mischief Now", "Tease Her" and "Give the Windows Back". The autonomous switch is on by default; manual ordinary actions rotate through kick, punch, charge and hat stash, and with a full bar she chooses a hatless super kick or a tear. Bar values, cooldowns, the action catalog and phase status are documented in one place in [Characters](CHARACTERS.md); for the effects and the reasoning behind the implementation see [Window mischief design](FEIBI_WINDOW_PLAY_PLAN.md).

Ordinary kicks and punches move the real window; the hat and the special moves only deform an in-memory snapshot of the real window, while the app stays minimized and keeps its taskbar button, and is never closed or edited. After shattering or tearing, Feibi picks up her hat, puts the shards or two halves into it, then puts her hat on and returns to daily life; once collected, no shards remain on the desktop, and the window is not returned on a timer or restored automatically. Only choosing "Give the Windows Back" from the right-click menu takes it out of the hat, reassembles it and restores it; clicking the hat or the shards does not return it. While holding a window, she does not start a second window prank. Manual capture allows any foreground window on the same screen that is unobscured and not maximized/full screen; autonomous mode still prefers ordinary restorable windows. Known full-screen capture layers are ignored by identity and are never treated as solid windows. Permissions and content protection are unchanged. Everyday dragging, going home, resizing, Quiet Mode and turning autonomy off do not return the window automatically; switching characters, exiting, locking the screen, real display changes and errors keep the safe return. When the user restores or takes over the target from the taskbar, it is released immediately; see the full boundaries in [Window holding rules](CHARACTERS.md#window-results-restored-by-the-user-adopted).

Screenshots are never written to disk or uploaded, and window titles or content are never written to the mischief log. After an abnormal end, the user can still get the window back through the taskbar; automatic recovery after a crash is not promised.

The standalone exclusive test uses `Revision 6`, keeps the order of its eight steps unchanged, and demonstrates a complete window hat stash only once; the two special moves add a check that the shards are collected into the hat after the destruction. After the performance, the four stash/destruction steps wait for the user's right-click restore, with no timeout, and the test never returns the window automatically; only after the request does it verify the real restore result and continue. Returning early before stashing or the hatless observation is complete is marked `NeedsReview`. `Tease` does not depend on a window precheck, while window interactions still check the actual target and safety conditions. Progress uses only the right-click menu, the test window title and the report; real failures can be retried or stopped. For starting and acceptance see [Manual tests](../SELF_TEST.md#06-feibis-standalone-exclusive-feature-test), and for status see [Character progress](CHARACTERS.md#current-progress-and-phase-exit-criteria).

## Interaction and physics

| Capability | Status | Notes |
| --- | --- | --- |
| Free dragging | Stable | The left button can interrupt idling and autonomous roaming; repeated presses never re-enter the drag state |
| Cheek pinching for both characters | Awaiting hands-on test | Hold either character's cheek and pull outward: the cheek stretches with your hand and she keeps pouting, and on release it bounces back into place; outside the face it is still the original drag. For animation and assets see [Cheek pinching](CHEEK_PINCH.md) |
| Gesture release | Stable | Samples the mouse velocity about 140 ms before release to distinguish gentle drops, sideways flings, upward tosses and diagonal throws |
| Gravity and landing | Stable | After release, 2D inertia and air drag are kept; she bounces softly off monitor edges and lands on usable terrain |
| Window platforms | Experimental | Treats the top edge of ordinary visible application windows as a standing platform; when the window closes or moves away, she falls again |
| Moving-platform inertia | Experimental | Moving quickly upward tosses Nuonuo up, and she is pushed up again when the window edge catches up with her feet; dragging downward creates a brief inertial separation before she lands back on the live window edge, rather than sticking to her feet |
| Window side impacts | Experimental | Continuously tracks the solid edges of ordinary visible windows; when a left or right edge sweeps through the character's body, a launch impulse is applied based on the impact direction and window speed |
| Window enclosure | Experimental | Dragging her inside a window and releasing switches to a four-walled enclosure; the character keeps her inertia, is affected by gravity, and bounces off the moving walls relative to them. Icon licking pauses inside the enclosure, and a deletion eating request makes her run out on her own |
| Window-edge behaviors | Experimental | Supports climbing, jumping, sliding down, actively jumping to the next level, and bouncing outward when a window is maximized |
| Multi-monitor terrain | Experimental | Computes physical-pixel terrain separately for each monitor, supporting negative coordinates and window segments that span monitors |

The non-character area of the window passes the mouse through using Win32 hit testing, while the character body can still be dragged.

Mouse interaction only responds to the user actively pressing, dragging, releasing and the right-click menu; mouse movement alone never triggers chasing, dodging, following or hugging. Autonomous exploration is driven by life state and window terrain, so the character never follows the pointer and gets in the way.

## Autonomous behavior

The character switches through a state machine between idling, roaming, climbing, falling, landing, sleeping and character-specific interactions. Nuonuo combines four long-term states; Feibi uses only sleepiness, curiosity and her own mischief value, and is not driven by hunger or fullness:

- **Hunger**: the higher it is, the more likely she requests food or shows hungry behavior.
- **Fullness**: rises after eating and changes slowly over time.
- **Sleepiness**: grows while awake and recovers while sleeping.
- **Curiosity**: exploration and interacting with the environment change this value.

Life state is written atomically per character, and Nuonuo keeps using her original save. The official path table is in [Character data boundaries](CHARACTERS.md#characters-and-data-boundaries). On the next load it keeps evolving for a limited offline duration, and an interrupted write never corrupts the previous valid data.

Current autonomous behaviors include:

- standing idle uses a separate blinking loop; each autonomous decision also has a small chance of switching to a short nap, more likely the sleepier she is;
- only while standing idle, Feibi tries to play an everyday recording every random 20–50 seconds, subject to mute, Quiet Mode and the voice cooldown; no character-name text is shown;
- the next autonomous decision starts according to each character's idle limit; for the specific rhythm see [Character personality](CHARACTERS.md#personality-and-voice);
- turning around, climbing, sliding down or jumping to nearby terrain at window edges;
- sleeping and exploring according to needs; only Nuonuo requests food; Feibi can interact with windows once the user enables autonomous mischief;
- important events use the current character's local voice, with priorities, per-situation cooldowns and per-recording anti-repeat protection. Clear landings get their own response, small drops stay quiet; whether text appears above the head is controlled by a separate switch.

The tray menu provides two life modes that are saved persistently:

- **Fasting Mode, Nuonuo only**: hides the hunger label and bar, keeps hunger fixed at 0, and excludes begging for food, licking icons and rolling from hunger; ordinary walking, sleeping and eating deleted items are kept. Feibi's menu does not show this option.
- **Quiet Mode, shared by both characters**: only autonomous idling and sleeping; no roaming, climbing, licking icons, responding to deletions or mischief; stashed windows are kept until a right-click restore, and the mischief bar does not build up. User dragging and direct window collisions are kept.

## Recycle Bin eating

The following eating features apply only to Nuonuo and work with Windows file events and Explorer metadata:

1. before deletion, try to record the selected desktop item's display name and physical coordinates;
2. after the file enters the Recycle Bin, match the original name from the Recycle Bin metadata;
3. add the target to the pending queue;
4. Nuonuo moves to the target and completes the eating interaction;
5. consecutive deletions are processed one by one, and the queue keeps at most 24 items.

Eating tasks can be interrupted by user dragging. The interrupted current target is put back at the front of the queue, and Nuonuo continues after landing, so tasks are never silently lost.

### Safety boundaries

- The contents of deleted files are never read;
- deletion or restore is never performed on the user's behalf;
- the contents of the Recycle Bin are never changed;
- if capture or matching fails, only the interaction is skipped, without affecting the original system operation;
- by default it watches the desktop, the Downloads folder and the Recycle Bin information visible to the current user; extra folders can be added in the settings.

## Display and system integration

- A transparent, borderless, always-on-top WPF window;
- the tray menu provides "Bring Her Home", "Pet Character", a live 60%–200% size slider, Start with Windows, Fasting Mode, Quiet Mode, "Show Speech Bubbles", "Mute" and "Exit Desktop Pet"; with both pets together, two-person dialogue can also be triggered manually; the character name is used in the tray tooltip and the size slider label;
- Start with Windows registers per current Windows user, and the portable package prefers to start the root-folder launcher; unchecking it deletes the corresponding startup entry;
- Per-Monitor V2 DPI manifest;
- watching for monitor hot-plugging, resolution, DPI and taskbar work-area changes;
- automatically shrinks in very small work areas and restores the configured size when back on an ordinary monitor;
- structured logs record state transitions, monitor geometry, window support and file events;
- the log rotates at 8 MB and is stored only on the local machine.

## Current limitations

- Some UWP apps, games, hardware-accelerated overlays or custom windows do not provide usable standard window bounds.
- Restarting Explorer or third-party desktop organizers may invalidate the desktop position snapshot.
- Moving between monitors with different scaling involves WPF and Win32 coordinate conversion and still needs verification on more hardware combinations.
- The app has no digital signature, automatic updates or crash telemetry.
- There is currently no separate settings window; the common options are gathered in the tray menu.

## Planned directions

The following are only candidate directions, with no promised release dates:

- GitHub Releases and checksums;
- automated Windows builds and tests;
- a more complete settings interface;
- a more complete regression matrix for mixed DPI and multiple taskbars;
- optional settings for behavior intensity and movement speed.
