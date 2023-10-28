using UnityEngine.Events;
using UnityEngine.UI;

namespace DF.Extension
{
    public static partial class Extension
    {
        public static void Add(this Button button, UnityAction action) => button.onClick.AddListener(action);
        public static void Remove(this Button button, UnityAction action) => button.onClick.RemoveListener(action);
        public static void RemoveAll(this Button button) => button.onClick.RemoveAllListeners();
    }
}
