# Two-pet daily interactions

## Current delivery and exit criteria

Adopted 2026-09-28: added Little Tagalong, Nuzzle in Passing, Play Ball Together and Watch the Fun Together, reusing the existing two-window coordination, running, hat removal and interruption cleanup. Nuonuo follows her partner, not the mouse; the nuzzle is triggered by meeting up close; the ball is drawn separately and synchronized with the kicking frames; watching the fun only observes window position changes and never reads content or operates the target window. Quiet Mode does not start these four interactions. Eating icons, dragging and active window mischief take priority.

Exit criteria: the four manual entries and autonomous triggering are wired in; the six character sequences generated directly from the original images are cropped and anchor-checked; trajectories, cooldowns, interruption cleanup and assets are verified silently in the background; off-screen previews and the official portable package are generated. The actual look on the desktop is tested by the user, and the app is not opened automatically.

This serves only this project's two characters and is maintained by this project, with no new general behavior framework. Everything reused comes from the project's existing code and original assets, with no new external runtime dependency. Generated images must not be used as later model input; the selected original sheets and hashes follow pair-sprite-manifest.json.

## Triggers and presentation in place

| Interaction | Autonomous condition (the shared busy/same-screen/same-ground checks must also pass) | Presentation and cooldown |
| --- | --- | --- |
| Little Tagalong | Feibi is walking normally and moving away from Nuonuo, with a horizontal foot distance of 1.3–4 times the character window width | Nuonuo starts 0.8 seconds later, and Feibi pauses midway to look back; about 8.2 seconds. If Feibi is already at an edge she stops and waits instead of walking in place; separate cooldown of 65 seconds |
| Nuzzle in Passing | At least one of them is walking normally, at a distance of 0.3–1.05 times the width | Keeps the original left/right order: approach, close eyes and nuzzle gently, return; 3.6 seconds once in position, cooldown 80 seconds |
| Play Ball Together | A regular invitation is due, nobody is very sleepy or very hungry, there is enough space, and the ball cooldown has ended | Take off the hat and bring out the ball, six passes, put the ball away and put the hat on, about 20.1 seconds once in position; cooldown 100 seconds. When ball play is unavailable, the original interactions can still be invited |
| Watch the Fun Together | A new window appears on the same screen, or window positions between samples change by at least 64 DIP horizontally and vertically combined; the event is within 8 seconds | They look toward the event, Feibi reacts first and Nuonuo 0.55 seconds later, about 4.2 seconds; cooldown 45 seconds |

All four share a scene interval of at least 18 seconds, and the separate cooldowns above count from the start. Quiet Mode does not start them; when either character's sleepiness reaches 70 or Nuonuo's hunger reaches 55 (outside Fasting/Infinite Mode), the existing sleep/feeding invitations take priority. The regular invitation interval stays at 30–55 seconds, and ball play joins that path; following, meeting and watching the fun evaluate their context once per second. Windows that already exist when observation starts do not count as new events; both ordinary windows and the current foreground maximized window can be watched, but here they are never moved, minimized or captured.

Manual entries are not limited by the autonomous cooldowns, but still respect character availability, the same monitor, the same height and continuous support. Moving/closing/minimizing the window ledge ends them; crossing screens, size changes, screen lock, exit, turning off coexistence, dragging, deletion tasks or manual mischief all use the unified cleanup. The ball uses a single transparent, mouse-click-through prop window that never takes focus, and nothing is left behind after cleanup. Failure reasons are recorded in PairLifeUnavailable (different heights, support not shared, not enough space, no visible window), without recording window titles, screenshots or file contents.

## Art and verification maintenance

notice, nuzzle and ball each have 16-frame sequences for both characters, 96 frames in total, with the source sheets in assets/pair_interactions/sheets. Each set calibrates a single scale factor against the same character's idle neutral face width and aligns the feet, and transparency cleanup is only a deterministic crop; all six current source sheets were generated directly from the original character art with the built-in imagegen. Running, hat removal and putting the hat on reuse the project's selected assets. Nuzzling and kicking the ball use dedicated poses; the ball is a prop drawn natively by this project, not a generated character image that was edited.

The ball trajectory and the action clock are maintained by this project's CompanionBallTimeline and are used only at runtime and for off-screen verification. The shoe-tip markers are 512-canvas coordinates on frame 7 of the selected pair_ball: Nuonuo (404,392), Feibi (100,384); the ball center is offset outward by one ball radius. The hat opening reuses the last hat_open frame (235,424). Character mirroring, size and DPI transform the markers together; the window center must not stand in for the shoe tip. When passing back and forth, the animation timeline of the same name is reset explicitly so the second kick does not stop on the previous kick's last frame.

