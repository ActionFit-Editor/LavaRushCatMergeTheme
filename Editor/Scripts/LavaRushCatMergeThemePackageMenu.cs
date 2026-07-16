#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace ActionFit.LavaRush.Theme.CatMerge.Editor
{
    public static class LavaRushCatMergeThemePackageMenu
    {
        private const string MenuRoot = "Tools/Package/ActionFit Lava Rush Cat Merge Theme/";
        private const string ReadmePath = "Packages/com.actionfit.lava-rush.theme.catmerge/README.md";

        [MenuItem(MenuRoot + "README", false, 907)]
        private static void OpenReadme()
        {
            var readme = AssetDatabase.LoadAssetAtPath<TextAsset>(ReadmePath);
            if (readme == null)
            {
                EditorUtility.DisplayDialog("Package README", $"README was not found.\n{ReadmePath}", "OK");
                return;
            }
            Selection.activeObject = readme;
            AssetDatabase.OpenAsset(readme);
        }
    }
}
#endif
