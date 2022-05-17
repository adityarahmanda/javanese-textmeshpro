using UnityEngine;
using UnityEditor;

namespace JVTMPro {
    public class JVTMProUIStyleManager : MonoBehaviour {
        public static GUIStyle textArea;
        public static GUIStyle label;

        static JVTMProUIStyleManager()
        {
            textArea = new GUIStyle(EditorStyles.textArea);
            textArea.font = JVTMProSettings.defaultEditorFont;
            textArea.fontSize = 12;
            textArea.wordWrap = true;
            textArea.stretchHeight = true;

            label = new GUIStyle(EditorStyles.label);
            label.font = JVTMProSettings.defaultEditorFont;
            label.fontSize = 12;
        }
    }
}