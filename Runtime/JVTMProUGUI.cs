using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JVTMPro {
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasRenderer))]
    [AddComponentMenu("Javanese Toolkit/Javanese Text (TMP)", 10)]
    public class JVTMProUGUI : TextMeshProUGUI
    {
#if TMP_VERSION_2_1_0_OR_NEWER
        public override string text
#else
        public new string text
#endif
        {
            get { return base.text; }
            set {
                if (m_inputText == value) 
                    return;
                
                m_inputText = value;

                UpdateText();
            } 
        }

        public string InputText
        {
            get { return m_inputText; }
        }

        [SerializeField] protected string m_inputText;

        protected void Update() {
            if(havePropertiesChanged) {
                UpdateText();
            }
        }

        public void UpdateText() {
            if(m_inputText == null) 
                m_inputText = "";

            base.text = JavaneseTextFixer.Fix(m_inputText);
            havePropertiesChanged = true;
        }

        protected override void Reset()
        {
            //Output the message to the Console
            this.font = JVTMProSettings.defaultFontAsset;
            this.fontSize = JVTMProSettings.defaultFontSize;
        }
    }
}