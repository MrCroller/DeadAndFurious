namespace DF.Controller
{
    using DF.Builder;
    using DF.Data;
    using DF.Input;
    using DF.ObjectPool;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngineTimers;

    public sealed class EnemySpawnController : IDisposable
    {
        private EnemySpawnConfig _enemySpawnConfig = default;
        private PlayerInput _player = default;
        private Transform _enemyParent = default;
        private Coroutine _enemySpawnCoroutine = default;

        private Transform _enemySpawnZone = default;

        private bool GameEnd = false;

        private EnemyBuilder _enemyBuilder = default;

        private BoxCollider2D _spawnZoneCollider = default;
        private ObjectPool<BulletInput> _bulletSpawnZone = default;

        private float _minZone = 0;
        private float _maxZone = 0;

        public EnemySpawnController(EnemySpawnConfig enemySpawnConfig, 
            PlayerInput player, 
            Transform parent, 
            Transform enemySpawnZone, 
            ObjectPool<BulletInput> bulletObjectPool)
        {
            _enemySpawnZone = enemySpawnZone;
            _enemyParent = parent;
            _player = player;
            _enemySpawnConfig = enemySpawnConfig;            
            _enemyBuilder = new EnemyBuilder(_enemyParent, bulletObjectPool);
            _spawnZoneCollider = _enemySpawnZone.GetComponent<BoxCollider2D>();
            _minZone = _spawnZoneCollider.bounds.min.x;
            _maxZone = _spawnZoneCollider.bounds.max.x;
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
            bool _firstPartScreen = true;
            while (!GameEnd)
            {
                yield return new WaitForSeconds(_enemySpawnConfig.SpawnTimer);

                int randomCarClassID = UnityEngine.Random.Range(0, _enemySpawnConfig.CarClasses.CarClasses.Count);
                int randomCompanyID = UnityEngine.Random.Range(0, _enemySpawnConfig.Companies.Companies.Count);

                float minForSpawn = _firstPartScreen ? _minZone : (_maxZone + _minZone) / 2;
                float maxForSpawn = _firstPartScreen ? (_maxZone + _minZone) / 2 : _maxZone;

                Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(minForSpawn, maxForSpawn), 
                    _spawnZoneCollider.bounds.min.y, 0);

                _firstPartScreen = !_firstPartScreen;


                SpawnEnemy(randomSpawnPosition, 
                    _enemySpawnConfig.CarClasses.CarClasses[randomCarClassID],
                    _enemySpawnConfig.Companies.Companies[randomCompanyID]);
            }
        }

        private void SpawnEnemy(Vector3 position, CarClassConfig carClass, CompanyConfig company)
        {
            EnemyInput enemy = _enemyBuilder
                .Reset()
                .WithRootPrefab(carClass.ShipPrefab)
                .WithCarClass(carClass)
                .WithCompany(company)
                .Build(position, _player);

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
