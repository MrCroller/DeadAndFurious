namespace DF.Data
{
    using UnityEngine;

    /// <summary>
    /// Конфиг для врагов
    /// </summary>
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "DF/Configs/Enemy/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField, Header("Weapon")]
        private GunConfig _weapon = default;
        [SerializeField, Min(0)]
        private float _enemySpeed = default;

        public float EnemySpeed => _enemySpeed;
        public GunConfig Weapon => _weapon;
    }
}
