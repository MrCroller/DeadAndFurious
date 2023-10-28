namespace DF.UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class ButtonOpenScene : MonoBehaviour
    {
        [SerializeField, Header("Название следующей сцены")]
        private string _targetSceneOpen = default;
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
            SceneManager.LoadScene(_targetSceneOpen);
    }
}
