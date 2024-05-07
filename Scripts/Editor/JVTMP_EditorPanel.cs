#if UNITY_EDITOR
using System.Collections;
using UnityEngine;
using UnityEditor;
using TMPro.EditorUtilities;

namespace JVTMPro.EditorUtilities
{
    [CustomEditor(typeof(JVTextMeshPro)), CanEditMultipleObjects]
    public class JVTMP_EditorPanel : TMP_EditorPanel
     {
        private SerializedProperty originalTextProp;

        private JVTextMeshPro tmpro;

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
            tmpro = (JVTextMeshPro)target;

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

        private void ChangeEditorStyle()
        {
            defaultEditorFont = new GUIStyle().font;
            EditorStyles.textArea.font = JVTMP_Settings.defaultEditorFont;
        }

        private void RevertEditorStyle()
        {
            EditorStyles.textArea.font = defaultEditorFont;
        }
    }
}
#endif