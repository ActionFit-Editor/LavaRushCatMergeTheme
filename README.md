# ActionFit Lava Rush Cat Merge Theme (`com.actionfit.lava-rush.theme.catmerge`)

A public, redistribution-safe Cat Merge presentation preset for `com.actionfit.lava-rush.ui`. It contains a package-owned color palette and a ready-to-use `LavaRushCatMergePresentation` while intentionally excluding unverified project binaries.

The package declares Unity's built-in `com.unity.modules.audio@1.0.0` because the presentation synthesizes its UI cues at runtime.

## Install

After the public packages are published, add:

```json
{
  "dependencies": {
    "com.actionfit.lava-rush.ui": "https://github.com/ActionFit-Editor/LavaRushUI.git#0.1.1",
    "com.actionfit.lava-rush.theme.catmerge": "https://github.com/ActionFit-Editor/LavaRushCatMergeTheme.git#0.1.2"
  }
}
```

## Use

- Add `LavaRushCatMergePresentation` to a scene or prefab and pass it to `LavaRushBootstrap.Initialize` or `InitializeDefault`.
- For another presentation class, call `LavaRushCatMergeTheme.Create()` and pass the result to `LavaRushPresentation.ApplyThemeOverride` before initialization.

The preset changes backdrop, panel, accent, lava, progress, text, and button colors. `LavaRushCatMergePresentation` also supplies Korean UI strings, a Cat Chef profile, and short screen/progress/reward cues synthesized at runtime. It retains the neutral UI flow and all authoritative engine behavior.

## Asset Boundary

The package contains no copied LavaRush PNG, audio, font, material, animation, prefab, Addressable entry, or third-party asset. The current Cat Merge project assets remain in `Assets/_Project/Content/LavaRush`. See `Documentation/AssetProvenance.md` and `Third Party Notices.md`. A later binary-asset release requires explicit provenance, GUID/reference migration, and visual QA.

## Publishing

Repository visibility metadata is Public. Repository creation, Git push, tagging, catalog registration, and publishing remain manual Custom Package Manager actions.
