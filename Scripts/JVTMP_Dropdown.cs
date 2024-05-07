using UnityEngine;
using TMPro;

namespace JVTMPro {
    /// <summary>
    /// Kelas TMP_Dropdown lanjutan yang mendukung pemrosesan teks beraksara Jawa
    /// </summary>
    /// <example>
    /// <code lang="csharp">
    /// using UnityEngine;
    /// using JVTMPro;
    ///
    /// public class ExampleScript : MonoBehaviour
    /// {
    ///     [SerializeField] private JVTextMeshProUGUI sampleText;
    ///     [SerializeField] private JVTMP_Dropdown dropdown;
    ///
    ///     void Start()
    ///     {
    ///         dropdown.onValueChanged.AddListener(delegate {
    ///             OnDropdownValueChange();
    ///         });
    ///     }
    ///
    ///     public void OnDropdownValueChange()
    ///     {
    ///         sampleText.text = $"ꦏꦺꦴꦮꦺꦩꦶꦭꦶꦃ : { dropdown.options[dropdown.value].text }";
    ///     }
    /// }
    /// </code>
    /// </example>
    [AddComponentMenu("UI/Dropdown - Javanese TextMeshPro", 35)]
    [RequireComponent(typeof(RectTransform))]
    public class JVTMP_Dropdown : TMP_Dropdown {
        
    }
}
    