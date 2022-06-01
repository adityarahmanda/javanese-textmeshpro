using TMPro;
using UnityEngine;
using JVTMPro.Utilities;
using JVTMPro.EditorUtilities;

namespace JVTMPro
{
    /// <summary>
    /// Description
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshRenderer))]
    [AddComponentMenu("Mesh/Javanese TextMeshPro - Text")]
    [ExecuteAlways]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0")]
    public class JVTextMeshPro : TextMeshPro
    {
        // ReSharper disable once InconsistentNaming
#if TMP_VERSION_2_1_0_OR_NEWER
        public override string text
#else
        public new string text
#endif
        {
            get { return base.text; }
            set
            {
                if (originalText == value)
                    return;

                originalText = value;

                UpdateText();
            }
        }

        /// <summary>
        /// A string containing the original javanese text before the displayed text is being fixed
        /// </summary>
        public string OriginalText
        {
            get { return originalText; }
        }

        [SerializeField]
        [TextArea(5, 10)]
        protected string originalText;

        protected void Update()
        {
            if (havePropertiesChanged)
            {
                UpdateText();
            }
        }

        protected override void Reset()
        {
            base.Reset();
            font = JVTMP_Settings.defaultFontAsset;
        }

        /// <summary>
        /// Update the original javanese text by fixing it so it would be displayed correctly
        /// </summary>
        public void UpdateText()
        {
            if (originalText == null)
                originalText = "";

            base.text = JavaneseTextFixer.Fix(originalText);

            havePropertiesChanged = true;
        }
    }
}