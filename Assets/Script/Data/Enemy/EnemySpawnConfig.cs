namespace DF.Data
{
    using DF.Input;
    using UnityEngine;
    /// <summary>
    /// Конфиг для спавна врагов
    /// </summary>
    [CreateAssetMenu(fileName = nameof(EnemySpawnConfig), menuName = "DF/Configs/Enemy/EnemySpawner")]
    public sealed class EnemySpawnConfig : ScriptableObject
    {
        [SerializeField]
        private Enemy _enemyPrefab = default;

        [SerializeField]
        private CarClassesConfig _carClasses = default;
        [SerializeField]
        private CompaniesConfig _companiesConfig = default;
        [SerializeField, Min(0)]
        private int _spawnTime = 0;

        public Enemy Enemy => _enemyPrefab;
        public CarClassesConfig CarClasses => _carClasses;
        public CompaniesConfig Companies => _companiesConfig; 
        public int SpawnTimer => _spawnTime;
    }
}
