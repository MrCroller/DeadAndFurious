using DF.Input;
using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(GunConfig), menuName = "DF/Configs/Gun")]
    public class GunConfig : ScriptableObject
    {

        #region Fields

        [Tooltip("Спрайт оружия")]
        [SerializeField] private Sprite _sprite;
        [Tooltip("Задержка между выстрелами")]
        [SerializeField, Range(0f, 15f)] private float _attackDelay;
        [Tooltip("Сила выстрела")]
        [SerializeField] private float _fireForse;
        [Tooltip("Префаб пули")]
        [SerializeField] private BulletInput _bullet;
        [Tooltip("Время жизни пули")]
        [SerializeField] private float _bulletTimeLife;

        #endregion


        #region Properties

        public Sprite Sprite => _sprite;
        public float AttackDelay => _attackDelay;
        public float FireForse => _fireForse;
        public BulletInput Bullet => _bullet;
        public float BulletLifeTime => _bulletTimeLife;

        #endregion

    }
}
