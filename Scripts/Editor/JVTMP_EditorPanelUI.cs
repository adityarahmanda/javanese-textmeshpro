using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

namespace JVTMPro.EditorUtilities
{
    [CustomEditor(typeof(JVTextMeshProUGUI)), CanEditMultipleObjects]
    public class RTLTextMeshProEditor : TMP_EditorPanelUI
    {
        private SerializedProperty originalTextProp;

        private JVTextMeshProUGUI tmpro;
        
        private Font defaultEditorFont;

        protected override void OnEnable()
        {
            base.OnEnable();
            originalTextProp = serializedObject.FindProperty("originalText");
        }

        public override void OnInspectorGUI()
        {
            ChangeEditorStyle();

            serializedObject.Update();
            tmpro = (JVTextMeshProUGUI)target;

            
            EditorGUILayout.Space();

            EditorGUILayout.LabelField(new GUIContent("<b>Javanese Text Input</b>"), TMP_UIStyleManager.sectionHeader);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(originalTextProp, GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                OnChanged();

            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();

            RevertEditorStyle();
        }

        protected void OnChanged()
        {
            tmpro.UpdateText();
            m_HavePropertiesChanged = false;
            m_TextComponent.havePropertiesChanged = true;
            m_TextComponent.ComputeMarginSize();
            EditorUtility.SetDirty(target);
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