

namespace DF.Builder
{
    using DF.Data;
    using DF.Input;
    using DF.ObjectPool;
    using UnityEngine;
    /// <summary>
    /// Билдер врагов
    /// </summary>
    internal class EnemyBuilder
    {
        private Enemy _enemyPrefab = default;
        private CompanyConfig _companyConfig = default;
        private CarClassConfig _carClassConfig = default;

        private Transform _objectParent = default;
        private ObjectPool<Enemy> _enemyObjectPool = default;

        public EnemyBuilder(Transform objectParent)
        {
            _objectParent = objectParent;
            _enemyObjectPool = new ObjectPool<Enemy>(_objectParent);
        }

        public EnemyBuilder Reset()
        {
            _enemyPrefab = null;
            _companyConfig = null;
            _carClassConfig = null;
            return this;
        }

        public EnemyBuilder WithRootPrefab(Enemy prefab)
        {
            _enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder WithCompany(CompanyConfig companyConfig)
        {
            _companyConfig = companyConfig;
            return this;
        }

        public EnemyBuilder WithCarClass(CarClassConfig carClassConfig)
        {
            _carClassConfig = carClassConfig;
            return this;
        }
        public Enemy Build(Vector3 position, PlayerInput player)
        {
            Enemy enemy = _enemyObjectPool.GetObjectFromPool(_enemyPrefab);
            enemy.SetData(_carClassConfig, _companyConfig, player, _enemyObjectPool);
            return enemy;
        }
    }
}