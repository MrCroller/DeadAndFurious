using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "DF/Configs/Player")]
    public sealed class PlayerConfig : ScriptableObject
    {

        #region Fields

        [Tooltip("Базовые хп")]
        [SerializeField] private float _hp;
        [Tooltip("Скорость движения лодки")]
        [SerializeField] private float _speed = 5f;
        [Tooltip("Степень смягчения движения")]
        [SerializeField] private float _movementSmoothing = .05f;
        [Tooltip("Базовый урон")]
        [SerializeField] private float _damage = .05f;
        [Tooltip("Базовая задержка между выстрелами")]
        [SerializeField] private float _speedAtackDelay = .05f;

        [Tooltip("Начальное оружие")]
        [SerializeField] private GunConfig _defaultGun;
        [Tooltip("Карта необходимого опыта для уровней")]
        [SerializeField] private PlayerExpLevelGradeConfig _levelGradeMap;
        [Tooltip("Предел уровня")]
        [SerializeField] private int _lvlCup;

        #endregion


        #region Properties

        public float HP => _hp;
        public float Speed => _speed;
        public float MovementSmoothing => _movementSmoothing;
        public float Damage => _damage;
        public float SpeedAtackDelay => _speedAtackDelay;

        public GunConfig DefaultGun => _defaultGun;
        public PlayerExpLevelGradeConfig LevelGradeMap => _levelGradeMap;
        public int LevelCup => _lvlCup;

        #endregion

        private void OnValidate() => _hp = (_hp > 0) ? _hp : 0;
    }
}
