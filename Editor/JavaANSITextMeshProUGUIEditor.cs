using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using TMPro;
using TMPro.EditorUtilities;

#pragma warning disable 0414 // Disabled a few warnings related to serialized variables not used in this script but used in the editor.

namespace JavaneseToolkit {
    [CustomEditor(typeof(JavaANSITextMeshProUGUI), true), CanEditMultipleObjects]
    public class JavaANSITextMeshProUGUIEditor : TMP_EditorPanelUI
    {
        private SerializedProperty m_transliteratorInputTextProp;
        private SerializedProperty m_enableTransliteratorInputProp;
        
        private bool preview = true;
        private JavaANSITextMeshProUGUI tmpro;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_transliteratorInputTextProp = serializedObject.FindProperty("m_transliteratorInputText");
            m_enableTransliteratorInputProp = serializedObject.FindProperty("m_enableTransliteratorInput");
        }

        public override void OnInspectorGUI()
        {
            // Make sure Multi selection only includes TMP Text objects.
            if (IsMixSelectionTypes()) return;

            serializedObject.Update();
            tmpro = (JavaANSITextMeshProUGUI)target;

            DrawJavaneseTextInput();

            DrawTextInput();

            DrawMainSettings();

            DrawExtraSettings();

            EditorGUILayout.Space();

            if (serializedObject.ApplyModifiedProperties() || m_HavePropertiesChanged)
            {
                OnChanged();
                m_TextComponent.havePropertiesChanged = true;
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
                preview = EditorGUILayout.Toggle("Preview", preview);
                if(preview) {
                    string previewText = Regex.Replace(m_TextProp.stringValue, "<[^<>]+>", string.Empty);
                    EditorGUILayout.LabelField(previewText, JT_UIStyleManager.javaANSILabel, GUILayout.MinHeight(30));
                }
                EditorGUILayout.Space();
                
                // Enable and Display ANSI Transliterator Input
                Rect rect = EditorGUILayout.GetControlRect(false, 22);
                EditorGUI.LabelField(rect, new GUIContent("<b>ANSI Transliterator Input</b>"), TMP_UIStyleManager.sectionHeader);
                EditorGUI.indentLevel = 0;
                
                float labelWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 50f;

                EditorGUI.BeginChangeCheck(); 
                m_enableTransliteratorInputProp.boolValue = EditorGUI.Toggle(new Rect(rect.width - 60, rect.y + 3, 130, 20), "Enable", m_enableTransliteratorInputProp.boolValue);
                if(EditorGUI.EndChangeCheck())
                    OnToggleEnableTransliteratorInput();
                
                EditorGUIUtility.labelWidth = labelWidth;
                EditorGUILayout.Space(); 
                
                if(m_enableTransliteratorInputProp.boolValue) {
                    EditorGUILayout.Space();
                    EditorGUI.BeginChangeCheck(); 
                    m_transliteratorInputTextProp.stringValue = EditorGUILayout.TextArea(m_transliteratorInputTextProp.stringValue, JT_UIStyleManager.textArea, GUILayout.MinHeight(70));
                    if(EditorGUI.EndChangeCheck())
                        OnChanged();
                }
            }
        }

        protected void OnChanged() {
            m_HavePropertiesChanged = false;
            m_TextComponent.havePropertiesChanged = true;
            m_TextComponent.ComputeMarginSize();
            EditorUtility.SetDirty(target);
        }

        protected void OnToggleEnableTransliteratorInput() {
            if(m_enableTransliteratorInputProp.boolValue) {
                if(m_TextProp.stringValue == null || m_TextProp.stringValue == "") 
                    return;

                m_transliteratorInputTextProp.stringValue = m_TextProp.stringValue.JavaANSIToLatin();
            }
        }
    }
}