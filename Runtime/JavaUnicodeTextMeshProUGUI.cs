using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JavaneseToolkit {
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasRenderer))]
    [AddComponentMenu("Javanese Toolkit/Javanese Unicode Text (TMP)", 10)]
    public class JavaUnicodeTextMeshProUGUI : TextMeshProUGUI
    {
#if TMP_VERSIO_2_1_0_OR_NEWER
        public override string text
#else
        public new string text
#endif
        {
            get { return base.text; }
            set {
                if (m_javaUnicodeInputText == value) 
                    return;
                
                m_javaUnicodeInputText = value;

                UpdateText();
            } 
        }

        public string JavaUnicodeInputText
        {
            get { return m_javaUnicodeInputText; }
        }

        [SerializeField] protected string m_javaUnicodeInputText;

        protected void Update() {
            if(havePropertiesChanged) {
                UpdateText();
            }
        }

        public void UpdateText() {
            if(m_javaUnicodeInputText == null) 
                m_javaUnicodeInputText = "";

            base.text = m_javaUnicodeInputText.JavaUnicodeFix();
            havePropertiesChanged = true;
        }

        protected override void Reset()
        {
            //Output the message to the Console
            this.font = JT_Settings.defaultJavaUnicodeFontAsset;
            this.fontSize = JT_Settings.defaultFontSize;
        }
    }
}