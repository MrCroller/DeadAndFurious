namespace DF.UI
{
    using UnityEngine;
using UnityEngine.UI;

    public class ButtonOpenWindow : MonoBehaviour
    {
        [SerializeField, Header("Объект следующего окна")]
        private GameObject _targetWindowOpen = default;
        [SerializeField, Header("Нужно ли закрывать предыдущее окно?")]
        private bool _isClose = default;
        [SerializeField, Header("Окно, которое необходимо закрыть (закрывается, если Is Close = true)")]
        private GameObject _currentWindow = default;
        [SerializeField]
        private Button _button = default;

        private void Start()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            _button.onClick.AddListener(OpenTargetWindow);
        }

        private void OpenTargetWindow()
        {
            _targetWindowOpen.SetActive(true);
            if (_isClose)
            {
                _currentWindow.SetActive(false);
            }
        }
    }
}
