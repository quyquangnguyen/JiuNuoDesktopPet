# JiuNuo Desktop Pet manual test checklist

Use only temporary files you create yourself for the tests below. Do not use existing files for deletion tests, and do not empty the whole Recycle Bin.

The scope, assets and acceptance progress of the character phase follow [Characters](docs/CHARACTERS.md). The official portable package includes both characters, their complete actions and their dedicated voices; after delivery you perform the hands-on checks below yourself, and the agent never starts the desktop pet automatically. Use the latest delivered `dist\JiuNuoDesktopPet-Portable`, not old-brand archives or old release folders.

Feibi's actions and calibration assets are complete; the official package does not include the separate test tools, so check the operations directly from the normal right-click menu following sections 0.4–0.5. Nuonuo keeps her original eating tests; Feibi should not eat, lick or show a hunger bar. Mischief tests only use ordinary blank test windows you prepare yourself, never apps in which you are editing important content.

The retest launcher of the release build is `dist\JiuNuoDesktopPet-Portable\JiuNuoDesktopPet.exe`; you can also fully extract the ZIP of the same name and run it. Packaging and verification status follow [Character release progress](docs/CHARACTERS.md#current-progress-and-phase-exit-criteria). First exit the old process from the tray, then open the new normal EXE. Do not mix in files copied from old preview, test or Behavior Control editions.

The existing separate Behavior Control Edition is kept and is currently not updated with the release build; sections 0.6–0.7 are only for reference if you still have an old standalone development test package.

Keep observing the top-and-bottom tear as before: the seventh item of the exclusive demonstration is the tear, and the earlier hat-stash and shatter items need a right-click return before continuing. The key points are temporary growth → gripping firmly and crouching to wind up → pulling apart upward and downward → a brief pause at the maximum spread → letting go and shrinking back to her original size → both pieces stashed in the hat completely → returned in place after a right-click. Check at 60% / 100% / 200% sizes, different Windows scaling and on a secondary screen; the performance should not change the saved size, and where her hands and face overlap the window you should still be able to right-click or drag. The temporary size should also be cleared after an interruption. The size evidence of a normal completion is `PrankTearGrowth` / `PrankTearSizeRestored`, and the stashing evidence is still `PrankRemainsStored`.

## 0. Starting and exiting

### v1.3.1 four fixes (awaiting user testing)

First exit the old version from the tray, then start the v1.3.1 official package; turn on coexistence and turn off Quiet Mode.

1. **Volume**: keep the same volume slider position, compare both characters' everyday recordings, then listen to Feibi's line before her special move. Loud recordings should be turned down, and the original loud volume should never suddenly come back after adjusting the slider. Whispers/sleepy clips stay quieter; after muting, neither character makes any sound. The `VoicePlayed` / `VoiceBurstStarted` logs include the shared volume and the actual compensated volume.
2. **Icon relay**: delete a newly created temporary shortcut and check that after it is kicked into her mouth she only keeps chewing, without opening her mouth to slurp again; then delete three temporary shortcuts in a batch. Right after the catch, drag her up, open the menu or switch modes; icons already eaten must not be queued again; the log should have exactly one `GhostConsumed` per item.
3. **Mouse cheek pinch**: for each character, lightly pull the left and right cheeks, pull far and hold, pull diagonally up/down, then release. Check the squinting, blush, mouth opening and closing and the soft rebound; there must be no leftover black edges, skin cracks, size changes or ghosting. The body/hat can still be dragged normally. Test again after both characters turn around, and test at 100%/125%/150% scaling. Use the [offline preview](docs/media/pinch-continuity-v131.gif) as reference; the subjective look awaits confirmation.
4. **Long-range feeding**: place the two at opposite ends of the screen and right-click to feed; they should turn in place, take off the hat, pull out the food and toss and catch it, without first running together. Swap left and right, then put one of them on a window ledge; with two screens, put them on different monitors. The food should reach the open mouth, and hunger is only reduced after the catch. Dragging a character away during the flight, moving the window she stands on or turning off coexistence should end safely, with no leftover food. `KeepPositions=True`, the distance and the flight time of Feed in `PairSceneStarted` help locate problems.

Automated verification runs silently in the background throughout and never started the desktop pet for you. If something goes wrong, providing the step, a complete screen recording and the log for that time range is enough; you do not need to provide real file contents.

### Cheek pinch and pouting (official package, awaiting testing)

First exit the old version, then double-click the EXE in the root folder of the current official package. Switch to Nuonuo and to Feibi Jiubi, or turn on both-pets coexistence and try each one:

1. While the character is idle, hold the left button on her left cheek and drag outward slowly, then quickly pull it far and hold for 1–2 seconds. The cheek outline should stretch continuously, and while holding, her mouth briefly opens and closes; her eyes, hair clip, body and feet should not stretch along with it, and there should be no character pulling her own face, double outline or size change. On release, it shrinks back from its current position.
2. Repeat with the right cheek; check that both sides can be hit, and that the blue hair clip on Feibi Jiubi's right cheek side stays on its original side. Repeat at 60%, 100% and 200% sizes and on a secondary screen with different scaling; the gesture range should scale proportionally with the character's size.
3. Dragging from the hat or body should still be the original lift/throw and should never be mistaken for a cheek pinch. After releasing the mouse during a pinch, right-clicking to open the menu, clicking "Bring Her Home" or turning off coexistence, the character should not get stuck or keep a stretched face.
4. If misalignment, skipped frames, stutter or the continuous pouting not playing occurs, give the character, left/right cheek, size, monitor scaling and time, and provide the nearby `CheekPinchStarted`, `CheekPinchReleased`, `CheekPinchSettled` or `UiFrameSlow` records in `activity.log` along with a screen recording.

For the implementation and asset sources, see [Cheek pinching](docs/CHEEK_PINCH.md).

### v1.2.1 action continuity retest

First watch single-character walking and running for two consecutive loops, then turn on coexistence and watch cheek pinching, sleeping together and the treat toss in turn. Focus on size before and after transitions, whether the top of the hat is complete, whether the body jumps sideways when hands and feet extend, and whether the food lands in the mouth. Test on 100% and 125% monitors. She should only grow noticeably in the planned phase of the tear special move; if the whole pet still keeps rescaling at other times, provide the name of the problematic action, a complete screen recording and the log for the same time range, to keep telling asset problems apart from display-environment problems.

### Right-click menu stutter retest (September 8 local release build)

1. Exit the old process and run the normal launcher `dist\JiuNuoDesktopPet-Portable\JiuNuoDesktopPet.exe`, not the automatic exclusive demonstration.
2. While she is walking, right-click the character, and also try right-clicking the tray once. Once the menu is open she should stop; hovering over items, entering the "Pet Character" submenu and dragging the size slider should respond.
3. Close it with Esc or by clicking outside the menu, then open it again; she should keep moving, without suddenly fast-forwarding or freezing permanently. Check each of the two characters once.
4. Open the menu while a window is in the hat; the window must not be returned automatically because of the menu's foreground change; clicking "Give the Windows Back" yourself should still work.
5. If it still stutters, note the approximate time and what she was doing, and provide `activity.log` (plus `activity.previous.log` if needed). The new `PetMenuOpened` / `PetMenuClosed` locate menu sessions; `UiFrameSlow` means one UI frame's work took over 100 ms, which is not the same as the whole duration of the stutter.

### Both-pets coexistence and synced settings (v1.2.2 official package, awaiting testing)

First exit the old process and start the updated official package. Once both appear, right-click either of them and check with the same menu:

1. Check "Both Pets Together" and confirm both appear at once, initially side by side; drag each one, and the other should keep moving on her own. When the program starts again, the coexistence preference should be kept.
2. Adjust the "Size" slider and watch both characters' normal size change together; after dragging them to different monitors, adjust it again; different actual pixel sizes due to each screen's work area and DPI are allowed.
3. Check "Quiet Mode" and confirm both stop autonomous walking and mischief; unchecking it resumes them. Check "Mute" and trigger each character's sounds; neither should make a sound.
4. With both modes off, both bars are shown. Check "Fasting Mode" and then "Infinite Mode", and confirm the hunger bar and mischief bar disappear together immediately; with both on, whichever you uncheck first, both bars should stay hidden, and they only come back together when the last one is unchecked. Hiding does not clear Feibi's mischief value, and she still makes mischief at the original cooldown.
5. Right-click either one and choose "Bring Her Home"; both should return to adjacent positions on the same screen. "Make Mischief Now" and "Give the Windows Back" only apply to Feibi, and Fasting Mode only changes Nuonuo's hunger behavior, but while together both bars are hidden in sync.
6. Turn off "Both Pets Together" or choose "Pet Character", and confirm only the selected one remains, with only one tray icon; a window in Feibi's hat is handled by the original safe-return rules before she leaves coexistence. Exit the program from the tray, and both should disappear.

7. Keep Fasting Mode on and Infinite Mode off, exit and restart; both bars should still be hidden; repeat with Nuonuo and with Feibi as the main character. After turning off coexistence, Feibi alone should get her mischief bar back, while Nuonuo alone still hides her hunger bar; coexisting again hides both together again.

If a step fails, note the time of the operation and provide `CoexistenceModeChanged`, `ProgressDisplayVisibilityChanged`, `PetLoaded` and the related settings events from the log. The official record of the rules is [Both-pets coexistence and synced settings](docs/CHARACTERS.md#both-pets-coexistence-and-synced-settings-adopted-2026-09-23-awaiting-hands-on-acceptance).

Before testing, exit the old version from the tray first, so the old process's single-instance protection does not take over the new launch request. After fully extracting this round's ZIP, double-click `JiuNuoDesktopPet.exe` in the root folder; on this machine you can also use directly:

```text
.\dist\JiuNuoDesktopPet-Portable\JiuNuoDesktopPet.exe
```

The release package bundles the runtime, so no extra components need to be installed. Only when developing from source, use the following alternative launcher in the project folder:

```powershell
dotnet '.\src\SoftMochiPet\bin\x64\Release\net8.0-windows\JiuNuoDesktopPet.dll'
```

When testing is done, right-click the current character's pet icon in the system tray and choose "Exit Desktop Pet". Do not end the process directly; this way the current character's life state is saved immediately.

### 0.0.1 Official name and upgrade compatibility

- The portable root folder has only one normal launcher EXE, "JiuNuoDesktopPet.exe", and the official package contains no test tools. A normal start does not run the demonstration automatically.
- The product name of both the root launcher and the main EXE in "app" is "JiuNuoDesktopPet"; window and tray tooltips show "JiuNuo Desktop Pet · current character", and the character menu still lists "Nuonuo" and "Feibi Jiubi".
- The new version should keep reading the old version's character choice, size, volume/mute and both characters' save data, without creating a new-brand data folder. For the specific compatibility decisions, see [Official rename notes](README.md#official-rename-and-legacy-compatibility).
- While an old-version process is running, the new version still obeys the same single-instance protection; exit the old version before starting the new one, so you do not mistake the old version's display for the update not working.
- If you want it to start with Windows, re-check "Start with Windows" in the new version's menu and check that the Run command points to "JiuNuoDesktopPet.exe" in the new folder, that the value name is still `SoftMochiPet`, and that no second brand startup entry is created.

When you need to watch the log, open another PowerShell:

```powershell
Get-Content "$env:LOCALAPPDATA\SoftMochiPet\activity.log" -Wait
```

The log saves a runtime snapshot every two seconds and records state changes immediately; beyond 8 MB, older content moves to `activity.previous.log`.

## 0.1 Voice

For the following recording acceptance, choose Nuonuo first. Voice is on by default at first start; existing mute and volume preferences are kept. Trigger each of the following actions:

- Delete a dedicated test file to trigger eating: the slurp should play a positive tone, and finishing should play an affirming tone;
- autonomous icon licking at high hunger: setting off should sound aggrieved; if there are no visible icons on the desktop, the super-sad tone should play;
- autonomous exploring and sleeping: you should hear the questioning and calm tones respectively;
- a window quickly tossing her upward: rotates among at least 7 gentler short responses, and the old shrill "scream" should no longer be heard; a fast downward pull can still play the out-of-control panic, interrupting any ordinary voice that is playing;
- flinging her or letting her fall from high up: the short landing response only plays on a clear impact when no voice was just played on the way; ordinary small steps, her own jumps, and back-to-back "cry out mid-air, then cry again on landing" should not occur;
- begging for food, licking icons and rolling while hungry share one reaction interval, and should not trigger in turn within tens of seconds or keep repeating the same line;
- dragging her with the left button: there should be an aggrieved tone, but repeated clicks do not stack sounds.

After checking "Mute" in the tray, triggering actions should be completely silent; unchecking it plays an everyday response. The same recording must not play again within 12 seconds, even if it belongs to another action; `VoiceSkipped Reason=FileRepeatCooldown` in the log means this anti-repeat protection has taken effect. `VoicePlayed`, `VoiceCompleted`, `VoiceMissing` and `Voice media failed` can also locate asset, interruption or decoding problems.

### 0.1.1 Feibi's dedicated recordings

Using this round's portable package, switch to "Feibi Jiubi" and unmute. All recordings and the situations they apply to are in [Voice notes](docs/CHARACTERS.md#feibis-dedicated-voice). Leave a cooldown between actions; not every animation phase is required to make a sound:

1. When switching in, on Bring Her Home, on unmuting, and while standing idle outside Quiet Mode, you should hear Feibi's own everyday recordings. All 9 numbered recordings are in the random pool, but random playback does not guarantee hearing them all in a short time. The `File` of `VoicePlayed Character=feibijiubi` in the log confirms which clip was chosen.
2. Check "sleepy" when she falls asleep on her own and the aggrieved clips while dragging; when flung or tossed by a window she should respond randomly from the 9 numbered recordings, no longer playing "feibijiubi_falling.wav"; when she stops while exploring it is still "puzzled". Fling her several times with cooldowns in between; `Cue=Scream` / `Panic` in the log may only choose numbered files, and a number just played in everyday chatter must not be used for falling again within 12 seconds. Small drops should not make her cry out repeatedly, the short landing response is unchanged, and no Nuonuo recording may slip in.
3. Prepare a test window as in section 0.5: kicks, punches and charges get positive or excited responses, hat stashing leans toward hushed/whispered clips, the full-bar tear gets the gritting-teeth response, and endings get short playful sounds. Mischief voices are at least 3.5 seconds apart; short phases being skipped is the anti-back-to-back protection.
4. Check "Mute" while a sound is playing; it should stop immediately, and further dragging and mischief stay silent. Unmuting restores sound; the volume slider in the right-click menu works. After entering Quiet Mode there is no more automatic everyday chatter or mischief sound, but the sleep and manual drag reactions are still controlled by mute.
5. Switch characters or cancel mischief while a sound is playing, and the old sound should stop. Switching back and forth should not mix voices, multiple clips should never play at once, and the same file does not repeat within 12 seconds.
6. Check the actual loudness, background noise, truncation and how well it fits the action, paying special attention to whether `041` and "dejected hushed" are too quiet. The background checks neither listened to nor adjusted the original recordings; if something does not fit, provide the `File` name and the triggering action so the mapping can be changed precisely.

## 0.2 Speech bubble switch

Bubbles are off by default; first verify the off state, then actively check "Show Speech Bubbles" in the right-click menu:

- While off, watch startup, standing idle, exploring, waking up, climbing, dragging and going home: neither character should pop up a speech bubble. After a restart, the default or the chosen switch state is kept.
- When on, each character shows short lines that fit her personality; the bubble follows the character, lets the mouse click through and never takes focus from the current app; after dragging to a monitor edge or to a monitor with different scaling, the text is still complete and not covered by the taskbar. The file name shown on Nuonuo's fake icons is kept.
- With both-pets coexistence on, trigger "Pair Interaction Demo → Let Them Chat" manually: one should say a line first and then the other replies, and the two lines must not stack in the same bubble; after standing idle for a while they should also occasionally chat on their own. Dialogue should be interrupted when dragging or an exclusive interaction starts, without freezing either character.
- Turning on "Quiet Mode" should hide bubbles immediately; turning it off restores the original switch preference. Checking "Mute" alone only silences sound and does not turn off the text; turning off bubbles should not make the characters silent either.
- Check the original voice and volume preferences as in section 0.1. While standing idle outside Quiet Mode, Feibi can still randomly play everyday recordings; `IdleVoiceAttempt` in the log can locate when attempts happen.
- Nuonuo's hunger bar when not fasting, Feibi's mischief bar, and the right-click/tray menus should display normally; the bubble switch should not hide these controls.
- Exclusive test progress only appears in the right-click menu, the test window title and the report; no steps, countdowns or ending text should be shown above the head.

## 0.3 Startup and life modes

Right-click the character or the tray icon to verify Start with Windows and Quiet Mode; Fasting Mode only appears in Nuonuo's menu:

1. Check "Start with Windows"; the current user's Run startup entry should point to the valid launcher of the version in use; unchecking removes it. Source mode should not mistakenly register the old portable package's launcher; if the current source launch method does not support registration, it should clearly report failure instead of showing success.
2. Check "Fasting Mode (Never Hungry)"; the hunger label and progress bar above her head should be fully hidden immediately and stay hidden after a restart; the internal hunger value is fixed at 0, and during observation she must not beg for food, lick icons or trigger the hunger roll, but she can still walk and respond to ordinary deletion eating.
3. After turning off Fasting Mode, the hunger bar above her head should come back immediately, and the hunger value grows normally over time, without jumping back to the old high value from before it was enabled.
4. Check "Quiet Mode (Only Stand or Sleep)"; the current roaming or interaction should stop; while watching continuously, she may only stand and blink or randomly fall asleep, and must not walk, climb or lick icons.
5. In Quiet Mode, delete a dedicated test file; it should not trigger running or eating; left-button dragging, falling after release and direct window impacts should still work. After turning off Quiet Mode, autonomous behavior resumes.

The log should show `StartupRegistrationChanged`, `FastingModeChanged` and `QuietModeChanged` respectively. After testing, you can keep the switches as you prefer.

## 0.4 Character switching and isolation

First note down the settings, Nuonuo's `TotalMeals` and Feibi's mischief value; do not delete, merge or rename save data. Paths follow [Character data boundaries](docs/CHARACTERS.md#characters-and-data-boundaries).

1. Open "Pet Character" in the tray; you should see "Nuonuo" and "Feibi Jiubi". Switch between them in turn and back and forth repeatedly; there should always be only one pet window and one tray icon, and the process does not restart; the menu check mark, tooltip name and size label match the actual character.
2. Switch while she is idling normally, walking, sleeping, on a window platform and inside a window enclosure. The old character's picture, sound and actions must not mix into the new character; with bubbles off neither shows text, and with them on only the current character's lines are shown. After switching she should get valid support again or fall naturally, never hanging in the air.
3. Request a switch while dragging; before you let go, the old character and drag state should be kept, and the request is applied after release, without getting the mouse capture stuck. Request once more and click the currently checked character before it takes effect; the pending switch should be cancelled, and after release the original character stays.
4. Choose Nuonuo and delete a dedicated file, then request switching to Feibi at three moments: heading to the fake icon, opening her mouth to slurp, and the satisfied animation. A portion that has already entered swallowing/satisfaction finishes first; once the switch takes effect, all pending fake icons and the queue are cleared, nothing is handed to Feibi, and no meal is counted twice.
5. Create and delete 5 dedicated files as in section 6, switching from Nuonuo to Feibi midway. Only the records Nuonuo actually finished eating before the switch are kept; the remaining fake icons are cleared. Feibi produces no eating increments, and switching back to Nuonuo does not make up for the cancelled old queue. The system's real deletion results are unaffected.
6. Switch at 60%, 100% and 200%; the size percentage is kept and the label changes to the current character's name. After checking "Mute", switch between the two characters back and forth; both should have no audio; unmute, and each character gets her own recordings back without mixing.
7. Turn on Fasting Mode for Nuonuo, then switch to Feibi: Feibi still only has the mischief bar and shows no Fasting Mode menu; switch back to Nuonuo, and the original Fasting Mode preference is kept. Quiet Mode is shared by both characters; Feibi makes no mischief and the bar does not fill, but an already stashed window is kept and can be restored by right-click.
8. Have Nuonuo eat a dedicated file, and for Feibi use "Tease Her" to raise the mischief value. Switch back and forth and exit and restart normally; both characters' records stay continuous on their own, Feibi does not inherit meal counts and Nuonuo does not inherit the mischief value. When Feibi is active, deleting a dedicated file leaves no fake icon, and she does not run to eat or lick it.
9. If Feibi's assets are still missing frames, choosing her should keep the current character, save data and check mark, and the log records `CharacterChangeRejected` and the reason for the missing assets, without an above-head hint. Do not modify the original assets for this step; only create a missing-frame situation artificially in a separate test copy.

`CharacterChangeRequested`, `CharacterChanged`, `CharacterChangeRejected`, `CharacterStartupFallback` and `CharacterSpritesReady` can be combined to locate timing; the absence of an event cannot itself replace visual acceptance. If something goes wrong, note the character before and after switching, her state and the menu mode.

### 0.4.1 Feibi's visuals and character presentation

The following checks must be done once the 33 action sets, the hat prop and the masks are complete; the current status follows [Character phase progress](docs/CHARACTERS.md#current-progress-and-phase-exit-criteria).

- Watch complete actions while idling, running/walking, being tossed, falling, landing, sleeping, climbing, being dragged, jumping and throughout mischief: the big white hat, blonde hair and both little feet are complete and never cut off because a motion gets bigger.
- At 60%, 100% and 200%, check the hat brim and hair for magenta edges, white halos or black backgrounds; the white hat and clothes must not become transparent, and the purple eyes and their original pupil highlights must not be hollowed out by color keying.
- Both feet keep a single standing baseline; adjacent frames do not jump in size or suddenly change position, and loops do not twitch between end and start. Jumping and running should show her actively pushing off with the hat brim and hair following slightly behind, not liveliness achieved only by speeding up playback.
- Feibi never shows tongue-out, swallowing, satisfied or hungry performances; for mischief, check the actual contact of foot, fist, shoulder and both hands as in section 0.5, with no hits from a distance. When climbing and sliding down an edge, her hands and feet still stay on the window edge.
- Watch for several minutes at similar sleepiness and curiosity: Feibi should be lighter and lean toward exploring and jumping, still rest when sleepy, and never bypass Quiet Mode. Mischief is not mouse tracking; she does not chase the mouse.

## 0.5 Feibi's window mischief

Prepare a test window you open yourself, for example an empty folder window, at normal size rather than maximized, fully inside a single monitor's work area, with blank space on its right at least one full pet width wide. Put Feibi on the same screen too. The manual "Make Mischief Now" can attack the current foreground window directly; maximized, full-screen, actually covered, protected-content, permission-incompatible or boundary-unsafe windows are still rejected by the safety checks, and refusing to make mischief when no compatible target is found is a normal boundary.

1. Switch to Feibi and confirm the bar above her head is only the mischief bar, with no hunger number or hunger bar; the menu has "Allow Autonomous Mischief", "Mischief status", "Make Mischief Now", "Tease Her" and "Give the Windows Back", and no Fasting Mode. With a brand-new configuration or on the first upgrade from v4 or earlier, the autonomy switch should be checked; a choice already turned off in v5 should be kept. The status line is not clickable, and the return item is unavailable while no window is stashed.
2. To focus on manual actions, first turn autonomy off and confirm the bar turns gray and the status line says it is off. With the mischief bar not full and the hat free, click "Make Mischief Now", and click again after each action completes, rotating through kick, punch, charge and hat stash; each time only one target is moved, never knocking into other windows in a chain. When something is already stashed, test as in the next section.
   Also click "Make Mischief Now" once during her `sleep` / `land` animation while she is sleeping or has just landed: after the menu closes she should first wake up or wait for the landing animation to finish, then run it automatically; the log should show `MischiefManualRequested`, plus `MischiefManualDeferred` and `MischiefManualDeferredExecuting` when needed, and the request should never be lost or the menu click turned into a drag.
3. Kicks, punches and charges should all wind up first, and the window only moves when a foot/fist/shoulder touches the real window edge. The window is not activated, not resized and does not leave the work area; the character ends after the action's own arm recovery, leg recovery and steadying, with no extra crouch, reach or gloating. The window must not slide away before the character has touched it.
4. For the hat stash you should see, in order: taking off the hat, holding the hat, the real window shrinking into a card, passing the hat opening and being covered by the front brim, then going into the hat; the real app is only minimized and its taskbar button stays. Once Feibi puts her hat back on she can move around normally while the window stays hidden; wait a while yourself, and it should not be taken out automatically. A generic fake window or a plain transparent fade-out is not acceptable.
5. Right-click "Give the Windows Back", and you should see the same card unfold and the real window restored, with its content unchanged. Clicking the hat or effects no longer triggers a return. Also try restoring the target yourself from the Windows taskbar: Feibi should stop holding it and never stash the window back.
6. While a window is being kicked or during a performance, actively activate, drag, maximize or close the test window, and check that the pet gives up control immediately; it must not keep pulling it back to the old position, minimize it repeatedly or leave a screenshot on the desktop.
7. With autonomy still off, click "Tease Her" repeatedly, at least 1.5 seconds apart; each effective tease adds 12 points; rapid repeated clicks should not stack. Meanwhile the gray bar stays still without pulsing, and when it is full it does not change windows by itself; you still need to click "Make Mischief Now" manually. Separately, with autonomy on, watch the slight bounce near full; it should not flash.
8. Trigger manually once the bar is full: first she throws the hat, which flies to the side and bounces once, and the character becomes hatless; then the super kick, and cartoon shattering only appears on the hit. The wind-up and the spreading shards are more leisurely than ordinary attacks so the action can be seen clearly; the shards keep the same test window's content, then go into the hat, and the real window is not restored automatically right away. The character picks up the same hat and puts it on, with no extra crouch or reach; after waiting, a right-click restore is what takes it out of the hat and hands the real window back.
9. After the special move, the bar resets to zero and the status line shows the cooldown; the duration follows the [official rhythm parameters](docs/CHARACTERS.md#autonomous-mischief-defaults-and-rhythm). During the cooldown the bar does not keep filling and there are no automatic repeats; manual small actions can still be tried. First restore the stash via right-click, and after the cooldown ends, tease her to full again and trigger manually; the next full-bar move is the tear: she first grips with both hands and builds up strength, then clearly pulls up and down apart; the tear line and the two halves must follow her hands, not an independently played split down the middle. The two halves then go into the hat, the real window stays minimized, and it is only returned on a right-click restore.
10. After she throws the hat and takes over the window, grab Feibi yourself, drag and toss her upward, then set her down gently. The window should stay hidden and must not be restored automatically because of the interruption; dragging, tossing, falling and landing all stay hatless, and once steady she goes back to pick up her hat and put it on, and finally you restore the window via right-click. No orphaned hat may be left behind, and the mouse capture must not get locked.
11. After the hat stash and after the hatless special move finish, turn on Quiet Mode, click "Bring Her Home", adjust the size or drag across screens: the window should stay hidden, and the right-click restore should still work. Switching characters, exiting normally, locking the screen, sleeping the PC or a real display layout/work-area change are safety exceptions: the held window should be returned and the effects cleaned up; the old character's actions do not mix into the new character, and content and saved state are unchanged.
12. Turn on "Allow Autonomous Mischief"; the bar returns to blue-purple; watch the status line go from charging to cooldown or waiting. Effective active time accumulates according to the [official rhythm parameters](docs/CHARACTERS.md#autonomous-mischief-defaults-and-rhythm): finishing an ordinary action does not reduce the bar, and a full value triggers only one special move. When there is no suitable window it shows waiting and the retry time, and a full bar must not drop from 100 because of it; autonomous mode never forcibly activates windows or widens the safety range to attack. Keeping the menu open for a long time, sleeping or the performance itself do not count as filling time.
13. The bar does not fill while sleeping, in Quiet Mode or while Windows is locked; after unlocking, waking or restarting after being offline there is no concentrated burst. Turning autonomy off should cancel pending intents immediately, and turning it back on does not immediately fire old tasks one after another.
14. Repeat kicks, punches and the hat stash at 60%, 100% and 200% and on screens with different DPI, confirming that contact, the card, brim occlusion and the hat prop stay aligned; if the window crosses screens, is covered or lacks space on the right, it should be refused safely, never capturing the wrong app's picture.

Note the kind of abnormal action, the bar value, the switch, the menu status line, whether the target was in the foreground/covered, the monitor scaling and a complete screen recording. In the log, focus on `MischiefStatus`, `PrankStarted`, `PrankPhaseChanged`, `PrankInterrupted`, `PrankCompleted`, `prank.motion.*`, `prank.snapshot.*` and `prank.cancel`; the mischief log never records window titles, content or screenshots.

### 0.5.1 Autonomy upgrade, status and the two-window stash

This part uses the normal launcher, with two windows A and B without important content that you prepare yourself. Each must meet the safety requirements of section 0.5; manual tests allow the current foreground window, but it must not be maximized, full screen or actually covered. All of the following await hands-on acceptance, and offline tests do not replace the results with two real windows.

1. After the first normal start of the new version, check that the version in `settings.json` is 5. If the original file's version was below 5, autonomy should have been turned on automatically this time; then turn it off from the menu, exit normally and start again, and it should still be off with the gray bar kept. Do not delete or tamper with the existing configuration for testing; the other coverage of new installs and old-version migration is checked by isolated offline fixtures. The exclusive test launcher should not trigger a real configuration upgrade.
2. Keep autonomy off, and first stash A in the hat, or complete a shatter/tear and stash it. A stays minimized and keeps its taskbar button. Put B in a safe spot on the same screen that Feibi can reach, click the desktop to take B out of the foreground, then click "Make Mischief Now": she should be able to kick, punch and charge B, A is not restored, B is not stashed, and A's original image is not overwritten.
3. Repeat complete small actions. Even when the bar is full and the hat is occupied, she can only do small actions on B, the status line explains that she is waiting for the hat to empty, and B is never stashed or destroyed. Ordinary small actions do not reduce the bar, and A is never returned automatically just because time passes.
4. While B is being kicked, punched or charged, actively activate or move B so this small action is cancelled. A should stay minimized; B's ordinary failure or takeover must not trigger A's return. Then, during another small action, click "Give the Windows Back": B's action stops first, then A is retrieved; the restored content, window identity and original position must belong to A, never mixed up with B.
5. Stash A again, and during a small action on B, restore A yourself from the taskbar: A's stash ownership should be released, A is not minimized again and no old snapshot remains; B finishes according to its own safety result. Only after the hat is empty can later hat stashes or special moves use the slot again.
6. With A stashed, going home, Quiet Mode, resizing, ordinary dragging across screens and opening/closing the right-click menu should keep A. Separately check switching characters, exiting normally, screen lock/sleep, or a real display layout/work-area change: the current small action should stop, and A should be released safely. Do not substitute killing the process directly for a normal exit test.
7. Turn autonomy on and prepare a suitable B, and check that with A stashed she still tries small actions at the ordinary rhythm. Without a safe B she only waits and retries; a full bar stays at 100. Check whether the menu status accurately distinguishes off, charging, cooldown, waiting for a window and an occupied hat; she can still charge while being dragged, the status says she is waiting for you to let go, and she must not suddenly strike while in your hand. Values below full should never show 100 early. Also retest right-click highlighting, submenus, the slider, and continued movement after closing with Esc, without catch-up fast-forwarding.
8. Prepare a compatible, non-maximized window without important content on both a 100% primary screen and a 125% secondary screen, and let Feibi launch an autonomous shatter special move once. Focus on `FetchHat → PickHat → CollectRemains → WearHat`: picking up the hat should not get stuck or make the process exit, and the shards should go into the hat; the target stays minimized while waiting, and right-clicking "Give the Windows Back" restores the same window. If something goes wrong, keep the lines around `PrankPhaseChanged`, `Hat prop`, `PrankStoppedSafely`, `prank.cancel` and `Stack` in that run's `activity.log`; sanitize local information before sharing.

In the log, `PrankStorageParked` means A was parked for the next small action, and `PrankStorageReturnRequested` means the original stash was taken back; judge together with `PrankManualRestoreCompleted`, the native confirmation and `MischiefStatus`, never declaring the visuals passed from event names alone. Before sharing the log, check it and sanitize personal information other than paths and handles.

## 0.6 Feibi's standalone Exclusive Feature Test

This launcher only demonstrates Feibi Jiubi's exclusive gameplay and creates a dedicated test window automatically. For the official scope, known issues and the acceptance status of fixes, see [Standalone Exclusive Feature Test launcher](docs/CHARACTERS.md#standalone-exclusive-feature-test-launcher-adopted) and the current progress in that document.

1. First exit the current desktop pet from the tray. The exclusive test launcher is only provided in development builds; the official package does not contain `test-tools`. In the development build folder, double-click `test-tools\FeibiJiubi-FeatureTest.exe` without moving it on its own; for everyday starts use `JiuNuoDesktopPet.exe` in the root folder of the official package.
2. Watch the current step in the right-click menu and in the dedicated test window's title; no speech bubble should appear. The fixed order is: kick the window → punch it flying → charge into it → stash it in the hat and wait for a right-click return → tease her until the mischief bar is full → throw the hat and shatter the window, stash it in the hat and wait for a right-click restore → throw the hat and tear the window, stash it in the hat and wait for a right-click restore → a hatless interruption, then pick up the hat and wait for a right-click restore. The step IDs in the report are, in order, `Kick / Punch / Charge / HatStoreReturn / Tease / Shatter / Tear / HatlessInterruption`. There are no separate demonstrations of walking/running, sleeping, window physics, size, mute or going home; running to approach the target is still part of the exclusive action.
3. The demonstration inherits your original size, volume and mute preferences; if you were muted, it does not turn sound on by itself. If you need to check the sound, you decide whether to unmute. The demonstration only saves temporary session settings and state; it does not change your real preferences, real life saves or Start with Windows, and does not operate on your app windows.
4. If a step fails, confirm the flow stops at that step and the following steps are not marked as failed in a chain. Note the hint and the step, fix the problem (for example, something covering the window), then right-click and choose "Retry This Step"; the current action should be redone, and the next step continues only after it passes.
5. To stop early, right-click the character or the tray and choose "Stop Exclusive Feature Test"; left-clicking the character directly also stops it. Screen lock, sleep and exit cancel the demonstration. Confirm that the dedicated test window and any leftover effects are cleaned up and later steps do not continue; muting during the test still takes effect immediately.
6. After the demonstration ends, pauses on a failure or is stopped, look at `%TEMP%\SoftMochiPet.FeatureTest\<session>\feature-test-report.json`. If you cannot find this run's folder, look up the `ReportDirectory` of `FeatureDemoStarted` / `FeatureDemoFinished` in the diagnostic log.

The hat stash is demonstrated only once. The hat stash, shatter, tear and hatless interruption steps enter `WaitingForManualRestore` after the performance, which means normal waiting, not failure. You can observe for a while first to confirm the window has not restored itself, then right-click "Give the Windows Back"; restoring immediately is also allowed, with no minimum wait. The manual wait has no timeout, while the animations and the restore checks after a request still have time limits. The program must never call restore automatically to continue the demonstration, clicking the hat or effects does not replace the right-click, and clicking the character stops the whole demonstration.

If you right-click restore in the eighth step before the hatless drag, toss or hat pickup has been fully observed, the simulated action should stop immediately and returning the window takes priority. Once the real return is confirmed, that step and the whole report are marked `NeedsReview`, with `Evidence.HatlessInterruptionObserved=false`; this is not a window-restore failure, and it also cannot count as a pass of the full hatless performance. If you need to observe it fully, run this launcher again and only right-click restore after the hatless performance ends.

Teasing to fill the bar is a separate step and should not be blocked by a failed window precheck; later window actions still need the program's own test window to be prepared and to pass the real safety checks. Watch that preparing the window does not steal focus and that actions only start once the target has a visible position; a complete real run of this version still needs to be confirmed according to this section.

In this version, also watch the attacks' wind-up and sudden strike, the hit-stop/small impact sparkle at the moment of contact, the window moving away quickly and the character's single rebound; there must be no hits from a distance, back-and-forth jitter or sliding in place. Attacks no longer end with an extra crouch, reach or gloating; the special moves are slowed down so the wind-up, strike and destruction are easy to see. At the shatter, tear and hatless interruption steps, after the bar is full she should first call out the specified "Feiba Jiubi", and only after the whole line ends approach the window and throw her hat; when muted, the sound is skipped and she should not get stuck there. After exiting/stopping during playback, the attack must not continue. The voice logs are `VoiceBurstStarted` and `VoiceBurstFinished`, which should end before `PrankPhaseChanged Phase="Approach"`.

`Completed` requires the actual displacement or minimize/return checks of the corresponding window to pass, and does not mean the visuals and sound are acceptable. Targets of the hat, shatter, tear and hatless interruption steps must first receive a real right-click request, and then the same window must be confirmed restored; the eighth step cannot pass just by picking the hat back up. The report version should be `Revision: 6`; `ManualRestore.State` distinguishes `WaitingForManualRestore`, `ManualRestoreRequested` and `Restored`, `HeldSeconds` records the actual wait, and `RequestedAt` records the time of the real right-click request. A special move should first pick up the hat, then stash the shards or two halves in the hat opening, and after putting the hat on no shards remain on the desktop; after the right-click, the pieces come out of the hat, the window image reassembles, the real window is restored, and the hat goes back on, in that order. Your observation and screen recording that the window had still not been restored after waiting on your own can be combined with these fields for acceptance; quickly clicking restore does not prove that long-term holding has been observed sufficiently.

For target failures look at `LastTargetCheck`, for successful actions at this run's `Evidence`, and for phases at `PhaseHint`; the log contains `FeatureDemoWaitingForManualRestore`, `FeatureDemoManualRestoreRequested`, `FeatureDemoPhase` and the native events `prank.target.inspected`, `prank.selection.rejected` and `prank.operation.confirmed`. Please provide this run's report and the corresponding log, checking and sanitizing local paths before sharing. Multiple screens and different scaling, mouse dragging/clicking in normal mode, Start with Windows, and locking and unlocking still need separate manual tests and are not part of these automated steps.

## 0.7 Standalone Behavior Control Edition

The launcher is `dist\JiuNuoDesktopPet-BehaviorControl\JiuNuoDesktopPet-BehaviorControl.exe`; fully extract the behavior edition ZIP and start it from the root folder; it has no "test-tools". For the scope and isolation rules see [Behavior Control Edition notes](docs/CHARACTERS.md#standalone-behavior-control-edition-adopted), and the delivery status follows the last section of that document. The following is accepted by you personally; background checks cannot replace these real operations.

1. First exit the old desktop pet, then open the behavior edition. Right-clicking should show "Trigger Behavior Directly", categorized by the current character, and by default she does not walk or run on her own; "Automatic Daily Activities (Behavior Control Edition)" is off after every restart. The normal edition and the behavior edition cannot run at the same time; opening one again should ask you to exit first and must not pull the character you are operating back home.
2. For each character, pick Stand, Look Around Curiously, Take a Walk / Go for a Run, Explore Nearby, Patrol Around, Do a Hop, Do a Roll, Go to Sleep / Wake Up, Free Fall and Toss Her Up. Each only starts after the menu closes; walking and running should cause real displacement, and "Wake Up" only becomes available after she goes to sleep. You can use a window's top edge to check climbing, sliding down and jumping down; without terrain, space or support, it should not pretend to succeed.
3. Switch to Nuonuo, turn off Fasting Mode, uncover the desktop, then click "Get Hungry", "Lick an Icon" and "Slurp an Icon Copy" in turn. The copy's appearance should come from a real icon, and after she eats it the original icon and file still exist; "Satisfied (Animation Preview)" only plays the animation and does not increase the meal count. These food entries must not appear in Feibi's menu.
4. Prepare a window without important content for Feibi, placed on the same screen where she can reach it and nothing covers it. Directly pick kick, punch, charge, hat stash, shatter and top-and-bottom tear; targeted attacks do not need a full bar first; the current foreground window can also be targeted manually, as long as it is not maximized or full screen. If the target is unsuitable, check the menu status; the program must not activate the target on its own or widen the safety range to achieve the effect.
5. After a hat stash, or after a shatter/tear has been stashed in the hat, wait first; the real window should stay hidden; "Stop Current Action" must not replace returning it. Choose another compatible window and check that kicks, punches and charges still work, while new hat stashes/special moves are grayed out because the hat is occupied. Finally click "Give the Windows Back" and confirm the original window's content and position are fully restored. Check the endings of stopping midway, going home, switching characters and exiting normally separately.
6. Pick Throw Her Hat and Pick It Up, Tease Her and Fill the Mischief Bar. The hat throw should end with the hat fully picked up and put back on, with no lingering hatless in-between state; the interval between repeated teases is still kept. With Quiet Mode on, while she sleeps, while dragging her or while the hat is occupied, check that the related entries are grayed out and the status is accurate. Opening the menu, switching submenus and the size slider stay responsive, and after closing the menu there is no catch-up fast-forwarding.
7. In the behavior edition, change the character, size and volume/mute, then exit and reopen; the preferences are kept; "Automatic Daily Activities (Behavior Control Edition)" is still off by default. Then exit the behavior edition, open the release edition and check that its original settings and life records were not rewritten by the behavior edition. Do not delete or tamper with the original configuration to create a migration scenario; the first-run whitelist and old-configuration protection are covered by isolated offline fixtures.

For problems, note the character, menu item, conditions at the time and the time, and locate them together with `BehaviorControlStarted` / `BehaviorControlUnavailable` / `BehaviorControlStopped` / `BehaviorControlCompleted` and the existing window logs. A menu showing completion does not mean the look passed; window actions still need the actual target checked, and you decide whether to unmute for anything involving sound.

## 1. Basic visuals and stability

After starting, first watch for 30 seconds:

- The window should be about 220×220, and transparent areas should show no black background or magenta edges.
- Both feet should touch the bottom edge of the work area above the taskbar, without sinking, floating or shaking violently.
- The top of the head, hair and both feet must never be cut off.
- When Nuonuo is not fasting, `Hunger 0–100` is shown, turning orange above 55 and red above 80; when fasting, the whole bar is hidden. Feibi never has a hunger bar and only shows the mischief bar as in section 0.5.
- Idle frames should change slowly, with no teleporting or obvious frame skipping between actions.
- Standing idle only does natural blinking, and the body should not drift left or right; after watching a few rounds, she should randomly go into the original lying-down sleep animation and then get up normally.
- The mouse merely passing by never triggers eye tracking or the body chasing, dodging, following or hugging; Nuonuo has no extra pupils, and Feibi keeps the original image's purple eyes and native pupil highlights.

### 1.1 Size slider

Right-click the current character or the tray icon and drag the size slider in the menu that starts with the current character's name:

1. Adjust from 100% to 60%, 140% and 200% respectively; the character should scale continuously and instantly, with no restart needed.
2. If she is standing on the taskbar or a window, her feet should stay in the same place before and after scaling, without bouncing up, sinking into the platform or jumping sideways.
3. The character body, hit area, collision body and the current character's hunger or mischief bar should stay usable with the window size, and hair and feet must not be cut off; with bubbles off no text should appear, and with them on the bubble must not cover the character's face.
4. After exiting and restarting, the last set percentage should be restored; `PetSize` in `settings.json` should be updated accordingly.
5. When choosing 200% on a small screen or a high-DPI monitor, the program may temporarily shrink her for the current work area; after moving back to a monitor with enough space, the set size should be restored.

### 1.2 Feel of dragging and flinging

1. Move her a short distance slowly with the left button and release: she should settle directly as if set down gently, never flying off for no reason.
2. Hold, fling quickly horizontally and release while moving: she should keep flying a while in the fling direction, with speed gradually decaying, instead of dropping vertically at the release point.
3. Fling quickly upward, diagonally up and diagonally down: the trajectory should keep the corresponding 2D direction, and an upward fling goes past the apex before falling.
4. Fling toward the outside of the monitor: before the foot anchor reaches an area with no monitor, she should bounce back softly and never be lost off screen permanently.
5. While being dragged in the air she uses the dedicated soft, droopy pose, with head, hair and both feet complete; after release it transitions smoothly into the jump/fall and the bouncy landing.

The log should show `DragReleasedGently` or `DragReleasedWithInertia` respectively, the latter with `Velocity`, `Speed` and `SampleSeconds`; followed by `FallStarted` and `Landed`.

## 2. Window terrain and gravity

First open the test platform:

```powershell
powershell -ExecutionPolicy Bypass -File .\tools\runtime_test_platform.ps1
```

Then test in order:

1. Drag Fu Nuonuo to about 200–400 pixels above the platform and release.
2. She should accelerate as she falls, play the falling animation, and land on the window's top edge.
3. After landing she should play the roughly 1-second squash-and-rebound animation once completely, with both feet finally on the window edge.
4. Move the platform window down about 150 pixels. She should first stay at her original height and separate naturally from the window edge, then fall under gravity onto the platform's new position.
5. Move the platform away sideways or close it. Once the platform is no longer under her feet, she should drop to the next window down or to the bottom of the desktop.
6. Stack two ordinary windows at different heights and release her from above; she should land on the upper window she passes through first, never falling through to the lower one.

Then test window-edge inertia:

7. After Fu Nuonuo is standing steadily, move the platform up and down slowly; she should follow steadily without shaking or jumping on her own.
8. Drag the platform upward fairly quickly by about 120–250 pixels; she should first rise with the platform, then leave the window edge and be tossed upward, playing a compact surprised weightless animation with both feet visible and inertia in her hair and sleeves, switching to falling at the highest point. While airborne, if the platform catches up with her feet it should push her up again, never passing through her; while the platform has not caught up or is moving down, she should keep a free ballistic trajectory and must not move in sync as if stuck to the window edge.
9. Drag the platform downward fairly quickly; her feet should briefly separate from the window edge, then she falls to catch up with the platform's live position. She must not go down in sync as if stuck, pass through the platform, or fall to the desktop for no reason.
10. Moving up quickly should log `PlatformLaunch`, `FallStarted`, `TossApexReached` and `Landed` in order; moving down should log `PlatformDownwardRelease` and `FallStarted`, followed by `Landed` back on the same platform handle, with no `PlatformSupportLost`.

Then test window terrain behaviors:

11. Have her stand on the top edge of an ordinary window and keep watching; when she chooses to jump on her own, she should play the separate squash—take-off—mid-air ball animation, forming a real parabola horizontally and vertically and landing on a collidable window or the desktop.
12. Keep an ordinary window open and watch for 2–5 minutes: on reaching an edge she should randomly turn around normally, jump off, hug the edge and slide down, or actively jump to a lower level; while sliding down an edge her hands stay on the real window side, and her body descends continuously along the side before she lets go and falls.
13. While she stands on an ordinary window, suddenly click that window's maximize button: once the original top edge disappears she should bounce off upward toward the outside of the screen, instead of hanging in place or sinking into the window; the log shows `WindowMaximizeBounce`.
14. Have Nuonuo stand outside a window, then quickly drag another ordinary window sideways into her from the left and from the right. She should fly off in the direction of the impact with a slight upward arc; the log shows `WindowSideImpact`, with a `Direction` matching the window's direction.
15. Drag Nuonuo inside a sufficiently large ordinary window and release. She should land on the window's inner bottom edge; when you shake the window back and forth or up and down, she keeps her inertia and bounces off the left, right, top and bottom walls, never sticking to the window. Dragging her out or closing the window should release the enclosure.
16. This item only tests Nuonuo: at high hunger inside the enclosure she should not run off to lick icons; after a dedicated file is deleted, the enclosure should be released and she runs out to eat. Feibi is unaffected by deletions and gets no eating tasks.

The enclosure logs use `WindowEnclosureEntered`, `WindowEnclosureImpact` and `WindowEnclosureSettled` in order; dragging her out or closing the window logs `WindowEnclosureReleased`. Eating a deleted item from inside the box logs `WindowEnclosureMealEscape`, and an icon-licking request inside the box records `IconLickSuppressedInEnclosure`.

The edge behavior logs use `TerrainEdgeActionChosen`, `TerrainHopStarted`, `EdgeSlideStarted` / `EdgeSlideReleased` or `TerrainJumpDownStarted` in order, so you can tell whether it simply was not randomly chosen or whether the physical transition failed.

For multi-monitor testing, place the platform across two monitors, for example by adjusting `Left` to your screen arrangement:

```powershell
powershell -ExecutionPolicy Bypass -File .\tools\runtime_test_platform.ps1 -Left 2300 -Top 650 -Width 700 -Height 320
```

Put her on the parts of the window on each of the two screens. She should be able to land steadily on both sides; after crossing screens, her size, foot position and speed should not change abruptly. Maximized windows, the taskbar, tooltips and hidden windows should not become standable platforms.

## 2.5 Mouse interaction boundaries

Turn off Quiet Mode, let Nuonuo and Feibi Jiubi idle and roam normally, and keep watching for 3–5 minutes:

- Resting the mouse nearby, circling slowly or passing by her quickly should never trigger chasing, dodging, following or hugging the mouse;
- holding the left button on the character still interrupts roaming and drags her, and gentle drops, flings and upward tosses after release are still accepted as in section 1.2;
- right-clicking the character still opens the menu, and clicks on the transparent non-character area should still go through to the app below.

## 3. Autonomous behavior

Leave it alone for 3–5 minutes and watch the new life loop:

- Each time she returns to idle, Nuonuo stays in place for at most about 5 seconds and Feibi for at most about 4 seconds before starting a new behavior; she must not stay on the same frame for a long time without reason.
- After starting a slow walk in the normal state she should keep walking: on reaching one side of the platform she turns around directly or turns toward a climbing target, with no "walk a bit—stop a few seconds—walk again" rhythm in between.
- When there is a climbable window, she walks to its left or right side, plays the climbing animation with alternating hands and feet, and rises along the real side.
- Climbing may succeed or slip; a success must land her exactly on the target window's top edge and continue roaming, and a failure must go into a real fall/landing, never teleporting back to the ground.
- Even at low sleepiness she occasionally takes a random nap, visible for at least a few seconds; at higher sleepiness the probability clearly increases. She should go from standing to lying on her side frame by frame and breathe slowly in the same lying pose; when waking she gets up in reverse and never snaps back to standing instantly.
- Only Nuonuo chooses to lick icons, beg for food or do the full roll when quite hungry. Feibi shows none of these food behaviors, and her autonomous mischief is accepted as in section 0.5.

A passing result is "living continuously, with randomness but no mechanical back-to-back playback". Walks must move along the platform under her feet, turning into a fall when the platform disappears.

For the climbing test you can keep the test platform from section 2 open and put Fu Nuonuo back at the bottom of the desktop on the same monitor. By default, the platform's bottom edge is within the range she can jump up and grab; watch for about 1–3 minutes. The log should show `ClimbTargetChosen` and `ClimbStarted`, followed by `ClimbSucceeded` or `ClimbSlipped`. After a success, `Support` should become the platform window's handle.

In addition, Nuonuo should occasionally choose a visible icon, run to its right side and lick it, with a cooldown of about 70 seconds after each lick. The real icon never disappears, moves or gets renamed. Feibi never does this.

If you need to force a specific need to observe, first exit the desktop pet from the tray, then back up:

The example below is only for checking Nuonuo's needs. Feibi's sleep/exploration can be checked by changing her own `Sleepiness` / `Curiosity` after a separate backup; changing hunger or fullness should not affect her behavior and should not show a hunger bar. Test Feibi's mischief with the menu, not by editing the save to force past the cooldown. Do not mix the two characters' backups.

```powershell
Copy-Item "$env:APPDATA\SoftMochiPet\life-state.json" "$env:APPDATA\SoftMochiPet\life-state.self-test-backup.json" -Force
notepad "$env:APPDATA\SoftMochiPet\life-state.json"
```

Only change the four numbers below and leave other fields alone:

| Goal | Hunger | Fullness | Sleepiness | Curiosity |
|---|---:|---:|---:|---:|
| Hungry icon licking/rolling | 100 | 5 | 10 | 10 |
| Sleepy sleeping | 5 | 20 | 100 | 10 |
| Curious exploring | 10 | 20 | 10 | 100 |
| Full and resting | 5 | 100 | 20 | 10 |

Save, restart, and watch for at most 90 seconds. Behaviors have random weights, so the first decision is not required to trigger it. When done testing, exit first, then restore the backup.

```powershell
Copy-Item "$env:APPDATA\SoftMochiPet\life-state.self-test-backup.json" "$env:APPDATA\SoftMochiPet\life-state.json" -Force
```

## 4. High hunger and icon licking

Sections 4–6 only apply to Nuonuo; the reverse check for Feibi is no licking, no eating and no fake icons.

Using the method from section 3, set `Hunger` to `100` and `Fullness` to no more than `8`, then start the desktop pet; make sure the desktop has at least one fully visible icon not covered by any window, and wait for her to choose to lick an icon on her own:

- She should immediately choose a nearby real desktop icon, rather than running toward the mouse or the menu position.
- She should stand to the right of the icon and play the roughly 1.8-second licking animation facing left; the middle of the tongue-out should touch the icon's right edge.
- The top of the head, hair and both feet stay complete throughout; the tongue should be short, wide and rounded, and after pulling it back she puffs her cheeks, squashes and springs back upright, without suddenly lying down or skipping frames violently.
- After the action ends, the icon's position, image and name are completely unchanged; `Hunger` in the state should be around 100, `Fullness` no more than 8, and `TotalMeals` does not increase.
- If it triggers while she is falling, landing, being dragged or eating a file, she should wait until she is steady or has finished eating before going to lick.
- Temporarily hide the desktop icons or cover them completely with windows; on a high-hunger decision she should say "Nothing to lick." and then stay in place playing the full hunger roll; she must not run to the old coordinates.

## 5. Single deletion animation

Create a dedicated file on the desktop:

```powershell
$desktop = [Environment]::GetFolderPath('Desktop')
Set-Content -LiteralPath (Join-Path $desktop 'FNN_TEST_FOOD_SINGLE.txt') -Value 'disposable test file'
```

Wait 2 seconds, then click this real icon on the desktop and press `Delete`:

- After the real file disappears, the same icon and file name should immediately be left at exactly the same position.
- The fake icon must not jump to the mouse menu or any other clicked position.
- Fu Nuonuo should run to the right of the icon and open her mouth wide facing left, rather than standing on the wrong side.
- The icon and text should first stay in place, then shake, stretch, shrink and get slurped into her mouth.
- The whole swallowing process should be clear and fairly slow; the fake icon only disappears once it is inside her mouth.
- After swallowing, the satisfied animation plays, hunger in the state decreases, and fullness and `TotalMeals` increase.

If the fake icon does not appear, first exit the desktop pet and confirm that `ReactToDeletes` in `%APPDATA%\SoftMochiPet\settings.json` is `true`.

## 6. Consecutive deletions and the buffet

Create 5 temporary files:

```powershell
$desktop = [Environment]::GetFolderPath('Desktop')
1..5 | ForEach-Object {
    Set-Content -LiteralPath (Join-Path $desktop ("FNN_TEST_FOOD_{0:D2}.txt" -f $_)) -Value 'disposable test file'
}
```

Wait 2 seconds. Hold `Ctrl` and select only these 5 test icons (do not use `Ctrl+A`), then press `Delete` just once:

- After each real icon is deleted, its own fake icon and text should immediately be left at its own original position; the five fake icons must not pile up at the same point.
- Icons and file names should match their original positions; the single `DesktopSelectionCaptured` in the log should list five different center points, and the following five `DeletionQueued` should have different `QueueId`s and coordinates.
- While she eats the first one, the other fake icons must stay at their own original positions, never disappearing first and then suddenly reappearing.
- A second quick deletion should trigger the "buffet" reaction.
- She should go to each corresponding position one by one and slurp it completely, without losing the order; the next one is only handled after the previous one is eaten.
- The satisfied animation between meals may be shortened, but the slurp must never be skipped.
- In the end all 5 fake icons disappear, and `TotalMeals` should increase by 5.

Do not test with existing files. In the Recycle Bin, only handle these `FNN_TEST_FOOD_*` items; do not empty the whole Recycle Bin just to clean up the test.

## 7. Character state and saving

The following four-need and eating-statistics checks are for Nuonuo. For Feibi, check her separate sleepiness, curiosity and mischief saves instead: hunger/fullness reset to zero and the meal count does not grow; the mischief save has no window handles or snapshots, does not increase offline, and does not restore old actions. The official paths are in [Character data boundaries](docs/CHARACTERS.md#characters-and-data-boundaries), and cross-character isolation is in section 0.4.

After exiting from the tray, look at:

```powershell
Get-Content "$env:APPDATA\SoftMochiPet\life-state.json"
Get-ChildItem "$env:APPDATA\SoftMochiPet" -Filter '*.tmp'
```

Check:

- After being awake for a while: hunger, sleepiness and curiosity rise slowly, and fullness drops.
- After eating a file: hunger drops, fullness rises, `TotalMeals` increases, and the extension is counted in `FoodTypeCounts`.
- After finishing exploring: curiosity drops.
- After sleeping: sleepiness drops clearly.
- All four values always stay within 0–100.
- `life-state.json` can be read normally, and no `.tmp` files are left in the folder.
- Exit for a while and start again; the state evolves for at most 12 hours of offline time, and never dies or becomes permanently invalid.

## Two-pet relay for deleted icons (please test yourself)

### v1.3.0 four daily interactions (awaiting user testing)

1. Exit the old process, start the new version, turn on both-pets coexistence and turn off Quiet Mode. First bring both home, then drag them to a spacious spot at the bottom of the same monitor; do not have one on a window ledge and the other on the ground. Right-click "Pair Interaction Demo" and choose Little Tagalong, Nuzzle in Passing, Play Ball Together and Watch the Fun Together in turn.
2. Following: Feibi walks ahead, looks back midway, and Nuonuo follows a little later; when Feibi is at the screen edge she should stop and wait, never crossing the edge. Nuzzling: the left/right order should not swap, their cheeks come close and then return, and the tops of their heads/feet are not cut off.
3. Ball play: watch the complete sequence of taking off the hat to bring out the ball, six back-and-forth passes, and putting the ball away and the hat back on. After the second kick there must still be kicking, not just the ball flying; the ball only changes direction at the shoe tip, never jumping to the foot out of nowhere or passing through the hat. Test with Feibi on the left and on the right, then try 60%/100%/200% sizes and 100%/125% display scaling.
4. Watching the fun: open a new ordinary window or clearly move one on the screen they are on; when both are idle and at least 18 seconds have passed since their last interaction, watch them turn their heads. Feibi looks first and Nuonuo a little later; this behavior does not change the window's position/size. A maximized foreground window can also be watched, but all windows that already exist at startup should not fire a burst of events.
5. Observe autonomously for 3–5 minutes; walking apart, meeting, idling and window changes correspond to different triggers; the same behavior should not repeat within seconds. In Quiet Mode none of the four should start; the existing priorities of feeding when hungry, sleeping together when sleepy and the deletion relay are kept.
6. During ball play, drag one of them, delete a newly created temporary file, adjust the size, turn off coexistence or actively make mischief; the action should end, the ball disappears, and both return to normal. When they stand on the same wide window ledge, moving/minimizing the ledge should end it safely, without sliding away in mid-air. When a manual scene is refused, report the PairLifeUnavailable reason and time from the log.

### v1.2.3 coexistence life and relay retest

1. Fully exit the old version, start the new official package, turn on "Both Pets Together", turn off Quiet Mode, and keep both on the same monitor. After about 12 seconds the first invitation is attempted; ordinary walking can also accept invitations, without waiting for both to stand still at the same time. When busy attacking or being dragged it is delayed, retrying every 2 seconds.
2. Watch for two or three minutes without opening the menu: you should see autonomous cheek pinching, treat tossing or sleeping together; after each one ends they stay together for a moment before going their separate ways. At high sleepiness sleeping together comes first, and in normal mode at high hunger feeding comes first. It is not a fixed forced interruption of the current action every few tens of seconds.
3. Create a recoverable test shortcut and delete it while Feibi is walking: both should set off together, Feibi kicks and Nuonuo catches with her mouth open. Repeat in the first column of the desktop and at the right and bottom edges; while waiting and running over, the icon/text should stay in place, and only small sliding is allowed once they are in position and winding up.
4. Delete a test icon while Feibi is falling or asleep: it waits at most 5 seconds and relays if she becomes ready, otherwise Nuonuo eats it alone. Do not drag her around to force a relay. Select 3 temporary files and delete them together, and check that they are handled in turn, without piled-up icons or eating the same one twice.
5. When Feibi already has a test window without unsaved content in her hat, check the two-person interactions and the deletion relay again; the original window should stay in the hat until you return it yourself. During an interaction, right-clicking "Give the Windows Back" or "Make Mischief Now" should first end the two-person scene safely, never running two timelines at once.
6. Operate from either character's right-click, and test again after swapping the main character; crossing monitors, turning off coexistence, changing size and drag interruptions must not get stuck. When it falls back to a single pet, providing the `PairIconKickSkipped/Waiting/Ended` logs for that time range is enough to see why.

Turn on "Both Pets Together" and the deletion response, put a **recoverable test shortcut** in the middle of the desktop and delete it: Feibi should run to its right, and the icon and text first stay in place; while Feibi winds up, the icon may drop slightly; at the moment of the kick the text fades out, the icon flies into Nuonuo's open mouth, and only then does she chew. Then put the test shortcut in the leftmost column of the desktop and confirm the icon hits the left screen edge and bounces into Nuonuo's mouth on the right. Select three test shortcuts at once and delete them, confirming each icon appears only once, they are handled in order, and the hunger statistics increase only three times. Finally, try lifting either pet before the kick, and splitting the two pets onto different monitors; the former should restore the fake icon in place and return it to the queue, and the latter should use Nuonuo's original single-pet slurp. Do not test with important files.

If there is a problem, providing the `activity.log` excerpt containing `PairIconKickStarted`, `PairIconKickImpact`, `PairIconKickEnded` or `PairIconKickSkipped` and a screen recording is enough. This feature has so far only been tested in the background; the desktop pet was not started for you for foreground acceptance.

## 8. Information to provide when you find a problem

Please note:

1. which of the steps above failed and with which character, and whether you had just switched characters;
2. a screen recording containing the complete action, not just a screenshot of the end;
3. monitor resolution, scaling and the arrangement of the primary and secondary screens;
4. the output of the commands below:

```powershell
Get-Content "$env:LOCALAPPDATA\SoftMochiPet\activity.log" -Tail 80
Get-Content "$env:APPDATA\SoftMochiPet\life-state.json"
```

If the problem happens with batch deletion or being tossed from a window edge, extend the log range to 200 lines so it includes the selection snapshot and the whole rise and fall:

```powershell
Get-Content "$env:LOCALAPPDATA\SoftMochiPet\activity.log" -Tail 200
```

This makes it possible to tell whether it is an animation asset, coordinate conversion, window terrain, deletion capture or state machine problem.
