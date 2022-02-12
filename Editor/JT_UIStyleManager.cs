using UnityEngine;
using UnityEditor;

namespace JavaneseToolkit {
    public class JT_UIStyleManager : MonoBehaviour {
        public static GUIStyle textArea;
        public static GUIStyle javaANSITextArea;
        public static GUIStyle javaANSILabel;

        const string kDefaultFontPath = "Packages/com.adityarahmanda.javanese-toolkit/Editor/Fonts/NotoSans.ttf";
        const string kJavaANSIFontPath = "Packages/com.adityarahmanda.javanese-toolkit/Editor/Fonts/GenkKobraJeje.ttf";

        static JT_UIStyleManager()
        {
            textArea = new GUIStyle(EditorStyles.textArea);
            textArea.font = (Font)AssetDatabase.LoadAssetAtPath(kDefaultFontPath, typeof(Font));
            textArea.fontSize = 12;
            textArea.wordWrap = true;
            textArea.stretchHeight = true;

            javaANSITextArea = new GUIStyle(EditorStyles.textArea);
            javaANSITextArea.font = (Font)AssetDatabase.LoadAssetAtPath(kJavaANSIFontPath, typeof(Font));
            javaANSITextArea.fontSize = 10;
            javaANSITextArea.padding.top = 12;
            javaANSITextArea.padding.bottom = 12;
            javaANSITextArea.wordWrap = true;
            javaANSITextArea.stretchHeight = true;

            javaANSILabel = new GUIStyle(EditorStyles.label);
            javaANSILabel.font = (Font)AssetDatabase.LoadAssetAtPath(kJavaANSIFontPath, typeof(Font));
            javaANSILabel.fontSize = 10;
        }
    }
}