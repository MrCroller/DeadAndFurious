namespace DF.Input
{
    using DF.Data;
    using DF.ObjectPool;
    using UnityEngine;
    using UnityEngine.UI;

    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private EnemyConfig _enemyConfig = default;
        [SerializeField]
        private GameObject _bulletSpawn;
        [SerializeField]
        private Slider _hpBar;

        private CarClassConfig _carClass = default;
        private CompanyConfig _company = default;
        private PlayerInput _player = default;
        private ObjectPool<Enemy> _enemyObjectPool = default;

        public EnemyConfig EnemyConfig => _enemyConfig;
        public GameObject BulletSpawn => _bulletSpawn;

        public CarClassConfig CarClass => _carClass;
        public CompanyConfig Company => _company;
        public PlayerInput Player => _player;
        public ObjectPool<Enemy> EnemyObjectPool => _enemyObjectPool;

        public Slider HpBar => _hpBar;

        private int _hp = 0;
        public int HP => _hp;


        public void SetData(CarClassConfig carClassConfig,
            CompanyConfig companyconfig,
            PlayerInput player,
            ObjectPool<Enemy> enemyObjectPool)
        {
            _carClass = carClassConfig;
            _company = companyconfig;
            _player = player;
            _enemyObjectPool = enemyObjectPool;

            _hp = _carClass.HP;
        }

        public void UpdateHP(int value)
        {
            _hp = value;
        }

        public void UpdateVisual()
        {
            UpdateHpBar(1);
            //Изменить цвет в зависимости от компании
        }
        
        public void UpdateHpBar(float value)
        {
            _hpBar.value = value;
        }
    }
}
