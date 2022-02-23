using UnityEngine;
using UnityEditor;

namespace JavaneseToolkit
{
    public class TransliteratorWindow : EditorWindow
    {
        string inputText = "";
        string outputText = "";

        bool useJavaneseFont = true;

        public enum Methods {
            LatinToJavaUnicode,
            LatinToJavaANSI,
            JavaUnicodeToLatin,
            JavaANSIToLatin
        }

        Methods method = Methods.LatinToJavaUnicode;

        [MenuItem("Window/Javanese Toolkit/Transliterator")]
        public static void Open()
        {
            GetWindow<TransliteratorWindow>("Transliterator");
        }

        public void OnGUI() {
            EditorGUILayout.Space(); 
            
            EditorGUI.BeginChangeCheck();
            method = (Methods)EditorGUILayout.EnumPopup("Method", method);
            if (EditorGUI.EndChangeCheck())
            {
                inputText = "";
                outputText = "";
            }
            EditorGUILayout.Space(); 

            if(method == Methods.LatinToJavaANSI || method == Methods.JavaANSIToLatin) {
                useJavaneseFont = EditorGUILayout.Toggle("Javanese Font", useJavaneseFont);
                EditorGUILayout.Space();

                GUILayout.Label("Input", EditorStyles.boldLabel);
                if(useJavaneseFont && method == Methods.JavaANSIToLatin) {
                    inputText = EditorGUILayout.TextArea(inputText, JT_UIStyleManager.javaANSITextArea, GUILayout.MinHeight(60));
                } else {
                    inputText = EditorGUILayout.TextArea(inputText, JT_UIStyleManager.textArea, GUILayout.MinHeight(60));
                }
                EditorGUILayout.Space();

                GUILayout.Label("Output", EditorStyles.boldLabel);
                if(useJavaneseFont && method == Methods.LatinToJavaANSI) {
                    outputText = EditorGUILayout.TextArea(outputText, JT_UIStyleManager.javaANSITextArea, GUILayout.MinHeight(60));
                } else {
                    outputText = EditorGUILayout.TextArea(outputText, JT_UIStyleManager.textArea, GUILayout.MinHeight(60));
                }
                EditorGUILayout.Space();
            } else {
                GUILayout.Label("Input", EditorStyles.boldLabel);
                inputText = EditorGUILayout.TextArea(inputText, JT_UIStyleManager.textArea, GUILayout.MinHeight(60));
                EditorGUILayout.Space();

                GUILayout.Label("Output", EditorStyles.boldLabel);
                outputText = EditorGUILayout.TextArea(outputText, JT_UIStyleManager.textArea, GUILayout.MinHeight(60));
                EditorGUILayout.Space();
            }

            if(GUILayout.Button("Transliterate")) {
                if(method == Methods.LatinToJavaANSI) {
                    outputText = inputText.LatinToJavaANSI();
                } else if(method == Methods.JavaANSIToLatin) {
                    outputText = inputText.JavaANSIToLatin();
                } else if(method == Methods.LatinToJavaUnicode) {
                    outputText = inputText.LatinToJavaUnicode();
                } else if(method == Methods.JavaUnicodeToLatin) {
                    outputText = inputText.JavaUnicodeToLatin();
                }
            }
        }
    }
}