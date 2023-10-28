

namespace DF.Builder
{
    using DF.Data;
    using DF.Input;
    using UnityEngine;
    /// <summary>
    /// Билдер врагов
    /// </summary>
    internal class EnemyBuilder
    {
        private Enemy _enemyPrefab = default;
        private CompanyConfig _companyConfig = default;
        private CarClassConfig _carClassConfig = default; 

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
        public Enemy Build(Vector3 position)
        {
            GameObject enemyGO = GameObject.Instantiate(_enemyPrefab.gameObject, position, Quaternion.identity);
            Enemy enemy = enemyGO.GetComponent<Enemy>();
            enemy.SetCarClassConfig(_carClassConfig);
            enemy.SetCompanyConfig(_companyConfig);
            enemy.UpdateVisual();
            return enemy;
        }
    }
}