# Development guide

## Maintaining the source and release packages

GitHub filters non-ASCII attachment file names, so release attachments are named `JiuNuoDesktopPet-<version>-win-x64.zip` and given a display label. The local ZIP, the extracted folder, the product name and the launcher EXE use the same name, `JiuNuoDesktopPet`; the attachment content does not change because of the upload name.

The conditions for publishing source code and resources are defined by [Release readiness](RELEASE_READINESS.md) and [Asset rights](../ASSET_RIGHTS.md). Once confirmed, the source code and the licensed character runtime resources are committed to `main` of the chosen repository, the portable ZIP is attached to a GitHub Release, and the bundled .NET runtime is never committed to Git. The repository's visibility does not change with a release. Original images, generated source images, final prompts, selected assets and processing hashes are kept; generation service addresses, configuration IDs, job states, plan copies and local credentials are not part of what is committed. Final generation receipts keep only the original image/prompt/output hashes, model, size and provenance-chain fields, enough for offline re-slicing verification; derived `keyframes` are not committed and are produced with the existing processing tools. The project maintainer is responsible for checking that the source code, attachment checksums and release tags match.

## Tech stack

- .NET 8
- WPF
- Win32 P/Invoke
- Windows Forms `NotifyIcon` (only for the tray icon and menu)
- PowerShell build and packaging scripts
- Native C x64 portable launcher

## Setting up

Basic development only needs Windows 10/11 x64 and the .NET 8 SDK:

```powershell
dotnet --info
dotnet restore .\SoftMochiPet.sln
```

Building the full portable package also needs Python 3.12+ and Pillow (`python -m pip install Pillow==12.3.0`) for the pre-packaging privacy check. The launcher uses the Visual Studio 2022 / Build Tools C++ desktop development components (v143), or set `LLVM_MINGW_ROOT` to an LLVM-MinGW 20260616 UCRT x64 distribution folder. For tool sources and maintenance scope, see [Release readiness](RELEASE_READINESS.md). `DOTNET_EXE` and `PYTHON_EXE` can point to local tool paths; when unset, PATH is used.

## Common commands

### Run

```powershell
.\run.ps1
```

`run.ps1` first builds the current source in the Release x64 configuration, then starts the matching EXE; it never accidentally starts an outdated old release from `dist`. To run the official portable folder, run `JiuNuoDesktopPet.exe` in its root folder separately.

### Build

```powershell
.\build.ps1
```

The equivalent core command is:

```powershell
dotnet build .\SoftMochiPet.sln -c Release -p:Platform=x64
```

### Test

```powershell
dotnet run --project .\tests\SoftMochiPet.LogicTests\SoftMochiPet.LogicTests.csproj -c Release
```

The test project is a headless test runner, suited to verifying deterministic state machines, physics and queue logic. WPF window interaction, mouse capture, Explorer and monitor switching must additionally go through the hands-on checks in `SELF_TEST.md`.

### Publish the folder build

```powershell
.\publish.ps1
```

The output goes to `dist\JiuNuoDesktopPet`, and the main program is `JiuNuoDesktopPet.exe`. This is a self-contained Windows x64 folder that includes the .NET runtime, so the target PC does not need .NET preinstalled.

### Build the portable package

```powershell
.\package.ps1
```

The script:

1. publishes the self-contained WPF main program into the `app` subfolder;
2. compiles `JiuNuoDesktopPet.exe`, the only normal launcher in the root folder;
3. copies the edition's instructions, the code license, the asset rights record and the third-party notices;
4. produces two official outputs without test tools: a folder and a ZIP.

Output paths:

```text
dist\JiuNuoDesktopPet-Portable\
dist\JiuNuoDesktopPet-Portable.zip
```

If the Visual C++ toolchain is not installed, the script reuses the cached launcher only when the one for the selected mode exists and its timestamp is not older than the launcher sources and program resources. The exclusive test launcher can still use a separate `FeatureTest` intermediate build folder in development builds, but never goes into the release package. A fresh clone usually has no such cache, so it needs the Visual C++ Build Tools or an explicitly configured LLVM-MinGW.

