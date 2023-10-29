using System.Text;
using DF.Input;
using DF.Interface;
using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(GunConfig), menuName = "DF/Configs/Gun")]
    public class GunConfig : ScriptableObject, ISkillInfo
    {

        #region Fields

        [Tooltip("Спрайт оружия")]
        [SerializeField] private Sprite _icon;
        [Tooltip("Название")]
        [SerializeField] private string _name;

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

        public Sprite Icon => _icon;
        public string Name => _name;

        public float AttackDelay => _attackDelay;
        public float FireForse => _fireForse;
        public BulletInput Bullet => _bullet;
        public float BulletLifeTime => _bulletTimeLife;

        public string Description
        {
            get => $"Урон: {_bullet.Damage} \nПерезарядка: {_attackDelay} \nСила выстрела: {_fireForse}";
        }


        #endregion

    }
}
