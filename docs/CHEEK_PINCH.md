# Mouse cheek pinching

For status, versions and outstanding hands-on checks, see [Current progress](CHARACTERS.md#current-progress-and-phase-exit-criteria). The two-person "Feibi pinches Nuonuo" is not part of this rework.

## Adopted behavior

2026-09-29: both characters bind a continuous cheek outline, eye compression and a squinting expression, a brief open mouth and teeth to the fixed idle frame 0. When the left button hits a cheek, the cheek stretches with the mouse movement and can be pulled up or down; the maximum horizontal gesture of 105 asset pixels maps to a 64-pixel outline extension, and a vertical gesture of 42 maps to a 26-pixel outline shift. The gradient skin tone, rounded grip point and blush follow the stretched outline. Holding a large outward pull for about 0.28 seconds makes the mouth open and close periodically; the body tilts slightly around its original standing position (at most 3.5°) without changing the window size or overall scale.

On release, it springs back from the current deformation without switching to another full-body animation or cross-fading two bodies. The spring converges with bounded overshoot at 30/60/120 Hz. The original pixels of the head top, hat, clothes and feet are kept, face drawing is confined to a fixed canvas, and an off-screen bitmap is reused at runtime. The left and right cheeks have separate anchors, so the character is never mirrored as a whole just because the right cheek was chosen.

The reference is the "sailor-uniform Yumi" video provided by the user, studying its sideways cheek pull, squinting under the pull, sustained open mouth and rebound rhythm. The implementation is a local vector rig on this project's fixed character art, not the reference game's underlying implementation or arm skeleton; it **must not be labeled a one-to-one recreation**, and the actual feel and cuteness await user acceptance. The effect is driven by continuous parameters, so no new AI sprite frames were added, and no old generated image was fed back into an image model.

## Interaction and maintenance

- A left-button hit on a cheek can interrupt idling, curiosity, sleep or ordinary running; the body and hat still use the original drag flow, and eating targets go back into the queue first. Mischief, climbing, falling and similar actions are not preempted.
- Displacement uses window-local coordinates converted for the current facing, so it does not drift with feedback from the face and body tilt. The gesture is released on losing mouse capture, menus, switching, going home, resizing and display-environment changes.
- `CheekPinchDynamics` maintains the spring and the mouth rhythm; `CheekPinchFrameRenderer` maintains the outlines, expression masks and reuse cache of both character images, and `MainWindow.CheekPinch.cs` handles the mouse and body pose. Maintenance responsibility lies with this project; there is no general animation framework and no new dependency.
- The base images come from each character's `runtime/idle/frame_00.png`. The old `runtime/pinch` and `pinch_right` and their source assets stay in the source code and do not go into the release package. Any later AI art production must still be fully regenerated from each character's `original.png`; generated sheets must never be used as input.

## Acceptance evidence

Background checks cover hits on both sides, the body-drag boundary, rebound at 30/60/120 Hz, preservation of the canvas and non-face pixels, cache reuse and all runtime assets. The preview is output by the actual C# renderer: [pull—hold—release](media/pinch-continuity-v131.gif). It shows the face drawing and does not simulate real input or desktop windows; the desktop pet was not started, the screen was not recorded and no sound was played.

Use [SELF_TEST.md](../SELF_TEST.md#v131-four-fixes-awaiting-user-testing) to accept both characters' left and right cheeks, light/long pulls, vertical dragging, release, reversed facing and different DPI settings.
