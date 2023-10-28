namespace DF.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ButtonQuit : MonoBehaviour
    {
        [SerializeField]
        private Button _button = default;

        private void Start()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            _button.onClick.AddListener(OpenTargetScene);
        }

        private void OpenTargetScene() =>
            Application.Quit();
    }
}
