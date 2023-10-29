namespace DF.UI
{
    using System;
    using System.Collections.Generic;
    using UnityEditor.SearchService;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class CutSceneConfig : MonoBehaviour
    {
        [SerializeField]
        private List<DialogItem> _dialogConfig = new List<DialogItem>();

        [SerializeField]
        private Text _characterName = default;
        [SerializeField]
        private Text _text = default;
        [SerializeField]
        private Image _characterAvatar = default;

        [SerializeField]
        private Button _nextButton = default;

        [SerializeField]
        private string _nextSceneName = default;

        private int _currentDialogIndex = 0;

        private void OnEnable()
        {
            NextText();
            _nextButton.onClick.AddListener(TryNextDialog);
        }

        private void TryNextDialog()
        {
            if(_currentDialogIndex == _dialogConfig.Count)
            {
                LoadNextScene();
                return;
            }
            NextText();
        }

        private void NextText()
        {
            DialogItem item = _dialogConfig[_currentDialogIndex];
            _text.text = item.text;
            _text.color = item._character.CharacterTextColor;
            _characterName.text = item._character.CharacterName;
            _characterName.color = item._character.CharacterTextColor;
            _characterAvatar.sprite = item._character.CharacterImage;
            _currentDialogIndex++;

        }

        private void LoadNextScene()
        {
            SceneManager.LoadScene(_nextSceneName);
        }

        private void OnDisable()
        {
            _nextButton.onClick.RemoveListener(TryNextDialog);
        }
    }

    [Serializable]
    public class DialogItem
    {
        public Character _character = default;
        public string text = default;
    }
}