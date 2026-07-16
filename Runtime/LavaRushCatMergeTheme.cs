using System;
using System.Collections.Generic;
using ActionFit.LavaRush.UI;
using UnityEngine;

namespace ActionFit.LavaRush.Theme.CatMerge
{
    /// <summary>Redistribution-safe Cat Merge palette built without project art, fonts, or audio.</summary>
    public static class LavaRushCatMergeTheme
    {
        public static LavaRushUITheme Create()
        {
            return new LavaRushUITheme(
                new Color(0.12f, 0.075f, 0.055f, 0.96f),
                new Color(0.34f, 0.22f, 0.15f, 1f),
                new Color(0.56f, 0.16f, 0.08f, 1f),
                new Color(1f, 0.38f, 0.08f, 1f),
                new Color(0.18f, 0.1f, 0.07f, 0.95f),
                new Color(1f, 0.93f, 0.75f, 1f),
                new Color(0.88f, 0.75f, 0.58f, 1f),
                new Color(0.96f, 0.42f, 0.12f, 1f),
                new Color(0.47f, 0.31f, 0.21f, 1f));
        }
    }

    /// <summary>Applies the Cat Merge palette while retaining the neutral presentation flow.</summary>
    [RequireComponent(typeof(AudioSource))]
    [AddComponentMenu("ActionFit/Lava Rush Cat Merge Presentation")]
    public sealed class LavaRushCatMergePresentation : LavaRushPresentation,
        ILavaRushUILocalizer,
        ILavaRushUIAudio,
        ILavaRushUIProfileProvider
    {
        private const int SampleRate = 22050;
        private readonly Dictionary<string, AudioClip> _clips = new();
        private AudioSource _audioSource;

        protected override LavaRushUITheme ResolveDefaultTheme() => LavaRushCatMergeTheme.Create();

        public string Get(string key, string fallback)
        {
            if (Application.systemLanguage != SystemLanguage.Korean)
            {
                return fallback ?? string.Empty;
            }

            return key switch
            {
                LavaRushUIKeys.Title => "용암 탈출",
                LavaRushUIKeys.ScreenEventStart => "이벤트 시작",
                LavaRushUIKeys.ScreenDifficulty => "난이도 선택",
                LavaRushUIKeys.ScreenTutorial => "플레이 방법",
                LavaRushUIKeys.ScreenMatch => "용암에서 탈출하세요",
                LavaRushUIKeys.ScreenResult => "스테이지 결과",
                LavaRushUIKeys.ScreenComplete => "모든 스테이지 완료",
                LavaRushUIKeys.ScreenEventEnd => "이벤트 종료",
                LavaRushUIKeys.ActionStartEvent => "이벤트 시작",
                LavaRushUIKeys.ActionEasy => "쉬움",
                LavaRushUIKeys.ActionNormal => "보통",
                LavaRushUIKeys.ActionHard => "어려움",
                LavaRushUIKeys.ActionContinue => "계속",
                LavaRushUIKeys.ActionStartStage => "스테이지 시작",
                LavaRushUIKeys.ActionAddProgress => "+ 진행도",
                LavaRushUIKeys.ActionEvaluateStage => "타이머 판정",
                LavaRushUIKeys.ActionClaim => "보상 받기",
                LavaRushUIKeys.ActionRetry => "다시 도전",
                LavaRushUIKeys.ActionEndEvent => "이벤트 종료",
                LavaRushUIKeys.ActionClose => "닫기",
                LavaRushUIKeys.MessageStart => "활성 시간이 끝나기 전에 이벤트를 시작하세요.",
                LavaRushUIKeys.MessageDifficulty => "난이도를 선택하면 이번 이벤트 동안 유지됩니다.",
                LavaRushUIKeys.MessageTutorial => "용암이 모든 발판에 도착하기 전에 진행도를 채우세요.",
                LavaRushUIKeys.MessageReady => "준비가 되면 다음 스테이지를 시작하세요.",
                LavaRushUIKeys.MessagePlaying => "제한 시간이 끝나기 전에 진행도를 획득하세요.",
                LavaRushUIKeys.MessageWin => "용암에서 탈출했습니다. 저장된 보상을 확인하세요.",
                LavaRushUIKeys.MessageLose => "용암이 따라잡았습니다. 결과를 확인하고 다시 도전하세요.",
                LavaRushUIKeys.MessageComplete => "모든 스테이지를 완료했습니다.",
                LavaRushUIKeys.MessageEventEnd => "이벤트 활성 시간이 종료되었습니다.",
                LavaRushUIKeys.FormatEventTime => "이벤트 {0}",
                LavaRushUIKeys.FormatStageTime => "스테이지 {0}",
                LavaRushUIKeys.FormatStage => "난이도 {0}  |  스테이지 {1} / {2}",
                LavaRushUIKeys.FormatProgress => "진행도 {0} / {1}",
                LavaRushUIKeys.FormatSeats => "남은 발판 {0} / {1}",
                LavaRushUIKeys.FormatRank => "순위 {0}",
                LavaRushUIKeys.FormatReward => "{0} x{1}",
                LavaRushUIKeys.FormatProfile => "도전자: {0}",
                _ => fallback ?? string.Empty,
            };
        }

        public LavaRushUIProfile GetProfile()
        {
            string name = Application.systemLanguage == SystemLanguage.Korean ? "고양이 셰프" : "Cat Chef";
            return new LavaRushUIProfile(name, new Color(1f, 0.72f, 0.24f, 1f));
        }

        public void Play(string cue)
        {
            if (!Application.isPlaying || string.IsNullOrWhiteSpace(cue))
            {
                return;
            }

            _audioSource ??= GetComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.spatialBlend = 0f;
            if (!_clips.TryGetValue(cue, out AudioClip clip))
            {
                clip = CreateCue(cue);
                _clips.Add(cue, clip);
            }
            _audioSource.PlayOneShot(clip);
        }

        private void OnDestroy()
        {
            foreach (AudioClip clip in _clips.Values)
            {
                if (clip != null)
                {
                    Destroy(clip);
                }
            }
            _clips.Clear();
        }

        private static AudioClip CreateCue(string cue)
        {
            float duration;
            float firstFrequency;
            float secondFrequency;
            if (string.Equals(cue, LavaRushUIKeys.AudioProgress, StringComparison.Ordinal))
            {
                duration = 0.12f;
                firstFrequency = 660f;
                secondFrequency = 880f;
            }
            else if (string.Equals(cue, LavaRushUIKeys.AudioReward, StringComparison.Ordinal))
            {
                duration = 0.34f;
                firstFrequency = 523.25f;
                secondFrequency = 783.99f;
            }
            else
            {
                duration = 0.16f;
                firstFrequency = 330f;
                secondFrequency = 440f;
            }

            int sampleCount = Mathf.CeilToInt(duration * SampleRate);
            var samples = new float[sampleCount];
            for (int index = 0; index < sampleCount; index++)
            {
                float time = index / (float)SampleRate;
                float envelope = 1f - index / (float)sampleCount;
                float first = Mathf.Sin(2f * Mathf.PI * firstFrequency * time);
                float second = Mathf.Sin(2f * Mathf.PI * secondFrequency * time);
                samples[index] = (first * 0.65f + second * 0.35f) * envelope * 0.18f;
            }

            AudioClip clip = AudioClip.Create($"LavaRush.{cue}", sampleCount, 1, SampleRate, false);
            clip.SetData(samples, 0);
            return clip;
        }
    }
}
