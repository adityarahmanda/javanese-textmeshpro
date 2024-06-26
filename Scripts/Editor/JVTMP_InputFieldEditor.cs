#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using TMPro.EditorUtilities;

namespace JVTMPro.EditorUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(JVTMP_InputField), true)]
    public class JVTMP_InputFieldEditor : TMP_InputFieldEditor
    {
        private Font defaultEditorFont;
        
        public override void OnInspectorGUI()
        {
            ChangeEditorStyle();
            base.OnInspectorGUI();
            RevertEditorStyle();
        }

        private void ChangeEditorStyle() {
            defaultEditorFont = new GUIStyle().font;
            EditorStyles.textArea.font = JVTMP_Settings.defaultEditorFont;
        }

        private void RevertEditorStyle() {
            EditorStyles.textArea.font = defaultEditorFont;
        }
    }
}
#endif