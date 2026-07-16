# AI Guide - ActionFit Lava Rush Cat Merge Theme

## Package Identity

- Package ID: `com.actionfit.lava-rush.theme.catmerge`
- Display name: ActionFit Lava Rush Cat Merge Theme
- Repository: `https://github.com/ActionFit-Editor/LavaRushCatMergeTheme.git`
- Repository visibility: Public
- Current package version at generation time: `0.1.2`
- Unity version: `6000.2`
- Runtime dependencies: `com.actionfit.lava-rush.ui@0.1.1` and `com.unity.modules.audio@1.0.0`

## Purpose And Boundary

This package provides a redistribution-safe Cat Merge color preset and `LavaRushCatMergePresentation`. It changes presentation defaults only and supplies package-owned Korean strings, a presentation profile, and synthesized UI cues. It does not own engine state, bootstrap action routing, project localization/sound systems, Addressables, project navigation, or reward behavior.

## Project Router Registration

Requested router entry:

- `Packages/com.actionfit.lava-rush.theme.catmerge/AI_GUIDE.md` - ActionFit Lava Rush Cat Merge Theme owns the redistribution-safe Cat Merge palette and presentation preset layered over the neutral Lava Rush UI.

## Runtime Contract

- `LavaRushCatMergeTheme.Create()` returns a new immutable-by-public-API `LavaRushUITheme` value set.
- `LavaRushCatMergePresentation` overrides only `ResolveDefaultTheme`; all rendering and action behavior remain in `com.actionfit.lava-rush.ui`.
- The presentation implements the UI package's localizer, audio, and profile contracts. Audio clips are generated in memory from ActionFit-authored PCM synthesis and are never serialized.
- Do not copy engine commands, view-model mapping, or project adapters into this package.
- Do not add a dependency on `Assembly-CSharp`, Cat Merge managers, project assets, Addressables, DOTween, UniTask, localization, or sound systems.

## Asset Rights And Migration

- Version `0.1.1` contains no project binary assets or third-party content. The palette and code are the complete released candidate surface.
- `Documentation/AssetProvenance.md` is the shipped inclusion/exclusion matrix, and `Third Party Notices.md` must remain aligned with it.
- Existing Cat Merge LavaRush assets, prefabs, `.meta` files, and Addressable keys stay in their current project paths.
- A later asset-bearing version requires ownership/license evidence for every file, a single canonical copy, explicit GUID/reference migration approval, and consumer validation. Public visibility does not waive that review.

## Package Tools Menu

- `Tools/Package/ActionFit Lava Rush Cat Merge Theme/README`: opens the installed README.
- The package owns no settings ScriptableObject and exposes no `Setting SO` menu.

## Validation

- Run the package contract validator for `com.actionfit.lava-rush.theme.catmerge`.
- Run `com.actionfit.lava-rush.theme.catmerge.Editor.Tests`.
- Compile with the declared UI dependency in an isolated Unity project.
- Verify source and package contents contain no reference to `Assets/_Project`, project APIs, or unreviewed binaries.

## Metadata And Release

- `package.json` owns identity, version, Unity version, and dependency.
- `Editor/PackageInfo/ActionFitPackageInfo_SO.asset` owns repository name `LavaRushCatMergeTheme`, Public visibility, Korean description, and release note.
- Publishing is manual through Custom Package Manager. Do not create repositories, push, tag, or append catalog rows without separate authorization.
