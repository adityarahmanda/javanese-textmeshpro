using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;


namespace JVTMPro
{

    public static class JVTMPro_DefaultControls
    {
        private static Vector2 s_TextElementSize = new Vector2(100f, 100f);
        private static Vector2 s_ButtonElementSize = new Vector2(160f, 50f);
        private static Vector2 s_InputFieldElementSize = new Vector2(200f, 50f);
        private static Vector2 s_DropdownElementSize = new Vector2(200f, 50f);
        
        private static Color s_DefaultSelectableColor = new Color(1f, 1f, 1f, 1f);
        private static Color s_TextColor = new Color(50f / 255f, 50f / 255f, 50f / 255f, 1f);

        private static GameObject CreateUIElementRoot(string name, Vector2 size)
        {
            GameObject child = new GameObject(name);
            RectTransform rectTransform = child.AddComponent<RectTransform>();
            rectTransform.sizeDelta = size;
            return child;
        }

        static GameObject CreateUIObject(string name, GameObject parent)
        {
            GameObject go = new GameObject(name);
            go.AddComponent<RectTransform>();
            SetParentAndAlign(go, parent);
            return go;
        }
        
        public static GameObject CreateText(TMP_DefaultControls.Resources resources)
        {
            GameObject go = null;

            #if UNITY_EDITOR
                go = ObjectFactory.CreateGameObject("Javanese Text (TMP)");
                JVTMProUGUI text = ObjectFactory.AddComponent<JVTMProUGUI>(go);
            #else
                go = CreateUIElementRoot("Javanese Text (TMP)", s_TextElementSize);
                JVTMProUGUI text = go.AddComponent<JVTMProUGUI>();
            #endif

            return go;
        }

        private static void SetDefaultTextValues(TMP_Text lbl)
        {
            // Set text values we want across UI elements in default controls.
            // Don't set values which are the same as the default values for the Text component,
            // since there's no point in that, and it's good to keep them as consistent as possible.
            lbl.color = s_TextColor;
            lbl.fontSize = 18;
        }

        private static void SetDefaultColorTransitionValues(Selectable slider)
        {
            ColorBlock colors = slider.colors;
            colors.highlightedColor = new Color(0.882f, 0.882f, 0.882f);
            colors.pressedColor = new Color(0.698f, 0.698f, 0.698f);
            colors.disabledColor = new Color(0.521f, 0.521f, 0.521f);
        }

        private static void SetParentAndAlign(GameObject child, GameObject parent)
        {
            if (parent == null)
                return;

            child.transform.SetParent(parent.transform, false);
            SetLayerRecursively(child, parent.layer);
        }

        private static void SetLayerRecursively(GameObject go, int layer)
        {
            go.layer = layer;
            Transform t = go.transform;
            for (int i = 0; i < t.childCount; i++)
                SetLayerRecursively(t.GetChild(i).gameObject, layer);
        }

        public static GameObject CreateButton(TMP_DefaultControls.Resources resources)
        {
            GameObject buttonRoot = CreateUIElementRoot("Javanese Button", s_ButtonElementSize);

            GameObject childText = new GameObject("Javanese Text (TMP)");
            childText.AddComponent<RectTransform>();
            SetParentAndAlign(childText, buttonRoot);

            Image image = buttonRoot.AddComponent<Image>();
            image.sprite = resources.standard;
            image.type = Image.Type.Sliced;
            image.color = s_DefaultSelectableColor;

            Button bt = buttonRoot.AddComponent<Button>();
            SetDefaultColorTransitionValues(bt);

            JVTMProUGUI text = childText.AddComponent<JVTMProUGUI>();
            text.text = "ꦠꦺꦴꦩ꧀ꦧꦺꦴꦭ꧀";
            text.alignment = TextAlignmentOptions.Center;
            SetDefaultTextValues(text);

            RectTransform textRectTransform = childText.GetComponent<RectTransform>();
            textRectTransform.anchorMin = Vector2.zero;
            textRectTransform.anchorMax = Vector2.one;
            textRectTransform.sizeDelta = Vector2.zero;

            return buttonRoot;
        }

