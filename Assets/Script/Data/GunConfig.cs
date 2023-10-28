using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(GunConfig), menuName = "DF/Configs/Gun")]
    public class GunConfig : ScriptableObject
    {

        #region Fields

        [Tooltip("Спрайт оружия")]
        [SerializeField] private Sprite _sprite;
        [Tooltip("Урон")]
        [SerializeField] private float _damage;
        [Tooltip("Задержка между выстрелами")]
        [SerializeField, Range(0f, 15f)] private float _attackDelay;
        [Tooltip("Сила выстрела")]
        [SerializeField] private float _fireForse;
        [Tooltip("Префаб пули")]
        [SerializeField] private Rigidbody2D _bulletPrefab;
        [Tooltip("Время жизни пули")]
        [SerializeField] private float _bulletTimeLife;

        #endregion


        #region Properties

        public Sprite Sprite => _sprite;
        public float Damage => _damage;
        public float AttackDelay => _attackDelay;
        public float FireForse => _fireForse;
        public Rigidbody2D BulletPrefab => _bulletPrefab;
        public float BulletLifeTime => _bulletTimeLife;

        #endregion

    }
}
