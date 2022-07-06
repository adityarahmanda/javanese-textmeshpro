using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace JVTMPro.EditorUtilities
{
    public class JVTMP_Settings : ScriptableObject
    {
        private static JVTMP_Settings s_Instance;

        /// <summary>
        /// Returns the release version of the product.
        /// </summary>
        public static string version
        {
            get { return "1.0.0"; }
        }

        /// <summary>
        /// Returns the Default Javanese Unicode Font to be used in Editor.
        /// </summary>
        public static Font defaultEditorFont
        {
            get { return instance.m_defaultEditorFont; }
        }
        [SerializeField]
        private Font m_defaultEditorFont;

        /// <summary>
        /// Returns the Default Font Asset to be used by newly created text objects.
        /// </summary>
        public static TMP_FontAsset defaultFontAsset
        {
            get { return instance.m_defaultFontAsset; }
        }
        [SerializeField]
        private TMP_FontAsset m_defaultFontAsset;

        /// <summary>
        /// Get a singleton instance of the settings class.
        /// </summary>
        public static JVTMP_Settings instance
        {
            get
            {
                if (JVTMP_Settings.s_Instance == null)
                {
                    JVTMP_Settings.s_Instance = Resources.Load<JVTMP_Settings>("JVTMP_Settings");

                    #if UNITY_EDITOR
                    // Make sure TextMesh Pro UPM packages resources have been added to the user project
                    if (JVTMP_Settings.s_Instance == null)
                    {
                        // Open TMP Resources Importer
                        JVTMP_PackageUtilities.ImportEssentialResources();
                    }
                    #endif
                }

                return JVTMP_Settings.s_Instance;
            }
        }
    }
}