using TimersSystemUnity.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngineTimers;

namespace DF.Extension
{
    public static partial class Extension
    {
        /// <summary>
        /// Sets the alpha channel
        /// </summary>
        /// <param name="itemColor"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Color SetAlpha<T>(this T itemColor, float value) where T : IColor
        {
            Color color = itemColor.Color;
            color.a = Mathf.Lerp(0.0f, 1.0f, value);
            return itemColor.Color = color;
        }

        /// <summary>
        /// Dynamically changes the channel alpha value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mono"></param>
        /// <param name="time">Time of change </param>
        /// <param name="easing">Curve of change versus time</param>
        /// <param name="isChangeActive">Do I turn the object on and off before and after executing the method?</param>
        public static IStop SetAplhaDynamic<T>(this T mono,
                                              float time,
                                              AnimationCurve easing,
                                              bool isChangeActive = true,
                                              bool unscale = false) where T : Component, IColor
        {
            if (isChangeActive)
            {
                mono.gameObject.SetActive(true);
            }

            return TimersPool.GetInstance().StartTimer(EndMethod, GreatSelect, time, unscale);
            void GreatSelect(float progress)
            {
                mono.SetAlpha(easing.Evaluate(progress));
            }

            void EndMethod()
            {
                if (isChangeActive)
                {
                    mono.gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Dynamically changes the channel alpha value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mono"></param>
        /// <param name="EndMethod"></param>
        /// <param name="time">Time of change </param>
        /// <param name="easing">Curve of change versus time</param>
        /// <param name="isChangeActive">Do I turn the object on and off before and after executing the method?</param>
        public static IStop SetAplhaDynamic<T>(this T mono,
                                              UnityAction EndMethod,
                                              float time,
                                              AnimationCurve easing,
                                              bool isChangeActive = true,
                                              bool unscale = false) where T : Component, IColor
        {
            if (isChangeActive)
            {
                mono.gameObject.SetActive(true);
            }

            return TimersPool.GetInstance().StartTimer(EndMethodLocal, GreatSelect, time, unscale);
            void GreatSelect(float progress)
            {
                mono.SetAlpha(easing.Evaluate(progress));
            }

            void EndMethodLocal()
            {
                EndMethod();

                if (isChangeActive)
                {
                    mono.gameObject.SetActive(false);
                }
            }
        }

        public static IStop SetAplhaDynamicRevert<T>(this T mono,
                                                     UnityAction EndMethod,
                                                     float time,
                                                     AnimationCurve easing,
                                                     bool isChangeActive = true,
                                                     bool unscale = false) where T : Component, IColor
        {
            if (isChangeActive)
            {
                mono.gameObject.SetActive(true);
            }

            IStop stop = TimersPool.GetInstance().StartTimer(EndMethodIN, GreatSelect, time, unscale);

            void GreatSelect(float progress)
            {
                mono.SetAlpha(easing.Evaluate(1f - progress));
            }

            void EndMethodIN()
            {
                if (isChangeActive)
                {
                    mono.gameObject.SetActive(false);
                }
                EndMethod();
            }

            return stop;
        }

        /// <summary>
        /// Dynamically changes the channel alpha value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mono"></param>
        /// <param name="timeToVisable">Time of object appearance (linear)</param>
        /// <param name="timeVisible">Object visibility time (100%-alpha)</param>
        /// <param name="timeToInvisable">Object disappearance time (linear)</param>
        /// <param name="isChangeActive">Do I turn the object on and off before and after executing the method?</param>
        public static void SetAplhaDynamic<T>(this T mono,
                                             float timeToVisable,
                                             float timeVisible,
                                             float timeToInvisable,
                                             bool isChangeActive = true,
                                             bool unscale = false) where T : Component, IColor
        {
            if (isChangeActive)
            {
                mono.gameObject.SetActive(true);
            }

            mono.SetAlpha(0.0f);

            // To Visable
            TimersPool.GetInstance().StartTimer(Wait, (float progress) => mono.SetAlpha(progress), timeToVisable, unscale);

            void Wait()
            {
                TimersPool.GetInstance().StartTimer(ToInvisible, timeVisible, unscale);
            }

            void ToInvisible()
            {
                TimersPool.GetInstance().StartTimer(EndMethod, (float progress) =>
                {
                    mono.SetAlpha(1.0f - progress);
                }, timeToInvisable, unscale);
            }

            void EndMethod()
            {
                mono.SetAlpha(0.0f);

                if (isChangeActive)
                {
                    mono.gameObject.SetActive(false);
                }
            }
        }
    }
}