The product name, the published assembly and the launcher are unified as `JiuNuoDesktopPet`; the source project name and existing data identifiers are unchanged. The compatibility boundaries and the upgrade note for starting with Windows are defined in [Official rename and legacy compatibility](../README.md#official-rename-and-legacy-compatibility).

## Code structure

| Folder | Responsibility |
| --- | --- |
| `src/SoftMochiPet/Core` | Behavior policies, drag velocity, window climbing, queues and pure logic |
| `src/SoftMochiPet/Interop` | Win32 constants, structs and P/Invoke declarations |
| `src/SoftMochiPet/Models` | Settings, deletion events and long-term life state |
| `src/SoftMochiPet/Services` | Monitor geometry, window terrain, file watching, logging, sound and tray services |
| `src/SoftMochiPet/MainWindow.xaml.cs` | WPF lifecycle, state machine orchestration and user interaction |
| `tests/SoftMochiPet.LogicTests` | Headless regression tests |
| `launcher` | Outermost native launcher of the portable edition |

When adding behavior that can be verified deterministically, prefer putting the computation and decisions in `Core` or a separate service and have the window layer call it. This avoids tying all logic to the WPF Dispatcher and makes it easy to run tests without a desktop session.

## Local data

| Data | Path |
| --- | --- |
| Settings | `%APPDATA%\SoftMochiPet\settings.json` |
| Life state | `%APPDATA%\SoftMochiPet\life-state.json` |
| Current log | `%LOCALAPPDATA%\SoftMochiPet\activity.log` |
| Previous log | `%LOCALAPPDATA%\SoftMochiPet\activity.previous.log` |

When debugging state migration, you can exit the app first and then back up or move the life-state file. Do not edit that file while the app is running; the exit flow may overwrite manual changes.

## Troubleshooting with the log

`activity.log` is structured text with time, PID and event fields. Suggested order for locating a problem:

1. find the latest `PetLoaded` and confirm it belongs to the current process;
2. check the monitor list, DPI, work areas and pet size;
3. follow `StateTransition` to see states and the purpose of each action;
4. for drag problems, check `DragStarted`, the release velocity and landing events;
5. for deletion problems, check the watch source, the position snapshot, `QueueId` and the eating-finished event;
6. finally search for exceptions, capture failures or service-stopped records.

The current log redacts external paths and file names; logs from older versions, external tool output and newly added fields still need a manual check. Never attach a complete local log directly to a public issue.

## What not to commit

```text
bin/
obj/
dist/
.codex-temp/
artifacts/
test_artifacts/
tmp/
```

Also, do not commit local settings, life state, logs, IDE user configuration or test data containing personal paths.

## Release checks

`.github/workflows/verify.yml` runs the build, the headless tests, the privacy and credential scans, and the full packaging verification on Windows 2022; it does not upload or publish release packages. It uses [actions/checkout](https://github.com/actions/checkout) v6, [actions/setup-dotnet](https://github.com/actions/setup-dotnet) v5 and [actions/setup-python](https://github.com/actions/setup-python) v6 (all MIT), pinned to the commits shown in the workflow. The image tooling uses [Pillow 12.3.0](https://pypi.org/project/pillow/12.3.0/) (MIT-CMU), and the credential scan uses [Gitleaks 8.30.1](https://github.com/gitleaks/gitleaks/releases/tag/v8.30.1) (MIT, with the download checksum pinned in the workflow). These tools are not modified locally and are not shipped with the desktop pet. Original license texts keep their original bytes through `.gitattributes`, so different Git line-ending settings cannot break the source hashes.

`package.ps1` stages the self-contained runtime folder and ZIP in `dist/.package-<unique-id>`, calls `tools/verify_portable_package.ps1` to check the x64 GUI entry point, the launcher/main program versions, the bundled .NET/WPF, character frame completeness, source asset hashes and the hash of every file in the ZIP, and only after that succeeds moves the previous official package into `dist/previous-releases` and replaces the official path. If compilation or verification fails, the previous official package is kept and the staging folder is left for investigation. This flow only serves the current portable release; the project maintainer keeps the frame-folder counts in line with the character asset contract. The Behavior Control Edition is only updated when the corresponding parameter is passed explicitly.

Before preparing a distributable version:

1. run the Release build and all logic tests;
2. complete the offline checks silently in the background; hands-on desktop, window and sound acceptance is done by the user with `SELF_TEST.md`, recording the scope of each verification separately;
3. run `package.ps1` and extract the result into a fresh folder;
4. hand over the root-folder launcher so the user can start it personally to confirm real behavior and feel;
5. check that the ZIP contains no logs, settings, life state or development-machine paths;
6. if you have a code-signing certificate, sign the executables before creating the ZIP;
7. record the version number, the commit SHA and the SHA-256 checksum.
