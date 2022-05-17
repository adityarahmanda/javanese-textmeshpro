using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace JVTMPro 
{
    [CreateAssetMenu(fileName = "JVTMProSettings", menuName = "Javanese TextMeshPro/Settings", order = 1)]
    public class JVTMProSettings : ScriptableObject
    {
        private static JVTMProSettings s_Instance;

        /// <summary>
        /// Returns the Default Font Asset to be used by newly created text objects.
        /// </summary>
        public static Vector4 defaultMargin
        {
            get { return instance.m_defaultMargin; }
        }
        [SerializeField]
        private Vector4 m_defaultMargin = new Vector4(0, 21, 0, 0);
        
        /// <summary>
        /// Returns the Default Font Asset to be used by newly created text objects.
        /// </summary>
        public static int defaultFontSize
        {
            get { return instance.m_defaultFontSize; }
        }
        [SerializeField]
        private int m_defaultFontSize = 24;

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
        public static JVTMProSettings instance
        {
            get
            {
                if (JVTMProSettings.s_Instance == null)
                {
                    JVTMProSettings.s_Instance = Resources.Load<JVTMProSettings>("JVTMProSettings");

                    #if UNITY_EDITOR
                    // Make sure TextMesh Pro UPM packages resources have been added to the user project
                    if (JVTMProSettings.s_Instance == null)
                    {
                        // Open TMP Resources Importer
                        // TMP_PackageResourceImporterWindow.ShowPackageImporterWindow();
                    }
                    #endif
                }

                return JVTMProSettings.s_Instance;
            }
        }
    }
}