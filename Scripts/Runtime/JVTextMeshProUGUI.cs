using TMPro;
using UnityEngine;
using JVTMPro.Utilities;
using JVTMPro.EditorUtilities;

namespace JVTMPro
{
    /// <summary>
    /// Kelas TextMeshProUGUI lanjutan yang mendukung pemrosesan teks beraksara Jawa
    /// </summary>
    /// <example>
    /// <code lang="csharp">
    /// using UnityEngine;
    /// using JVTMPro;
    ///
    /// public class ExampleScript : MonoBehaviour
    /// {
    ///    [SerializeField] private JVTextMeshProUGUI sampleText;
    ///
    ///     private void Start()
    ///     {
    ///         sampleText.text = "꧋ꦮꦗꦶꦏ꧀​ꦏ꧀ꦭꦼꦛꦶꦏ꧀ꦒꦸꦭꦗꦮ꧈ ꦭꦸꦮꦶꦃꦧꦼꦕꦶꦏ꧀ꦱꦶꦁꦥꦿꦱꦗ꧉";
    ///     }
    /// }
    /// </code>
    /// </example>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshRenderer))]
    [AddComponentMenu("UI/Javanese TextMeshPro - Text (UI)")]
    [ExecuteAlways]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0")]
    public class JVTextMeshProUGUI : TextMeshProUGUI
    {
        // ReSharper disable once InconsistentNaming
#if TMP_VERSION_2_1_0_OR_NEWER
        public override string text
#else
        public new string text
#endif
        public override string text
        {
            get { return m_originalText; }
            set
            {
                if (m_originalText == value)
                    return;

                m_originalText = value;

                UpdateText();
            }
        }

        /// <summary>
        /// Teks asli yang tatanan aksara Jawanya masih belum diperbaiki
        /// </summary>
        public string OriginalText
        {
            get { return m_originalText; }
        }

        [SerializeField] [TextArea(5, 10)] protected string m_originalText;

        /// <summary>
        /// Lihat <see href="https://docs.unity3d.com/2018.3/Documentation/ScriptReference/MonoBehaviour.Update.html">MonoBehaviour.Update</see>
        /// </summary>
        protected void Update()
        {
            if (havePropertiesChanged)
            {
                UpdateText();
            }
        }

        /// <summary>
        /// Lihat <see href="https://docs.unity3d.com/2018.3/Documentation/ScriptReference/MonoBehaviour.Reset.html">MonoBehaviour.Reset</see>
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            font = JVTMP_Settings.defaultFontAsset;
        }

        /// <summary>
        /// Memperbarui teks yang tertampil dalam game dengan teks asli yang tatanan aksara Jawanya sudah diperbaiki
        /// </summary>
        public void UpdateText()
        {
            if (m_originalText == null)
                m_originalText = "";

            base.text = JavaneseTextFixer.Fix(m_originalText);

            havePropertiesChanged = true;
        }
    }
}