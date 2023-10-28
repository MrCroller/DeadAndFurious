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
        private Coroutine _enemySpawnCoroutine = default;
        private bool GameEnd = false;

        private EnemyBuilder _enemyBuilder = default;

        public EnemySpawnController(EnemySpawnConfig enemySpawnConfig)
        {
            _enemySpawnConfig = enemySpawnConfig;            
            _enemyBuilder = new EnemyBuilder();
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

                float spawnOffsetY = _enemySpawnConfig.CarClasses.CarClasses[randomCarClassID].ScaleFactor;
                Vector3 randomSpawnPositionWithoutOffset = Camera.main.ScreenToWorldPoint(
                    new Vector3(UnityEngine.Random.Range(0f, Screen.width), Screen.height, 0));

                Vector3 randomSpawnPosition = new Vector3(randomSpawnPositionWithoutOffset.x, randomSpawnPositionWithoutOffset.y + spawnOffsetY, 0);
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
                .Build(position);
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
