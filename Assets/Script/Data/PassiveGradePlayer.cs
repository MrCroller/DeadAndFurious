using System.Collections.Generic;
using UnityEngine;


namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(PassiveGradePlayer), menuName = "DF/Configs/Grade/Passive")]
    public class PassiveGradePlayer : ScriptableObject
    {
        #region Fields

        [Tooltip("Иконка грейда")]
        [SerializeField] private Sprite _icon;
        [Tooltip("Название")]
        [SerializeField] private string _name;


        [Tooltip("Скорость движения лодки")]
        [SerializeField] private float _speed;
        [Tooltip("Степень смягчения движения")]
        [SerializeField] private float _movementSmoothing;
        [Tooltip("Базовый урон")]
        [SerializeField] private float _damage;
        [Tooltip("На сколько уменьшется базовая задержка перед выстрелами")]
        [SerializeField] private float _speedAtackDelay;


        #endregion


        #region Properties

        public Sprite Icon => _icon;
        public string Name => _name;

        public float Speed => _speed;
        public float MovementSmoothing => _movementSmoothing;
        public float Damage => _damage;
        public float SpeedAtackDelay => _speedAtackDelay;

        #endregion
    }
}
