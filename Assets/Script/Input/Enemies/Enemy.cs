namespace DF.Input
{
    using DF.Data;
    using UnityEngine;

    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField]
        private EnemyConfig _enemyConfig;

        public EnemyConfig EnemyConfig => _enemyConfig;
        public abstract void InitController();
    }
}