        public static GameObject CreateInputField(TMP_DefaultControls.Resources resources)
        {
            GameObject root = CreateUIElementRoot("Javanese InputField (TMP)", s_InputFieldElementSize);

            GameObject textArea = CreateUIObject("Javanese Text Area", root);
            GameObject childPlaceholder = CreateUIObject("Javanese Placeholder", textArea);
            GameObject childText = CreateUIObject("Javanese Text", textArea);

            Image image = root.AddComponent<Image>();
            image.sprite = resources.inputField;
            image.type = Image.Type.Sliced;
            image.color = s_DefaultSelectableColor;

            TMP_InputField inputField = root.AddComponent<TMP_InputField>();
            SetDefaultColorTransitionValues(inputField);

            // Use UI.Mask for Unity 5.0 - 5.1 and 2D RectMask for Unity 5.2 and up
            RectMask2D rectMask = textArea.AddComponent<RectMask2D>();
            #if UNITY_2019_4_OR_NEWER && !UNITY_2019_4_1 && !UNITY_2019_4_2 && !UNITY_2019_4_3 && !UNITY_2019_4_4 && !UNITY_2019_4_5 && !UNITY_2019_4_6 && !UNITY_2019_4_7 && !UNITY_2019_4_8 && !UNITY_2019_4_9 && !UNITY_2019_4_10 && !UNITY_2019_4_11
            rectMask.padding = new Vector4(-8, -5, -8, -5);
            #endif

            RectTransform textAreaRectTransform = textArea.GetComponent<RectTransform>();
            textAreaRectTransform.anchorMin = Vector2.zero;
            textAreaRectTransform.anchorMax = Vector2.one;
            textAreaRectTransform.sizeDelta = Vector2.zero;
            textAreaRectTransform.offsetMin = new Vector2(10, 6);
            textAreaRectTransform.offsetMax = new Vector2(-10, -7);


            JVTMProUGUI text = childText.AddComponent<JVTMProUGUI>();
            text.text = "";
            text.enableWordWrapping = false;
            text.extraPadding = true;
            text.richText = true;
            SetDefaultTextValues(text);

            JVTMProUGUI placeholder = childPlaceholder.AddComponent<JVTMProUGUI>();
            placeholder.text = "ꦏꦼꦠꦶꦏ꧀...";
            placeholder.fontSize = 18;
            placeholder.fontStyle = FontStyles.Italic;
            placeholder.enableWordWrapping = false;
            placeholder.extraPadding = true;

            // Make placeholder color half as opaque as normal text color.
            Color placeholderColor = text.color;
            placeholderColor.a *= 0.5f;
            placeholder.color = placeholderColor;

            // Add Layout component to placeholder.
            placeholder.gameObject.AddComponent<LayoutElement>().ignoreLayout = true;

            RectTransform textRectTransform = childText.GetComponent<RectTransform>();
            textRectTransform.anchorMin = Vector2.zero;
            textRectTransform.anchorMax = Vector2.one;
            textRectTransform.sizeDelta = Vector2.zero;
            textRectTransform.offsetMin = new Vector2(0, 0);
            textRectTransform.offsetMax = new Vector2(0, 0);

            RectTransform placeholderRectTransform = childPlaceholder.GetComponent<RectTransform>();
            placeholderRectTransform.anchorMin = Vector2.zero;
            placeholderRectTransform.anchorMax = Vector2.one;
            placeholderRectTransform.sizeDelta = Vector2.zero;
            placeholderRectTransform.offsetMin = new Vector2(0, 0);
            placeholderRectTransform.offsetMax = new Vector2(0, 0);

            inputField.textViewport = textAreaRectTransform;
            inputField.textComponent = text;
            inputField.placeholder = placeholder;
            inputField.fontAsset = text.font;

            return root;
        }

