#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace JVTMPro.EditorUtilities
{
    [CustomEditor(typeof(JVTMP_Dropdown), true)]
    [CanEditMultipleObjects]
    public class JVTMP_DropdownEditor : TMPro.EditorUtilities.DropdownEditor
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
            EditorStyles.textField.font = JVTMP_Settings.defaultEditorFont;
        }

        private void RevertEditorStyle() {
            EditorStyles.textField.font = defaultEditorFont;
        }
    }
}
#endif