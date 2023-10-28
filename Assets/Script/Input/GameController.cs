using System.Collections.Generic;
using DF.Controller;
using DF.Data;
using DF.Interface;
using UnityEngine;

namespace DF.Input
{
    public sealed class GameController : MonoBehaviour
    {

        #region Links

        [Header("Configs")]

        [SerializeField] private MapConfig mapConfig;
        [SerializeField] private PlayerConfig playerConfig;

        [Header("Links")]

        [SerializeField] private Chunk chunkPrefab;
        [SerializeField] private Transform roadParent;
        [SerializeField] private PlayerInput player;

        #endregion


        #region Properties



        #endregion


        #region Controllers

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
        }

        private void Update() => _executes.ForEach(ex => ex.Execute());

        private void FixedUpdate() => _executesLaters.ForEach(ex => ex.ExecuteLater());

        #endregion

    }
}