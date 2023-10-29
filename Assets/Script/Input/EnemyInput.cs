namespace DF.Input
{
    using DF.Controller;
    using DF.Data;
    using DF.ObjectPool;
    using DF.UI;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class EnemyInput : MonoBehaviour
    {

        public UnityEvent<float, float> OnHPChange;

        #region Fields

        [SerializeField]
        private EnemyController _enemyController = default;
        [SerializeField]
        private EnemyConfig _enemyConfig = default;
        [SerializeField]
        private Transform _bulletSpawn;
        [SerializeField]
        private SpriteRenderer _shipBorder;
        [SerializeField]
        private SpriteRenderer _managerSprite;

        private CarClassConfig _carClass = default;
        private CompanyConfig _company = default;
        private PlayerInput _player = default;

        private ObjectPool<EnemyInput> _enemyObjectPool = default;
        private ObjectPool<BulletInput> _bulletPool = default;

        #endregion


        #region Properties

        public EnemyConfig EnemyConfig => _enemyConfig;
        public Transform BulletSpawn => _bulletSpawn;

        public CarClassConfig CarClass => _carClass;
        public CompanyConfig Company => _company;
        public PlayerInput Player => _player;

        public ObjectPool<EnemyInput> EnemyObjectPool => _enemyObjectPool;
        public ObjectPool<BulletInput> BulletPool => _bulletPool;

        public int HP { get; set; }
        public int MAXHP { get; private set; }

        #endregion


        private void Start()
        {
            OnHPChange ??= new();
        }

        public void SetData(CarClassConfig carClassConfig,
            CompanyConfig companyconfig,
            PlayerInput player,
            ObjectPool<EnemyInput> enemyObjectPool,
            ObjectPool<BulletInput> bulletPool)
        {
            _carClass = carClassConfig;
            _company = companyconfig;
            _player = player;
            _enemyObjectPool = enemyObjectPool;
            _bulletPool = bulletPool;

            HP = _carClass.HP;
            MAXHP = _carClass.HP;
            _enemyController.Init(this);
        }

        public void UpdateVisual()
        {
            _shipBorder.color = _company.CompanyColor;
            _managerSprite.sprite = _company.ManagerSprite;
        }
    }
}
