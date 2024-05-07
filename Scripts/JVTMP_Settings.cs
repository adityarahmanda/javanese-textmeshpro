using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using JVTMPro.EditorUtilities;
#endif

namespace JVTMPro
{
    public class JVTMP_Settings : ScriptableObject
    {
        private static JVTMP_Settings s_Instance;

        /// <summary>
        /// Returns the Default Javanese Unicode Font to be used in Editor.
        /// </summary>
        public static Font defaultEditorFont => instance.m_defaultEditorFont;
        [SerializeField]
        private Font m_defaultEditorFont;

        /// <summary>
        /// Returns the Default Font Asset to be used by newly created text objects.
        /// </summary>
        public static TMP_FontAsset defaultFontAsset => instance.m_defaultFontAsset;
        [SerializeField]
        private TMP_FontAsset m_defaultFontAsset;

        /// <summary>
        /// Get a singleton instance of the settings class.
        /// </summary>
        public static JVTMP_Settings instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = Resources.Load<JVTMP_Settings>("JVTMP_Settings");

                    #if UNITY_EDITOR
                    // Make sure TextMesh Pro UPM packages resources have been added to the user project
                    if (s_Instance == null)
                    {
                        // Open TMP Resources Importer
                        JVTMP_PackageUtilities.ImportEssentialResources();
                    }
                    #endif
                }

                return s_Instance;
            }
        }
    }
}
