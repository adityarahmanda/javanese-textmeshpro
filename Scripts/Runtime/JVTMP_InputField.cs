using UnityEngine;
using TMPro;

namespace JVTMPro {
    /// <summary>
    /// Kelas TMP_InputField lanjutan yang mendukung pemrosesan teks aksara Jawa
    /// </summary>
    /// <example>
    /// <code lang="csharp">
    /// using UnityEngine;
    /// using UnityEngine.UI;
    /// using JVTMPro;
    ///
    /// public class ExampleScript : MonoBehaviour
    /// {
    ///     [SerializeField] private JVTextMeshProUGUI sampleText;
    ///     [SerializeField] private JVTMP_InputField inputField;
    ///     [SerializeField] private Button button;
    ///
    ///     void Start()
    ///     {
    ///         button.onClick.AddListener(delegate {
    ///             SubmitText();
    ///         });
    ///     }
    ///
    ///     public void SubmitText()
    ///     {
    ///         sampleText.text = inputField.text;
    ///     }
    /// }
    /// </code>
    /// </example>
    [AddComponentMenu("UI/Javanese TextMeshPro - Input Field", 11)]
    public class JVTMP_InputField : TMP_InputField {
        
    }
}