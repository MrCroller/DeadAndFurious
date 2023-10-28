namespace DF.Input
{
    using DF.Data;
    using DF.ObjectPool;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _enemySprite = default;
        [SerializeField]
        private EnemyConfig _enemyConfig = default;
        [SerializeField]
        private GameObject _bullet;

        private CarClassConfig _carClass = default;
        private CompanyConfig _company = default;
        private PlayerInput _player = default;
        private ObjectPool<Enemy> _enemyObjectPool = default;

        public EnemyConfig EnemyConfig => _enemyConfig;
        public GameObject Bullet => _bullet;

        public CarClassConfig CarClass => _carClass;
        public CompanyConfig Company => _company;
        public PlayerInput Player => _player;
        public ObjectPool<Enemy> EnemyObjectPool => _enemyObjectPool;


        public void SetData(CarClassConfig carClassConfig,
            CompanyConfig companyconfig,
            PlayerInput player,
            ObjectPool<Enemy> enemyObjectPool)
        {
            _carClass = carClassConfig;
            _company = companyconfig;
            _player = player;
            _enemyObjectPool = enemyObjectPool;
        }

        public void UpdateVisual()
        {
            _enemySprite.sprite = _carClass.ShipSprite;
        }
    }
}
