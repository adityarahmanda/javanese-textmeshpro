using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;
using TMPro;

namespace JavaneseToolkit {
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasRenderer))]
    [AddComponentMenu("Javanese Toolkit/Javanese ANSI Text (TMP)", 10)]
    public class JavaANSITextMeshProUGUI : TextMeshProUGUI
    {
#if TMP_VERSIO_2_1_0_OR_NEWER
        public override string text
#else
        public new string text
#endif
        {
            get { return base.text; }
            set {
                if (originalText == value) 
                    return;
                
                originalText = value;

                UpdateText();
            } 
        }

        public string OriginalText
        {
            get { return originalText; }
        }

        [SerializeField] [TextArea(3, 10)] protected string originalText;

        protected void Update() {
            if(havePropertiesChanged) {
                UpdateText();
            }
        }

        public void UpdateText() {
            if(originalText == null) 
                originalText = "";

            base.text = originalText.LatinToJava();

            havePropertiesChanged = true;
        }

        protected override void Reset()
        {
            //Output the message to the Console
            this.font = (TMP_FontAsset)AssetDatabase.LoadAssetAtPath("Packages/com.adityarahmanda.javanese-toolkit/Runtime/Fonts/Ndomblong SDF.asset", typeof(TMP_FontAsset));
        }
    }
}