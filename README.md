# ActionFit Lava Rush Cat Merge 테마 (`com.actionfit.lava-rush.theme.catmerge`)

`com.actionfit.lava-rush.ui`에서 사용할 수 있는 공개·재배포 가능 Cat Merge 프레젠테이션 프리셋입니다. 패키지가 소유하는 색상 팔레트와 즉시 사용할 수 있는 `LavaRushCatMergePresentation`을 포함하며, 출처가 확인되지 않은 프로젝트 바이너리는 의도적으로 제외합니다.

프레젠테이션이 런타임에 UI cue를 합성하므로 Unity 기본 모듈 `com.unity.modules.audio@1.0.0`을 선언합니다.

## 설치

공개 패키지가 publish된 후 다음 항목을 추가합니다.

```json
{
  "dependencies": {
    "com.actionfit.lava-rush.ui": "https://github.com/ActionFit-Editor/LavaRushUI.git#0.1.3",
    "com.actionfit.lava-rush.theme.catmerge": "https://github.com/ActionFit-Editor/LavaRushCatMergeTheme.git#0.1.6"
  }
}
```

## 사용법

- Scene 또는 Prefab에 `LavaRushCatMergePresentation`을 추가하고 `LavaRushBootstrap.Initialize` 또는 `InitializeDefault`에 전달합니다.
- 다른 프레젠테이션 클래스를 사용한다면 초기화 전에 `LavaRushCatMergeTheme.Create()` 결과를 `LavaRushPresentation.ApplyThemeOverride`에 전달합니다.

프리셋은 배경, 패널, 강조색, 용암, 진행도, 텍스트와 버튼 색상을 변경합니다. `LavaRushCatMergePresentation`은 한국어 UI 문자열, Cat Chef 프로필과 런타임에서 합성하는 짧은 화면/진행/보상 cue도 제공합니다. 중립 UI 흐름과 엔진의 모든 권한 동작은 그대로 유지합니다.

## 에셋 경계

이 패키지에는 복사된 LavaRush PNG, 오디오, 폰트, 머티리얼, 애니메이션, 프리팹, Addressable 항목 또는 서드파티 에셋이 없습니다. 현재 Cat Merge 프로젝트 에셋은 `Assets/_Project/Content/LavaRush`에 유지합니다. 자세한 내용은 `Documentation/AssetProvenance.md`와 `Third Party Notices.md`를 확인하세요. 이후 바이너리 에셋을 릴리스하려면 명확한 출처, GUID/참조 마이그레이션 및 시각 QA가 필요합니다.

## 배포

저장소 공개 범위 메타데이터는 Public입니다. 저장소 생성, Git push, 태그 생성, 카탈로그 등록 및 publish는 Custom Package Manager에서 수동으로 실행합니다.
