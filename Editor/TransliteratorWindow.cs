#if UNITY_EDITOR
using System.Reflection;
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
            LatinToJava,
            JavaToLatin
        }

        Methods method = Methods.LatinToJava;

        [MenuItem("Window/Javanese Toolkit/Transliterator")]
        public static void Open()
        {
            GetWindow<TransliteratorWindow>("Transliterator");
        }

        public void OnGUI() {
            GUIStyle javaneseTextAreaStyle = new GUIStyle(EditorStyles.textArea);
            javaneseTextAreaStyle.font = (Font)EditorGUIUtility.Load("Packages/com.adityarahmanda.javanese-toolkit/Editor/Fonts/Ndomblong.fontsettings");
            javaneseTextAreaStyle.fontSize = 0;
            javaneseTextAreaStyle.padding.top = 12;
            javaneseTextAreaStyle.padding.bottom = 12;

            EditorGUILayout.Space(); 
            EditorGUI.BeginChangeCheck();
            method = (Methods)EditorGUILayout.EnumPopup("Method", method);
            if (EditorGUI.EndChangeCheck())
            {
                inputText = "";
                outputText = "";
            }
            useJavaneseFont = EditorGUILayout.Toggle("Javanese Font", useJavaneseFont);
            EditorGUILayout.Space(); 

            GUILayout.Label("Input", EditorStyles.boldLabel);
            if(method == Methods.JavaToLatin && useJavaneseFont) {
                inputText = EditorGUILayout.TextArea(inputText, javaneseTextAreaStyle, GUILayout.MinHeight(60));
            } else {
                inputText = EditorGUILayout.TextArea(inputText, EditorStyles.textArea, GUILayout.MinHeight(60));
            }
            EditorGUILayout.Space(); 

            GUILayout.Label("Output", EditorStyles.boldLabel);
            if(method == Methods.LatinToJava && useJavaneseFont) {
                outputText = EditorGUILayout.TextArea(outputText, javaneseTextAreaStyle, GUILayout.MinHeight(60));
            } else {
                outputText = EditorGUILayout.TextArea(outputText, EditorStyles.textArea, GUILayout.MinHeight(60));
            }
            EditorGUILayout.Space();

            if(GUILayout.Button("Transliterate")) {
                if(method == Methods.LatinToJava) {
                    // outputText = transliterator.LatinToJava(inputText);
                } else if(method == Methods.JavaToLatin) {
                    outputText = Transliterator.JavaToLatin(inputText);
                }
            }
        }
    }
}
#endif