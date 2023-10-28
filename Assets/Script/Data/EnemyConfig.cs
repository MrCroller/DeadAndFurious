namespace DF.Data
{
    using DF.Input;
    using System;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "DR/Configs/Enemy")]
    public sealed class EnemyConfig : ScriptableObject
    {
        [SerializeField]
        private Enemy _enemyPrefab = default;
        [SerializeField, Min(0)]
        private float _speed = 0;

        private event Action OnSpeedChange = delegate { };

        public Enemy EnemyPrefab => _enemyPrefab;
        public float Speed
        {
            get { return _speed; }
            set 
            { 
                _speed = value;
                OnSpeedChange();
            }
        }

    }
}
