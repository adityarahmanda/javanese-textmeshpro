using UnityEngine;
using UnityEditor;

namespace JavaneseToolkit {
    public class JT_UIStyleManager : MonoBehaviour {
        public static GUIStyle textArea;
        public static GUIStyle label;
        public static GUIStyle javaANSITextArea;
        public static GUIStyle javaANSILabel;

        static JT_UIStyleManager()
        {
            textArea = new GUIStyle(EditorStyles.textArea);
            textArea.font = JT_Settings.defaultJavaUnicodeEditorFont;
            textArea.fontSize = 12;
            textArea.wordWrap = true;
            textArea.stretchHeight = true;

            label = new GUIStyle(EditorStyles.label);
            label.font = JT_Settings.defaultJavaUnicodeEditorFont;
            label.fontSize = 12;

            javaANSITextArea = new GUIStyle(EditorStyles.textArea);
            javaANSITextArea.font = JT_Settings.defaultJavaANSIEditorFont;
            javaANSITextArea.fontSize = 10;
            javaANSITextArea.padding.top = 12;
            javaANSITextArea.padding.bottom = 12;
            javaANSITextArea.wordWrap = true;
            javaANSITextArea.stretchHeight = true;

            javaANSILabel = new GUIStyle(EditorStyles.label);
            javaANSILabel.font = JT_Settings.defaultJavaANSIEditorFont;
            javaANSILabel.fontSize = 10;
        }
    }
}