The background tests cover follow spacing and frame rate, event validity, ball trajectory continuity at five scales and in two directions, six real animation restarts and repeated cancellation. tools/companion_life_preview.py generates four silent GIFs from real runtime frames; ball play reads the official timeline and real player frame numbers exported by the test program's --companion-preview, rather than writing a separate simulated playback. The previews live in dist/pair-daily-life-preview and do not go into the release package. Official versions and release hashes are maintained only in the current progress section of CHARACTERS.md; the hands-on acceptance checklist is in SELF_TEST.md.

## Action prompts

### notice_feibi

Original input: `assets/characters/feibijiubi/original.png`

Create ONE professional 4 by 4 spritesheet containing exactly 16 sequential full-body animation poses of the supplied original character, row-major. Transparent background, no grid, labels, text, objects, companions or shadows. All cells equal size with wide transparent gutters; every hat, hair, hand and foot fully inside its own cell. Fixed orthographic camera, same chibi proportions, crisp smooth outlines and original colors. Fixed world-space foot baseline, identical neutral body size across frames; movement comes from articulated poses, never camera zoom. Frame 0 and frame 15 neutral standing with two visible feet. Playful, cute and expressive but anatomically consistent, no creepy stretched faces. High resolution square sheet.
Feibijiubi: energetic adorable blonde, original giant white hat with black/blue band ALWAYS on head, purple glossy eyes, blue cross clip, white/black/blue outfit, black gloves, short striped socks and small black shoes. Main facing three-quarter towards screen LEFT. Preserve original identity.
16-pose noticing animation: 0 neutral; 1-3 head perks up and eyes become attentive; 4-6 turn gaze sideways toward companion while hand lifts a little; 7-9 rise onto toes and lean forward to peek; 10-12 small delighted response with hands near chest; 13-15 settle gently back to neutral. Standing, head upright, subtle bounce not size changes.

### notice_nuonuo

Original input: `assets/characters/nuonuo/original.png`

Create ONE professional 4 by 4 spritesheet containing exactly 16 sequential full-body animation poses of the supplied original character, row-major. Transparent background, no grid, labels, text, objects, companions or shadows. All cells equal size with wide transparent gutters; every hat, hair, hand and foot fully inside its own cell. Fixed orthographic camera, same chibi proportions, crisp smooth outlines and original colors. Fixed world-space foot baseline, identical neutral body size across frames; movement comes from articulated poses, never camera zoom. Frame 0 and frame 15 neutral standing with two visible feet. Playful, cute and expressive but anatomically consistent, no creepy stretched faces. High resolution square sheet.
Nuonuo: soft sleepy cute grey-blue long-haired mochi girl, half-lidded FLAT eyes split pink above pale blue below, NO pupils or dark circles, original red/white outfit and red bow, small body and two little black shoes below red skirt. Complete original upper-body reference to full-body chibi. Main facing slightly towards screen RIGHT. Preserve flat original eye design.
16-pose noticing animation: 0 neutral; 1-3 head perks up and eyes become attentive; 4-6 turn gaze sideways toward companion while hand lifts a little; 7-9 rise onto toes and lean forward to peek; 10-12 small delighted response with hands near chest; 13-15 settle gently back to neutral. Standing, head upright, subtle bounce not size changes.

### nuzzle_feibi

Original input: `assets/characters/feibijiubi/original.png`

Create ONE professional 4 by 4 spritesheet containing exactly 16 sequential full-body animation poses of the supplied original character, row-major. Transparent background, no grid, labels, text, objects, companions or shadows. All cells equal size with wide transparent gutters; every hat, hair, hand and foot fully inside its own cell. Fixed orthographic camera, same chibi proportions, crisp smooth outlines and original colors. Fixed world-space foot baseline, identical neutral body size across frames; movement comes from articulated poses, never camera zoom. Frame 0 and frame 15 neutral standing with two visible feet. Playful, cute and expressive but anatomically consistent, no creepy stretched faces. High resolution square sheet.
Feibijiubi: energetic adorable blonde, original giant white hat with black/blue band ALWAYS on head, purple glossy eyes, blue cross clip, white/black/blue outfit, black gloves, short striped socks and small black shoes. Main facing three-quarter towards screen LEFT. Preserve original identity.
16-pose affectionate shoulder/cheek nuzzle: 0 neutral; 1-3 tiny side step closer with shy smile; 4-6 lean shoulder and cheek toward partner offscreen; 7-9 eyes close and cheek presses softly, hands tucked; 10-12 two tender side-to-side rubbing poses; 13-15 spring gently upright. NO partner drawn. No distorted mouth or giant hands. Lean LEFT for Feibi, RIGHT for Nuonuo.

