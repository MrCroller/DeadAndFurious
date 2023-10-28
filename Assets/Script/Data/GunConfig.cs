using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(GunConfig), menuName = "DF/Configs/Gun")]
    public class GunConfig : ScriptableObject
    {

        #region Fields

        [Tooltip("Спрайт оружия")]
        [SerializeField] private Sprite _sprite;
        [Tooltip("Префаб пули")]
        [SerializeField] private Rigidbody2D _bulletPrefab;
        [Tooltip("Урон")]
        [SerializeField] private float _damage;
        [Tooltip("Скорость атаки")]
        [SerializeField] private float _attackSpeed;
        [Tooltip("Скорость полета пули")]
        [SerializeField] private float _bulletSpeed;

        #endregion


        #region Properties

        public Sprite Sprite => _sprite;
        public Rigidbody2D BulletPrefab => _bulletPrefab;
        public float Damage => _damage;
        public float AttackSpeed => _attackSpeed;
        public float BulletSpeed => _bulletSpeed;

        #endregion

    }
}
