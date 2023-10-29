namespace DF.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    [CreateAssetMenu(fileName = nameof(Character), menuName = "DF/UI/Character")]
    public class Character : ScriptableObject
    {
        [SerializeField]
        private string _characterName = default;
        [SerializeField]
        private Sprite _characterImage = default;
        [SerializeField]
        private Color _characterTextColor = default;

        public string CharacterName => _characterName;
        public Color CharacterTextColor => _characterTextColor;
        public Sprite CharacterImage => _characterImage;
    }
}
