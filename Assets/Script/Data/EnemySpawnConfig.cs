namespace DF.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(EnemySpawnConfig), menuName = "DR/Configs/EnemySpawn")]
    public sealed class EnemySpawnConfig : ScriptableObject
    {
        [SerializeField]
        private EnemiesConfig _enemiesConfig = default;
        [SerializeField, Min(0)]
        private int _spawnTime = 0;

        public EnemiesConfig EnemiesConfig => _enemiesConfig;
        public int SpawnTimer => _spawnTime;
    }
}
