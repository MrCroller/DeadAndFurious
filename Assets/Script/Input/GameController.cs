using System.Collections.Generic;
using DF.Controller;
using DF.Data;
using DF.Interface;
using DF.ObjectPool;
using DF.UI;
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
        [SerializeField] private Transform bulletParent;
        [SerializeField] private PlayerInput player;
        [SerializeField]
        private Transform _enemyParent = default;

        [SerializeField] private OptionInput optionMenu;
        [SerializeField] private Fader faderOption;
        [SerializeField]
        private Transform _enemySpawnZone = default;
        [SerializeField]
        private Transform _bulletSpawnZone;
        [field: SerializeField] internal MusicManager MusicManager { get; private set; }

        #endregion


        #region Properties

        public bool IsMenuOpen
        {
            get => _isMenuOpen;
            set
            {
                optionMenu.gameObject.SetActive(value);
                if (!value)_saveTime = Time.timeScale;

                if (value)
                {
                    faderOption.FadeIn();
                    Time.timeScale = 0;
                }
                else
                {
                    faderOption.FadeOut();
                    Time.timeScale = 1f;
                }

                player.IsControlable = !value;
                
                _isMenuOpen = value;
            }
        }


        #endregion


        #region Controllers

        private EnemySpawnController _enemySpawnController = default;
        private PlayerController _playerController = default;

        private List<IExecute> _executes;
        private List<IExecuteLater> _executesLaters;

        private bool _isMenuOpen = false;
        private float _saveTime;
        private ObjectPool<BulletInput> _bulletPool;

        #endregion


        #region MONO

        private void Awake()
        {
            _bulletPool = new ObjectPool<BulletInput>(bulletParent);
            _enemySpawnController = new EnemySpawnController(_enemySpawnConfig, player, _enemyParent, _enemySpawnZone, _bulletPool);
            _playerController = new PlayerController(player, playerConfig, bulletParent);

            _executes = new() 
            {
                _playerController,
            };


            _executesLaters = new() 
            {
                new RoadController(chunkPrefab, roadParent, mapConfig),
                _playerController
            };

        }

        private void Start()
        {
            Subscribe();

            _enemySpawnController.Init();
            _playerController.Init();
        }

        private void Update()
        {
            if (_isMenuOpen) return;
            _executes.ForEach(ex => ex.Execute());
        }

        private void FixedUpdate()
        {
            if (_isMenuOpen) return;
            _executesLaters.ForEach(ex => ex.ExecuteLater());
        }

        private void OnDestroy()
        {
            Unsubscribe();
            _playerController.Dispose();
        }

        private void Subscribe()
        {
            player.OnOpenOptionEvent += OpenMenu;
        }

        private void Unsubscribe()
        {
            player.OnOpenOptionEvent -= OpenMenu;
        }

        #endregion

        private void OpenMenu() => IsMenuOpen = !_isMenuOpen;

    }
}