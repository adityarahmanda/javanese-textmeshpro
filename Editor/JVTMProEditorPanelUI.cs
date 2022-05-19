using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using TMPro;
using TMPro.EditorUtilities;

#pragma warning disable 0414 // Disabled a few warnings related to serialized variables not used in this script but used in the editor.

namespace JVTMPro {
    [CustomEditor(typeof(JVTMProUGUI), true), CanEditMultipleObjects]
    public class JVTMProEditorPanelUI : TMP_EditorPanelUI
    {
        private SerializedProperty m_JVInputTextProp;
        private JVTMProUGUI m_JVTextComponent;
        
        static readonly GUIContent k_StyleLabel = new GUIContent("Text Style", "The style from a style sheet to be applied to the text.");
        static readonly GUIContent k_PreviewLabel = new GUIContent("<b>Preview</b>");
        
        protected new struct Foldout
        {
            // Track Inspector foldout panel states, globally.
            public static bool preview = true;
            public static bool extraSettings = false;
            public static bool materialInspector = true;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            m_JVInputTextProp = serializedObject.FindProperty("m_inputText");
            m_JVTextComponent = (JVTMProUGUI)target;
        }

        public override void OnInspectorGUI()
        {
            // Make sure Multi selection only includes TMP Text objects.
            if (IsMixSelectionTypes()) return;

            serializedObject.Update();

            DrawJavaneseTextInput();

            DrawMainSettings();

            DrawExtraSettings();

            EditorGUILayout.Space();

            if (serializedObject.ApplyModifiedProperties() || m_HavePropertiesChanged)
            {
                OnChanged();
                m_JVTextComponent.havePropertiesChanged = true;
                m_HavePropertiesChanged = false;
                EditorUtility.SetDirty(target);
            }
        }

        protected void DrawJavaneseTextInput() {
            // If the text component is linked, disable the text input box.
            
            if (m_ParentLinkedTextComponentProp.objectReferenceValue == null)
            {   
                // Preview start
                EditorGUILayout.Space();
                
                Rect rect = EditorGUILayout.GetControlRect(false, 24);

                if (GUI.Button(rect, k_PreviewLabel, TMP_UIStyleManager.sectionHeader))
                    Foldout.preview = !Foldout.preview;

                GUI.Label(rect, (Foldout.preview ? k_UiStateLabel[0] : k_UiStateLabel[1]), TMP_UIStyleManager.rightLabel);
                if (Foldout.preview)
                {
                    string previewText = Regex.Replace(m_TextProp.stringValue, "<[^<>]+>", string.Empty);
                    EditorGUILayout.LabelField(previewText, JVTMProUIStyleManager.label);
                }

                EditorGUILayout.Space();
                // Preview end
                
                // Text Input start
                rect = EditorGUILayout.GetControlRect(false, 22);
                EditorGUI.LabelField(rect, new GUIContent("<b>Text Input</b>"), TMP_UIStyleManager.sectionHeader);
                EditorGUI.indentLevel = 0;
                
                float labelWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 50f;

                EditorGUI.BeginChangeCheck();
                
                EditorGUIUtility.labelWidth = labelWidth;
                EditorGUILayout.Space(); 
                
                EditorGUILayout.Space();
                EditorGUI.BeginChangeCheck(); 
                m_JVInputTextProp.stringValue = EditorGUILayout.TextArea(m_JVInputTextProp.stringValue, JVTMProUIStyleManager.textArea, GUILayout.MinHeight(70));
                if(EditorGUI.EndChangeCheck())
                    OnChanged();
                // Text Input end

                // Text Style start
                if (m_StyleNames != null)
                {
                    rect = EditorGUILayout.GetControlRect(false, 17);

                    EditorGUI.BeginProperty(rect, k_StyleLabel, m_TextStyleHashCodeProp);

                    m_TextStyleIndexLookup.TryGetValue(m_TextStyleHashCodeProp.intValue, out m_StyleSelectionIndex);

                    EditorGUI.BeginChangeCheck();
                    m_StyleSelectionIndex = EditorGUI.Popup(rect, k_StyleLabel, m_StyleSelectionIndex, m_StyleNames);
                    if (EditorGUI.EndChangeCheck())
                    {
                        m_TextStyleHashCodeProp.intValue = m_Styles[m_StyleSelectionIndex].hashCode;
                        m_JVTextComponent.textStyle = m_Styles[m_StyleSelectionIndex];
                        m_HavePropertiesChanged = true;
                    }

                    EditorGUI.EndProperty();
                }
                // Text Style end
            }
        }

        protected void OnChanged() {
            m_HavePropertiesChanged = false;
            m_JVTextComponent.havePropertiesChanged = true;
            m_JVTextComponent.ComputeMarginSize();
            EditorUtility.SetDirty(target);
        }
    }
}