using ActionFit.LavaRush.UI;
using NUnit.Framework;
using UnityEngine;

namespace ActionFit.LavaRush.Theme.CatMerge.Tests
{
    public sealed class LavaRushCatMergeThemeTests
    {
        [Test]
        public void Create_ReturnsIndependentCatMergePalette()
        {
            LavaRushUITheme first = LavaRushCatMergeTheme.Create();
            LavaRushUITheme second = LavaRushCatMergeTheme.Create();

            Assert.That(first, Is.Not.SameAs(second));
            Assert.That(first.Lava, Is.EqualTo(new Color(1f, 0.38f, 0.08f, 1f)));
            Assert.That(first.Panel, Is.Not.EqualTo(new LavaRushUITheme().Panel));
        }

        [Test]
        public void Presentation_ProvidesCatMergeAdaptersWithoutGeneratingHierarchy()
        {
            var root = new GameObject("Lava Rush Cat Merge Theme Test");
            try
            {
                var presentation = root.AddComponent<LavaRushCatMergePresentation>();

                Assert.That(root.transform.childCount, Is.Zero);
                Assert.That(root.GetComponent<AudioSource>(), Is.Not.Null);
                Assert.That(presentation.GetProfile().DisplayName, Is.Not.Empty);
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(root);
            }
        }
    }
}
