# Privacy and public boundaries

For the current noncommercial license, asset rights and public-release status, see [Release readiness](RELEASE_READINESS.md). Before contributing, make sure you hold the relevant rights and agree that your code is distributed under this project's license; do not submit private credentials, raw logs or unlicensed assets.

## Adopted rules

As of 2026-09-30, for source code, production records, runtime assets and official release packages: the project maintainer's public attribution uses only **桃天帝不差 / nicedoctors**. Commits use a GitHub noreply address and no private e-mail is made public; it is not a contact address. Third-party licenses, author attributions and source notices are never removed as part of the maintainer's privacy cleanup.

Private disk locations, account credentials, debug logs and user configuration are not public material. Asset records use relative paths and checksums. Public images have descriptions, generation-source wrappers and comments removed while pixels, transparency, color and animation data are kept; recordings have descriptive container fields removed while PCM data, duration and the existing loudness compensation are kept. Original material that may need restoring stays in a restricted backup outside the project and must not be uploaded or put into shared packages.

Released program version numbers do not automatically append the local Git commit ID, so build outputs do not expose history object identifiers. Which source matches a version is maintained through release tags.

Paths, file display names and window titles in the log are replaced with per-session HMAC correlation IDs, and the random key is never persisted. Events, states, window handles, coordinates, DPI, error types, error codes and call sites without source paths are kept to keep supporting troubleshooting. Raw exception messages are not written to the log. This rule does not change user settings needed at runtime or the user's real file names.

## Verification and maintenance

Since 2026-10-05, test screenshots of the real desktop, crops and composites never go into the public source or release material; they are all written to the ignored `test_artifacts/`. The paths of removed historical screenshots were also added to the ignore rules. Public demonstrations use an isolated test background; before release, the picture content of every new or modified media file is checked manually, and animated images must be checked through their full animation. Metadata and text scans cannot replace this check.

`python -X utf8 tools/public_privacy.py` checks every Git-tracked file and every non-ignored file awaiting publication; the report lists only relative file names and issue categories and never echoes the matched content. This tool is a release check for the media formats the project currently has; it is not a general secret detector and cannot recognize image content, recording content or every form of credential.

`python -X utf8 -m unittest discover -s tests -p test_public_privacy.py` checks that metadata removal does not change pixels, transparency or audio data. Production asset cleanup compares the decoded pixels or audio data file by file and updates the corresponding file hashes; the related programs are maintained by the project maintainer.

History rewriting uses [git-filter-repo](https://github.com/newren/git-filter-repo) 2.47.0 under its MIT license; the tool is used as is and is not distributed with the desktop pet. The process follows [GitHub's guide to removing sensitive data](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/removing-sensitive-data-from-a-repository). Back up before rewriting, process all public branches and tags, and update the remote with a lease check against the specified old values to avoid overwriting concurrent updates.

Rewriting cannot take back other people's clones, downloaded files, third-party caches or copies kept internally by the platform. Existing collaborators should re-clone and must not merge or push the old history. If old commit caches and read-only references on the server are still accessible, the repository owner needs to contact GitHub Support; no promise of absolute anonymity is made on this basis.

## 2026-09-30 cleanup record

The following record covers only the branches, tags and release packages processed at the time. A later review found that old PR references and hosted caches could still retain pre-rewrite objects, so it cannot be concluded from this that the original repository is safe to make public. For the current decision and progress, see [Release readiness](RELEASE_READINESS.md).

- Metadata cleanup of the current source and cover outputs is complete: 77 images and 46 recordings; decoded pixels or audio data were compared one by one and are unchanged, and file hashes were updated accordingly.
- The basic scan of files awaiting publication found none of the checked personal paths, private e-mail addresses or common credential patterns.
- A zero-warning build, 217 headless silent logic regression tests and 2 metadata tests passed; the desktop pet was not started and no sound was played.
- With the user's authorization, the history of all remote branches and existing tags was rewritten and the remote references were checked; the maintainer's commit attribution is `nicedoctors` with a GitHub noreply e-mail. The repository remained private, and no change to open-source visibility was made.
- The [v1.3.2 official package](https://github.com/nicedoctors/NuonuoDesktopPet/releases/tag/v1.3.2) was published as Latest, and its server size and SHA-256 match the local copy. The ZIP is 175,374,749 bytes with SHA-256 `e6473c2cf88bba2f87efa127a2e420fc9743329b9f65edfb0035ffe8b49ccdaa`.
- The old v1.0.0 and v1.3.1 download attachments were taken down after a verified restricted backup; the release notes are kept and point to the new package. The Behavior Control Edition was not updated; old local packages, historical production caches and old Git metadata were moved to a restricted backup outside the project and are not distributed with the repository or the new package. The project's `dist` keeps only the current official folder and ZIP.
- Pending for the repository owner: on 2026-09-30 it was confirmed that old commits are still reachable on GitHub by their original commit IDs. Rewriting branches cannot delete old objects retained by the platform; a sensitive-data cache cleanup must be requested from GitHub Support, and whether it is accepted and what is removed is up to the platform's review. This rewrite cannot be treated as physically erasing every platform copy.
