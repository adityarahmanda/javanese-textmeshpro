using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using TMPro;
using TMPro.EditorUtilities;

#pragma warning disable 0414 // Disabled a few warnings related to serialized variables not used in this script but used in the editor.

namespace JVTMPro {
    [CustomEditor(typeof(JVTMProUGUI), true), CanEditMultipleObjects]
    public class JVTMProUGUIEditor : TMP_EditorPanelUI
    {
        private SerializedProperty m_inputTextProp;
        private bool m_preview = true;
        private JVTMProUGUI m_textComponent;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_inputTextProp = serializedObject.FindProperty("m_inputText");
        }

        public override void OnInspectorGUI()
        {
            // Make sure Multi selection only includes TMP Text objects.
            if (IsMixSelectionTypes()) return;

            serializedObject.Update();
            m_textComponent = (JVTMProUGUI)target;

            DrawJavaneseTextInput();

            DrawTextInput();

            DrawMainSettings();

            DrawExtraSettings();

            EditorGUILayout.Space();

            if (serializedObject.ApplyModifiedProperties() || m_HavePropertiesChanged)
            {
                OnChanged();
                m_textComponent.havePropertiesChanged = true;
                m_HavePropertiesChanged = false;
                EditorUtility.SetDirty(target);
            }
        }

        protected void DrawJavaneseTextInput() {
            // If the text component is linked, disable the text input box.
            
            if (m_ParentLinkedTextComponentProp.objectReferenceValue == null)
            {   
                EditorGUILayout.Space();
                // Display Preview
                m_preview = EditorGUILayout.Toggle("Preview", m_preview);
                if(m_preview) {
                    string previewText = Regex.Replace(m_TextProp.stringValue, "<[^<>]+>", string.Empty);
                    EditorGUILayout.LabelField(previewText, JVTMProUIStyleManager.label);
                }
                EditorGUILayout.Space();
                
                // Enable and Display ANSI Transliterator Input
                Rect rect = EditorGUILayout.GetControlRect(false, 22);
                EditorGUI.LabelField(rect, new GUIContent("<b>Javanese Unicode Input</b>"), TMP_UIStyleManager.sectionHeader);
                EditorGUI.indentLevel = 0;
                
                float labelWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 50f;

                EditorGUI.BeginChangeCheck();
                
                EditorGUIUtility.labelWidth = labelWidth;
                EditorGUILayout.Space(); 
                
                EditorGUILayout.Space();
                EditorGUI.BeginChangeCheck(); 
                m_inputTextProp.stringValue = EditorGUILayout.TextArea(m_inputTextProp.stringValue, JVTMProUIStyleManager.textArea, GUILayout.MinHeight(70));
                if(EditorGUI.EndChangeCheck())
                    OnChanged();
            }
        }

        protected void OnChanged() {
            m_HavePropertiesChanged = false;
            m_textComponent.havePropertiesChanged = true;
            m_textComponent.ComputeMarginSize();
            EditorUtility.SetDirty(target);
        }
    }
}