        public static GameObject CreateDropdown(TMP_DefaultControls.Resources resources)
        {
            GameObject root = CreateUIElementRoot("Javanese Dropdown", s_DropdownElementSize);

            GameObject label = CreateUIObject("Javanese Label", root);
            GameObject arrow = CreateUIObject("Arrow", root);
            GameObject template = CreateUIObject("Template", root);
            GameObject viewport = CreateUIObject("Viewport", template);
            GameObject content = CreateUIObject("Content", viewport);
            GameObject item = CreateUIObject("Item", content);
            GameObject itemBackground = CreateUIObject("Item Background", item);
            GameObject itemCheckmark = CreateUIObject("Item Checkmark", item);
            GameObject itemLabel = CreateUIObject("Item Javanese Label", item);

            // Sub controls.

            GameObject scrollbar = TMP_DefaultControls.CreateScrollbar(resources);
            scrollbar.name = "Scrollbar";
            SetParentAndAlign(scrollbar, template);

            Scrollbar scrollbarScrollbar = scrollbar.GetComponent<Scrollbar>();
            scrollbarScrollbar.SetDirection(Scrollbar.Direction.BottomToTop, true);

            RectTransform vScrollbarRT = scrollbar.GetComponent<RectTransform>();
            vScrollbarRT.anchorMin = Vector2.right;
            vScrollbarRT.anchorMax = Vector2.one;
            vScrollbarRT.pivot = Vector2.one;
            vScrollbarRT.sizeDelta = new Vector2(vScrollbarRT.sizeDelta.x, 0);

            // Setup item UI components.

            JVTMProUGUI itemLabelText = itemLabel.AddComponent<JVTMProUGUI>();
            SetDefaultTextValues(itemLabelText);
            itemLabelText.alignment = TextAlignmentOptions.Left;

            Image itemBackgroundImage = itemBackground.AddComponent<Image>();
            itemBackgroundImage.color = new Color32(245, 245, 245, 255);

            Image itemCheckmarkImage = itemCheckmark.AddComponent<Image>();
            itemCheckmarkImage.sprite = resources.checkmark;

            Toggle itemToggle = item.AddComponent<Toggle>();
            itemToggle.targetGraphic = itemBackgroundImage;
            itemToggle.graphic = itemCheckmarkImage;
            itemToggle.isOn = true;

            // Setup template UI components.

            Image templateImage = template.AddComponent<Image>();
            templateImage.sprite = resources.standard;
            templateImage.type = Image.Type.Sliced;

            ScrollRect templateScrollRect = template.AddComponent<ScrollRect>();
            templateScrollRect.content = (RectTransform)content.transform;
            templateScrollRect.viewport = (RectTransform)viewport.transform;
            templateScrollRect.horizontal = false;
            templateScrollRect.movementType = ScrollRect.MovementType.Clamped;
            templateScrollRect.verticalScrollbar = scrollbarScrollbar;
            templateScrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport;
            templateScrollRect.verticalScrollbarSpacing = -3;

            Mask scrollRectMask = viewport.AddComponent<Mask>();
            scrollRectMask.showMaskGraphic = false;

            Image viewportImage = viewport.AddComponent<Image>();
            viewportImage.sprite = resources.mask;
            viewportImage.type = Image.Type.Sliced;

            // Setup dropdown UI components.

            JVTMProUGUI labelText = label.AddComponent<JVTMProUGUI>();
            SetDefaultTextValues(labelText);
            labelText.alignment = TextAlignmentOptions.Left;

            Image arrowImage = arrow.AddComponent<Image>();
            arrowImage.sprite = resources.dropdown;

            Image backgroundImage = root.AddComponent<Image>();
            backgroundImage.sprite = resources.standard;
            backgroundImage.color = s_DefaultSelectableColor;
            backgroundImage.type = Image.Type.Sliced;

            TMP_Dropdown dropdown = root.AddComponent<TMP_Dropdown>();
            dropdown.targetGraphic = backgroundImage;
            SetDefaultColorTransitionValues(dropdown);
            dropdown.template = template.GetComponent<RectTransform>();
            dropdown.captionText = labelText;
            dropdown.itemText = itemLabelText;

            // Setting default Item list.
            itemLabelText.text = "ꦥꦶꦭꦶꦃꦲꦤ꧀ A";
            dropdown.options.Add(new TMP_Dropdown.OptionData {text = "ꦥꦶꦭꦶꦃꦲꦤ꧀ A" });
            dropdown.options.Add(new TMP_Dropdown.OptionData {text = "ꦥꦶꦭꦶꦃꦲꦤ꧀ B" });
            dropdown.RefreshShownValue();

            // Set up RectTransforms.

            RectTransform labelRT = label.GetComponent<RectTransform>();
            labelRT.anchorMin = Vector2.zero;
            labelRT.anchorMax = Vector2.one;
            labelRT.offsetMin = new Vector2(10, 6);
            labelRT.offsetMax = new Vector2(-25, -7);

            RectTransform arrowRT = arrow.GetComponent<RectTransform>();
            arrowRT.anchorMin = new Vector2(1, 0.5f);
            arrowRT.anchorMax = new Vector2(1, 0.5f);
            arrowRT.sizeDelta = new Vector2(20, 20);
            arrowRT.anchoredPosition = new Vector2(-15, 0);

            RectTransform templateRT = template.GetComponent<RectTransform>();
            templateRT.anchorMin = new Vector2(0, 0);
            templateRT.anchorMax = new Vector2(1, 0);
            templateRT.pivot = new Vector2(0.5f, 1);
            templateRT.anchoredPosition = new Vector2(0, 2);
            templateRT.sizeDelta = new Vector2(0, 108);

            RectTransform viewportRT = viewport.GetComponent<RectTransform>();
            viewportRT.anchorMin = new Vector2(0, 0);
            viewportRT.anchorMax = new Vector2(1, 1);
            viewportRT.sizeDelta = new Vector2(-18, 0);
            viewportRT.pivot = new Vector2(0, 1);

            RectTransform contentRT = content.GetComponent<RectTransform>();
            contentRT.anchorMin = new Vector2(0f, 1);
            contentRT.anchorMax = new Vector2(1f, 1);
            contentRT.pivot = new Vector2(0.5f, 1);
            contentRT.anchoredPosition = new Vector2(0, 0);
            contentRT.sizeDelta = new Vector2(0, 58);

            RectTransform itemRT = item.GetComponent<RectTransform>();
            itemRT.anchorMin = new Vector2(0, 0.5f);
            itemRT.anchorMax = new Vector2(1, 0.5f);
            itemRT.sizeDelta = new Vector2(0, 50);

            RectTransform itemBackgroundRT = itemBackground.GetComponent<RectTransform>();
            itemBackgroundRT.anchorMin = Vector2.zero;
            itemBackgroundRT.anchorMax = Vector2.one;
            itemBackgroundRT.sizeDelta = Vector2.zero;

            RectTransform itemCheckmarkRT = itemCheckmark.GetComponent<RectTransform>();
            itemCheckmarkRT.anchorMin = new Vector2(0, 0.5f);
            itemCheckmarkRT.anchorMax = new Vector2(0, 0.5f);
            itemCheckmarkRT.sizeDelta = new Vector2(20, 50);
            itemCheckmarkRT.anchoredPosition = new Vector2(10, 0);

            RectTransform itemLabelRT = itemLabel.GetComponent<RectTransform>();
            itemLabelRT.anchorMin = Vector2.zero;
            itemLabelRT.anchorMax = Vector2.one;
            itemLabelRT.offsetMin = new Vector2(20, 1);
            itemLabelRT.offsetMax = new Vector2(-10, -2);

            template.SetActive(false);

            return root;
        }
    }
}
