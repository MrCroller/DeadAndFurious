using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(MapConfig), menuName = "DR/Configs/Map")]
    internal sealed class MapConfig : ScriptableObject
    {

        #region Fields

        [Tooltip("Скорость карты (визуал)")]
        [SerializeField] private float _speedWoter = 5f;

        #endregion


        #region Properties

        public float Speed => _speedWoter;

        #endregion

    }
}
