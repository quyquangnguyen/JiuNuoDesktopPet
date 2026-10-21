# JiuNuo Desktop Pet

A WPF desktop pet that lives on your Windows windows and taskbar: Nuonuo treats files in the Recycle Bin as food, and Feibi Jiubi treats windows as toys.

> [!NOTE]
> The official product name is "JiuNuo Desktop Pet", featuring two characters, Nuonuo and Feibi Jiubi. Official releases are self-contained, portable Windows x64 folders that run as soon as they are fully extracted; for hands-on acceptance status see [Characters](docs/CHARACTERS.md#current-progress-and-phase-exit-criteria).

## License and assets

Code the maintainer holds rights to is licensed under [PolyForm Noncommercial 1.0.0](LICENSE), which permits noncommercial use, modification and redistribution within its terms; commercial use is not licensed. The project describes itself as "source-available, noncommercial use". See [NOTICE](NOTICE) for its scope.

Character and asset sources, production contributions and licenses still to be confirmed are listed in [ASSET_RIGHTS.md](ASSET_RIGHTS.md). The assets do not automatically fall under the code license, and publishing the project does not mean redistribution rights have been obtained from the upstream characters' owners or the artists.

## About the project

Nuonuo is not a widget pinned to a corner of the screen. She treats your real desktop as her playground: she walks on the taskbar and on application windows, falls off window edges, gets knocked flying by fast-moving windows, can be put inside a window where she sways and bounces off its walls, and chooses what to do on her own based on hunger, sleepiness and curiosity.

When a file goes into the Recycle Bin the usual way, Nuonuo remembers where the original desktop item was and runs over to eat it. The whole process uses only file-system events and the necessary system metadata; it never reads file contents and never deletes files on the user's behalf.

## Highlights

- **Character choice and coexistence**: switch between Nuonuo and the lively Feibi Jiubi, or enable "Both Pets Together" to show both at once; animations, recordings and progress saves stay separate, while size, mute, Quiet Mode and the optional speech bubbles (off by default) are shared. For asset and acceptance status, see [Characters](docs/CHARACTERS.md).
- **Feibi's window mischief**: she kicks, punches and charges windows and collects them in her hat; with a full mischief bar she throws her hat and shatters or tears a window snapshot, then stashes the shards or two torn halves in her hat. Windows are never restored on a timer; the user returns them with the right-click "Give the Windows Back". Attacks no longer add an extra crouch or reach at the end, and the special move is slowed down so the charge-up, destruction and stashing are easy to see. For hands-on acceptance status, see [Characters](docs/CHARACTERS.md#current-progress-and-phase-exit-criteria). Feibi does not eat or lick icons and has no hunger bar.
- **Desktop physics**: the top edges of application windows, the taskbar and the monitor work area can all become terrain to walk or land on.
- **Solid window collisions**: the left and right edges of ordinary windows can knock Nuonuo flying; put her inside a window and its walls form an enclosure that can be shaken.
- **Dragging with inertia**: gentle drops, sideways flings, upward tosses and diagonal throws produce different release speeds, gravity and soft-bounce effects.
- **Autonomous life state**: Nuonuo tracks hunger, fullness, sleepiness and curiosity; Feibi tracks sleepiness, curiosity and her own mischief state, and does not build up mischief while offline.
- **Adjustable character size**: the tray menu has a live 60%–200% size slider, and scaling keeps the foot anchor and collision proportions consistent.
- **Optional life modes**: Nuonuo can use Fasting Mode, both characters share Quiet Mode and Infinite Mode; Feibi's autonomous mischief is on by default and can be turned off in the menu.
- **Startup option**: optionally start when the current Windows user signs in, with no administrator rights needed.
- **Recycle Bin eating**: recognizes where a desktop item was before deletion, and supports queuing and batching consecutive deletions.
- **Multi-monitor support**: supports monitors at negative coordinates, windows spanning screens, work-area changes and Per-Monitor DPI.
- **Local first**: it never goes online at runtime, never uploads logs or screenshots, never reads file contents and never deletes files itself; window-effect snapshots are kept only briefly in memory.

For the full set of capabilities, behavior boundaries and current limitations, see [Features](docs/FEATURES.md).

## Requirements

| Scenario | Requirements |
| --- | --- |
| Run a packaged release | Windows 10/11 x64 |
| Run from source | Windows 10/11 x64, .NET 8 SDK |
| Build the full portable package | The above, Python/Pillow, plus the Visual Studio 2022 C++ components or an explicitly specified LLVM-MinGW; see the development guide |

The project targets Windows only. Transparent windows, the tray menu, desktop item location and window terrain depend on Win32/WPF, so macOS and Linux are not supported for now.

## Quick start

### Download the Portable Edition

The current version is **v1.3.3**, which adds the noncommercial code license, asset-source documentation and third-party notices, pins the bundled .NET/Windows Desktop to 8.0.31, and strengthens the packaging checks. Character features are unchanged. For the release decision, verification results and follow-ups, see the [release record](docs/RELEASE_READINESS.md).

Download the ZIP labeled "JiuNuoDesktopPet-Portable" from [GitHub Releases](https://github.com/nicedoctors/JiuNuoDesktopPet/releases/latest), extract it completely, and run `JiuNuoDesktopPet.exe` in the root folder. The public source code lives in this repository with its own history; it does not include old commits or PR references from the original private repository.

### Run from source

```powershell
git clone https://github.com/nicedoctors/JiuNuoDesktopPet.git
cd JiuNuoDesktopPet
.\run.ps1
```

You can also use the .NET CLI directly:

```powershell
dotnet run --project .\src\SoftMochiPet\SoftMochiPet.csproj -c Release
```

### Build the portable package

```powershell
.\package.ps1
```

When it finishes, it produces:

```text
dist\JiuNuoDesktopPet-Portable\
dist\JiuNuoDesktopPet-Portable.zip
```

Fully extract the ZIP, then double-click `JiuNuoDesktopPet.exe` in the root folder. The release package root has only this one launcher; the `app` subfolder contains everything the program needs to run and must not be moved apart from the launcher. The exclusive test launcher is kept only in the source code and development builds and is not shipped in the release package.

For more build commands and packaging notes, see the [development guide](docs/DEVELOPMENT.md).

### Feibi's standalone Exclusive Feature Test

The exclusive test launcher is only for development builds and is not included in the official portable package. If you need to run it, build the test launcher from source or use a separate development test folder; the release package only provides the everyday desktop pet launcher.

## Basic controls

| Action | Effect |
| --- | --- |
| Hold the left button on Nuonuo and move | Drag her; autonomous roaming pauses immediately |
| Release the left button slowly | Gently set her down; she then drops to the nearest usable terrain |
| Release the left button quickly | Fling or toss her using the gesture's final speed |
| Put Nuonuo inside an ordinary window | She enters an enclosure and collides and bounces off the window walls; a deletion event makes her run out to eat |
| Move an ordinary window sideways into her | She flies off in the direction of the impact |
| Right-click Nuonuo | Opens the same menu as the tray icon |
| Menu "Pet Character" | Choose Nuonuo or Feibi Jiubi; switching is delayed while she is being dragged or eating |
| Menu "Both Pets Together" | Show both at once; click again to go back to a single pet, and choosing "Pet Character" also returns to single-pet mode |
| Menu "Infinite Mode" | Hides both progress bars above their heads and pauses Nuonuo's hunger behavior; Feibi keeps making mischief at her usual pace |
| Drag the character size slider in the menu | Scales instantly within 60%–200% and saves automatically |
| Tray menu "Start with Windows" | Turns starting when the current Windows user signs in on or off |
| Nuonuo's menu "Fasting Mode" | Hides the hunger bar, resets hunger to zero, and stops begging for food, licking icons and rolling from hunger; Feibi has no such option |
| Feibi's menu "Allow Autonomous Mischief" | A persistent switch, on by default; if your old settings version was 4 or earlier, the upgrade turns it on once, and your manual choice is kept afterwards. Both autonomous and manual mode may act on any compatible foreground window that is not maximized or full screen, not only ordinary windows |
| Feibi's menu "Make Mischief Now" / "Tease Her" | Try the window gameplay yourself / raise the mischief bar; used once the full asset set is ready |
| Feibi's menu "Give the Windows Back" | Restores a window held in the hat, shattered or torn; it is never returned on a timer |
| Tray menu "Quiet Mode" | Stops autonomous walking, eating and mischief, leaving only idling or sleeping; stashed windows stay held and can still be restored with a right-click |
| Double-click the tray icon | Brings Nuonuo back to the currently visible work area |
| Tray menu "Mute" | Turns character voices off or back on immediately |
| Tray menu "Exit Desktop Pet" | Saves the life state and exits |

After a normal delete sends an item to the Recycle Bin, Nuonuo goes to eat it if the original desktop position was captured. If watching fails, the file itself is unaffected, and the system's delete flow is never intercepted or changed.

While a window is being held, Quiet Mode, going home, resizing and dragging across screens do not restore it on their own. Switching characters, exiting, locking the screen, sleeping the PC, or a real change in display layout or work area returns it safely so no window is left behind; this differs from everyday timed automatic restoring.

## Development and testing

```powershell
# Release build
.\build.ps1

# Run the headless logic tests
dotnet run --project .\tests\SoftMochiPet.LogicTests\SoftMochiPet.LogicTests.csproj -c Release

# Produce the self-contained Windows x64 folder build
.\publish.ps1

```

The logic tests cover physics, size, roaming, Nuonuo's eating, character isolation, mischief cooldowns and animation events; the production asset checks truly decode every required frame of each character and verify real contact points, hat masks and hashes. For current acceptance results see [Character progress](docs/CHARACTERS.md#current-progress-and-phase-exit-criteria); effects involving external windows, Explorer, visuals and mixed DPI are verified by the user with the [manual checklist](SELF_TEST.md).

## Project structure

```text
NuonuoDesktopPet/
├─ src/SoftMochiPet/              WPF main program
│  ├─ Core/                       State machines, physics and behavior policies
│  ├─ Interop/                    Win32 interop declarations
│  ├─ Models/                     Settings and life state
│  └─ Services/                   Desktop, logging, sound and file-watching services
├─ tests/SoftMochiPet.LogicTests/ Headless logic tests
├─ launcher/                      Native launcher for the portable package
├─ packaging/                     Portable-edition instruction files
├─ docs/                          Feature and development docs
└─ *.ps1                          Build, run and publish scripts
```

## Data, logs and privacy

JiuNuo Desktop Pet stores runtime data only in the current Windows user's folders:

| Content | Path |
| --- | --- |
| Settings | `%APPDATA%\SoftMochiPet\settings.json` |
| Life state | `%APPDATA%\SoftMochiPet\life-state.json` |
| Feibi's character data | See [Character data boundaries](docs/CHARACTERS.md#characters-and-data-boundaries); her life and mischief state are saved separately |
| Diagnostic log | `%LOCALAPPDATA%\SoftMochiPet\activity.log` |
| Previous rotated log | `%LOCALAPPDATA%\SoftMochiPet\activity.previous.log` |

"Start with Windows" uses the current user's `HKCU\Software\Microsoft\Windows\CurrentVersion\Run` entry; turning the option off removes that entry.

### Official rename and legacy compatibility

The product name and window/tray titles are "JiuNuo Desktop Pet", and the released EXE and DLL are named `JiuNuoDesktopPet`; the characters are still called "Nuonuo" and "Feibi Jiubi". To keep reading existing settings and both characters' save data, the `SoftMochiPet` data/log folder, internal namespaces, the single-instance mutex and activation event, and the Windows Run value name are all kept. No separate new-brand save data or startup entry is created, and the original images and character IDs are not renamed; the voice recordings were given English file names as part of the English translation, with the same audio content.

When upgrading, exit the old version first, then extract the complete package to a new folder; do not replace only the EXE or mix old and new "app" folders. An old version's startup command is never changed silently; to have the new version start with Windows, re-check "Start with Windows" in the new version's menu, and the existing Run value is updated to the new launcher. The repository URL and source project file names stay the same, which does not mean the release files still use the old brand.

The log rotates at 8 MB and records behavior states, window terrain, monitor parameters and event correlation IDs. Since v1.3.2 it no longer writes full file paths, file display names or window titles; exceptions keep their type, error code and call site, and raw exception messages are not saved. Logs, screenshots and screen recordings from older versions still need a manual check before being made public. For public attribution, asset metadata and historical handling rules, see [Privacy and public boundaries](docs/PRIVACY.md).

## Known limitations

- The current release packages have no Authenticode signature, so Windows may show "Unknown publisher".
- Locating desktop items depends on Windows Explorer's current implementation; restarting Explorer, third-party desktop managers or non-standard delete flows may keep the eating interaction from triggering.
- Mixed DPI, monitor hot-plugging and unusual taskbar layouts are handled, but remain areas of focused testing.
- The repository does not yet provide an automatic updater and never checks for versions in the background.

When you run into a problem, please attach your Windows version, monitor layout and scaling, the steps to reproduce, and a sanitized `activity.log`. See the [contributing guide](CONTRIBUTING.md) for the detailed format.

## Contributing

Bug reports, reproduction logs and suggestions are welcome. Before submitting code, please read [CONTRIBUTING.md](CONTRIBUTING.md) and make sure the logic tests pass; do not commit `dist`, `bin`, `obj`, temporary logs or data containing personal paths.

## License

For the code license and asset scope, see [License and assets](#license-and-assets) on this page. When distributing, you must keep [LICENSE](LICENSE), [NOTICE](NOTICE) and the applicable third-party notices; for asset licensing status, see [ASSET_RIGHTS.md](ASSET_RIGHTS.md).
