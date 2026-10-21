# Local version sync record

This page keeps the version and release paths as they were at the time of syncing; for the current "JiuNuo Desktop Pet" release name, paths and compatibility decisions, see [Official rename notes](../README.md#official-rename-and-legacy-compatibility).

## 2026-09-07

- Source: the `main` branch of the GitHub repository `nicedoctors/NuonuoDesktopPet`.
- Version: `df33a256da1175ab76db15501a3669f1bb60f6ab` (the corresponding commit after the privacy cleanup), commit date 2026-09-05.
- Decision and scope: the local source and the Windows x64 release outputs are based on this remote version; the local `main` tracks `origin/main`, and the remote fetch rules cover all branches.
- Rationale: this version provides "Fasting Mode (Never Hungry)", which hides the hunger bar and keeps the hunger value at 0 when enabled, and also includes the size slider, Quiet Mode and the new idle assets.
- How local changes were kept: tracked changes and untracked files from before the sync were archived in a restricted private backup outside the project and are not distributed with the public history. The current source uses the remote implementation; the backup is available for the maintainer to look up as needed.
- Release scope: `dist/NuonuoDesktopPet-Portable`, the matching ZIP, and `dist/NuonuoDesktopPet` used by `run.ps1`.
- Verification status: the Release build passed; 65 headless logic tests passed, covering Fasting Mode and the hunger display policy. Desktop interaction is accepted manually by the user with `SELF_TEST.md`.
- Maintenance: for later syncs, the project maintainer checks the remote commit and the target features, and updates the version rationale in this record.
