using System.Collections;
using System.Collections.Generic;
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
                if(m_enableTransliteratorInput) {
                    if (m_transliteratorInputText == value) 
                        return;
                    
                    m_transliteratorInputText = value;

                    UpdateText();
                } else {
                    base.text = value;
                }
            } 
        }

        public string TransliteratorInputText
        {
            get { return m_transliteratorInputText; }
        }

        [SerializeField] protected string m_transliteratorInputText;

        
        public bool EnableTransliteratorInput
        {
            get { return m_enableTransliteratorInput; }
        }

        [SerializeField] protected bool m_enableTransliteratorInput;

        protected void Update() {
            if(havePropertiesChanged && m_enableTransliteratorInput) {
                UpdateText();
            }
        }

        public void UpdateText() {
            if(m_transliteratorInputText == null) 
                m_transliteratorInputText = "";

            base.text = m_transliteratorInputText.LatinToJavaANSI();

            havePropertiesChanged = true;
        }

        protected override void Reset()
        {
            //Output the message to the Console
            this.font = JavaneseToolkitSettings.defaultJavaANSIFontAsset;
        }
    }
}