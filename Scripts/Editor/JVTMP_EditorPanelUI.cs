#if UNITY_EDITOR
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

namespace JVTMPro.EditorUtilities
{
    [CustomEditor(typeof(JVTextMeshProUGUI)), CanEditMultipleObjects]
    public class JVTMP_EditorPanelUI : TMP_EditorPanelUI
    {
        private SerializedProperty originalTextProp;

        private JVTextMeshProUGUI tmpro;
        
        private Font defaultEditorFont;

        static readonly GUIContent javaneseTextInputLabel = new GUIContent("<b>Javanese Text Input</b>");

        protected override void OnEnable()
        {
            base.OnEnable();
            originalTextProp = serializedObject.FindProperty("m_originalText");
        }

        public override void OnInspectorGUI()
        {
            ChangeEditorStyle();

            serializedObject.Update();
            tmpro = (JVTextMeshProUGUI)target;

            DrawJavaneseTextInput();

            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();

            RevertEditorStyle();
        }

        protected void DrawJavaneseTextInput()
        {
            EditorGUILayout.Space();

            EditorGUILayout.LabelField(javaneseTextInputLabel, TMP_UIStyleManager.sectionHeader);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(originalTextProp, GUIContent.none);

            if (EditorGUI.EndChangeCheck())
            {
                tmpro.UpdateText();
                m_HavePropertiesChanged = false;
                m_TextComponent.havePropertiesChanged = true;
                m_TextComponent.ComputeMarginSize();
                EditorUtility.SetDirty(target);
            }
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
