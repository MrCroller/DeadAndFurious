using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "DF/Configs/Player")]
    public sealed class PlayerConfig : ScriptableObject
    {

        #region Fields

        [Tooltip("Скорость движения лодки")]
        [SerializeField] private float _speed = 5f;
        [Tooltip("Степень смягчения движения")]
        [SerializeField] private float _movementSmoothing = .05f;
        [Tooltip("Базовый урон")]
        [SerializeField] private float _damage = .05f;
        [Tooltip("Базовая скорость атаки")]
        [SerializeField] private float _speedAtack = .05f;
        [Tooltip("Начальное оружие")]
        [SerializeField] private GunConfig _defaultGun;

        #endregion


        #region Properties

        public float Speed => _speed;
        public float MovementSmoothing => _movementSmoothing;
        public float Damage => _damage;
        public float SpeedAtack => _speedAtack;
        public GunConfig DefaultGun => _defaultGun;

        #endregion

    }
}
