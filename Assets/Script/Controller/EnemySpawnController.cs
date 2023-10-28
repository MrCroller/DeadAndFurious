namespace DF.Controller
{
    using DF.Data;
    using DF.Factory;
    using System;
    using System.Collections;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngineTimers;

    public sealed class EnemySpawnController : IDisposable
    {
        private EnemySpawnConfig _enemySpawnConfig = default;
        private Coroutine _enemySpawnCoroutine = default;
        private bool GameEnd = false;

        private EnemySpawnFactory _enemySpawnFactory = default;

        public EnemySpawnController(EnemySpawnConfig enemySpawnConfig)
        {
            _enemySpawnConfig = enemySpawnConfig;
            _enemySpawnFactory = new EnemySpawnFactory();
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

                int randomEnemyID = UnityEngine.Random.Range(0, _enemySpawnConfig.EnemiesConfig.EnemiesConfigs.Count); 

                float spawnOffsetY = _enemySpawnConfig.EnemiesConfig.EnemiesConfigs[randomEnemyID].EnemyPrefab.gameObject.transform.localScale.y;
                Vector3 randomSpawnPositionWithoutOffset = Camera.main.ScreenToWorldPoint(
                    new Vector3(UnityEngine.Random.Range(0f, Screen.width), Screen.height, 0));

                Vector3 randomSpawnPosition = new Vector3(randomSpawnPositionWithoutOffset.x, randomSpawnPositionWithoutOffset.y + spawnOffsetY, 0);
                _enemySpawnFactory.SpawnEnemy(_enemySpawnConfig.EnemiesConfig.EnemiesConfigs[randomEnemyID].EnemyPrefab, randomSpawnPosition);
            }
        }

        void IDisposable.Dispose() 
        {
            if(_enemySpawnCoroutine != null)
            {
                Coroutines.StopRoutine(_enemySpawnCoroutine);
            }
        }
    }
}
