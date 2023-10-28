using DF.Extension;
using TimersSystemUnity.Extension.Adapter;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngineTimers;


namespace TimersSystemUnity.Extension
{
    public static class AdapterFabric
    {
        public static SpriteRendererAdapter Ext(this SpriteRenderer spriteRenderer) => new SpriteRendererAdapter(spriteRenderer);
        public static ImageAdapter Ext(this Image image) => new ImageAdapter(image);
        public static TextAdapter Ext(this TMP_Text text) => new TextAdapter(text);

        #region SpriteRenderer

        public static Color SetAlpha(this SpriteRenderer spriteRenderer, float value) => spriteRenderer.Ext().SetAlpha(value);
        public static IStop SetAplhaDynamic(this SpriteRenderer spriteRenderer,
                                              float time,
                                              AnimationCurve easing,
                                              bool isChangeActive = true,
                                              bool unscale = false)
        {
            return spriteRenderer.Ext().SetAplhaDynamic(time, easing, isChangeActive, unscale);
        }

        public static IStop SetAplhaDynamic(this SpriteRenderer spriteRenderer,
                                              UnityAction EndMethod,
                                              float time,
                                              AnimationCurve easing,
                                              bool isChangeActive = true,
                                              bool unscale = false)
        {
            return spriteRenderer.Ext().SetAplhaDynamic(EndMethod, time, easing, isChangeActive, unscale);
        }

        public static void SetAplhaDynamic(this SpriteRenderer spriteRenderer,
                                             float timeToVisable,
                                             float timeVisible,
                                             float timeToInvisable,
                                             bool isChangeActive = true,
                                              bool unscale = false)
        {
            spriteRenderer.Ext().SetAplhaDynamic(timeToVisable, timeVisible, timeToInvisable, isChangeActive, unscale);
        }

        #endregion


        #region Image

        public static Color SetAlpha(this Image spriteRenderer, float value) => spriteRenderer.Ext().SetAlpha(value);
        public static IStop SetAplhaDynamic(this Image spriteRenderer,
                                              float time,
                                              AnimationCurve easing,
                                              bool isChangeActive = true,
                                              bool unscale = false)
        {
            return spriteRenderer.Ext().SetAplhaDynamic(time, easing, isChangeActive, unscale);
        }

        public static IStop SetAplhaDynamic(this Image spriteRenderer,
                                              UnityAction EndMethod,
                                              float time,
                                              AnimationCurve easing,
                                              bool isChangeActive = true,
                                              bool unscale = false)
        {
            return spriteRenderer.Ext().SetAplhaDynamic(EndMethod, time, easing, isChangeActive, unscale);
        }

        public static IStop SetAplhaDynamicRevert(this Image spriteRenderer,
                                              UnityAction EndMethod,
                                              float time,
                                              AnimationCurve easing,
                                              bool isChangeActive = true,
                                              bool unscale = false)
        {
            return spriteRenderer.Ext().SetAplhaDynamicRevert(EndMethod, time, easing, isChangeActive, unscale);
        }

        public static void SetAplhaDynamic(this Image spriteRenderer,
                                             float timeToVisable,
                                             float timeVisible,
                                             float timeToInvisable,
                                             bool isChangeActive = true,
                                              bool unscale = false)
        {
            spriteRenderer.Ext().SetAplhaDynamic(timeToVisable, timeVisible, timeToInvisable, isChangeActive, unscale);
        }

        #endregion


        #region TMP_Text

        public static Color SetAlpha(this TMP_Text spriteRenderer, float value) => spriteRenderer.Ext().SetAlpha(value);
        public static IStop SetAplhaDynamic(this TMP_Text spriteRenderer,
                                              float time,
                                              AnimationCurve easing,
                                              bool isChangeActive = true,
                                              bool unscale = false)
        {
            return spriteRenderer.Ext().SetAplhaDynamic(time, easing, isChangeActive, unscale);
        }

        public static IStop SetAplhaDynamic(this TMP_Text spriteRenderer,
                                              UnityAction EndMethod,
                                              float time,
                                              AnimationCurve easing,
                                              bool isChangeActive = true,
                                              bool unscale = false)
        {
            return spriteRenderer.Ext().SetAplhaDynamic(EndMethod, time, easing, isChangeActive, unscale);
        }

        public static void SetAplhaDynamic(this TMP_Text spriteRenderer,
                                             float timeToVisable,
                                             float timeVisible,
                                             float timeToInvisable,
                                             bool isChangeActive = true,
                                              bool unscale = false)
        {
            spriteRenderer.Ext().SetAplhaDynamic(timeToVisable, timeVisible, timeToInvisable, isChangeActive, unscale);
        }

        #endregion

    }
}
