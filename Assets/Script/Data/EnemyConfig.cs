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
        [SerializeField, Min(0), Header("—корость")]
        private float _speed = 0;
        [SerializeField, Min(0), Header("’ѕшечка")]
        private float _hp = 0;

        private event Action OnSpeedChange = delegate { };
        private event Action OnHPChange = delegate { };

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
        public float HP
        {
            get { return _hp; }
            set
            {
                _hp = value;
                OnHPChange();
            }
        }

    }
}
