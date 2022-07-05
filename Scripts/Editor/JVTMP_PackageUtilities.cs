using System;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace JVTMPro.EditorUtilities
{
    public class JVTMP_PackageUtilities : Editor
    {
        private static string GetPackageFullPath()
        {
            // Check for potential UPM package
            string packagePath = Path.GetFullPath("Packages/com.unity.javanese-textmeshpro");
            if (Directory.Exists(packagePath))
            {
                return packagePath;
            }

            // Search default location for development package
            packagePath = Path.GetFullPath("Packages/JavaneseTextMeshPro");
            if (Directory.Exists(packagePath))
            {
                return packagePath;
            }

            return null;
        }

        [MenuItem("Window/Javanese TextMeshPro/Import JVTMP Essential Resources", false, 2250)]
        public static void ImportProjectResourcesMenu()
        {
            ImportEssentialResources();
        }

        /// <summary>
        ///
        /// </summary>
        [MenuItem("Window/Javanese TextMeshPro/Import JVTMP Examples Resources", false, 2250)]
        public static void ImportExamplesContentMenu()
        {
            ImportExamplesAndExtras();
        }

        private static string k_SettingsFilePath;
        private static byte[] k_SettingsBackup;

        public static void ImportEssentialResources()
        {
            // Check if the JVTMP Settings asset is already present in the project.
            string[] settings = AssetDatabase.FindAssets("t:JVTMP_Settings");

            if (settings.Length > 0)
            {
                // Save assets just in case the TMP Setting were modified before import.
                AssetDatabase.SaveAssets();

                // Copy existing TMP Settings asset to a byte[]
                k_SettingsFilePath = AssetDatabase.GUIDToAssetPath(settings[0]);
                k_SettingsBackup = File.ReadAllBytes(k_SettingsFilePath);

                RegisterResourceImportCallback();
            }

            AssetDatabase.ImportPackage(GetPackageFullPath() + "/Package Resources/JVTMP Essential Resources.unitypackage", true);
        }

        public static void ImportExamplesAndExtras()
        {
            AssetDatabase.ImportPackage(GetPackageFullPath() + "/Package Resources/JVTMP Examples Resources.unitypackage", true);
        }

        private static void RegisterResourceImportCallback()
        {
            AssetDatabase.importPackageCompleted += ImportCallback;
        }

        private static void ImportCallback(string packageName)
        {
            // Restore backup of TMP Settings from byte[]
            File.WriteAllBytes(k_SettingsFilePath, k_SettingsBackup);

            AssetDatabase.Refresh();

            AssetDatabase.importPackageCompleted -= ImportCallback;
        }
    }
}