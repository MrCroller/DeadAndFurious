namespace DF.Input
{
    using DF.Data;
    using DF.ObjectPool;
    using DF.UI;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class EnemyInput : MonoBehaviour
    {
        public UnityEvent<float, float> OnHPChange;

        [SerializeField]
        private EnemyConfig _enemyConfig = default;
        [SerializeField]
        private GameObject _bulletSpawn;
        [SerializeField]
        private SpriteRenderer _shipBorder;
        [SerializeField]
        private SpriteRenderer _managerSprite;

        private CarClassConfig _carClass = default;
        private CompanyConfig _company = default;
        private PlayerInput _player = default;
        private ObjectPool<EnemyInput> _enemyObjectPool = default;

        public EnemyConfig EnemyConfig => _enemyConfig;
        public GameObject BulletSpawn => _bulletSpawn;

        public CarClassConfig CarClass => _carClass;
        public CompanyConfig Company => _company;
        public PlayerInput Player => _player;
        public ObjectPool<EnemyInput> EnemyObjectPool => _enemyObjectPool;

        private int _hp = 0;
        public int HP => _hp;

        private void Start()
        {
            OnHPChange ??= new();
        }

        public void SetData(CarClassConfig carClassConfig,
            CompanyConfig companyconfig,
            PlayerInput player,
            ObjectPool<EnemyInput> enemyObjectPool)
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
            _shipBorder.color = _company.CompanyColor;
            _managerSprite.sprite = _company.ManagerSprite;
        }
    }
}
