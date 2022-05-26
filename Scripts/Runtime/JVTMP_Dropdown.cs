using UnityEngine;
using TMPro;

namespace JVTMPro {
    /// <summary>
    ///   A standard dropdown that presents a list of options when clicked, of which one can be chosen.
    /// </summary>
    /// <remarks>
    /// The dropdown component is a Selectable. When an option is chosen, the label and/or image of the control changes to show the chosen option.
    ///
    /// When a dropdown event occurs a callback is sent to any registered listeners of onValueChanged.
    /// </remarks>
    [AddComponentMenu("UI/Dropdown - Javanese TextMeshPro", 35)]
    [RequireComponent(typeof(RectTransform))]
    public class JVTMP_Dropdown : TMP_Dropdown {

    }
}
    