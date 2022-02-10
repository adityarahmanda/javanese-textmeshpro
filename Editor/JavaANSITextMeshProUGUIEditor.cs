using UnityEngine;
using UnityEditor;
using TMPro;
using TMPro.EditorUtilities;

#pragma warning disable 0414 // Disabled a few warnings related to serialized variables not used in this script but used in the editor.

namespace JavaneseToolkit {
    [CustomEditor(typeof(JavaANSITextMeshProUGUI), true), CanEditMultipleObjects]
    public class JavaANSITextMeshProUGUIEditor : TMP_EditorPanelUI
    {
        private SerializedProperty originalTextProp;
        
        private bool enableTransliteratorInput = true;
        private JavaANSITextMeshProUGUI tmpro;

        protected override void OnEnable()
        {
            base.OnEnable();
            originalTextProp = serializedObject.FindProperty("originalText");
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

                EditorGUILayout.LabelField("Preview :");
                EditorGUILayout.LabelField(m_TextProp.stringValue, UIStyleManager.javaANSILabel);

                EditorGUILayout.Space();
                
                Rect rect = EditorGUILayout.GetControlRect(false, 22);
                EditorGUI.LabelField(rect, new GUIContent("<b>ANSI Transliterator Input</b>"), TMP_UIStyleManager.sectionHeader);
                EditorGUI.indentLevel = 0;
                
                // Display RTL Toggle
                float labelWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 50f;

                enableTransliteratorInput = EditorGUI.Toggle(new Rect(rect.width - 60, rect.y + 3, 130, 20), "Enable", enableTransliteratorInput);

                EditorGUIUtility.labelWidth = labelWidth;
                
                if(enableTransliteratorInput) {
                    EditorGUILayout.Space();

                    EditorGUI.BeginChangeCheck(); 
                    originalTextProp.stringValue = EditorGUILayout.TextArea(originalTextProp.stringValue, UIStyleManager.textArea, GUILayout.MinHeight(60));
                
                    if(EditorGUI.EndChangeCheck())
                        OnChanged();
                }
            }
        }

        protected void OnChanged() {
            tmpro.UpdateText();
            m_HavePropertiesChanged = false;
            m_TextComponent.havePropertiesChanged = true;
            m_TextComponent.ComputeMarginSize();
            EditorUtility.SetDirty(target);
        }
    }
}