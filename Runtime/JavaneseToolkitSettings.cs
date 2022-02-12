using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace JavaneseToolkit 
{
    public class JavaneseToolkitSettings : ScriptableObject
    {
        private static JavaneseToolkitSettings s_Instance;
        
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
        public static JavaneseToolkitSettings instance
        {
            get
            {
                if (JavaneseToolkitSettings.s_Instance == null)
                {
                    JavaneseToolkitSettings.s_Instance = Resources.Load<JavaneseToolkitSettings>("Javanese Toolkit Settings");

                    #if UNITY_EDITOR
                    // Make sure TextMesh Pro UPM packages resources have been added to the user project
                    if (JavaneseToolkitSettings.s_Instance == null)
                    {
                        // Open TMP Resources Importer
                        // TMP_PackageResourceImporterWindow.ShowPackageImporterWindow();
                    }
                    #endif
                }

                return JavaneseToolkitSettings.s_Instance;
            }
        }
    }
}