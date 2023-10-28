using System.Collections.Generic;
using System.Linq;
using DF.Controller;
using DF.Data;
using DF.Interface;
using DF.ObjectPool;
using UnityEngine;

namespace DF.Input
{
    public sealed class GameController : MonoBehaviour
    {

        #region Links

        [Header("Configs")]

        [SerializeField] private MapConfig mapConfig;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField]
        private EnemySpawnConfig _enemySpawnConfig = default;

        [Header("Links")]

        [SerializeField] private Chunk chunkPrefab;
        [SerializeField] private Transform roadParent;
        [SerializeField] private PlayerInput player;
        [SerializeField]
        private Enemy _enemyPrefab = default;
        [SerializeField]
        private Transform _enemyParent = default;
        [SerializeField]
        private Bullet _bulletPrefab = default;

        #endregion


        #region Properties



        #endregion


        #region Controllers
        private EnemySpawnController _enemySpawnController = default;
        private ObjectPool<Bullet> _bulletPool = default;

        private List<IExecute> _executes;
        private List<IExecuteLater> _executesLaters;

        #endregion


        #region MONO

        private void Awake()
        {
            _executes = new() 
            { 
                
            };


            _executesLaters = new() 
            {
                new RoadController(chunkPrefab, roadParent, mapConfig),
                new PlayerController(player, playerConfig)
            };

            _enemySpawnController = new EnemySpawnController(_enemySpawnConfig, player, _enemyParent);
        }

        private void Start()
        {
            _enemySpawnController.Init();
        }

        private void Update() => _executes.ForEach(ex => ex.Execute());

        private void FixedUpdate() => _executesLaters.ForEach(ex => ex.ExecuteLater());

        #endregion

    }
}