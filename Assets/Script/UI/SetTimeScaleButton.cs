using UnityEngine;
using UnityEngine.UI;

public class SetTimeScaleButton : MonoBehaviour
{
    [SerializeField, Header("TimeScale = 1?")]
    private bool _isActiveTimeScale = false;
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
        Time.timeScale = 1.0f;
}
