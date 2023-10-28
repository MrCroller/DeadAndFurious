namespace DF.Data 
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(EnemiesConfig), menuName = "DR/Configs/Enemies")]
    public sealed class EnemiesConfig : ScriptableObject
    {
        [SerializeField]
        private List<EnemyConfig> _enemiesConfigs = default;

        public List<EnemyConfig> EnemiesConfigs => _enemiesConfigs;
    }
}
