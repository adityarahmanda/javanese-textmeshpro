using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace JavaneseToolkit 
{
    public class JT_Settings : ScriptableObject
    {
        private static JT_Settings s_Instance;
        
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
        /// Returns the Default Font Asset to be used by newly created text objects.
        /// </summary>
        public static Vector4 defaultMargin
        {
            get { return instance.m_defaultMargin; }
        }
        [SerializeField]
        private Vector4 m_defaultMargin = new Vector4(0, 21, 0, 0);

        /// <summary>
        /// Returns the Default Javanese Unicode Font to be used in Editor.
        /// </summary>
        public static Font defaultJavaUnicodeEditorFont
        {
            get { return instance.m_defaultJavaUnicodeEditorFont; }
        }
        [SerializeField]
        private Font m_defaultJavaUnicodeEditorFont;

        /// <summary>
        /// Returns the Default Javanese ANSI Font to be used in Editor.
        /// </summary>
        public static Font defaultJavaANSIEditorFont
        {
            get { return instance.m_defaultJavaANSIEditorFont; }
        }
        [SerializeField]
        private Font m_defaultJavaANSIEditorFont;

        /// <summary>
        /// Returns the Default Font Asset to be used by newly created text objects.
        /// </summary>
        public static TMP_FontAsset defaultJavaUnicodeFontAsset
        {
            get { return instance.m_defaultJavaUnicodeFontAsset; }
        }
        [SerializeField]
        private TMP_FontAsset m_defaultJavaUnicodeFontAsset;

        /// <summary>
        /// Returns the Default Font Asset to be used by newly created text objects.
        /// </summary>
        public static TMP_FontAsset defaultJavaANSIFontAsset
        {
            get { return instance.m_defaultJavaANSIFontAsset; }
        }
        [SerializeField]
        private TMP_FontAsset m_defaultJavaANSIFontAsset;

        /// <summary>
        /// Get a singleton instance of the settings class.
        /// </summary>
        public static JT_Settings instance
        {
            get
            {
                if (JT_Settings.s_Instance == null)
                {
                    JT_Settings.s_Instance = Resources.Load<JT_Settings>("Javanese Toolkit Settings");

                    #if UNITY_EDITOR
                    // Make sure TextMesh Pro UPM packages resources have been added to the user project
                    if (JT_Settings.s_Instance == null)
                    {
                        // Open TMP Resources Importer
                        // TMP_PackageResourceImporterWindow.ShowPackageImporterWindow();
                    }
                    #endif
                }

                return JT_Settings.s_Instance;
            }
        }
    }
}