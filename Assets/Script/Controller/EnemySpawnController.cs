namespace DF.Controller
{
    using DF.Builder;
    using DF.Data;
    using DF.Input;
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngineTimers;

    public sealed class EnemySpawnController : IDisposable
    {
        private EnemySpawnConfig _enemySpawnConfig = default;
        private PlayerInput _player = default;
        private Transform _enemyParent = default;
        private Coroutine _enemySpawnCoroutine = default;
        private bool GameEnd = false;

        private EnemyBuilder _enemyBuilder = default;

        public EnemySpawnController(EnemySpawnConfig enemySpawnConfig, PlayerInput player, Transform parent)
        {
            _enemyParent = parent;
            _player = player;
            _enemySpawnConfig = enemySpawnConfig;            
            _enemyBuilder = new EnemyBuilder(_enemyParent);
        }

        /// <summary>
        /// Метод инициализации
        /// </summary>
        public void Init()
        {
            if (_enemySpawnCoroutine != null)
            {
                Coroutines.StopRoutine(_enemySpawnCoroutine);
            }
            _enemySpawnCoroutine = Coroutines.StartRoutine(EnemySpawnCoroutine());
        }

        private IEnumerator EnemySpawnCoroutine()
        {
            while (!GameEnd)
            {
                yield return new WaitForSeconds(_enemySpawnConfig.SpawnTimer);

                int randomCarClassID = UnityEngine.Random.Range(0, _enemySpawnConfig.CarClasses.CarClasses.Count);
                int randomCompanyID = UnityEngine.Random.Range(0, _enemySpawnConfig.Companies.Companies.Count);

                Vector3 randomSpawnPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(UnityEngine.Random.Range(0f, Screen.width), Screen.height, 0));

                SpawnEnemy(randomSpawnPosition, 
                    _enemySpawnConfig.CarClasses.CarClasses[randomCarClassID],
                    _enemySpawnConfig.Companies.Companies[randomCompanyID]);
            }
        }

        private void SpawnEnemy(Vector3 position, CarClassConfig carClass, CompanyConfig company)
        {
            Enemy enemy = _enemyBuilder
                .Reset()
                .WithRootPrefab(_enemySpawnConfig.Enemy)
                .WithCarClass(carClass)
                .WithCompany(company)
                .Build(position, _player);

            enemy.transform.position = new Vector3(position.x, position.y - enemy.transform.localScale.y, 0);
            enemy.UpdateVisual();
        }

        void IDisposable.Dispose() 
        {
            if(_enemySpawnCoroutine != null)
            {
                Coroutines.StopRoutine(_enemySpawnCoroutine);
            }
            _enemySpawnCoroutine = null;
        }
    }
}
