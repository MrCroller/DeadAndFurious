namespace DF.Data
{
    using DF.Input;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "DR/Configs/Enemy")]
    public sealed class EnemyConfig : ScriptableObject
    {
        [SerializeField]
        private Enemy _enemyPrefab = default;

        public Enemy EnemyPrefab => _enemyPrefab;

    }
}
