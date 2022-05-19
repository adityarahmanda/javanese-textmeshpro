using System.Collections;
using UnityEngine;
using UnityEditor;
using Unity.EditorCoroutines.Editor;

namespace JVTMPro
{
    public class TransliteratorWindow : EditorWindow
    {
        Vector2 scrollPosition = Vector2.zero;
        bool scrollbarYVisible = false;

        enum Methods {
            LatinToJava,
            JavaToLatin,
        }
        
        Methods method = Methods.LatinToJava;
        
        string inputText = "";
        string outputText = "";
        TextEditor inputTextEditor = null;

        bool murda = false;
        bool ignoreSpace = false;
        bool dipthong = false;

        string[] specialChars = new string[] { "Ê", "ê", "ā", "ī", "ū", "ḍ", "ḍh", "ṣ", "ś", "ṭ", "ṭh", "ṇ", "ñ", "ŋ" };
        int specialCharButtonWidth = 30;

        [MenuItem("Window/Javanese TextMeshPro/Transliterator", false, 2200)]
        public static void Open()
        {
            GetWindow<TransliteratorWindow>("Transliterator");
        }

        public void OnGUI() {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false,  GUILayout.Width(position.width),  GUILayout.Height(position.height));

            EditorGUILayout.Space(); 

            EditorGUI.BeginChangeCheck();
            method = (Methods)EditorGUILayout.EnumPopup("Method", method);
            if (EditorGUI.EndChangeCheck()) Reset();
            
            EditorGUILayout.Space(); 

            GUILayout.Label("Input", EditorStyles.boldLabel);
            
            Rect rect = EditorGUILayout.GetControlRect(false, 100);
            inputText = GUI.TextArea(rect, inputText, JVTMProUIStyleManager.textArea);

            inputTextEditor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

            EditorGUILayout.Space();

            if(method == Methods.LatinToJava) {
                EditorGUILayout.LabelField("Transliteration Settings", EditorStyles.boldLabel);
                
                murda = EditorGUILayout.Toggle("Murda", murda);
                ignoreSpace = EditorGUILayout.Toggle("Ignore Space", ignoreSpace);
                dipthong = EditorGUILayout.Toggle("Diphtong", dipthong);
            
                EditorGUILayout.Space();

                EditorGUILayout.LabelField("Special Characters", EditorStyles.boldLabel);

                bool createRow = true;
                int totalWidth = 0;
                
                for(int i = 0; i < specialChars.Length; i++) {
                    if(createRow) {
                        GUILayout.BeginHorizontal();
                        createRow = false;
                    }
                    
                    if(GUILayout.Button(specialChars[i], GUILayout.Width(specialCharButtonWidth))) {
                        InsertToInputText(specialChars[i]);
                    }

                    totalWidth += specialCharButtonWidth;
                    
                    float totalWidthOffset = 2f * specialCharButtonWidth + GUI.skin.button.margin.right;

                    if(scrollbarYVisible) {
                        totalWidthOffset += GUI.skin.verticalScrollbar.fixedWidth;
                    }

                    if(totalWidth + totalWidthOffset >= position.width || i == specialChars.Length - 1) {
                        GUILayout.EndHorizontal();
                        totalWidth = 0;
                        
                        if(i != specialChars.Length - 1) {
                            createRow = true;
                        }
                    }
                }

                // check scrollbar Y visibility
                if (Event.current.type == EventType.Repaint)
                {
                    if (GUILayoutUtility.GetLastRect().width != position.width)
                        scrollbarYVisible = true;
                    else
                        scrollbarYVisible = false;
                }

                EditorGUILayout.Space();
            }

            if(GUILayout.Button("Transliterate")) {
                if(method == Methods.LatinToJava) {
                    outputText = inputText.LatinToJava(murda, ignoreSpace, dipthong);
                } else if(method == Methods.JavaToLatin) {
                    outputText = inputText.JavaToLatin();
                }
            }

            EditorGUILayout.Space();

            GUILayout.Label("Output", EditorStyles.boldLabel);
            outputText = EditorGUILayout.TextArea(outputText, JVTMProUIStyleManager.textArea, GUILayout.Height(100));
            
            EditorGUILayout.Space();

            GUILayout.EndScrollView();
        }

        private void Reset() {
            inputText = "";
            outputText = "";
        }

        private void InsertToInputText(string s) {
            if(inputTextEditor == null) return;

            if(inputTextEditor.cursorIndex != inputTextEditor.selectIndex) {
                if (inputTextEditor.cursorIndex < inputTextEditor.selectIndex)
                {
                    inputText = inputText.Substring(0, inputTextEditor.cursorIndex) + inputText.Substring(inputTextEditor.selectIndex, inputText.Length - inputTextEditor.selectIndex);
                    inputTextEditor.selectIndex = inputTextEditor.cursorIndex;
                }
                else
                {
                    inputText = inputText.Substring(0, inputTextEditor.selectIndex) + inputText.Substring(inputTextEditor.cursorIndex, inputText.Length - inputTextEditor.cursorIndex);
                    inputTextEditor.cursorIndex = inputTextEditor.selectIndex;
                }
            }

            int lastInputTextCursorIndex = inputTextEditor.cursorIndex;
            int lastInputTextLength = inputText.Length;
            
            inputText = inputText.Insert(inputTextEditor.cursorIndex, s);
            
            if(lastInputTextCursorIndex == lastInputTextLength) {
                this.StartCoroutine(MoveTextEndAfterDelay(0.1f));
            } else {
                inputTextEditor.cursorIndex += s.Length;
                inputTextEditor.selectIndex = inputTextEditor.cursorIndex;
            }
        }

        private IEnumerator MoveTextEndAfterDelay(float delay) {
            yield return new EditorWaitForSeconds(delay);

            if(inputTextEditor == null) yield break;
            
            inputTextEditor.MoveTextEnd();
        }
    }
}