### nuzzle_nuonuo

Original input: `assets/characters/nuonuo/original.png`

Create ONE professional 4 by 4 spritesheet containing exactly 16 sequential full-body animation poses of the supplied original character, row-major. Transparent background, no grid, labels, text, objects, companions or shadows. All cells equal size with wide transparent gutters; every hat, hair, hand and foot fully inside its own cell. Fixed orthographic camera, same chibi proportions, crisp smooth outlines and original colors. Fixed world-space foot baseline, identical neutral body size across frames; movement comes from articulated poses, never camera zoom. Frame 0 and frame 15 neutral standing with two visible feet. Playful, cute and expressive but anatomically consistent, no creepy stretched faces. High resolution square sheet.
Nuonuo: soft sleepy cute grey-blue long-haired mochi girl, half-lidded FLAT eyes split pink above pale blue below, NO pupils or dark circles, original red/white outfit and red bow, small body and two little black shoes below red skirt. Complete original upper-body reference to full-body chibi. Main facing slightly towards screen RIGHT. Preserve flat original eye design.
16-pose affectionate shoulder/cheek nuzzle: 0 neutral; 1-3 tiny side step closer with shy smile; 4-6 lean shoulder and cheek toward partner offscreen; 7-9 eyes close and cheek presses softly, hands tucked; 10-12 two tender side-to-side rubbing poses; 13-15 spring gently upright. NO partner drawn. No distorted mouth or giant hands. Lean LEFT for Feibi, RIGHT for Nuonuo.

### ball_feibi

Original input: `assets/characters/feibijiubi/original.png`

Create ONE professional 4 by 4 spritesheet containing exactly 16 sequential full-body animation poses of the supplied original character, row-major. Transparent background, no grid, labels, text, objects, companions or shadows. All cells equal size with wide transparent gutters; every hat, hair, hand and foot fully inside its own cell. Fixed orthographic camera, same chibi proportions, crisp smooth outlines and original colors. Fixed world-space foot baseline, identical neutral body size across frames; movement comes from articulated poses, never camera zoom. Frame 0 and frame 15 neutral standing with two visible feet. Playful, cute and expressive but anatomically consistent, no creepy stretched faces. High resolution square sheet.
Feibijiubi: energetic adorable blonde, original giant white hat with black/blue band ALWAYS on head, purple glossy eyes, blue cross clip, white/black/blue outfit, black gloves, short striped socks and small black shoes. Main facing three-quarter towards screen LEFT. Preserve original identity.
16-pose playing with a SMALL BALL THAT IS NOT DRAWN: 0 neutral; 1-3 notice ball approaching feet and crouch slightly; 4-6 lift forward foot; 7-8 gently kick with crisp visible foot contact pose; 9-11 follow through with arms balancing, delighted eyes; 12-15 recoil into soft bounce then neutral. Feet stay low, grounded body, not running. NO ball or effects. Kick LEFT for Feibi, RIGHT for Nuonuo.

### ball_nuonuo

Original input: `assets/characters/nuonuo/original.png`

Create ONE professional 4 by 4 spritesheet containing exactly 16 sequential full-body animation poses of the supplied original character, row-major. Transparent background, no grid, labels, text, objects, companions or shadows. All cells equal size with wide transparent gutters; every hat, hair, hand and foot fully inside its own cell. Fixed orthographic camera, same chibi proportions, crisp smooth outlines and original colors. Fixed world-space foot baseline, identical neutral body size across frames; movement comes from articulated poses, never camera zoom. Frame 0 and frame 15 neutral standing with two visible feet. Playful, cute and expressive but anatomically consistent, no creepy stretched faces. High resolution square sheet.
Nuonuo: soft sleepy cute grey-blue long-haired mochi girl, half-lidded FLAT eyes split pink above pale blue below, NO pupils or dark circles, original red/white outfit and red bow, small body and two little black shoes below red skirt. Complete original upper-body reference to full-body chibi. Main facing slightly towards screen RIGHT. Preserve flat original eye design.
16-pose playing with a SMALL BALL THAT IS NOT DRAWN: 0 neutral; 1-3 notice ball approaching feet and crouch slightly; 4-6 lift forward foot; 7-8 gently kick with crisp visible foot contact pose; 9-11 follow through with arms balancing, delighted eyes; 12-15 recoil into soft bounce then neutral. Feet stay low, grounded body, not running. NO ball or effects. Kick LEFT for Feibi, RIGHT for Nuonuo.
