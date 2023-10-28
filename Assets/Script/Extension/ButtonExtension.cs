using UnityEngine.Events;
using UnityEngine.UI;

namespace DF.Extension
{
    public static partial class Extension
    {
        public static void Add(this Button button, UnityAction action) => button.onClick.AddListener(action);
        public static void Remove(this Button button, UnityAction action) => button.onClick.RemoveListener(action);
        public static void RemoveAll(this Button button) => button.onClick.RemoveAllListeners();

        public static void Add(this Slider slider, UnityAction<float> action) =>
            slider.onValueChanged.AddListener(action);
        public static void Remove(this Slider slider, UnityAction<float> action) =>
            slider.onValueChanged.RemoveListener(action);
        public static void RemoveAll(this Slider slider) => 
            slider.onValueChanged.RemoveAllListeners();
    }
}
