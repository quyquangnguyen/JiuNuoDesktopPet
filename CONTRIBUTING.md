# Contributing guide

For the current noncommercial license, asset rights and public-release status, see [Release readiness](docs/RELEASE_READINESS.md). Before contributing, make sure you hold the relevant rights and agree that your code is distributed under this project's license; do not submit private credentials, raw logs or unlicensed assets.

Thank you for your interest in Nuonuo Desktop Pet. The project depends heavily on the Windows desktop environment; clear reproduction conditions usually help locate a problem far more than a one-liner like "can't drag it".

## Reporting bugs

When opening an issue, please include as much of the following as possible:

- Windows version and system architecture;
- number of monitors, their arrangement, resolution and scaling;
- which side the taskbar is on and whether it auto-hides;
- repeatable steps, the expected result and the actual result;
- the approximate time the problem occurred;
- a sanitized `%LOCALAPPDATA%\SoftMochiPet\activity.log`.

Since v1.3.2, paths, display names and window titles in the log use per-session correlation IDs, and raw exception messages are not recorded; logs from older versions may still contain personal content. Before uploading anything publicly, still review logs, screenshots and screen recordings, especially third-party window content. See [Privacy and public boundaries](docs/PRIVACY.md) for the rules.

## Submitting code

1. Create a single-purpose branch from the latest `main`;
2. keep the scope of changes clear, and do not mix in build outputs or unrelated files;
3. add regression tests for logic that can be verified deterministically;
4. run the Release build and the logic tests;
5. for changes involving windows, the mouse, monitors or Explorer, complete the relevant hands-on steps in `SELF_TEST.md`;
6. in the pull request, explain the reason, the implementation, the verification environment and any remaining risks.

Recommended commands:

```powershell
.\build.ps1
dotnet run --project .\tests\SoftMochiPet.LogicTests\SoftMochiPet.LogicTests.csproj -c Release
```

## Code conventions

- Keep nullable reference type checking enabled;
- prefer putting pure computation in `Core` or in testable services;
- clearly distinguish physical pixels from WPF DIPs in Win32 coordinates;
- add structured diagnostic events when introducing new state transitions;
- do not silently swallow exceptions that affect user operations;
- do not read file contents, and do not add networking or telemetry that has not been explicitly described.

## Do not commit

- `bin`, `obj`, `dist` and temporary test folders;
- local settings, life state and logs;
- test samples containing personal paths, user names or private data;
- third-party content whose license has not been confirmed;
- IDE user configuration that is only valid on your machine.

## License notes

The code is licensed under [PolyForm Noncommercial 1.0.0](LICENSE); see [NOTICE](NOTICE) for its scope. When contributing, you must hold the relevant rights and agree that the contributed code is distributed under this project's license; third-party content must keep its original license and attribution. For character assets, see also [ASSET_RIGHTS.md](ASSET_RIGHTS.md).
