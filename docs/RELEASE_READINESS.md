# Release record and follow-ups

This file centrally maintains the v1.3.3 release record, long-term decisions and follow-up items. Character feature acceptance is still maintained in `CHARACTERS.md`; asset rights are maintained only in [ASSET_RIGHTS.md](../ASSET_RIGHTS.md).

## Adopted decisions

- The public source uses PolyForm Noncommercial 1.0.0 to meet the maintainer's requirement of prohibiting commercial use. Third-party code keeps its original licenses, and character assets are managed separately; no claim is made to meet the OSI open-source definition.
- The public repository is [nicedoctors/JiuNuoDesktopPet](https://github.com/nicedoctors/JiuNuoDesktopPet), built with an independent Git root history from the current source snapshot. The original `NuonuoDesktopPet` repository stays private, and its old PR references and hosted caches do not enter the new repository.
- On 2026-10-01, after understanding that asset licensing was still to be confirmed and the risks of the original repository's history, the maintainer explicitly asked for the upload and publication. The source code and the v1.3.3 portable package were released according to this decision; the decision does not supply the missing third-party asset licenses and does not change the boundary of managing code and assets separately.
- The .NET and Windows Desktop runtimes of the self-contained package are pinned to 8.0.31, with the official value maintained in `Directory.Build.props`. That version's original license texts and source hashes are distributed with the package. Upgrading the runtime requires updating the notices and verification records at the same time.
- The launcher prefers the Visual Studio 2022 v143 toolchain. Without it, `LLVM_MINGW_ROOT` can be set explicitly to use LLVM-MinGW; the verified distribution is 20260616 UCRT x64. This fallback only serves the current native launcher, and the project maintainer maintains its compiler options and distribution notices.
- The build scripts can use `DOTNET_EXE`, and the privacy check `PYTHON_EXE`, to point to local tools; by default PATH is used, with no dependency on the maintainer's private folders. The Python image check depends on Pillow.
- Before packaging, the asset privacy and notice integrity checks run; after packaging, the version, bundled runtime, licenses, source assets and ZIP hashes are verified. Automated checks only run headless background tests and never start the desktop pet or play sound.

## Verification and current delivery

Local verification results on 2026-10-01:

- Release built with .NET SDK 8.0.201: 0 warnings, 0 errors; 217 headless logic tests passed. The CI configuration uses 8.0.425; see [GitHub Actions](https://github.com/nicedoctors/JiuNuoDesktopPet/actions) for continuous results.
- 7 Python privacy and license integrity tests passed, including compatibility with temporary-folder path normalization; no leftover descriptive metadata was found in source images and audio, and the text scan found no private maintainer information or covered credential patterns.
- The normal portable package contains 1,402 files, and 1,128 runtime asset files match the source hashes one by one; the launcher and the main program are both version 1.3.3.0, both bundled frameworks are 8.0.31, and the ZIP matches the extracted folder file by file.
- Two broken packages, one missing a license and one carrying an old runtime, were both rejected by the verifier. The launcher was compiled with LLVM-MinGW, and its import table depends only on Windows system components.
- Gitleaks 8.30.1 found nothing in its credential scan of the prepared folder. The independent Git root history stores only this complete source snapshot, with no history objects or PR references from the original repository. The scan only covers its current rules and accessible content and is not an absolute guarantee against every possible secret.

The source code lives in this repository, and the portable package is distributed through the [v1.3.3 Release](https://github.com/nicedoctors/JiuNuoDesktopPet/releases/tag/v1.3.3); the local packaging path is `dist/JiuNuoDesktopPet-Portable.zip`. The package includes this file and the asset rights record, and the attachment SHA-256 is recorded in the release notes and checksum file.

## Follow-ups

A 2026-10-05 review found 11 historical desktop test screenshots, plus their crops and composites, mixed into the source; these files were not part of the portable package. That batch was deleted, and all 3 commits of the public repository were rewritten; both main and the v1.3.3 tag were checked to contain none of these images, and both references were updated atomically through the GitHub API with old-value comparison. Media content checks and the storage rules for test screenshots are maintained centrally in [Privacy and public boundaries](PRIVACY.md). Image links on the current branch now return 404, but the image objects for the old commit IDs are still reachable and need further cleanup by GitHub Support; no support request has been filed yet. The repository was checked to have no PRs, forks or Actions artifacts. The 7 Python checks pass, and the privacy scan of the current files found none of the covered problems. The portable package checksums did not change.

1. Complete the license review in the [asset rights record](../ASSET_RIGHTS.md). Source attribution, self-made sprite frames and the commercial-use prohibition cannot replace upstream licenses.
2. The original repository stays private. If the original URL is ever made public, first have GitHub Support handle the old PR references, caches and objects that a normal push cannot delete, then review the publicly visible content again. No message has been sent to GitHub Support or the artists yet.
3. The user performs acceptance of the real desktop interactions with `SELF_TEST.md`; this maintenance does not change character behavior, and automated verification does not stand in for manual visual and audio acceptance.
4. .NET 8 reaches end of support on 2026-11-10, and the maintainer must plan a migration to a supported runtime before then. Reference: [Microsoft support policy](https://dotnet.microsoft.com/en-us/platform/support/policy).

Acceptance criteria for this release: the independent source, license and documentation agree, the background tests and the full packaging verification pass, the remote source and attachment checksums match, and the original repository stays private. The asset license review stays in the follow-up items and is not marked as done.
